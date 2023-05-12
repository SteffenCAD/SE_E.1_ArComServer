using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using Opc.Ua;
using Opc.Ua.Client;
using OPCUaClient.Objects;
using OPCUaClient.Exceptions;
using Opc.Ua.Configuration;
using Opc.Ua.Gds;
using static System.Net.Mime.MediaTypeNames;
using OPCUaClient;
using System.Diagnostics;

namespace DUR.OPCUA
{
    /// <summary>
    /// Client for OPCUA Server
    /// </summary>
    public class UaClient
    {
        #region Private Fields
        public Session Session = null;
        private EndpointDescription EndpointDescription;
        private EndpointConfiguration EndpointConfig;
        private ConfiguredEndpoint Endpoint;
        private UserIdentity UserIdentity;
        private ApplicationConfiguration AppConfig;
        private int ReconnectPeriod = 10000;
        private object Lock = new object();
        private SessionReconnectHandler ReconnectHandler;
        #endregion

        #region Public fields
        /// <summary>
        /// will store all Tags after scan command
        /// </summary>
        public List<ReferenceDescription> TagBook = new List<ReferenceDescription>();

        /// <summary>
        /// Indicates if the instance is connected to the server.
        /// </summary>
        public bool IsConnected
        {
            get
            {
                if (this.Session == null)
                {
                    return false;
                }
                return this.Session.Connected;
            }
        }
        #endregion


        #region Public methods
        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="appName">
        /// Name of the application
        /// </param>
        /// <param name="serverUrl">
        /// Url of server
        /// </param>
        /// <param name="security">
        /// Enable or disable the security
        /// </param>
        /// <param name="untrusted">
        /// Accept untrusted certificates
        /// </param>
        /// <param name="user">
        /// User of the OPC UA Server
        /// </param>
        /// <param name="password">
        /// Password of the user
        /// </param>
        public UaClient(String appName, String serverUrl, bool security, bool untrusted, String user = "", String password = "")
        {
            String path = Path.Combine(Directory.GetCurrentDirectory(), "Certificates");
            Directory.CreateDirectory(path);
            Directory.CreateDirectory(Path.Combine(path, "Application"));
            Directory.CreateDirectory(Path.Combine(path, "Trusted"));
            Directory.CreateDirectory(Path.Combine(path, "TrustedPeer"));
            Directory.CreateDirectory(Path.Combine(path, "Rejected"));
            String hostName = System.Net.Dns.GetHostName();

            if (user.Length > 0)
            {
                UserIdentity = new UserIdentity(user, password);
            }
            else
            {
                UserIdentity = new UserIdentity();
            }
            AppConfig = new ApplicationConfiguration
            {
                ApplicationName = appName,
                ApplicationUri = Utils.Format(@"urn:{0}" + appName, hostName),
                ApplicationType = ApplicationType.Client,
                SecurityConfiguration = new SecurityConfiguration
                {
                    ApplicationCertificate = new CertificateIdentifier
                    {
                        StoreLocation = @"Directory",
                        StorePath = Path.Combine(path, "Application"),
                        SubjectName = $"CN={appName}, DC={hostName}"
                    },
                    TrustedIssuerCertificates = new CertificateTrustList
                    {
                        StoreType = @"Directory",
                        StorePath = Path.Combine(path, "Trusted")
                    },
                    TrustedPeerCertificates = new CertificateTrustList
                    {
                        StoreType = @"Directory",
                        StorePath = Path.Combine(path, "TrustedPeer")
                    },
                    RejectedCertificateStore = new CertificateTrustList
                    {
                        StoreType = @"Directory",
                        StorePath = Path.Combine(path, "Rejected")
                    },
                    AutoAcceptUntrustedCertificates = true,
                    AddAppCertToTrustedStore = true,
                    RejectSHA1SignedCertificates = false
                },
                TransportConfigurations = new TransportConfigurationCollection(),
                TransportQuotas = new TransportQuotas { OperationTimeout = 20000 },
                ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 5000 },
                TraceConfiguration = new TraceConfiguration
                {
                    DeleteOnLoad = true,
                },
                DisableHiResClock = false
            };
            AppConfig.Validate(ApplicationType.Client).GetAwaiter().GetResult();

