using RestDemo.Model;
using RestDemo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XmlParsingPage : ContentPage
    {
        public XmlParsingPage()
        {
            InitializeComponent();
            listviewPizza.ItemSelected += ListviewPizza_ItemSelected;
            GetRequest();
        }
       
        

        public async void GetRequest()
        {
            if (NetworkCheck.IsInternet())
            {
                #region Sample Xml
                /*
                <menu>
<item>
<id>1</id>
<name>Margherita</name>
<cost>155</cost>
<description>Single cheese topping</description>
</item>
<item>
<id>2</id>
<name>Double Cheese Margherita</name>
<cost>225</cost>
<description>Loaded with Extra Cheese</description>
</item>
<item>
<id>3</id>
<name>Fresh Veggie</name>
<cost>110</cost>
<description>Oninon and Crisp capsicum</description>
</item>
<item>
<id>4</id>
<name>Peppy Paneer</name>
<cost>155</cost>
<description>Paneer, Crisp capsicum and Red pepper</description>
</item>
<item>
<id>5</id>
<name>Mexican Green Wave</name>
<cost>445</cost>
<description>Onion, Crip capsicum, Tomato with mexican herb</description>
</item>
<item>
<id>6</id>
<name>Deluxe Veggie</name>
<cost>190</cost>
<description>Onion, crisp capsicum, Mashroom,Corn</description>
</item>
<item>
<id>7</id>
<name>Barbeque Chicken</name>
<cost>200</cost>
<description>Onion and Barbeque Chicken</description>
</item>
<item>
<id>8</id>
<name>Spicy Chicken</name>
<cost>285</cost>
<description>Red Pepper and Hot'n spicy chicken</description>
</item>
<item>
<id>9</id>
<name>Keema Do Pyaza</name>
<cost>330</cost>
<description>Onion, Double keema and Jalapeno</description>
</item>
<item>
<id>10</id>
<name>Chicken Golden Delight</name>
<cost>490</cost>
<description>Golden corn, Double Barbeque and Cheese</description>
</item>
</menu>*/
                #endregion

                Uri geturi = new Uri("http://api.androidhive.info/pizza/?format=xml"); //replace your xml url
                HttpClient client = new HttpClient();
                HttpResponseMessage responseGet = await client.GetAsync(geturi);
                string response = await responseGet.Content.ReadAsStringAsync();

                //Xml Parsing
                List<XmlPizzaDetails> ObjPizzaList = new List<XmlPizzaDetails>();
                XDocument doc = XDocument.Parse(response);
                foreach (var item in doc.Descendants("item"))
                {
                    XmlPizzaDetails ObjPizzaItem = new XmlPizzaDetails();
                    ObjPizzaItem.id = item.Element("id").Value.ToString();
                    ObjPizzaItem.name = item.Element("name").Value.ToString();
                    ObjPizzaItem.cost = item.Element("cost").Value.ToString();
                    ObjPizzaItem.description = item.Element("description").Value.ToString();
                    ObjPizzaList.Add(ObjPizzaItem);
                }
               listviewPizza.ItemsSource = ObjPizzaList;

            }
            else
            {
                await DisplayAlert("XmlParsing","No network is available.","Ok");
            }
            ProgressLoader.IsVisible = false;
        }
        
        private void ListviewPizza_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //XmlPizzaDetails ObjSelectedPizza = (XmlPizzaDetails)listviewPizza.SelectedItem;
            //WebNavigatedEventArgs(typeof(det), ObjSelectedPizza);
            var itemSelectedData = e.SelectedItem as XmlPizzaDetails;
            Navigation.PushAsync(new DetailsPage(itemSelectedData));
            
        }
    }
}
