using System;
using System.Diagnostics;

namespace Mix_Telematics_Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleFinder.FindClosestN(GetLookupPositions());
            
            Console.ReadKey();
        }


        private static Coord[] GetLookupPositions()
        {
            Coord[] coordArray1 = new Coord[10];
            coordArray1[0].Latitude = 34.54491f;
            coordArray1[0].Longitude = -102.1008f;
            coordArray1[1].Latitude = 32.34554f;
            coordArray1[1].Longitude = -99.12312f;
            coordArray1[2].Latitude = 33.23423f;
            coordArray1[2].Longitude = -100.2141f;
            coordArray1[3].Latitude = 35.19574f;
            coordArray1[3].Longitude = -95.3489f;
            coordArray1[4].Latitude = 31.89584f;
            coordArray1[4].Longitude = -97.78957f;
            coordArray1[5].Latitude = 32.89584f;
            coordArray1[5].Longitude = -101.7896f;
            coordArray1[6].Latitude = 34.11584f;
            coordArray1[6].Longitude = -100.2257f;
            coordArray1[7].Latitude = 32.33584f;
            coordArray1[7].Longitude = -99.99223f;
            coordArray1[8].Latitude = 33.53534f;
            coordArray1[8].Longitude = -94.79223f;
            coordArray1[9].Latitude = 32.23423f;
            coordArray1[9].Longitude = -100.2222f;
            return coordArray1;
        }
    }
}
