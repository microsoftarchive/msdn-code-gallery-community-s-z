using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.Net;

using System.Threading.Tasks;
using Java.IO;
using System.IO;


namespace DownloadAFile
{
    [Activity(Label = "DownloadAFile", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        TextView textlink;
        ProgressDialog dialog;
        string getname;
        string gettype;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
           
            Button button = FindViewById<Button>(Resource.Id.button1);
            textlink = FindViewById<TextView>(Resource.Id.editText1);
            

            if (!string.IsNullOrEmpty(textlink.Text))
            {
                button.Click += Button_Click;
            }
            

            
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            string[] slipt = textlink.Text.Split('/');

            string[] getitem = slipt[slipt.Length-1].Split('.');
            getname = getitem[0];
            gettype = getitem[1];
            //throw new NotImplementedException();
            var webClient = new WebClient();
            var url = new Uri(textlink.Text);
            byte[] bytes = null;


            webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            dialog = new ProgressDialog(this);
            dialog.SetProgressStyle(ProgressDialogStyle.Horizontal);
            dialog.SetTitle("Downloading...");
            dialog.SetCancelable(false);
            //dialog.SetButton("Cancel",);
            dialog.SetCanceledOnTouchOutside(false);
            dialog.Show();

            try
            {
                bytes = await webClient.DownloadDataTaskAsync(url);
            }
            catch (TaskCanceledException)
            {
                Toast.MakeText(this, "Task Canceled!", ToastLength.Long).Show();
                return;
            }
            catch (Exception a)
            {
                Toast.MakeText(this, a.InnerException.Message, ToastLength.Long).Show();
                dialog.Progress = 0;
                return;
            }

            //Java.IO.File documentsPath= new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMusic),"MusicDownloaded");
            // The derection: Device storage -> Download-> all files be save in here
            var documentsPath = Android.OS.Environment.ExternalStorageDirectory + "/Download";
            string localFilename = getname + "."+gettype;
            string localPath = System.IO.Path.Combine(documentsPath, localFilename);
            //Java.IO.File localPath=new Java.IO.File(documentsPath,localFilename);

            dialog.SetTitle("Download Complete");

            //Save the Mp3 using writeAsync
            FileStream fs = new FileStream(localPath, FileMode.OpenOrCreate);
            //OutputStream fs=new FileOutputStream(localPath);
            await fs.WriteAsync(bytes, 0, bytes.Length);

            fs.Close();


            dialog.Progress = 0;
        }

        void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            dialog.Progress = e.ProgressPercentage;
            if (e.ProgressPercentage == 100)
            {
                dialog.Hide();
            }
        }
    }
    
}

