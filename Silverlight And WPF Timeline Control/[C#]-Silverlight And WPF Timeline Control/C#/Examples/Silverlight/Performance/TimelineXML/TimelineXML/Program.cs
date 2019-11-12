using System;
using System.Xml.Linq;
using System.IO;

namespace TimelineXML
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;
            var xml = new XElement("data");
            var file = @"..\..\..\..\Timeline.Web\events.xml";

            for (var i = 1900; i < 2100; i++)
            {
                for (var j = 1; j < 12; j++)
                {
                    for (var z = 1; z <= 5; z++)
                    {
                        xml.Add(new XElement("event",
                                String.Format("text {0}", count),
                                new XAttribute("link", "\"http://www.google.com\""),
                                new XAttribute("start", new DateTime(i, j, z * 5, 0, 0, 0)),
                                new XAttribute("title", String.Format("title {0}-{1}-{2}", i, j, z * 5))
                                ));


                        count++;
                    }
                }
            }
            xml.Save(file);

            Console.WriteLine("output: " + file);
            Console.WriteLine(count + " events generated.");
        }
    }
}
