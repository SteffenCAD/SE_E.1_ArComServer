using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.itac.mes.imsapi.domain;
using com.itac.mes.imsapi.domain.container;
using com.itac.mes.imsapi.client.dotnet;
using System.Windows.Forms;

namespace MES.ITAC
{
    public class ITACapi
    {
        private static IIMSApiDotNet imsapi = null;
        private static IMSApiSessionContextStruct sessionContext = null;
        private static Dictionary<Int64, IMSApiSessionContextStruct> allSessions = new Dictionary<Int64, IMSApiSessionContextStruct>();
        //private static Dictionary<Int64, MyEventListener> myEventListeners = new Dictionary<Int64, MyEventListener>();

        private static IMSApiSessionValidationStruct sessValData = new IMSApiSessionValidationStruct();
        private static IMSApiSessionContextStruct newSessionContext = null;

        public int init()
        {
            int result = 0;

            //set appid as property programmatically
            //(usable for all properties
            IMSApiDotNet.setProperty("itac.appid", "IMSApiDotNetTestClient");

            //create imsapi instance 
            imsapi = IMSApiDotNet.loadLibrary();

            // call imsapiInit
            result = imsapi.imsapiInit();
            if (result != IMSApiDotNetConstants.RES_OK)
            {
                MessageBox.Show("imsapi.imsapiInit() " + result.ToString());
                string test = getError(result);
                return result;
            }

            // call apiLogin
            // declare variables

            // read values for 'in' and 'inout' arguments
            sessValData.stationNumber = "L01HRL01-0100-01";
            sessValData.stationPassword = "";
            sessValData.user = "";
            sessValData.password = "";
            sessValData.client = "";
            sessValData.registrationType = "";
            sessValData.systemIdentifier = "";
            // call imsapi function
            result = imsapi.regLogin(sessValData, out newSessionContext);
            if (result != IMSApiDotNetConstants.RES_OK)
            {
                MessageBox.Show("imsapi.regLogin " + result.ToString());
                string test = getError(result);
                return result;
            }
            sessionContext = newSessionContext;
            allSessions.Add(sessionContext.sessionId, sessionContext);
            // use or print the result and output values

            return result;
          }

        public string getVersion()
        {
            int result = imsapi.imsapiGetLibraryVersion(out string version);
            if (result != IMSApiDotNetConstants.RES_OK)
            {
                return result.ToString();
            }
            return version;
        }
        public string getError(int code)
        {
            string text = null;

            imsapi.imsapiGetErrorText(sessionContext, code, out text );

            return text;
        }

        #region MES functions

        public int mesWorkorderActive(string station, out string workorder, out string partnumber)
        {
            int result = 0;
            workorder = "";
            partnumber = "";

            string[] stationSettingResultKeys = { "PART_NUMBER", "WORKORDER_NUMBER"};
            string[] stationSettingResultValues;

            result = imsapi.trGetStationSetting(sessionContext, station, stationSettingResultKeys, out stationSettingResultValues);
            if(result == 0)
            {
                if(stationSettingResultValues.Length >= 2)
                {
                    partnumber = stationSettingResultValues[0];
                    workorder = stationSettingResultValues[1];
                }
            }
            return result;
        }

        public int mesGetTagVariant(string station, string partnumber, out string TagVariant)
        {
            int result = 0;
            TagVariant = "";

            KeyValue[] bomDataFilter = new KeyValue[1];
                bomDataFilter[0].key = "PRODUCT_NUMBER";
                bomDataFilter[0].key = "000001";
            string[] bomDataResultKeys = {"PART_NUMBER"};
            string[] bomDataResultValues;

            result = imsapi.mdataGetBomData(sessionContext, station, bomDataFilter, bomDataResultKeys, out bomDataResultValues);
            if (result == 0)
            {
                if (bomDataResultValues.Length >= 1)
                {
                    if(bomDataResultValues[0] == "RS0000")
                    {
                        TagVariant = "01";
                    }
                    else if(bomDataResultValues[0] == "RS0001")
                    {
                        TagVariant = "02";
                    }
                }
            }
            return result;
        }

