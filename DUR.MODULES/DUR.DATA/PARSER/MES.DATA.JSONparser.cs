using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace MES.DATA
{
    public class JSON
    {
        #region Convert
        /// <summary>
        /// parse json file string
        /// </summary>
        /// <param name="JSON"></param>
        /// <param name="orderDetails"></param>
        /// <param name="statusBits"></param>
        /// <param name="plcInfo"></param>
        public void fromJSON(string JSONstring)
        {
            try
            {
                //remove empty spaces and brakets
                JSONstring = JSONstring.Trim(new Char[] { ' ', '{', '}' });

                //split into raw array
                string[] JsonRawArray = JSONstring.Split(',');

                //get typs of object
                Type tprops = this.GetType();
                foreach (PropertyInfo propInfo in tprops.GetProperties())
                {
                    string propName = propInfo.Name;
                    string value = GetValue(JsonRawArray, propName);

                    if (value != null)
                    {
                        object result = Convert.ChangeType(value,propInfo.PropertyType,null);
                        propInfo.SetValue(this, result);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// convert data to json
        /// </summary>
        /// <param name="orderDetails"></param>
        /// <param name="statusBits"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public string toJSON()
        {
            string JSON = null;
            //var test = propInfo.GetValue(this, null);

            return JSON;
        }


        private string GetValue(string[] JsonRawArray, string Name)
        {
            string value = null;

            //loop through array to find variable name
            foreach(string str in JsonRawArray)
            {
                if(str.Contains(Name))
                {
                    string[] vs = str.Split(':');
                    if(vs.Length == 2)
                    {
                        //if found copy to output and break
                        value = vs[1].Trim(' ');
                        break;
                    }
                }                
            }

            return value;
        }
        #endregion
    }
}
