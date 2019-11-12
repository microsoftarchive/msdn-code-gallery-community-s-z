using System;
using Windows.ApplicationModel;
using Windows.Foundation.Metadata;

namespace WindowsRuntimeComponent
{
    [AllowForWeb]
    public sealed class SharedObject
    {
        public string getApplicationVersion()
        {
            PackageVersion version = Package.Current.Id.Version;
            return String.Format("{0}.{1}.{2}.{3}",
                                 version.Major, version.Minor, version.Build, version.Revision);
        }
    }
}
