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

        public static IBuffer ConvertFromBytesToBuffer(byte[] bytes)
        {
            using (InMemoryRandomAccessStream memoryStream = new InMemoryRandomAccessStream())
            {
                using (DataWriter dataWriter = new DataWriter(memoryStream))
                {
                    dataWriter.WriteBytes(bytes);
                    return dataWriter.DetachBuffer();
                }
            }
        }

        public static string ConvertFromBufferToString(IBuffer buffer)
        {
            DataReader reader = DataReader.FromBuffer(buffer);
            byte[] fileContent = new byte[reader.UnconsumedBufferLength];
            reader.ReadBytes(fileContent);
            string text = Encoding.UTF8.GetString(fileContent, 0, fileContent.Length);
            return text;
        }

        public static byte[] ConvertFromBufferToByteArray(IBuffer buffer)
        {
            DataReader reader = DataReader.FromBuffer(buffer);
            byte[] fileContent = new byte[reader.UnconsumedBufferLength];
            reader.ReadBytes(fileContent);
            return fileContent;
        }

        

        public static  InMemoryRandomAccessStream ConvertFromBufferToInMemoryRandomAccessStream(IBuffer buffer)
        {
            
            var stream = new InMemoryRandomAccessStream();
            uint value = GetResult<uint>( stream.WriteAsync(buffer).AsTask());
            return stream;

        }

        public static IBuffer ConvertFromByteArrayToBuffer(byte[] bytes)
        {
            return bytes.AsBuffer();
        }

        public static T GetResult<T>(Task<T> task)
        {
            return AsyncHelper.ci.GetResult<T>(task);
        }
    }
