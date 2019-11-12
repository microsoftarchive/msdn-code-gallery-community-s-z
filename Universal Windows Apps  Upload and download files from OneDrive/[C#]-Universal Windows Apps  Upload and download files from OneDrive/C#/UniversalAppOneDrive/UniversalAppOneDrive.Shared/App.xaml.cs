using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using UniversalAppOneDrive.Common;
using System.Threading.Tasks;
using Microsoft.Live;
using Windows.Storage;
using System.Runtime.Serialization;

// The Universal Hub Application project template is documented at http://go.microsoft.com/fwlink/?LinkID=391955

namespace UniversalAppOneDrive
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : Application
    {
#if WINDOWS_PHONE_APP
        private TransitionCollection transitions;
#endif

        /// <summary>
        /// Initializes the singleton instance of the <see cref="App"/> class. This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif
            int r = await UploadFileToOneDrive();
            if( r== 1)
            {
                await DownloadFileFromOneDrive();
            }

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                //Associate the frame with a SuspensionManager key                                
                SuspensionManager.RegisterFrame(rootFrame, "AppFrame");

                // TODO: change this value to a cache size that is appropriate for your application
                rootFrame.CacheSize = 1;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // Restore the saved session state only when appropriate
                    try
                    {
                        await SuspensionManager.RestoreAsync();
                    }
                    catch (SuspensionManagerException)
                    {
                        // Something went wrong restoring state.
                        // Assume there is no state and continue
                    }
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
#if WINDOWS_PHONE_APP
                // Removes the turnstile navigation for startup.
                if (rootFrame.ContentTransitions != null)
                {
                    this.transitions = new TransitionCollection();
                    foreach (var c in rootFrame.ContentTransitions)
                    {
                        this.transitions.Add(c);
                    }
                }

                rootFrame.ContentTransitions = null;
                rootFrame.Navigated += this.RootFrame_FirstNavigated;
#endif

                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(HubPage), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

#if WINDOWS_PHONE_APP
        /// <summary>
        /// Restores the content transitions after the app has launched.
        /// </summary>
        /// <param name="sender">The object where the handler is attached.</param>
        /// <param name="e">Details about the navigation event.</param>
        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            rootFrame.Navigated -= this.RootFrame_FirstNavigated;
        }
#endif

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await SuspensionManager.SaveAsync();
            deferral.Complete();
        }

        LiveConnectClient liveClient;
        private async Task<int> UploadFileToOneDrive()
        {
            try
            {
                //  create OneDrive auth client
                var authClient = new LiveAuthClient();
                
                //  ask for both read and write access to the OneDrive
                LiveLoginResult result = await authClient.LoginAsync(new string[] { "wl.skydrive", "wl.skydrive_update" });
                
                //  if login successful 
                if (result.Status == LiveConnectSessionStatus.Connected)
                {
                    //  create a OneDrive client
                    liveClient = new LiveConnectClient(result.Session);
                    
                    //  create a local file
                    StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("filename", CreationCollisionOption.ReplaceExisting);

                    //  copy some txt to local file
                    MemoryStream ms = new MemoryStream();
                    DataContractSerializer serializer = new DataContractSerializer(typeof(string));
                    serializer.WriteObject(ms, "Hello OneDrive World!!");

                    using (Stream fileStream = await file.OpenStreamForWriteAsync())
                    {
                        ms.Seek(0, SeekOrigin.Begin);
                        await ms.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();
                    }

                    //  create a folder
                    string folderID = await GetFolderID("folderone");

                    if (string.IsNullOrEmpty(folderID))
                    {
                        //  return error
                        return 0;
                    }

                    //  upload local file to OneDrive
                    await liveClient.BackgroundUploadAsync(folderID, file.Name, file, OverwriteOption.Overwrite);
                    
                    return 1;
                }
            }
            catch
            {
            }
            //  return error
            return 0;
        }

        public async Task<string> GetFolderID(string folderName)
        {
            try
            {
                string queryString = "me/skydrive" + "/files?filter=folders";
                //  get all folders
                LiveOperationResult loResults = await liveClient.GetAsync(queryString);
                dynamic folders = loResults.Result;

                foreach (dynamic folder in folders.data)
                {
                    if (string.Compare(folder.name, folderName, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        //  found our folder
                        return folder.id;
                    }
                }

                //  folder not found

                //  create folder
                Dictionary<string, object> folderDetails = new Dictionary<string, object>();
                folderDetails.Add("name", folderName);
                loResults = await liveClient.PostAsync("me/skydrive", folderDetails);
                folders = loResults.Result;

                // return folder id
                return folders.id;
            }
            catch
            {
                return string.Empty;
            }
        }

        public async Task<int> DownloadFileFromOneDrive()
        {
            try
            {
                string fileID = string.Empty;

                //  get folder ID
                string folderID = await GetFolderID("folderone");

                if (string.IsNullOrEmpty(folderID))
                {
                    return 0; // doesnt exists
                }

                //  get list of files in this folder
                LiveOperationResult loResults = await liveClient.GetAsync(folderID + "/files");
                List<object> folder = loResults.Result["data"] as List<object>;

                //  search for our file 
                foreach (object fileDetails in folder)
                {
                    IDictionary<string, object> file = fileDetails as IDictionary<string, object>;
                    if (string.Compare(file["name"].ToString(), "filename", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        //  found our file
                        fileID = file["id"].ToString();
                        break;
                    }
                }

                if (string.IsNullOrEmpty(fileID))
                {
                    //  file doesnt exists
                    return 0;
                }

                //  create local file
                StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("filename_from_onedrive", CreationCollisionOption.ReplaceExisting);

                //  download file from OneDrive
                await liveClient.BackgroundDownloadAsync(fileID + "/content", localFile);

                return 1;
            }
            catch
            {
            }
            return 0;
        }
    }
}