        public int mesGetNextSerialNumber(string station, string workorder, out string SerialNumber)
        {
            int result = 0;
            SerialNumber = "";


            string partNumber = "-1";
            int numberOfRecords = 1;
            SerialNumberData[] serialNumberArray;

            result = imsapi.trGetNextSerialNumber(sessionContext,station, workorder, partNumber, numberOfRecords, out serialNumberArray);
            if(result != 0)
            {
                return result;
            }
            if (serialNumberArray.Length == 0)
            {
                return 9999;
            }

            partNumber = "-1";
            string bomVersion = "-1";
            string serialNumberRef = serialNumberArray[0].serialNumber;
            string serialNumberRefPos = "-1";
            int processLayer = 2;
            serialNumberArray = null;
            int activateWorkOrder = 0;

            result = imsapi.trAssignSerialNumberForProductOrWorkOrder(sessionContext, station, workorder, partNumber, bomVersion, serialNumberRef, serialNumberRefPos, processLayer, serialNumberArray, activateWorkOrder);
            if(result != 0)
            {
                return result;
            }
            
            return result;
        }

        public int mesUploadState(string station, string SerialNumber, bool state)
        {
            int result = 0;
            
            int processLayer = 2;
            string serialNumberRefPos = "-1";
            int serialNumberState = 0;
                if (!state) serialNumberState = 1;
            int duplicateSerialNumber = 0;
            long bookDate = -1;
            float cycleTime = 0;
            string[] serialNumberUploadKeys = null;
            string[] serialNumberUploadValues = null;
            string[] serialNumberResultValues;

            result = imsapi.trUploadState(sessionContext, station, processLayer, SerialNumber, serialNumberRefPos, serialNumberState, duplicateSerialNumber,
                bookDate, cycleTime, serialNumberUploadKeys, serialNumberUploadValues, out serialNumberResultValues);

            return result;
        }
        #endregion


        #region trFunctions
        public int trGetWorkorderForStation()
        {
            int result = 0;
            return result;
        }

        public int trGetNextSerialNumber()
        {
            int result = 0;
            return result;
        }

        public int trAssignSerialNumberForProductOrWorkOrder(string station, string serial, string workorder)
        {
            int result = 0;

            string partNumber = "";
            string bomVersion = "";
            string serialNumberRefPos = "";
            int processLayer = 2;
            SerialNumberData[] serialNumberArray = null;
            int activateWorkOrder = 0;

            result = imsapi.trAssignSerialNumberForProductOrWorkOrder(sessionContext, station, workorder, partNumber, bomVersion, serial, serialNumberRefPos, processLayer, serialNumberArray, activateWorkOrder);

            return result;
        }

        public int trGetStationSetting(string station, out string[] stationSettingResultValues )
        {
            int result = 0;

            string[] stationSettingResultKeys = { "WORKORDER_NUMBER", "PART_NUMBER" };

            stationSettingResultValues = null;

            result = imsapi.trGetStationSetting(sessionContext, station, stationSettingResultKeys, out stationSettingResultValues);

            return result;
        }

        public int trUploadState(string station, string serial, bool state)
        {
            int result = 0;


            //imsapi.trUploadState(sessionContext,station, processLayer,serial, serialNumberRefPos, serialNumberState, duplicateSerialNumber, bookDate, cycleTime, serialNumberUploadKeys, );

            return result;
        }
        #endregion

        #region SHIP functions
        public int shipGetShippingLotInfo()
        {
            int result = 0;
            return result;
        }

        public int shipGetShippingPrefs(string stationNumber)
        {
            int result = 0;

            int objectType = 1;

            string[] shippingPrefsResultKeys = { "", "" };

            //imsapi.shipGetShippingPrefs(sessionContext, stationNumber,);

            return result;
        }

        #endregion

        #region MDATA functions

        #endregion
    }
}
