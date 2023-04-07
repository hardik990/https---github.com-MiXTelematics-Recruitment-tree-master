using GeoCoordinatePortable;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mix_Telematics_Assessment
{
    public class VehiclePosition
    {
    
        public int ID;
        public string Registration;
        public float Latitude;
        public float Longitude;
        public DateTime RecordedTimeUTC;
        
        public GeoCoordinate GeoCord()
        {
            return new GeoCoordinate(Latitude, Longitude);
        }

        public double GetDistance(GeoCoordinate _GeoCoordinate)
        {
            return GeoCord().GetDistanceTo(_GeoCoordinate);
        }
    }
}