            if (AppConfig.SecurityConfiguration.AutoAcceptUntrustedCertificates)
            {
                AppConfig.CertificateValidator.CertificateValidation += (s, ee) =>
                {
                    ee.Accept = (ee.Error.StatusCode == StatusCodes.BadCertificateUntrusted && untrusted);
                };
            }

            var application = new ApplicationInstance
            {
                ApplicationName = appName,
                ApplicationType = ApplicationType.Client,
                ApplicationConfiguration = AppConfig
            };
            Utils.SetTraceMask(0);
            application.CheckApplicationInstanceCertificate(true, 2048).GetAwaiter().GetResult();

            EndpointDescription = CoreClientUtils.SelectEndpoint(AppConfig, serverUrl, security);
            EndpointConfig = EndpointConfiguration.Create(AppConfig);
            Endpoint = new ConfiguredEndpoint(null, EndpointDescription, EndpointConfig);

        }


        /// <summary>
        /// Open the connection with the OPC UA Server
        /// </summary>
        /// <param name="timeOut">
        /// Timeout to try to connect with the server in seconds.
        /// </param>
        /// <param name="keepAlive">
        /// Sets whether to try to connect to the server in case the connection is lost.
        /// </param>
        /// <exception cref="ServerException"></exception>
        public void Connect(uint timeOut = 5, bool keepAlive = false)
        {
            this.Disconnect();

            this.Session = Task.Run(async () => await Session.Create(AppConfig, Endpoint, false, false, AppConfig.ApplicationName, timeOut * 1000, UserIdentity, null)).GetAwaiter().GetResult();

            if (keepAlive)
            {
                this.Session.KeepAlive += this.KeepAlive;
            }

            if (this.Session == null || !this.Session.Connected)
            {
                throw new ServerException("Error creating a session on the server");
            }
        }


        /// <summary>
        /// Close the connection with the OPC UA Server
        /// </summary>
        public void Disconnect()
        {
            if (this.Session != null && this.Session.Connected)
            {

                if (this.Session.Subscriptions != null && this.Session.Subscriptions.Any())
                {
                    foreach (var subscription in this.Session.Subscriptions)
                    {
                        subscription.Delete(true);
                    }
                }
                this.Session.Close();
                this.Session.Dispose();
                this.Session = null;
            }
        }

        public void ScanTags(NodeId sourceId)
        {
            // find all of the components of the node.
            BrowseDescription nodeToBrowse1 = new BrowseDescription();

            nodeToBrowse1.NodeId = sourceId;
            nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
            nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.Aggregates;
            nodeToBrowse1.IncludeSubtypes = true;
            nodeToBrowse1.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
            nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

            // find all nodes organized by the node.
            BrowseDescription nodeToBrowse2 = new BrowseDescription();

            nodeToBrowse2.NodeId = sourceId;
            nodeToBrowse2.BrowseDirection = BrowseDirection.Forward;
            nodeToBrowse2.ReferenceTypeId = ReferenceTypeIds.Organizes;
            nodeToBrowse2.IncludeSubtypes = true;
            nodeToBrowse2.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
            nodeToBrowse2.ResultMask = (uint)BrowseResultMask.All;

            BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            nodesToBrowse.Add(nodeToBrowse1);
            nodesToBrowse.Add(nodeToBrowse2);

            // fetch references from the server.
            ReferenceDescriptionCollection references = UaClientUI_utils.Browse(this.Session, nodesToBrowse, false);

            // process results.
            for (int ii = 0; ii < references.Count; ii++)
            {
                ReferenceDescription target = references[ii];
                if(target.NodeClass == NodeClass.Variable)
                {
                    if(!TagBook.Contains(target))
                    {
                        this.TagBook.Add(target);
                    }
                }
                else
                {
                    this.ScanTags((NodeId)target.NodeId);
                }
            }
        }

