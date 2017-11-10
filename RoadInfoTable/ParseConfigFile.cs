using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace RoadInfoTable
{
    public static class ParseConfigFile
    {
        public static string GetAppConfig(string strKey)
        {
            string strValue = null;
            try
            {
                strValue = ConfigurationManager.AppSettings[strKey];
            }
            catch (System.Exception)
            {
                strValue = null;
            }
            return strValue;
        }
    }
}
