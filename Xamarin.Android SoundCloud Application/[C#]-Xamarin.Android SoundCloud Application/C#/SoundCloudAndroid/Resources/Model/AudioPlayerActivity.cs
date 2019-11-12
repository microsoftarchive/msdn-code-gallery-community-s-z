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
using FFImageLoading;
using FFImageLoading.Views;
using Android.Media;
using Android.Graphics;
using System.Timers;
using System.Net;

using System.Threading.Tasks;
using Java.IO;
using System.IO;
namespace SoundCloudAndroid.Resources.Model
{
    [Activity(Label = "AudioPlayerActivity")]
    public class AudioPlayerActivity : Activity
    {
        public List<TrackModel.Collection> mListData = new List<TrackModel.Collection>();
        int mPosition;
        string stream_url_soundcloud;
        string clienId = "9ac2b17027e4af068adbb4f10330e1b3";
        //TracksByGenres trackbyGenres;
        //ExploreFragment explorer;
        //AudioPlayer audioPlayer;
        bool Isrepeat = false;
        ImageButton imgPlayorPause;
        ImageButton imgNext;
        ImageButton imgPrevious;
        ImageButton imgRepeat;
        ImageButton imgDownload;

        ImageViewAsync imgThumbail;
        TextView txtTitle;
        TextView txtSubTitle;
        //TextView txtCurrentTimer;
        //TextView txtTotalTimer;

        MediaPlayer player;
        SeekBar seekBar;
        Timer timer;
        // Utilities utils=new Utilities();
        ProgressDialog dialog;
        JsonConverter json = new JsonConverter();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.PlayerLayout);
            //Get data from Tracksbygenres and explorer
            if (mListData.Count == 0)
            {
                mListData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TrackModel.Collection>>(Intent.GetStringExtra("listdata"));
                mPosition = int.Parse(Intent.GetStringExtra("position"));
            }
            else
            {
                mPosition = int.Parse(Intent.GetStringExtra("position"));
            }

            //mListData = Intent.GetStringExtra ("listdata");

            //Checking Title



            //Media
            player = new MediaPlayer();
            player.Stop();


            // Create your application here
            imgPlayorPause = FindViewById<ImageButton>(Resource.Id.imgPlayorPausePlayer);
            imgNext = FindViewById<ImageButton>(Resource.Id.imgNextPlayer);
            imgPrevious = FindViewById<ImageButton>(Resource.Id.imgPreviousPlayer);
            imgThumbail = FindViewById<ImageViewAsync>(Resource.Id.imgThumbail);
            imgDownload = FindViewById<ImageButton>(Resource.Id.imgDownloadPlayer);
            imgRepeat = FindViewById<ImageButton>(Resource.Id.imgRepeatPlayer);

            txtTitle = FindViewById<TextView>(Resource.Id.textTitlePlayer);
            txtSubTitle = FindViewById<TextView>(Resource.Id.textSubTitlePlayer);
            //txtPlayCount = View.FindViewById<TextView> (Resource.Id.textOther);
            //imgThumbail = View.FindViewById<ImageViewAsync> (Resource.Id.imagePlayer);
            //imgPlayingCount = View.FindViewById<ImageView> (Resource.Id.imgIconPlayingCount);
            //Setting
            imgNext.SetImageResource(Resource.Drawable.ic_skip_next_black_36dp);
            imgPlayorPause.SetImageResource(Resource.Drawable.ic_play_arrow_black_36dp);
            imgPrevious.SetImageResource(Resource.Drawable.ic_skip_previous_black_36dp);
            imgDownload.SetImageResource(Resource.Drawable.ic_vertical_align_bottom_black_24dp);
            imgRepeat.SetImageResource(Resource.Drawable.ic_repeat_black_24dp);

            seekBar = FindViewById<SeekBar>(Resource.Id.seekBar);
            //player = View.FindViewById<MediaController> (Resource.Id.mediaControler);
            //
            //Play and Pause Event



            Getstream_url(mListData[mPosition].track.uri + "?client_id=" + clienId);

            seekBar.StartTrackingTouch += (object sender, SeekBar.StartTrackingTouchEventArgs e) =>
            {
                timer.Enabled = false;
            };
            seekBar.StopTrackingTouch += (object sender, SeekBar.StopTrackingTouchEventArgs e) => {
                timer.Enabled = true;
                player.SeekTo(e.SeekBar.Progress);
            };


            imgPlayorPause.Click += delegate (object sender, EventArgs e) {
                PlayorPauseMedia(player);
            };


            /////////////////////////////////////////////******************************************////////////////////////////////
            //Next item event
            imgNext.Click += delegate (object sender, EventArgs e) {
                NextTracks(mPosition);
            };

            //Previous item event
            imgPrevious.Click += delegate (object sender, EventArgs e) {
                PreviousTrack(mPosition);
            };

            //Download event
            imgDownload.Click += ImgDownload_Click;

            //repeat event
            imgRepeat.Click += delegate (object sender, EventArgs e) {
                if (Isrepeat == false)
                {
                    Isrepeat = true;

                }
                else
                {
                    Isrepeat = false;
                }
                Repeat(Isrepeat);
            };
        }

        async void ImgDownload_Click(object sender, EventArgs e)
        {
            var webClient = new WebClient();
            var url = new Uri(stream_url_soundcloud);
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
            string localFilename = mListData[mPosition].track.title + ".mp3";
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
        /*
		private void download()
		{
			var webClient = new WebClient ();
			webClient.DownloadDataCompleted+=  (object sender, DownloadDataCompletedEventArgs e)  => 
			{
				var bytes=e.Result;
				string documentsPath=System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
				string localFilename=mListData[mPosition].track.title+".png";
				string localPath=System.IO.Path.Combine(documentsPath,localFilename);
				File.WriteAllBytes(localPath,bytes);

			};

			var url = new Uri (mListData[mPosition].track.artwork_url);
			webClient.DownloadDataAsync (url);	


			ProgressDialog dialog=new ProgressDialog(this);
			dialog.SetProgressStyle(ProgressDialogStyle.Horizontal);
			dialog.SetTitle(mListData[mPosition].track.title);
			dialog.Progress = 50;
			dialog.Show();
		}
*/


        public void UpdateProcessBar()
        {
            timer = new Timer();
            timer.Interval = 100;
            timer.Enabled = true;

            timer.Elapsed += (object sender, ElapsedEventArgs e) => {
                seekBar.Progress = player.CurrentPosition;
                seekBar.Max = player.Duration;


            };
        }

        public void Load_Data()
        {
            if (!string.IsNullOrEmpty(mListData[mPosition].track.title))
            {
                txtTitle.Text = mListData[mPosition].track.title;
            }
            else
            {
                txtTitle.Text = "Unknown";
            }

            //Checking SubTitle
            if (!string.IsNullOrEmpty(mListData[mPosition].track.user.full_name))
            {
                txtSubTitle.Text = mListData[mPosition].track.user.full_name;
            }
            else
            {
                txtSubTitle.Text = "Unknown";
            }


            //Checking Thumbnail
            if (mListData[mPosition].track.artwork_url != null)
            {
                string replace_img = mListData[mPosition].track.artwork_url.Replace("large", "t500x500");
                ImageService.Instance.LoadUrl(replace_img)

                    .Retry(5, 200)
                    .Into(imgThumbail);
            }
            else
            {
                ImageService.Instance.LoadUrl("http://www.etag.ee/wp-content/plugins/ajax-search-lite/img/default.jpg")

                    .Retry(5, 200)
                    .Into(imgThumbail);
            }


        }




        public void StartMedia(string url_string)
        {

            Load_Data();
            seekBar.Max = player.Duration;
            player.Reset();

            try
            {
                player.SetAudioStreamType(Android.Media.Stream.Music);
                player.SetDataSource(url_string);
                player.PrepareAsync();
            }
            catch (Exception e)
            {
                Toast.MakeText(Application.Context, e.InnerException.Message, ToastLength.Long).Show();

            }
            player.Prepared += (object sender, EventArgs e) =>
            {
                player.Start();
            };
            //player.SetOnPreparedListener(player.Pause());
            //player.Start ();
            imgPlayorPause.SetImageResource(Resource.Drawable.ic_pause_black_36dp);
            //UpdatedTimerTask ();
            UpdateProcessBar();


        }


        public void PlayorPauseMedia(MediaPlayer mMedia)
        {
            if (mMedia.IsPlaying == true)
            {
                //mMedia.Prepare ();
                mMedia.Pause();
                imgPlayorPause.SetImageResource(Resource.Drawable.ic_play_arrow_black_36dp);
            }
            else
            {
                //mMedia.Prepare ();
                mMedia.Start();
                imgPlayorPause.SetImageResource(Resource.Drawable.ic_pause_black_36dp);
            }
        }

        public void NextTracks(int positon)
        {

            //player = new MediaPlayer ();
            if (Isrepeat == false)
            {
                if (positon >= mListData.Count - 1)
                {
                    mPosition = 1;
                }
                else
                {
                    mPosition++;

                }
            }
            else
            {
                mPosition = positon;
            }



            //StartMedia(mListData [mPosition].track.uri+ "?client_id=" + clienId);
            Getstream_url(mListData[mPosition].track.uri + "?client_id=" + clienId);
        }


        //Get stream_url from track.uri
        private async void Getstream_url(string url)
        {
            var result = await json.GetStringbyJson(url);
            if (result != null)
            {
                var item = Newtonsoft.Json.JsonConvert.DeserializeObject<StreamUrl.RootObject>(result);
                if (item.stream_url != null)
                {
                    stream_url_soundcloud = item.stream_url + "?client_id=" + clienId;
                    StartMedia(item.stream_url + "?client_id=" + clienId);
                }
                else
                {

                }
            }
        }

        public void PreviousTrack(int position)
        {
            //player = null;
            if (Isrepeat == false)
            {
                if (position == 0)
                {
                    mPosition = 1;

                }
                else
                {
                    mPosition--;
                }
            }
            else
            {
                mPosition = position;
            }


            //Getstream_url(mListData [mPosition].track.uri+ "?client_id=" + clienId);
            Getstream_url(mListData[mPosition].track.uri + "?client_id=" + clienId);
        }


        public void Repeat(bool rep)
        {
            if (rep != false)
            {
                imgRepeat.SetColorFilter(Color.ParseColor("#AB47BC"));

            }
            else
            {
                imgRepeat.SetColorFilter(Color.ParseColor("#757575"));
            }
        }


        public class TrackViewHolder : Java.Lang.Object
        {
            public TextView Title { get; set; }
            public TextView SubTitle { get; set; }
            public ImageViewAsync Image { get; set; }
            public ImageView ImgIcon { get; set; }
            public TextView PlayingCount { get; set; }
        }
    }
}