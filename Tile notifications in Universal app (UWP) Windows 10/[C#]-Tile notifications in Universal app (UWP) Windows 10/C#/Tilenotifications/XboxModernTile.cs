using NotificationsExtensions.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;

namespace Tilenotifications
{
    public static class XboxModernTile
    {
        public static XmlDocument Generate()
        {
            // Small content
            var smallContent = new TileBindingContentAdaptive();


            // Medium content
            

            var mediumContent = new TileBindingContentAdaptive()
            {
                TextStacking = TileTextStacking.Center,

                Children =
                {
                    new TileText()
                    {
                        Text = "Hi,",
                        Style = TileTextStyle.Base,
                        Align = TileTextAlign.Center
                    },

                    new TileText()
                    {
                        Text = "Chourouk",
                        Style = TileTextStyle.CaptionSubtle,
                        Align = TileTextAlign.Center
                    }
                }
            };



            // Wide content
            var wideContent = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new TileGroup()
                    {
                        Children =
                        {
                            new TileSubgroup()
                            {
                                Weight = 33,
                                Children =
                                {
                                    new TileImage()
                                    {
                                        Source = new TileImageSource("http://build2015-tile-polling.azurewebsites.net/assets/hipster.jpg"),
                                        Crop = TileImageCrop.Circle
                                    }
                                }
                            },

                            new TileSubgroup()
                            {
                                TextStacking = TileTextStacking.Center,
                                Children =
                                {
                                    new TileText()
                                    {
                                        Text = "Hi,",
                                        Style = TileTextStyle.Title
                                    },

                                    new TileText()
                                    {
                                        Text = "Chourouk",
                                        Style = TileTextStyle.SubtitleSubtle
                                    }
                                }
                            }
                        }
                    }
                }
            };



            // Large content
            var largeContent = new TileBindingContentAdaptive()
            {
                TextStacking = TileTextStacking.Center,

                Children =
                {
                    new TileGroup()
                    {
                        Children =
                        {
                            // this is for left padding
                            new TileSubgroup() { Weight = 1 },

                            // this is the image itself
                            new TileSubgroup()
                            {
                                Weight = 2,
                                Children =
                                {
                                    new TileImage()
                                    {
                                        Source = new TileImageSource("http://build2015-tile-polling.azurewebsites.net/assets/hipster.jpg"),
                                        Crop = TileImageCrop.Circle
                                    }
                                }
                            },

                            // this is for right padding
                            new TileSubgroup() { Weight = 1 }
                        }
                    },

                    new TileText()
                    {
                        Text = "Hi,",
                        Style = TileTextStyle.Title,
                        Align = TileTextAlign.Center
                    },

                    new TileText()
                    {
                        Text = "Chourouk",
                        Style = TileTextStyle.SubtitleSubtle,
                        Align = TileTextAlign.Center
                    }
                }
            };

            
            


            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    Branding = TileBranding.Name,

                    TileSmall = new TileBinding()
                    {
                        Content = smallContent
                    },

                    TileMedium = new TileBinding()
                    {
                        Content = mediumContent
                    },

                    TileWide = new TileBinding()
                    {
                        Content = wideContent
                    },

                    TileLarge = new TileBinding()
                    {
                        Branding = TileBranding.NameAndLogo,
                        DisplayName = "DX Team",
                        Content = largeContent
                    }
                }
            };

            throw new NotImplementedException();
        }
    }
}