        public ReferenceDescription getTag(string Name)
        {
            ReferenceDescription retTag = null;

            foreach(ReferenceDescription TagAddress in this.TagBook)
            {
                if(TagAddress.BrowseName.Name.Contains(Name) || TagAddress.BrowseName.ToString() == Name)
                {
                    retTag = TagAddress;
                    break;
                }
            }

            return retTag;
        }


        /// <summary>
        /// Write a value on a tag
        /// </summary>
        /// <param name="address">
        /// Address of the tag
        /// </param>
        /// <param name="value">
        /// Value to write
        /// </param>
        /// <exception cref="WriteException"></exception>
        public void Write(String Name, Object value)
        {
            ReferenceDescription Tag = getTag(Name);


            WriteValue valueToWrite = new WriteValue();

            valueToWrite.NodeId = (NodeId)Tag.NodeId;
            valueToWrite.AttributeId = Attributes.Value;
            valueToWrite.Value.Value = value;
            valueToWrite.Value.StatusCode = StatusCodes.Good;
            valueToWrite.Value.ServerTimestamp = DateTime.MinValue;
            valueToWrite.Value.SourceTimestamp = DateTime.MinValue;

            WriteValueCollection valuesToWrite = new WriteValueCollection();
            valuesToWrite.Add(valueToWrite);

            // write current value.
            StatusCodeCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;

            this.Session.Write(
                null,
                valuesToWrite,
                out results,
                out diagnosticInfos);

            ClientBase.ValidateResponse(results, valuesToWrite);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, valuesToWrite);

