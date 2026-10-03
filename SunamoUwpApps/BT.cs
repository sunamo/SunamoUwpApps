namespace apps;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

    public static class BufferHelper //: IAsync
    {
        public static IBuffer ConvertFromStringToBuffer(String str)
        {
            using (InMemoryRandomAccessStream memoryStream = new InMemoryRandomAccessStream())
            {
                using (DataWriter dataWriter = new DataWriter(memoryStream))
                {
                    dataWriter.WriteString(str);
                    return dataWriter.DetachBuffer();
                }
            }
        }

        public static IBuffer ConvertFromBytesToBuffer(byte[] p)
        {
            using (InMemoryRandomAccessStream memoryStream = new InMemoryRandomAccessStream())
            {
                using (DataWriter dataWriter = new DataWriter(memoryStream))
                {
                    dataWriter.WriteBytes(p);
                    return dataWriter.DetachBuffer();
                }
            }
        }

        public static string ConvertFromBufferToString(IBuffer ib)
        {
            DataReader reader = DataReader.FromBuffer(ib);
            byte[] fileContent = new byte[reader.UnconsumedBufferLength];
            reader.ReadBytes(fileContent);
            string text = Encoding.UTF8.GetString(fileContent, 0, fileContent.Length);
            return text;
        }

        public static byte[] ConvertFromBufferToByteArray(IBuffer ib)
        {
            DataReader reader = DataReader.FromBuffer(ib);
            byte[] fileContent = new byte[reader.UnconsumedBufferLength];
            reader.ReadBytes(fileContent);
            return fileContent;
        }

        

        public static  InMemoryRandomAccessStream ConvertFromBufferToInMemoryRandomAccessStream(IBuffer ib)
        {
            
            var vr = new InMemoryRandomAccessStream();
            uint u = GetResult<uint>( vr.WriteAsync(ib).AsTask());
            return vr;

        }

        public static IBuffer ConvertFromByteArrayToBuffer(byte[] v)
        {
            return v.AsBuffer();
        }

        public static T GetResult<T>(Task<T> t)
        {
            return AsyncHelper.ci.GetResult<T>(t);
        }
    }
