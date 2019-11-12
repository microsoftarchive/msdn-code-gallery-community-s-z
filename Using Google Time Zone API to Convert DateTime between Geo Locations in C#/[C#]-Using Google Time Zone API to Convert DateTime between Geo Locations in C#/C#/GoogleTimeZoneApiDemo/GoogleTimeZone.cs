using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GoogleTimeZoneApiDemo
{
    public class GoogleTimeZone
    {
        private string apiKey;
        private GeoLocation location;
        private string previousAddress = string.Empty;

        public GoogleTimeZone(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public GoogleTimeZoneResult GetConvertedDateTimeBasedOnAddress(string address, DateTime dateTime)
        {
            long timestamp = GetUnixTimeStampFromDateTime(TimeZoneInfo.ConvertTimeToUtc(dateTime));

            if (previousAddress != address)
            {
                this.location = GetCoordinatesByLocationName(address);

                previousAddress = address;

                if (this.location == null)
                {
                    return null;
                }
            }

            return GetConvertedDateTimeBasedOnAddress(this.location, timestamp);
        }

        private GoogleTimeZoneResult GetConvertedDateTimeBasedOnAddress(GeoLocation location, long timestamp)
        {
            string requestUri = string.Format("https://maps.googleapis.com/maps/api/timezone/xml?location={0},{1}&timestamp={2}&key={3}", location.Latitude, location.Longitude, timestamp, this.apiKey);

            XDocument xdoc = GetXmlResponse(requestUri);

            XElement result = xdoc.Element("TimeZoneResponse");
            XElement rawOffset = result.Element("raw_offset");
            XElement dstOfset = result.Element("dst_offset");
            XElement timeZoneId = result.Element("time_zone_id");
            XElement timeZoneName = result.Element("time_zone_name");

            return new GoogleTimeZoneResult()
            {
                DateTime = GetDateTimeFromUnixTimeStamp(Convert.ToDouble(timestamp) + Convert.ToDouble(rawOffset.Value) + Convert.ToDouble(dstOfset.Value)),
                TimeZoneId = timeZoneId.Value,
                TimeZoneName = timeZoneName.Value
            };
        }

        private GeoLocation GetCoordinatesByLocationName(string address)
        {
            string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&key={1}", Uri.EscapeDataString(address), this.apiKey);

            XDocument xdoc = GetXmlResponse(requestUri);

            XElement status = xdoc.Element("GeocodeResponse").Element("status");

            XElement result = xdoc.Element("GeocodeResponse").Element("result");
            XElement locationElement = result.Element("geometry").Element("location");
            XElement lat = locationElement.Element("lat");
            XElement lng = locationElement.Element("lng");

            return new GeoLocation()
            {
                Latitude = Convert.ToDouble(lat.Value),
                Longitude = Convert.ToDouble(lng.Value)
            };
        }

        private XDocument GetXmlResponse(string requestUri)
        {
            WebRequest request = WebRequest.Create(requestUri);
            WebResponse response = request.GetResponse();
            return XDocument.Load(response.GetResponseStream());
        }

        private long GetUnixTimeStampFromDateTime(DateTime dt)
        {
            DateTime epochDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan ts = dt - epochDate;
            return (int)ts.TotalSeconds;
        }

        private DateTime GetDateTimeFromUnixTimeStamp(double unixTimeStamp)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(unixTimeStamp);
            return dt;
        }
    }
}
