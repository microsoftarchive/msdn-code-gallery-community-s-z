using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.SharePoint.Client;

namespace Zhukov.Blog.CustomSuiteBar
{
    [ClientCallableType(
        Name = "CustomSuiteNavService",
        ServerTypeId = "{97bb7990-9444-4f22-b5ad-dc8a5667041e}")]
    public class CustomSuiteNavService
    {
        [ClientCallableMethod]
        public string GetSuiteNavData()
        {
            var suiteNav = GetSuiteNav();
            var serializer = new DataContractJsonSerializer(typeof (SuiteNav));
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, suiteNav);
                return Encoding.Default.GetString(ms.ToArray());
            }
        }

        private SuiteNav GetSuiteNav()
        {
            return new SuiteNav
            {
                DoNotCache = false,
                SPSuiteVersion = 2,
                NavBarData = new SuiteNavBarData
                {
                    AboutMeLink = new SuiteNavLink("ShellAboutMe", "About Me", null, "#ShellAboutMe"),
                    ClientData = null,
                    CurrentMainLinkElementID = "ShellSharepoint",
                    StringsOverride = null,
                    IsAuthenticated = true,
                    UserDisplayName = "UserDisplayName",
                    HelpLink = new SuiteNavLink("ShellHelp", "Help", null, "#ShellHelp"),
                    SignOutLink = new SuiteNavLink("ShellSignOut", "Sign Out", null, "#ShellSignOut"),
                    CurrentWorkloadHelpSubLinks = 
                        new[] { new SuiteNavLink("HelpSubLink", "HelpSubLink", null, "#HelpSubLink") },
                    CurrentWorkloadSettingsSubLinks =
                        new[] { new SuiteNavLink("SettingsSubLink", "SettingsSubLink", null, "#SettingsSubLink") },
                    CurrentWorkloadUserSubLinks =
                        new[] { new SuiteNavLink("UserSubLink", "UserSubLink", null, "#UserSubLink") },
                    WorkloadLinks = new List<SuiteNavLink>
                    {
                        new SuiteNavLink("ShellDocuments", "ShellDocuments", null, "#ShellDocuments"),
                        new SuiteNavLink("ShellFAQ", "ShellFAQ", null, "#ShellFAQ"),
                        new SuiteNavLink("ShellChat", "ShellChat", null, "#ShellChat"),
                        new SuiteNavLink("ShellVideo", "ShellVideo", null, "#ShellVideo"),
                        new SuiteNavLink("ShellCRM", "ShellCRM", null, "#ShellCRM"),
                        new SuiteNavLink("ShellStar", "ShellStar", null, "#ShellStar"),
                        new SuiteNavLink("ShellProject", "ShellProject", null, "#ShellProject"),
                        new SuiteNavLink("ShellYammer", "ShellYammer", null, "#ShellYammer"),
                        new SuiteNavLink("ShellExcel", "ShellExcel", null, "#ShellExcel"),
                        new SuiteNavLink("ShellPowerBI", "ShellPowerBI", null, "#ShellPowerBI"),
                        new SuiteNavLink("ShellCheck", "ShellCheck", null, "#ShellCheck"),
                        new SuiteNavLink("ShellSearch", "ShellSearch", null, "#ShellSearch"),
                    }
                }
            };
        }
    }
}
