using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Views;
using SoundCloudAndroid.Resources.Fragments;
using SoundCloudAndroid.Resources.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Auth;

namespace SoundCloudAndroid
{
    [Activity(Label = "SoundCloudAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        ExploreFragment explorFragment;
        GenreFragment genreFragment;
        AudioFragment audioFragment;
        //TracksByGenres tracksByGenres;

        //AudioFragment audioFragment;
        //int currentFragmentId=Resource.Id.nav_home;
        OAuth2Authenticator auth;


        JsonConverter json = new JsonConverter();
        TextView txtUsername;
        TextView txtLastmodifier;
        ImageViewAsync imgThunbailUsername;
        bool isOauth = false;
        public string token;
        public void addAccessToken(string _token)
        {
            token = _token;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            var headview = navigationView.GetHeaderView(0);
            txtUsername = headview.FindViewById<TextView>(Resource.Id.txtUsername);
            txtLastmodifier = headview.FindViewById<TextView>(Resource.Id.txtlast_modified);
            imgThunbailUsername = headview.FindViewById<ImageViewAsync>(Resource.Id.imgThunbailUser);
            // Login


            //OAuth ();




            var mToolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            mToolbar.Title = "Home";

            //Toolbar will now take on default action bar chacracteritics
            SetActionBar(mToolbar);
            //ActionBar.Title = "home";


            //Enable suppport action bar to display hamburger
            //ActionBar.SetHomeAsUpIndicator(Resource.Drawable.icon_hambuger);
            //ActionBar.SetDisplayHomeAsUpEnabled (true);

            //Set menu hambuger
            ActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu_white_24dp);

            ActionBar.SetDisplayHomeAsUpEnabled(true);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            //Event click on navigatonView
            // 
            CreateFragments();
            LoadInditialFragment();

            navigationView.SetCheckedItem(Resource.Id.nav_music);
            SwitchFragment(Resource.Id.nav_music);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;


            FragmentManager.BackStackChanged += Fragmanager_BackStackChanged;

        }

        public void OAuth()
        {
            auth = new OAuth2Authenticator(
            clientId: "9ac2b17027e4af068adbb4f10330e1b3",
            clientSecret: "3b6ed5b61cd7c3df17c1a339fb8904ea",
            scope: "",
            authorizeUrl: new Uri("https://soundcloud.com/connect"),
            redirectUrl: new Uri("https://mysoundclou.com/callback"),
            accessTokenUrl: new Uri("https://api.soundcloud.com/oauth2/token"),
            getUsernameAsync: null);
            StartActivity(auth.GetUI(this));

            auth.Completed += (object sender, AuthenticatorCompletedEventArgs e) =>
            {
                if (e.IsAuthenticated)
                {
                    isOauth = true;
                    addAccessToken(e.Account.Properties["access_token"]);
                    AccountInformation(token);
                    var bodyview = navigationView.Menu;
                    var text = bodyview.FindItem(Resource.Id.nav_signout);

                    text.SetTitle("Sign Out");
                }
                else
                {
                    Toast.MakeText(this, "Fail...", ToastLength.Long).Show();
                }
            };


        }
        private async void AccountInformation(string token)
        {

            var result = await json.GetStringbyJson("https://api.soundcloud.com/me?oauth_token=" + token);
            if (result != null)
            {
                var items = Newtonsoft.Json.JsonConvert.DeserializeObject<Me.RootObject>(result);

                txtUsername.Text = items.username;
                txtLastmodifier.Text = items.last_modified;
                ImageService.Instance.LoadUrl(items.avatar_url)

                    .Retry(5, 200)

                    .Into(imgThunbailUsername);
            }
        }


        void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            //e.MenuItem.SetChecked (true);
            SwitchFragment(e.MenuItem.ItemId);

            /*
			if (e.MenuItem.ItemId != currentFragmentId) {
				SwitchFragment (e.MenuItem.ItemId);
			}
			*/
            drawerLayout.CloseDrawers();
        }

        void Fragmanager_BackStackChanged(object sender, System.EventArgs e)
        {

            //ActionBar.SetHomeAsUpIndicator ();
            ActionBar.SetHomeButtonEnabled(FragmentManager.BackStackEntryCount > 0);
        }

        // Khoi tao gia tri cho fragment layout

        private void CreateFragments()
        {
            explorFragment = new ExploreFragment();
            genreFragment = new GenreFragment();
            audioFragment = new AudioFragment();
            //tracksByGenres = new TracksByGenres ();

        }
        //
        private void LoadInditialFragment()
        {
            var transaction = FragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.fragmentContainer, explorFragment).Hide(explorFragment);
            transaction.Add(Resource.Id.fragmentContainer, genreFragment).Hide(genreFragment);
            transaction.Add(Resource.Id.fragmentContainer, audioFragment).Hide(audioFragment);
            //transaction.Add (Resource.Id.fragmentContainer, tracksByGenres).Hide (tracksByGenres);
            transaction.Commit();
        }

        private void SwitchFragment(int FragmentId)
        {

            var transaction = FragmentManager.BeginTransaction();
           

            //transaction = FragmentManager.BeginTransaction ();
            switch (FragmentId)
            {
                case Resource.Id.nav_music:
                    transaction.Show(explorFragment);
                    transaction.Hide(genreFragment);
                    transaction.Hide(audioFragment);
                    //transaction.Hide (tracksByGenres);
                    ActionBar.Title = "All Music";
                    transaction.Commit();
                    break;

                case Resource.Id.nav_genre:
                    transaction.Show(genreFragment);
                    transaction.Hide(explorFragment);
                    transaction.Hide(audioFragment);
                    //transaction.Hide (tracksByGenres);
                    ActionBar.Title = "Genres";
                    transaction.Commit();
                    break;

                case Resource.Id.nav_audio:
                    transaction.Hide(genreFragment);
                    transaction.Hide(explorFragment);
                    transaction.Show(audioFragment);
                    //transaction.Hide (tracksByGenres);
                    ActionBar.Title = "All Audio";
                    transaction.Commit();
                    break;

                case Resource.Id.nav_signout:
                    if (isOauth == false)
                    {

                        OAuth();
                    }
                    else
                    {
                        // sign out the account here

                    }

                    break;

            }

            //transaction.Hide (TracksByGenresFragment);
            //transaction.Commit ();
            //currentFragmentId = FragmentId;
        }


        //Event Selected on nav menu

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {

                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;


            }
            return base.OnOptionsItemSelected(item);
        }
    }
}

