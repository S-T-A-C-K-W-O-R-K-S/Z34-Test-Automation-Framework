using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Framework.Config
{
    public class ConfigReader
    {
        public static string InitializeTest()
        {
            return ConfigurationManager.AppSettings["AUT"].ToString();
        }
    }
}
