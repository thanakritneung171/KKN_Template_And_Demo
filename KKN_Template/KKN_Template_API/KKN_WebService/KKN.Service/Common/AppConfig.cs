using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKN.Service.Common
{
    public class AppConfig
    {
        private static string GetAppSettingValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        private static string GetConnectionStringValue(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        public static string KKNDbConnectionString()
        {
            string connString = GetConnectionStringValue("KKNDbConnectionString");
            return connString;
        }
    }
}
