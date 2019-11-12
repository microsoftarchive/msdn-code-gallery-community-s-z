using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailConfigurationLibrary;

namespace MailConfigurationLibrary_Test
{
    /// <summary>
    /// Test will fail if you don't place values into the app.config file and also you need to do the same in the TODO's below
    /// </summary>
    [TestClass]
    public class SettingsTest
    {
        [TestMethod]
        public void TimeOut_Test()
        {
            MailConfiguration mc = new MailConfiguration();
            Assert.IsTrue(mc.FromAddress == "TODO", "Failed to read From address");
            Assert.IsTrue(mc.TimeOut == 2000, "Failed to read TimeOut");
        }

        [TestMethod]
        public void Host_Test()
        {
            MailConfiguration mc = new MailConfiguration();
            Assert.IsTrue(mc.Host == "TODO", "Failed to read host");
        }
        [TestMethod]
        public void Port_Test()
        {
            MailConfiguration mc = new MailConfiguration();
            Assert.IsTrue(mc.Port == 25, "Failed to read port");
        }
        [TestMethod]
        public void FileName_Test()
        {
            MailConfiguration mc = new MailConfiguration();
            string configFileName = mc.ConfigurationFileName;
            string projectFileName = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            Assert.IsTrue(configFileName == projectFileName, "File names different");
        }
    }
}
