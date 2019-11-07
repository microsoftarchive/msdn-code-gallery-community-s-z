using System;
using System.Device.Location;

namespace Geo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            var watcher = new GeoCoordinateWatcher();

            watcher.TryStart(false,TimeSpan.FromMilliseconds(5000));

            var coord = watcher.Position.Location;


            if (coord.IsUnknown != true)
            
                Console.WriteLine(coord);
            else
                Console.WriteLine("Can't locate");

        }
    }
}