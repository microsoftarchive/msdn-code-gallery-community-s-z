using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace FreeTunes
{
    class AssociationUriMapper : UriMapperBase
    {
        // Format coming in "freetunes:uri=http://cdn.marshill.com/files/2012/05/08/20120508_oh-god_by_citizens_audio.mp3&title=Oh God&artist=Citizens"
        private string tempUri;
        private static string AssociationUri = "freetunes:uri=";

        public override Uri MapUri(Uri uri)
        {
            tempUri = System.Net.HttpUtility.UrlDecode(uri.ToString());

            // URI association launch for for the app; parse out the URL, song name & title
            if (tempUri.Contains(AssociationUri))
            {
                int categoryIdIndex = tempUri.IndexOf(AssociationUri) + AssociationUri.Length;
                string photoUri = tempUri.Substring(categoryIdIndex);

                // Map the show products request to ShowProducts.xaml
                return new Uri("/MainPage.xaml?DataUri=" + photoUri, UriKind.Relative);
            }

            // Otherwise perform normal launch.
            return uri;
        }
    }

}
