using EdgeWebDriver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeWebDriver.Environment
{
    /// <summary>
    /// EnvironmentReader loads the environment variables from the App.config file.
    /// </summary>
    public class EnvironmentReader
    {
        private const string ROLES_KEY = "Roles";
        private const string BASE_URL_KEY = "Base_URL";
        private const string BROWSER_KEY = "Browser";
        private const string REMOTE_KEY = "Remote";
        private const string SLEEP_KEY = "Sleep";
        private const string LOGGER_KEY = "Logger";

        /// <summary>
        /// List of properties.
        /// </summary>
        public static readonly string Roles;
        public static readonly string Base_URL;
        public static readonly Browsers Browser;
        public static readonly bool Remote;
        public static readonly bool Sleep;
        public static readonly bool Logger;
        public static readonly string IHDtitle;

        /// <summary>
        /// Environment reader consrtuctor.
        /// </summary>
        static EnvironmentReader()
        {
            Roles = GetConfig(ROLES_KEY);
            Base_URL = GetConfig(BASE_URL_KEY);
            Browser = GetBrowserConfig(GetConfig(BROWSER_KEY));
            Remote = bool.Parse(GetConfig(REMOTE_KEY));
            Sleep = bool.Parse(GetConfig(SLEEP_KEY));
            Logger = bool.Parse(GetConfig(LOGGER_KEY));

        }

        /// <summary>
        /// Get config as String from environment or App.config.
        /// </summary>
        /// <returns>the config value for the key passed as paramter</returns>
        private static String GetConfig(String key)
        {
            var config = System.Environment.GetEnvironmentVariable(key);
            if (config != null && config.Length > 0)
            {
                return config;
            }
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// Gets the browser config value.
        /// </summary>
        /// <param name="browser">the browser name as String</param>
        /// <returns>the <see cref="Browsers"/></returns>
        private static Browsers GetBrowserConfig(String browser)
        {
            switch (browser)
            {
                case "Chrome":
                    return Browsers.Chrome;
                case "IExplorer":
                    return Browsers.IExplorer;
                case "Firefox":
                    return Browsers.Firefox;
            }
            // Returns the default browser == Chrome
            return Browsers.Chrome;
        }

        
    }
}