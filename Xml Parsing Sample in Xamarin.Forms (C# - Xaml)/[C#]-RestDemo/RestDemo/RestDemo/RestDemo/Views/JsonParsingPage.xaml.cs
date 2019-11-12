using Newtonsoft.Json;
using RestDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JsonParsingPage : ContentPage
    {
        public JsonParsingPage()
        {
            InitializeComponent();
            GetRequest();
        }
        public async void GetRequest()
        {
            if (NetworkCheck.IsInternet())
            {
                #region Sample Json
                /*
                {
                    "contacts": [
                        {
                "id": "c200",
                                "name": "Ravi Tamada",
                                "email": "ravi@gmail.com",
                                "address": "xx-xx-xxxx,x - street, x - country",
                                "gender" : "male",
                                "phone": {
                    "mobile": "+91 0000000000",
                                    "home": "00 000000",
                                    "office": "00 000000"
                }
},
        {
                "id": "c201",
                "name": "Johnny Depp",
                "email": "johnny_depp@gmail.com",
                "address": "xx-xx-xxxx,x - street, x - country",
                "gender" : "male",
                "phone": {
                    "mobile": "+91 0000000000",
                    "home": "00 000000",
                    "office": "00 000000"
                }
        },
        {
                "id": "c202",
                "name": "Leonardo Dicaprio",
                "email": "leonardo_dicaprio@gmail.com",
                "address": "xx-xx-xxxx,x - street, x - country",
                "gender" : "male",
                "phone": {
                    "mobile": "+91 0000000000",
                    "home": "00 000000",
                    "office": "00 000000"
                }
        },
        {
                "id": "c203",
                "name": "John Wayne",
                "email": "john_wayne@gmail.com",
                "address": "xx-xx-xxxx,x - street, x - country",
                "gender" : "male",
                "phone": {
                    "mobile": "+91 0000000000",
                    "home": "00 000000",
                    "office": "00 000000"
                }
        },
        {
                "id": "c204",
                "name": "Angelina Jolie",
                "email": "angelina_jolie@gmail.com",
                "address": "xx-xx-xxxx,x - street, x - country",
                "gender" : "female",
                "phone": {
                    "mobile": "+91 0000000000",
                    "home": "00 000000",
                    "office": "00 000000"
                }
        },
        {
                "id": "c205",
                "name": "Dido",
                "email": "dido@gmail.com",
                "address": "xx-xx-xxxx,x - street, x - country",
                "gender" : "female",
                "phone": {
                    "mobile": "+91 0000000000",
                    "home": "00 000000",
                    "office": "00 000000"
                }
        },
        {
                "id": "c206",
                "name": "Adele",
                "email": "adele@gmail.com",
                "address": "xx-xx-xxxx,x - street, x - country",
                "gender" : "female",
                "phone": {
                    "mobile": "+91 0000000000",
                    "home": "00 000000",
                    "office": "00 000000"
                }
        },
        {
                "id": "c207",
                "name": "Hugh Jackman",
                "email": "hugh_jackman@gmail.com",
                "address": "xx-xx-xxxx,x - street, x - country",
                "gender" : "male",
                "phone": {
                    "mobile": "+91 0000000000",
                    "home": "00 000000",
                    "office": "00 000000"
                }
        },
        {
                "id": "c208",
                "name": "Will Smith",
                "email": "will_smith@gmail.com",
                "address": "xx-xx-xxxx,x - street, x - country",
                "gender" : "male",
                "phone": {
                    "mobile": "+91 0000000000",
                    "home": "00 000000",
                    "office": "00 000000"
                }
        },
        {
                "id": "c209",
                "name": "Clint Eastwood",
                "email": "clint_eastwood@gmail.com",
                "address": "xx-xx-xxxx,x - street, x - country",
                "gender" : "male",
                "phone": {
                    "mobile": "+91 0000000000",
                    "home": "00 000000",
                    "office": "00 000000"
                }
        },
        {
                "id": "c2010",
                "name": "Barack Obama",
                "email": "barack_obama@gmail.com",
                "address": "xx-xx-xxxx,x - street, x - country",
                "gender" : "male",
                "phone": {
                    "mobile": "+91 0000000000",
                    "home": "00 000000",
                    "office": "00 000000"
                }
        },
        {
                "id": "c2011",
                "name": "Kate Winslet",
                "email": "kate_winslet@gmail.com",
                "address": "xx-xx-xxxx,x - street, x - country",
                "gender" : "female",
                "phone": {
                    "mobile": "+91 0000000000",
                    "home": "00 000000",
                    "office": "00 000000"
                }
        },
        {
                "id": "c2012",
                "name": "Eminem",
                "email": "eminem@gmail.com",
                "address": "xx-xx-xxxx,x - street, x - country",
                "gender" : "male",
                "phone": {
                    "mobile": "+91 0000000000",
                    "home": "00 000000",
                    "office": "00 000000"
                }
        }
    ]
}*/
                #endregion

               

                var client = new System.Net.Http.HttpClient();
                var response = await client.GetAsync("http://api.androidhive.info/contacts/");
                var placesJson = response.Content.ReadAsStringAsync().Result;
                List<Contact> ObjContactList = new List<Contact>();
                if (placesJson != "")
                {
                    ObjContactList = JsonConvert.DeserializeObject<List<Contact>>(placesJson);
                }
                
              //  listviewConacts.ItemsSource = ObjContactList;
            }
            else
            {
               // MessageDialog ObjMessageDialog = new MessageDialog("No network is available.");
                //ObjMessageDialog.ShowAsync();
            }
           // ProgressLoader.IsActive = false;
        }

    }
}
