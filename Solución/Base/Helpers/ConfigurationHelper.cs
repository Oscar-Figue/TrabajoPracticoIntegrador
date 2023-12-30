using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Helpers
{
    public static class ConfigurationHelper
    {
        public static string GetConnectionString()
        {
            var key = "ConnectionString";
            var connectionString = ConfigurationManager.ConnectionStrings[key]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ConfigurationErrorsException($"Connection string '{key}' not found or empty in configuration file.");
            }
            return connectionString;
        }
    }
}