            if (StatusCode.IsBad(results[0]))
            {
                throw new ServiceResultException(results[0]);
            }
        }

        /// <summary>
        /// Write a value on a tag
        /// </summary>
        /// <param name="tag"> <see cref="Tag"/></param>
        /// <exception cref="WriteException"></exception>
        public void Write(Tag tag)
        {
            this.Write(tag.Address, tag.Value);
        }


        /// <summary>
        /// Read a tag of the sepecific address
        /// </summary>
        /// <param name="address">
        /// Address of the tag
        /// </param>
        /// <returns>
        /// <see cref="Tag"/>
        /// </returns>
        public object Read(String Name)
        {
            ReferenceDescription Tag = getTag(Name);

            ReadValueId nodeToRead  = new ReadValueId();
            nodeToRead.NodeId       = (NodeId)Tag.NodeId;
            nodeToRead.AttributeId  = Attributes.Value;

            ReadValueIdCollection nodesToRead = new ReadValueIdCollection();
            nodesToRead.Add(nodeToRead);

            // read current value.
            DataValueCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;

            this.Session.Read(
                null,
                0,
                TimestampsToReturn.Neither,
                nodesToRead,
                out results,
                out diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);


            return results[0].Value;
        }


        /// <summary>
        /// Write a lis of values
        /// </summary>
        /// <param name="tags"> <see cref="Tag"/></param>
        /// <exception cref="WriteException"></exception>
        public void Write(List<Tag> tags)
        {
            WriteValueCollection writeValues = new WriteValueCollection();



            writeValues.AddRange(tags.Select(tag => new WriteValue
            {
                NodeId = new NodeId(tag.Address, 2),
                AttributeId = Attributes.Value,
                Value = new DataValue()
                {
                    Value = tag.Value
                }
            }));

            this.Session.Write(null, writeValues, out StatusCodeCollection statusCodes, out DiagnosticInfoCollection diagnosticInfo);

            if (statusCodes.Where(sc => !StatusCode.IsGood(sc)).Any())
            {
                var status = statusCodes.Where(sc => !StatusCode.IsGood(sc)).First();
                throw new WriteException("Error writing value. Code: " + status.Code.ToString());
            }
        }



        /// <summary>
        /// Read a list of tags on the OPCUA Server
        /// </summary>
        /// <param name="address">
        /// List of address to read.
        /// </param>
        /// <returns>
        /// A list of tags <see cref="Tag"/>
        /// </returns>
        public List<Tag> Read(List<String> address)
        {
            var tags = new List<Tag>();
            int i = 0;

            ReadValueIdCollection readValues = new ReadValueIdCollection();
            readValues.AddRange(address.Select(a => new ReadValueId
            {
                NodeId = new NodeId(a, 2),
                AttributeId = Attributes.Value
            }));

            this.Session.Read(null, 0, TimestampsToReturn.Both, readValues, out DataValueCollection dataValues, out DiagnosticInfoCollection diagnosticInfo);

            address.ForEach(a =>
            {
                tags.Add(new Tag
                {
                    Address = a,
                    Value = dataValues[i].Value,
                    Code = dataValues[i].StatusCode
                });
                i++;
            });

            return tags;
        }

        /// <summary>
        /// Monitoring a tag and execute a function when the value change
        /// </summary>
        /// <param name="address">
        /// Address of the tag
        /// </param>
        /// <param name="miliseconds">
        /// Sets the time to check changes in the tag
        /// </param>
        /// <param name="monitor">
        /// Function to execute when the value changes.
        /// </param>
        public void Monitoring(String Name, int miliseconds, MonitoredItemNotificationEventHandler monitor)
        {
            ReferenceDescription Tag = getTag(Name);

            var subscription = this.Subscription(miliseconds);
            MonitoredItem monitored = new MonitoredItem();
            monitored.StartNodeId = (NodeId)Tag.NodeId;
            monitored.AttributeId = Attributes.Value;
            monitored.Notification += monitor;
            subscription.AddItem(monitored);
            this.Session.AddSubscription(subscription);
            subscription.Create();
            subscription.ApplyChanges();
        }


        /// <summary>
        /// Scan root folder of OPC UA server and get all devices
        /// </summary>
        /// <param name="recursive">
        /// Indicates whether to search within device groups
        /// </param>
        /// <returns>
        /// List of <see cref="Device"/>
        /// </returns>
        public List<Device> Devices(bool recursive = false)
        {
            Browser browser = new Browser(this.Session);
            browser.BrowseDirection = BrowseDirection.Forward;
            browser.NodeClassMask = (int)NodeClass.Object | (int)NodeClass.Variable;
            //browser.ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences;
            browser.ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences;

            ReferenceDescriptionCollection browseResults = browser.Browse(Opc.Ua.ObjectIds.ObjectsFolder);

            var devices = browseResults.Where(d => d.ToString() != "Server").Select(b => new Device
            {
                Address = b.ToString()
            }).ToList();

            devices.ForEach(d =>
            {
                d.Groups = this.Groups(d.Address, recursive);
                d.Tags = this.Tags(d.Address);
            });

            return devices;
        }


        /// <summary>
        /// Create a browse description from a node id collection.
        /// </summary>
        /// <param name="nodeIdCollection">The node id collection.</param>
        /// <param name="template">The template for the browse description for each node id.</param>
        public BrowseDescriptionCollection CreateBrowseDescriptionCollectionFromNodeId(
            NodeIdCollection nodeIdCollection,
            BrowseDescription template)
        {
            var browseDescriptionCollection = new BrowseDescriptionCollection();
            foreach (var nodeId in nodeIdCollection)
            {
                BrowseDescription browseDescription = (BrowseDescription)template.MemberwiseClone();
                browseDescription.NodeId = nodeId;
                browseDescriptionCollection.Add(browseDescription);
            }
            return browseDescriptionCollection;
        }


        /// <summary>
        /// Create the continuation point collection from the browse result
        /// collection for the BrowseNext service.
        /// </summary>
        /// <param name="browseResultCollection">The browse result collection to use.</param>
        /// <returns>The collection of continuation points for the BrowseNext service.</returns>
        private static ByteStringCollection PrepareBrowseNext(BrowseResultCollection browseResultCollection)
        {
            var continuationPoints = new ByteStringCollection();
            foreach (var browseResult in browseResultCollection)
            {
                if (browseResult.ContinuationPoint != null)
                {
                    continuationPoints.Add(browseResult.ContinuationPoint);
                }
            }
            return continuationPoints;
        }


        /// <summary>
        /// Scan an address and retrieve the tags and groups
        /// </summary>
        /// <param name="address">
        /// Address to search
        /// </param>
        /// <param name="recursive">
        /// Indicates whether to search within group groups
        /// </param>
        /// <returns>
        /// List of <see cref="Group"/>
        /// </returns>
        public List<Group> Groups(String address, bool recursive = false)
        {

            var groups = new List<Group>();

            // find all nodes organized by the node.
            BrowseDescription nodeToBrowse2 = new BrowseDescription();

            nodeToBrowse2.NodeId = new NodeId(address, 2);
            nodeToBrowse2.BrowseDirection = BrowseDirection.Forward;
            nodeToBrowse2.ReferenceTypeId = ReferenceTypeIds.Organizes;
            nodeToBrowse2.IncludeSubtypes = true;
            nodeToBrowse2.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
            nodeToBrowse2.ResultMask = (uint)BrowseResultMask.All;

            BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            nodesToBrowse.Add(nodeToBrowse2);

            // start the browse operation.
            BrowseResultCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;

            Session.Browse(
                null,
                null,
                0,
                nodesToBrowse,
                out results,
                out diagnosticInfos);

            //ClientBase.ValidateResponse(results, nodesToBrowse);
            //ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToBrowse);






            Browser browser         = new Browser(this.Session);
            browser.BrowseDirection = BrowseDirection.Forward;
            browser.ReferenceTypeId = ReferenceTypeIds.Organizes;
            browser.NodeClassMask   = (int)NodeClass.Object | (int)NodeClass.Variable;
            browser.ResultMask      = (uint)BrowseResultMask.All;


            ReferenceDescriptionCollection browseResults = browser.Browse(new NodeId(address, 2));
            foreach (var result in browseResults)
            {
                if (result.NodeClass == NodeClass.Object)
                {
                    groups.Add(new Group
                    {
                        Address = address + "." + result.ToString()
                    });
                }
            }

            groups.ForEach(g =>
            {
                g.Groups = this.Groups(g.Address, recursive);
                g.Tags = this.Tags(g.Address);
            });

            return groups;
        }


        /// <summary>
        /// Scan an address and retrieve the tags.
        /// </summary>
        /// <param name="address">
        /// Address to search
        /// </param>
        /// <returns>
        /// List of <see cref="Tag"/>
        /// </returns>
        public List<Tag> Tags(String address)
        {

            var tags = new List<Tag>();
            Browser browser = new Browser(this.Session);
            browser.BrowseDirection = BrowseDirection.Forward;
            browser.NodeClassMask = (int)NodeClass.Object | (int)NodeClass.Variable;
            browser.ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences;

            ReferenceDescriptionCollection browseResults = browser.Browse(new NodeId(address, 2));
            foreach (var result in browseResults)
            {
                if (result.NodeClass == NodeClass.Variable)
                {
                    tags.Add(new Tag
                    {
                        Address = address + "." + result.ToString()
                    });
                }
            }

            return tags;
        }



        public void _brows()
        {
            if (this.Session == null || this.Session.Connected == false)
            {
                //m_output.WriteLine("Session not connected!");
                return;
            }

            try
            {
                // Create a Browser object
                Browser browser = new Browser(this.Session);

                // Set browse parameters
                browser.BrowseDirection = BrowseDirection.Forward;
                browser.NodeClassMask = (int)NodeClass.Object | (int)NodeClass.Variable;
                browser.ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences;

                //NodeId nodeToBrowse = NodeId. ObjectIds.Server;

                // Call Browse service
                //WriteLine("Browsing {0} node...", nodeToBrowse);
                ReferenceDescriptionCollection browseResults = browser.Browse(null);

                // Display the results
                //m_output.WriteLine("Browse returned {0} results:", browseResults.Count);

                foreach (ReferenceDescription result in browseResults)
                {
                    //m_output.WriteLine("     DisplayName = {0}, NodeClass = {1}", result.DisplayName.Text, result.NodeClass);
                }
            }
            catch (Exception ex)
            {
                // Log Error
                //m_output.WriteLine($"Browse Error : {ex.Message}.");
            }
        }


        #region Async methods

        /// <summary>
        /// Scan root folder of OPC UA server and get all devices
        /// </summary>
        /// <param name="recursive">
        /// Indicates whether to search within device groups
        /// </param>
        /// <returns>
        /// List of <see cref="Device"/>
        /// </returns>
        public Task<List<Device>> DevicesAsync(bool recursive = false)
        {
            return Task.Run(() =>
            {
                Browser browser = new Browser(this.Session);
                browser.BrowseDirection = BrowseDirection.Forward;
                browser.NodeClassMask = (int)NodeClass.Object | (int)NodeClass.Variable;
                browser.ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences;

                ReferenceDescriptionCollection browseResults = browser.Browse(Opc.Ua.ObjectIds.ObjectsFolder);

                var devices = browseResults.Where(d => d.ToString() != "Server").Select(b => new Device
                {
                    Address = b.ToString()
                }).ToList();

                devices.ForEach(d =>
                {
                    d.Groups = this.Groups(d.Address, recursive);
                    d.Tags = this.Tags(d.Address);
                });
                return devices;
            });
        }


        /// <summary>
        /// Scan an address and retrieve the tags and groups
        /// </summary>
        /// <param name="address">
        /// Address to search
        /// </param>
        /// <param name="recursive">
        /// Indicates whether to search within group groups
        /// </param>
        /// <returns>
        /// List of <see cref="Group"/>
        /// </returns>
        public Task<List<Group>> GroupsAsync(String address, bool recursive = false)
        {
            return Task.Run(() =>
            {
                var groups = new List<Group>();
                Browser browser = new Browser(this.Session);
                browser.BrowseDirection = BrowseDirection.Forward;
                browser.NodeClassMask = (int)NodeClass.Object | (int)NodeClass.Variable;
                browser.ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences;

                ReferenceDescriptionCollection browseResults = browser.Browse(new NodeId(address, 2));
                foreach (var result in browseResults)
                {
                    if (result.NodeClass == NodeClass.Object)
                    {
                        groups.Add(new Group
                        {
                            Address = address + "." + result.ToString()
                        });
                    }
                }

                groups.ForEach(g =>
                {
                    g.Groups = this.Groups(g.Address, recursive);
                    g.Tags = this.Tags(g.Address);
                });

                return groups;
            });
        }


        /// <summary>
        /// Scan an address and retrieve the tags.
        /// </summary>
        /// <param name="address">
        /// Address to search
        /// </param>
        /// <returns>
        /// List of <see cref="Tag"/>
        /// </returns>
        public Task<List<Tag>> TagsAsync(String address)
        {
            return Task.Run(() =>
            {

                var tags = new List<Tag>();
                Browser browser = new Browser(this.Session);
                browser.BrowseDirection = BrowseDirection.Forward;
                browser.NodeClassMask = (int)NodeClass.Object | (int)NodeClass.Variable;
                browser.ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences;

                ReferenceDescriptionCollection browseResults = browser.Browse(new NodeId(address, 2));
                foreach (var result in browseResults)
                {
                    if (result.NodeClass == NodeClass.Variable)
                    {
                        tags.Add(new Tag
                        {
                            Address = address + "." + result.ToString()
                        });
                    }
                }

                return tags;
            });
        }



        /// <summary>
        /// Write a value on a tag
        /// </summary>
        /// <param name="address">
        /// Address of the tag
        /// </param>
        /// <param name="value">
        /// Value to write
        /// </param>
        public async Task<Tag> WriteAsync(String address, Object value)
        {
            Tag tag;
            WriteValueCollection writeValues = new WriteValueCollection();
            var writeValue = new WriteValue
            {
                NodeId = new NodeId(address, 2),
                AttributeId = Attributes.Value,
                Value = new DataValue()
            };
            writeValue.Value.Value = value;
            writeValues.Add(writeValue);
            WriteResponse response = await this.Session.WriteAsync(null, writeValues, new CancellationToken());

            tag = new Tag()
            {
                Address = address,
                Value = value,
                Code = response.Results[0].Code
            };

            return tag;

        }



        /// <summary>
        /// Write a value on a tag
        /// </summary>
        /// <param name="tag"> <see cref="Tag"/></param>
        public async Task<Tag> WriteAsync(Tag tag)
        {
            tag = await this.WriteAsync(tag.Address, tag.Value);

            return tag;
        }

        /// <summary>
        /// Write a lis of values
        /// </summary>
        /// <param name="tags"> <see cref="Tag"/></param>
        public async Task<List<Tag>> WriteAsync(List<Tag> tags)
        {
            WriteValueCollection writeValues = new WriteValueCollection();



            writeValues.AddRange(tags.Select(tag => new WriteValue
            {
                NodeId = new NodeId(tag.Address, 2),
                AttributeId = Attributes.Value,
                Value = new DataValue()
                {
                    Value = tag.Value
                }
            }));

            WriteResponse response = await this.Session.WriteAsync(null, writeValues, new CancellationToken());

            for (int i = 0; i < response.Results.Count; i++)
            {
                tags[i].Code = response.Results[i].Code;
            }

            return tags;
        }



        /// <summary>
        /// Read a tag of the sepecific address
        /// </summary>
        /// <param name="address">
        /// Address of the tag
        /// </param>
        /// <returns>
        /// <see cref="Tag"/>
        /// </returns>
        public async Task<Tag> ReadAsync(String address)
        {
            var tag = new Tag
            {
                Address = address,
                Value = null,
            };
            ReadValueIdCollection readValues = new ReadValueIdCollection()
            {
                new ReadValueId
                {
                    NodeId = new NodeId(address, 2),
                    AttributeId = Attributes.Value
                }
            };

            var dataValues = await this.Session.ReadAsync(null, 0, TimestampsToReturn.Both, readValues, new CancellationToken());

            tag.Value = dataValues.Results[0].Value;
            tag.Code = dataValues.Results[0].StatusCode;

            return tag;
        }

        /// <summary>
        /// Read a list of tags on the OPCUA Server
        /// </summary>
        /// <param name="address">
        /// List of address to read.
        /// </param>
        /// <returns>
        /// A list of tags <see cref="Tag"/>
        /// </returns>
        public async Task<List<Tag>> ReadAsync(List<String> address)
        {
            var tags = new List<Tag>();
            int i = 0;

            ReadValueIdCollection readValues = new ReadValueIdCollection();
            readValues.AddRange(address.Select(a => new ReadValueId
            {
                NodeId = new NodeId(a, 2),
                AttributeId = Attributes.Value
            }));

            var dataValues = await this.Session.ReadAsync(null, 0, TimestampsToReturn.Both, readValues, new CancellationToken());

            address.ForEach(a =>
            {
                tags.Add(new Tag
                {
                    Address = a,
                    Value = dataValues.Results[i].Value,
                    Code = dataValues.Results[i].StatusCode
                });
                i++;
            });

            return tags;
        }


        #endregion



        #endregion

        #region Private methods
        private void KeepAlive(ISession session, KeepAliveEventArgs e)
        {
            try
            {
                if (ServiceResult.IsBad(e.Status))
                {
                    lock (this.Lock)
                    {
                        if (this.ReconnectHandler == null)
                        {
                            this.ReconnectHandler = new SessionReconnectHandler(true);
                            this.ReconnectHandler.BeginReconnect(this.Session, this.ReconnectPeriod, this.Reconnect);
                        }
                    }
                }
            }
            catch (Exception ex)
            {


            }
        }

        private void Reconnect(object sender, EventArgs e)
        {
            if (!Object.ReferenceEquals(sender, this.ReconnectHandler))
            {
                return;
            }

            lock (this.Lock)
            {
                if (this.ReconnectHandler.Session != null)
                {
                    this.Session = (Session)this.ReconnectHandler.Session;
                }
                this.ReconnectHandler.Dispose();
                this.ReconnectHandler = null;
            }
        }

        private Subscription Subscription(int miliseconds)
        {

            var subscription = new Subscription()
            {
                PublishingEnabled = true,
                PublishingInterval = miliseconds,
                Priority = 1,
                KeepAliveCount = 10,
                LifetimeCount = 20,
                MaxNotificationsPerPublish = 1000
            };

            return subscription;

        }
        #endregion

    }


}