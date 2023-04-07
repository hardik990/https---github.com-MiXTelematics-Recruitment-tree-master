using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Mix_Telematics_Assessment
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Coord
    {
        public float Latitude;
        public float Longitude;
    }
}
