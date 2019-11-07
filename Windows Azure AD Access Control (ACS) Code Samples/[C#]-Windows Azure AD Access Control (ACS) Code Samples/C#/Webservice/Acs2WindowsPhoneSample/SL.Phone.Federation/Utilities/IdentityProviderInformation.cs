//---------------------------------------------------------------------------------
// Copyright 2010 Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License"); 
// You may not use this file except in compliance with the License. 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, 
// INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR 
// CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, 
// MERCHANTABLITY OR NON-INFRINGEMENT. 

// See the Apache 2 License for the specific language governing 
// permissions and limitations under the License.
//---------------------------------------------------------------------------------


using System;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;

namespace SL.Phone.Federation.Utilities
{
    /// <summary>
    /// DataContract for IdentityProviderInformation returned by the Identity Provider Discover Service
    /// </summary>
    [DataContract]
    public class IdentityProviderInformation
    {
        private BitmapImage _image;

        /// <summary>
        /// The display name for the identity provider.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The url used for Login to the identity provider.
        /// </summary>
        [DataMember]
        public string LoginUrl { get; set; }

        /// <summary>
        /// The url that is used to retrieve the image for the identity provider
        /// </summary>
        [DataMember]
        public string ImageUrl { get; set; }

        /// <summary>
        /// A list fo email address suffixes configured for the identity provider.
        /// </summary>
        [DataMember]
        public string[] EmailAddressSuffixes { get; set; }

        /// <summary>
        /// The image populated by calling LoadImageFromImageUrl
        /// </summary>
        public BitmapImage Image
        {
            get
            {
                return _image;
            }
        }

        /// <summary>
        /// Retieves the image from ImageUrl
        /// </summary>
        /// <returns>The image from the url as a BitmapImage</returns>
        public BitmapImage LoadImageFromImageUrl()
        {
            _image = null;

            if (string.Empty != ImageUrl)
            {
                BitmapImage imageBitmap = new BitmapImage();
                Uri imageUrlUri = new Uri(ImageUrl);
                imageBitmap.UriSource = imageUrlUri;
                _image = imageBitmap;
            }

            return _image;
        }
    }
}
