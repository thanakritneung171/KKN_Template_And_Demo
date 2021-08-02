using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebService_API.Helper
{
    public class AppConfig
    {
        private static AppConfig instance = null;
        private static readonly object padlock = new object();

        public static AppConfig Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AppConfig();
                        instance.LoadConfiguration();
                    }
                    return instance;
                }
            }
        }

        private void LoadConfiguration()
        {
            APIVersion = ConfigurationManager.AppSettings["API:Version"];
        }

        public string APIVersion { get; private set; }
    }
}