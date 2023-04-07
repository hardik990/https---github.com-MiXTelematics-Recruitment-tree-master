using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mix_Telematics_Assessment
{
    public class DataFileReader
    {
        public static List<VehiclePosition> ReadDataFile()
        {
            string localFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"File\VehiclePositions.dat");
            byte[] data = File.ReadAllBytes(localFilePath);
            List<VehiclePosition> lstVehicle = new List<VehiclePosition>();
            for (int position = 0; position < data.Length; position++)
            {
                VehiclePosition objdata = new VehiclePosition();
                objdata.ID = BitConverter.ToInt32(data, position);
                position += 4;
                objdata.Registration = GetRegistration(data, ref position);
                position++;
                objdata.Latitude = BitConverter.ToSingle(data, position);
                position += 4;
                objdata.Longitude = BitConverter.ToSingle(data, position);
                position += 4;
                objdata.RecordedTimeUTC = DateTime.FromBinary(BitConverter.ToInt64(data, position));
                position += 7;
                lstVehicle.Add(objdata);
            }
            return lstVehicle;
        }

        private static string GetRegistration(byte[] data, ref int position)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var e1 in data)
            {
                if (data[position] == 0)
                    return builder.ToString();
                else
                    builder.Append((char)data[position]);
                position++;
            }
            return string.Empty;
        }

        //public static T ConvertTo1<T>(this byte[] bytes, int offset = 0)
        //{
        //    var type = typeof(T);
        //    if (type == typeof(sbyte)) return (T)(object)((sbyte)bytes[offset]);
        //    if (type == typeof(byte)) return (T)(object)bytes[offset];
        //    if (type == typeof(short)) return (T)(object)((short)(bytes[offset + 1] << 8 | bytes[offset]));
        //    if (type == typeof(ushort)) return (T)(object)((ushort)(bytes[offset + 1] << 8 | bytes[offset]));
        //    if (type == typeof(int)) return (T)(object)(bytes[offset + 3] << 24 | bytes[offset + 2] << 16 | bytes[offset + 1] << 8 | bytes[offset]);
        //    if (type == typeof(uint)) return (T)(object)((uint)bytes[offset + 3] << 24 | (uint)bytes[offset + 2] << 16 | (uint)bytes[offset + 1] << 8 | bytes[offset]);
        //    if (type == typeof(long)) return (T)(object)((long)bytes[offset + 7] << 56 | (long)bytes[offset + 6] << 48 | (long)bytes[offset + 5] << 40 | (long)bytes[offset + 4] << 32 | (long)bytes[offset + 3] << 24 | (long)bytes[offset + 2] << 16 | (long)bytes[offset + 1] << 8 | bytes[offset]);
        //    if (type == typeof(ulong)) return (T)(object)((ulong)bytes[offset + 7] << 56 | (ulong)bytes[offset + 6] << 48 | (ulong)bytes[offset + 5] << 40 | (ulong)bytes[offset + 4] << 32 | (ulong)bytes[offset + 3] << 24 | (ulong)bytes[offset + 2] << 16 | (ulong)bytes[offset + 1] << 8 | bytes[offset]);

        //    throw new NotImplementedException();
        //}
        //public static T ConvertTo2<T>(this byte[] bytes, int offset = 0)
        //{
        //    var type = typeof(T);
        //    if (type == typeof(sbyte)) return ((sbyte)bytes[offset]).As<T>();
        //    if (type == typeof(byte)) return bytes[offset].As<T>();
        //    if (type == typeof(short)) return BitConverter.ToInt16(bytes, offset).As<T>();
        //    if (type == typeof(ushort)) return BitConverter.ToUInt16(bytes, offset).As<T>();
        //    if (type == typeof(int)) return BitConverter.ToInt32(bytes, offset).As<T>();
        //    if (type == typeof(uint)) return BitConverter.ToUInt32(bytes, offset).As<T>();
        //    if (type == typeof(long)) return BitConverter.ToInt64(bytes, offset).As<T>();
        //    if (type == typeof(ulong)) return BitConverter.ToUInt64(bytes, offset).As<T>();

        //    throw new NotImplementedException();
        //}

        //public static int ConvertToInt(this byte[] bytes, int offset = 0)
        //{
        //    return (bytes[offset + 3] << 24 | bytes[offset + 2] << 16 | bytes[offset + 1] << 8 | bytes[offset]);
        //}

        //public static T As<T>(this object o)
        //{
        //    return (T)o;
        //}
    }
}
