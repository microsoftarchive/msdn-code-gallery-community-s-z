
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
using System.Collections;
using Android.Provider;
using Java.Util;

namespace SoundCloudAndroid.Resources.Fragments
{
    public class GenreFragment : Fragment
    {
        ListView lst;
        string[] items = new string[] { "Alternative Rock","Classical", "Country","Dance & EDM","Dancehall","Deep House","Disco","Drum & Bass","Electronic","Hip Hop & Rap","Rock","Soundtrack","Techno","Audiobooks","Business"
            ,"Comedy","Entertainment","New Politics","Science","Sports","Storytelling","Technology"};

        public string mData;
        public void Data(string mdata)
        {
            mData = mdata;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.GenreLayout, container, false);
        }
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            //listItems = new List<string> (items);

            lst = View.FindViewById<ListView>(Resource.Id.lstGenres);

            lst.Adapter = new ArrayAdapter<string>(Activity, Resource.Layout.textGenreItems, Resource.Id.textHeaderGenre, items);
            //lst = View.FindViewById<ListView> (Resource.Id.lst_genre);

            //lst.SetAdapter(new ArrayAdapter<String>(this.Activity, Resource.Layout.textGenreItems, items));
            //lst.Adapter=new CustomAdapter(Android.App.Application.Context,items);



            lst.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e) {

                //var intent = new Intent (this, typeof(TracksByGenres));
                //intent.PutStringArrayListExtra ("keys",	items);
                //StartActivity (intent);
                FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction();
                TracksByGenres fragTrack = new TracksByGenres();
                fragTrack.AddData(items[e.Position]);
                //get our item from listview

                fragmentTx.Replace(Resource.Id.fragmentContainer, fragTrack);
                fragmentTx.AddToBackStack(null);
                fragmentTx.Commit();


            };

        }
    }
}