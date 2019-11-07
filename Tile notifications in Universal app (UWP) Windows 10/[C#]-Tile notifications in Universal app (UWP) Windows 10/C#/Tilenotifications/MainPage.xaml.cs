using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NotificationsExtensions;
using Windows.UI;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;
using NotificationsExtensions.Tiles;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tilenotifications
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ButtonCirclePeek_Click(object sender, RoutedEventArgs e)
        {
            UpdateMedium(new TileBindingContentAdaptive()
            {
                PeekImage = new TilePeekImage()
                {
                    Source = new TileImageSource("https://z-1-scontent.xx.fbcdn.net/hphotos-xft1/v/t1.0-9/11403002_940729265987495_1202353898144621920_n.jpg?oh=9f5714fa5bc9babb1e0702646b21c0f0&oe=5745BE22"),

                    Crop = TileImageCrop.Circle
                },

                Children =
                {
                    new TileText()
                    {
                        Text = "Chourouk hopes that you rate this sample if you find it useful. :)",
                        Wrap = true
                    }
                }
            });
        }

        private async void UpdateMedium(TileBindingContentAdaptive mediumContent)
        {
       TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = mediumContent
                    }
                }
            };

            try
            {
                TileUpdateManager.CreateTileUpdaterForSecondaryTile("SecondaryTile").Update(new TileNotification(content.GetXml()));
            }

            catch
            {
                SecondaryTile tile = new SecondaryTile("SecondaryTile", "Example", "args", new Uri("ms-appx:///Assets/Logo.png"), TileSize.Default);
                tile.VisualElements.ShowNameOnSquare150x150Logo = true;
                tile.VisualElements.ShowNameOnSquare310x310Logo = true;
                tile.VisualElements.ShowNameOnWide310x150Logo = true;
                tile.VisualElements.BackgroundColor = Colors.Transparent;
                await tile.RequestCreateAsync();

                TileUpdateManager.CreateTileUpdaterForSecondaryTile("SecondaryTile").Update(new TileNotification(content.GetXml()));
            }
        }

        private void ButtonPeekAndBackground_Click(object sender, RoutedEventArgs e)
        {
            UpdateMedium(new TileBindingContentAdaptive()
            {
                PeekImage = new TilePeekImage()
                {
                    Source = new TileImageSource("https://z-1-scontent.xx.fbcdn.net/hphotos-xap1/v/t1.0-9/579406_433362536724173_1833812136_n.jpg?oh=6717b5255248cffa62063ae13d9376b5&oe=570A5861"),
                    Crop = TileImageCrop.Circle
                },

                BackgroundImage = new TileBackgroundImage()
                {
                    Source = new TileImageSource("https://z-1-scontent.xx.fbcdn.net/hphotos-xpt1/v/t1.0-9/11111880_927158810677874_8273846010501107760_n.jpg?oh=897c2fd71e1c2b0e938fe10f04228235&oe=571687AD")
                },

                Children =
                {
                    new TileText()
                    {
                        Text = "Chourouk updated her profile picture.",
                        Wrap = true
                    }
                }
            });
        }

       
    }
}
