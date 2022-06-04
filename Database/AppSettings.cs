using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class AppSettings
    {
        Configuration configuration;

        public AppSettings()
        {
            configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public string GetConnectionString(string key)
        {
            return configuration.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }

        public void SaveConnectionString(string key, string value)
        {
            configuration.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
            configuration.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
            configuration.Save(ConfigurationSaveMode.Modified);
        }
    }
}
