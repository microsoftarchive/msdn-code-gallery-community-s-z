using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Security.Server;
using Microsoft.SharePoint.Client;
using System.Linq.Expressions;

namespace LightSwitchApplication
{
    public class PhotoListHelper
    {
        public static void DeletePhoto(string url, ClientContext siteContext)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url");
            if (siteContext == null)
                throw new InvalidOperationException("Could not retrieve the Sharepoint context");

            Web appWeb = siteContext.Web;
            ListCollection webLists = appWeb.Lists;
            List appPicList = webLists.GetByTitle("Photos");
            Folder appPicListFolder = appPicList.RootFolder;
            FileCollection appPicListPictures = appPicListFolder.Files;
            File picture = appPicListPictures.GetByUrl(url);
            siteContext.Load(picture);
            siteContext.ExecuteQuery();

                if (picture != null && picture.Exists)
                {
                    picture.DeleteObject();
                    siteContext.ExecuteQuery();
                }
        }

        public static string AddPhoto(byte[] fileData, string name,  ClientContext siteContext)
        {
            if (fileData == null || fileData.Length <= 0)
                throw new ArgumentNullException("fileData");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if (siteContext == null)
                throw new InvalidOperationException("Could not retrieve the Sharepoint context");
            
            Web appWeb = siteContext.Web;
            ListCollection webLists = appWeb.Lists;
            List appPicList = webLists.GetByTitle("Photos");
            Folder appPicListFolder = appPicList.RootFolder;
            FileCollection appPicListPictures = appPicListFolder.Files;

            FileCreationInformation createPicFileInfo = new FileCreationInformation();
            createPicFileInfo.Content = fileData;
            createPicFileInfo.Url = String.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now) + "_" + name;
            createPicFileInfo.Overwrite = true;

            try
            {
                Microsoft.SharePoint.Client.File file = appPicListPictures.Add(createPicFileInfo);
                siteContext.Load(file);
                siteContext.ExecuteQuery();

                string relativePhotoPathUri = file.ServerRelativeUrl;
                string photoPathUri = new Uri(new Uri(siteContext.Web.Url), relativePhotoPathUri).AbsoluteUri;
                return photoPathUri;
            }
            catch (Exception e)
            {
                // Some browsers do not handle Http errors returned from POST request gracefully (IE, for example),
                // so we're sticking the error message in the result.  
                return @"FAILED::" + e.Message;
            }

        }
    }
}