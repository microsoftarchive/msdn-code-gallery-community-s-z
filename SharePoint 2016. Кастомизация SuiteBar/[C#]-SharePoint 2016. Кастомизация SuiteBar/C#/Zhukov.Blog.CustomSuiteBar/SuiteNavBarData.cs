using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zhukov.Blog.CustomSuiteBar
{
    public class SuiteNavBarData
    {
        [DataMember]
        public SuiteNavLink AboutMeLink { get; set; }

        [DataMember]
        public string ClientData { get; set; }

        [DataMember]
        public string CurrentMainLinkElementID { get; set; }

        [DataMember]
        public SuiteNavLink[] CurrentWorkloadHelpSubLinks { get; set; }

        [DataMember]
        public SuiteNavLink[] CurrentWorkloadSettingsSubLinks { get; set; }

        [DataMember]
        public SuiteNavLink[] CurrentWorkloadUserSubLinks { get; set; }

        [DataMember]
        public SuiteNavLink HelpLink { get; set; }

        [DataMember]
        public bool IsAuthenticated { get; set; }

        [DataMember]
        public SuiteNavLink SignOutLink { get; set; }

        [DataMember]
        public Dictionary<string, string> StringsOverride { get; set; }

        [DataMember]
        public string UserDisplayName { get; set; }

        [DataMember]
        public List<SuiteNavLink> WorkloadLinks { get; set; }
    }
}