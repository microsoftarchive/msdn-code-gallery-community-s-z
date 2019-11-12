
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
using FFImageLoading.Views;
using FFImageLoading;
using Android.Support.Design.Widget;
using SoundCloudAndroid.Resources.Model;

namespace SoundCloudAndroid.Resources.Fragments
{
    public class TracksByGenres : Fragment
    {
        ListView lst = null;
        JsonConverter json = new JsonConverter();
        int offset = 0;

        public string mData;
        public void AddData(string mdata)
        {
            mData = mdata.ToLower().Replace(" ", "").Replace("&", "");
        }
        public int mPosition;
        AudioPlayerActivity audioPlayer = new AudioPlayerActivity();
        TrackAdapter tAdapter;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return inflater.Inflate(Resource.Layout.TracksBYGenreLayout, container, false);
        }

       

        TrackModel.RootObject items;

        public async override void OnActivityCreated(Bundle savedInstancesState)
        {
            base.OnActivityCreated(savedInstancesState);

            //activity = this.Activity;
            //ActionBar actionBar = activity.ActionBar;

            //activity.ActionBar.SetHomeAsUpIndicator (Resource.Drawable.ic_arrow_back_white_24dp);
            //activity.ActionBar.SetHomeButtonEnabled (FragmentManager.BackStackEntryCount>0);
            //activity.ActionBar.Title ="";
            /*
			genreFragment = new GenreFragment ();
			TracksByGenres tracksbynews = new TracksByGenres ();
			//Get data from GenreFragment.cs
			tracksbynews.AddData(genreFragment.mData);
			*/
            // Find id of listview
            lst = View.FindViewById<ListView>(Resource.Id.lsttrack);


            //Get data by json

            var result = await json.GetStringbyJson("https://api-v2.soundcloud.com/charts?kind=top&genre=soundcloud%3Agenres%3A" + mData + "&limit=20&client_id=9ac2b17027e4af068adbb4f10330e1b3&app_version=1462873750&offset=" + offset);
            if (result != null)
            {
                items = Newtonsoft.Json.JsonConvert.DeserializeObject<TrackModel.RootObject>(result);
                tAdapter = new TrackAdapter(Activity, items.collection);
                lst.Adapter = tAdapter;
            }

            //Check the last of item of listview and show more data.

            lst.ScrollStateChanged += (object sender, AbsListView.ScrollStateChangedEventArgs e) =>
            {
                int lastItem = lst.LastVisiblePosition;

                int adapterCount = lst.Count - 1;

                if (lastItem >= adapterCount)
                {
                    offset += 25;
                    loadMoreData(offset);

                }

            };




            lst.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e) {
                /*
				FragmentTransaction fragTransaction = this.FragmentManager.BeginTransaction ();
				AudioPlayer audio = new AudioPlayer ();
				audio.AddArrayData(items.tracks,e.Position);
				fragTransaction.Replace(Resource.Id.fragmentContainer,audio);
				fragTransaction.AddToBackStack(null);
				fragTransaction.Commit();
				*/
                var data = new Intent(this.Activity, typeof(AudioPlayerActivity));

                if (audioPlayer.mListData.Count == 0)
                {
                    var adapter = lst.Adapter as TrackAdapter;
                    var track = Newtonsoft.Json.JsonConvert.SerializeObject(adapter._tracks);

                    data.PutExtra("listdata", track);
                    data.PutExtra("position", e.Position.ToString()).ToString();

                }
                else
                {
                    data.PutExtra("position", e.Position.ToString()).ToString();

                }


                StartActivity(data);

            };
        }


        public async void loadMoreData(int off)
        {
            var result = await json.GetStringbyJson("https://api-v2.soundcloud.com/charts?kind=top&genre=soundcloud%3Agenres%3A" + mData + "&limit=20&client_id=9ac2b17027e4af068adbb4f10330e1b3&app_version=1462873750&offset=" + off);
            if (result != null)
            {
                items = Newtonsoft.Json.JsonConvert.DeserializeObject<TrackModel.RootObject>(result);
                //tAdapter = new TrackAdapter (this.Activity,items.tracks);
                if (items.collection != null)
                {
                    var adapter = lst.Adapter as TrackAdapter;
                    adapter._tracks.AddRange(items.collection);
                    Toast.MakeText(Application.Context, "Loaded more tracks", ToastLength.Long).Show();
                    lst.Adapter = adapter;
                    tAdapter.NotifyDataSetChanged();

                }


                //lst.Adapter = new TrackAdapter (Activity, items.tracks);
            }
        }

        public class TrackAdapter : BaseAdapter<TrackModel.Collection>
        {
            LayoutInflater _inflater;
            public List<TrackModel.Collection> _tracks { get; set; }

            public TrackAdapter(Context context, List<TrackModel.Collection> tracks)//, List<TrackModel.Track> tracks
            {
                _inflater = LayoutInflater.FromContext(context);
                _tracks = tracks;
            }


            public override TrackModel.Collection this[int index]
            {
                get { return _tracks[index]; }
            }

            public override int Count
            {
                get { return _tracks.Count; }
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                View view = convertView ?? _inflater.Inflate(Resource.Layout.textViewItems, parent, false);

                var item = _tracks[position];
                var viewHolder = view.Tag as TrackViewHolder;
                if (viewHolder == null)
                {
                    viewHolder = new TrackViewHolder();
                    viewHolder.Title = view.FindViewById<TextView>(Resource.Id.textviewItems);
                    viewHolder.SubTitle = view.FindViewById<TextView>(Resource.Id.textviewSubItem);
                    viewHolder.Image = view.FindViewById<ImageViewAsync>(Resource.Id.image);
                    viewHolder.ImgIcon = view.FindViewById<ImageView>(Resource.Id.imgIconPlay);
                    viewHolder.PlayingCount = view.FindViewById<TextView>(Resource.Id.textviewPlayingCount);
                    view.Tag = viewHolder;
                }
                else
                    viewHolder = view.Tag as TrackViewHolder;

                viewHolder.Title.Text = item.track.title;
                viewHolder.PlayingCount.Text = item.track.playback_count.ToString();
                viewHolder.ImgIcon.SetImageResource(Resource.Drawable.HeadsetFilled);

                if (!string.IsNullOrEmpty(item.track.user.full_name))
                {
                    viewHolder.SubTitle.Text = item.track.user.full_name;
                }
                else
                {
                    viewHolder.SubTitle.Text = "Unknown";
                }

                //Android.Net.Uri uri = Android.Net.Uri.Parse ("/Resources/drawable/soundcloud.png");
                //Bitmap bitmap=GetBitmapFromUrl(track.artwork_url);
                if (item.track.artwork_url != null)
                {
                    ImageService.Instance.LoadUrl(item.track.artwork_url)

                        .Retry(5, 200)
                        .Into(viewHolder.Image);
                }
                else
                {
                    ImageService.Instance.LoadUrl("http://a4.mzstatic.com/us/r30/Purple49/v4/4c/ca/2b/4cca2bb3-8180-5c28-6632-a4d9cde8752c/icon100x100.png")

                        .Retry(5, 200)
                        .Into(viewHolder.Image);
                }

                return view;
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