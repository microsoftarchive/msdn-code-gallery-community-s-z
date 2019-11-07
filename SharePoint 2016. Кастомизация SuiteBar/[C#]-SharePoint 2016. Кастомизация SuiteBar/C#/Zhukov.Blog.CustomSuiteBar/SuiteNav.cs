using System.Runtime.Serialization;

namespace Zhukov.Blog.CustomSuiteBar
{
    [DataContract]
    public class SuiteNav
    {
        [DataMember]
        public bool DoNotCache { get; set; }

        [DataMember]
        public SuiteNavBarData NavBarData { get; set; }

        [DataMember]
        public int SPSuiteVersion { get; set; }
    }
}