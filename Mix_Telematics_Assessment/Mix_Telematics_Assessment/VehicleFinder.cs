using GeoCoordinatePortable;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mix_Telematics_Assessment
{
    public class VehicleFinder
    {
        public static void FindClosestN(Coord[] coords)
        {
            List<VehiclePosition> list = new List<VehiclePosition>();
            Stopwatch sw = Stopwatch.StartNew();
            List<VehiclePosition> lstvehiclePositions = DataFileReader.ReadDataFile();
            sw.Stop();
            Console.WriteLine($"file read execution time : {sw.ElapsedMilliseconds} ms");
            sw.Restart();
            foreach (Coord coord in coords)
            {
                list.Add(lstvehiclePositions.OrderBy(wo => wo.GetDistance(new GeoCoordinate(coord.Latitude, coord.Longitude))).FirstOrDefault());
            }
            sw.Stop();

            Console.WriteLine($"Closest position calculation execution time : {(long)sw.ElapsedMilliseconds} ms");
            Console.WriteLine();
        }
    }
}
