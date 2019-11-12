using System.Runtime.Serialization;

namespace Zhukov.Blog.CustomSuiteBar
{
    [DataContract]
    public class SuiteNavLink
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Url { get; set; }

        public SuiteNavLink(string id = null, string text = null, string title = null, string url = null)
        {
            Id = id;
            Text = text;
            Title = title;
            Url = url;
        }
    }
}