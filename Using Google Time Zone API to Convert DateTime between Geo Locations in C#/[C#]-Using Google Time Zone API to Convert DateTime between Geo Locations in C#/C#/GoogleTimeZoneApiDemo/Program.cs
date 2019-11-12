using System;
using System.Diagnostics;
using System.Net;
using System.Xml.Linq;

namespace GoogleTimeZoneApiDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            GoogleTimeZone googleTimeZone = new GoogleTimeZone("your api key");

            string timeString = "2015-01-01T08:00:00.000+05:30";
            DateTime dt = DateTime.Parse(timeString);

            //string location = "Colombo, Sri Lanka";
            //string location = "Sydney, Australia";
            string location = "Seattle, United States";

            GoogleTimeZoneResult googleTimeZoneResult = googleTimeZone.GetConvertedDateTimeBasedOnAddress(location, dt);
            Console.WriteLine("DateTime on the server : " + dt);
            Console.WriteLine("Server time in particular to : " + location);
            Console.WriteLine("TimeZone Id : " + googleTimeZoneResult.TimeZoneId);
            Console.WriteLine("TimeZone Name : " + googleTimeZoneResult.TimeZoneName);
            Console.WriteLine("Converted DateTime : " + googleTimeZoneResult.DateTime);
        }
    }
}
