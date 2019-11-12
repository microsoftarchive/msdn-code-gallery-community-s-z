
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using FFImageLoading.Views;
using FFImageLoading;
using SoundCloudAndroid.Resources.Model;

namespace SoundCloudAndroid.Resources.Fragments
{
    public class AudioFragment : Fragment
    {
        JsonConverter json = new JsonConverter();
        AudioPlayerActivity audioPlayer = new AudioPlayerActivity();
        public List<TrackModel.Track> mListData;
        public int mPosition;
        int offset = 0;
        TrackModel.RootObject items;
        ListView lst;
        string id_checkbox = "top";
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetHasOptionsMenu(true);
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.AudioLayout, container, false);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            lst = View.FindViewById<ListView>(Resource.Id.lstAudio);

            LoadingByFilter(id_checkbox, "normal");

            lst.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e) {
                /*
				FragmentTransaction fragTransaction= this.FragmentManager.BeginTransaction();
				AudioPlayer audio=new AudioPlayer();
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
            lst.ScrollStateChanged += (object sender, AbsListView.ScrollStateChangedEventArgs e) =>
            {
                var lastitem = lst.LastVisiblePosition;
                var adapterCount = lst.Count - 1;
                if (lastitem >= adapterCount)
                {
                    offset += 25;
                    LoadingByFilter(id_checkbox, "moreItem");
                }
            };
        }


        public class TrackAdapter : BaseAdapter<TrackModel.Collection>
        {
            LayoutInflater _inflater;

            public List<TrackModel.Collection> _tracks { get; set; }

            public TrackAdapter(Context context, List<TrackModel.Collection> tracks)
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
                    viewHolder = (TrackViewHolder)view.Tag as TrackViewHolder;

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

        private async void LoadingByFilter(string filter, string id_string)
        {
            var result = await json.GetStringbyJson("https://api-v2.soundcloud.com/charts?kind=" + filter + "&genre=soundcloud%3Agenres%3Aall-audio&limit=25&client_id=9ac2b17027e4af068adbb4f10330e1b3&offset=" + offset);


            if (result != "")
            {
                items = Newtonsoft.Json.JsonConvert.DeserializeObject<TrackModel.RootObject>(result);
                if (items.collection != null || items.collection.Count == 0)
                {
                    if (id_string == "normal")
                    {


                        lst.Adapter = new TrackAdapter(Activity, items.collection);


                    }
                    else if (id_string == "moreItem")
                    {
                        var adapter = lst.Adapter as TrackAdapter;
                        adapter._tracks.AddRange(items.collection);
                        Toast.MakeText(Application.Context, "Loaded more tracks", ToastLength.Long).Show();
                        lst.Adapter = adapter;
                        adapter.NotifyDataSetChanged();
                    }

                }

                //Track.AddRange (items.tracks);
                //AddTrack(items.tracks);
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem menu)
        {
            menu.SetChecked(true);
            switch (menu.ItemId)
            {

                case Resource.Id.selecta:
                    id_checkbox = "top";
                    LoadingByFilter("top", "normal");
                    Toast.MakeText(Application.Context, "Top 50", ToastLength.Long).Show();

                    return true;
                case Resource.Id.selectb:
                    id_checkbox = "trending";
                    LoadingByFilter("trending", "normal");
                    Toast.MakeText(Application.Context, "New & Hot", ToastLength.Long).Show();

                    return true;
            }
            return base.OnOptionsItemSelected(menu);

        }
        public override void OnCreateOptionsMenu(Android.Views.IMenu menu, MenuInflater inflater)
        {
            //MenuInflater.Inflate (Resource.Menu.Action_menu, menu);
            //menu.Clear();
            inflater.Inflate(Resource.Menu.Action_menu, menu);

            base.OnCreateOptionsMenu(menu, inflater);
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