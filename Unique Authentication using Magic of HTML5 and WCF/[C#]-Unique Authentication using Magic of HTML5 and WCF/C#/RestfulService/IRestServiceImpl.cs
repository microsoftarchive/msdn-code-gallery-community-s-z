using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Collections;

namespace RestfulService
{
    // NOTE: If you change the interface name "IIRestServiceImpl" here, you must also update the reference to "IIRestServiceImpl" in Web.config.
    [ServiceContract]
    public interface IRestServiceImpl
    {
        [OperationContract]
        [WebInvoke(Method = "*",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "SignUpUser")]
        string SignUpUser(string name, string email,string language, string phoneno, string gender, string country, string image);

    }
    // DataContract start here

    [DataContract]
    public class WebId
    {
        private string _filetype;
        private int _signed;
        private List<UserData> _userdata;
        private string[] _keys;

        [DataMember]
        public string filetype
        {
            get { return _filetype; }
            set { _filetype = value; }
        }

        [DataMember]
        public int signed
        {
            get { return _signed; }
            set { _signed = value; }
        }

        [DataMember]
        public List<UserData> userdata
        {
            get { return _userdata; }
            set { _userdata = value; }
        }

        [DataMember]
        public string[] keys
        {
            get { return _keys; }
            set { _keys = value; }
        }

    }


    [DataContract]
    public class UserData
    {
        private string _name;
        private string _gender;
        private string _phone;
        private string _country;
        private string _image;
        private string _countryImage;
        private string _language;

        [DataMember]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember]
        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        [DataMember]
        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }


        [DataMember]
        public string language
        {
            get { return _language; }
            set { _language = value; }
        }


        [DataMember]
        public string country
        {
            get { return _country; }
            set { _country = value; }
        }
        [DataMember]
        public string image
        {
            get { return _image; }
            set { _image = value; }
        }
        [DataMember]
        public string countryImage
        {
            get { return _countryImage; }
            set { _countryImage = value; }
        }
    }
}
