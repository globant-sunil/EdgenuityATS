using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using log4net.Core;
using System;
using System.Configuration;
using System.IO;
using EdgeWebDriver.Enums;

namespace EdgeWebDriver.Log {
    /// <summary>
    /// LogHandler handles the logging configuration for the test automation project by configuring a file appender 
    /// to save every actions that happens in the test.
    /// </summary>
    public class LogHandler
    {
        public static string testName;
        public string browser;
        public static string ProjectPath;
        public static string LogFilesPath;
        public static ILog Logger;
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static bool enabled = false;

        /// <summary>
        /// Inits the logs. File Appender is created.
        /// </summary>
        /// <param name="testName">the test name</param>
        /// <param name="testSuite">the test suite name</param>
        /// <param name="parameters">the test parameters</param>
        /// <param name="role">the test Role</param>
        /// <param name="enabled">the Logger ON/OFF flag</param>
        public static void SetLogs(string testName, string testSuite, string parameters, Roles role, bool enabled)
        {
            LogHandler.enabled = enabled;
            if (enabled)
            {
                GetLogFilePath();

                PatternLayout patternLayout = new PatternLayout
                {
                    ConversionPattern = "%date %-5level - %message%newline"
                };
                patternLayout.ActivateOptions();

                RollingFileAppender appender = new RollingFileAppender
                {
                    AppendToFile = true,
                    File = LogHandler.LogFilesPath + DateTime.Now.ToString("yyyy_dd_MM") + "//" + testSuite + "//" + testName + ".log",
                    Layout = patternLayout,
                    MaxSizeRollBackups = 5,
                    MaximumFileSize = "1MB",
                    RollingStyle = RollingFileAppender.RollingMode.Size,
                    StaticLogFileName = true
                };
                appender.ActivateOptions();

                //log4net.Config.BasicConfigurator.Configure(appender);
                Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
                hierarchy.Root.AddAppender(appender);
                hierarchy.Root.Level = Level.Debug;
                hierarchy.Configured = true;
                LogHandler.Info("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  START OF SCENARIO   >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                LogHandler.Info("SCENARIO NAME - " + testName);
                LogHandler.Info("DATASET - " + role + " - " + parameters);
                Console.WriteLine("DATASET - " + role + " - " + parameters);
            }
        }

        /// <summary>
        /// Log information with INFO level.
        /// </summary>
        /// <param name="message">the message to be logged</param>
        public static void Info(string message)
        {
            if (enabled)
            {
                logger.Info(message);
            }
        }

        /// <summary>
        /// Log information with ERROR level.
        /// </summary>
        /// <param name="message">the message to be logged</param>
        public static void Error(string message)
        {
            if (enabled)
            {
                logger.Error(message);
            }
        }

        /// <summary>
        /// Gets the log file path.
        /// </summary>
        public static void GetLogFilePath()
        {
            GetProjectPath();
            ConfigurationManager.AppSettings.Set("strLogFilesPath", "\\Logs\\");
            LogFilesPath = LogHandler.ProjectPath + ConfigurationManager.AppSettings.Get("strLogFilesPath").ToString();

        }

        /// <summary>
        /// Gets project path.
        /// </summary>
        public static void GetProjectPath()
        {
            try
            {
                ProjectPath = System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName;

                FileInfo info = new FileInfo(ProjectPath); //using System.IO;
                DirectoryInfo ParentDir = info.Directory;
                string ParentDi = ParentDir.ToString();
                FileInfo info2 = new FileInfo(ParentDi); //using System.IO;
                DirectoryInfo ChildDir = info2.Directory;

                ProjectPath = ParentDir.ToString();
            }
            catch (Exception ex)
            {
                // TODO: Print more information about the error, not only the exception. Or try to have a workaround if this exception happens.
                Console.WriteLine("LogHandler::" + ex.Message);
            }
        }
    }
}
