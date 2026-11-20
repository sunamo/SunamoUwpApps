namespace apps;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

    /// <summary>
    /// Represents the buffer helper type.
    /// </summary>
    public static class BufferHelper //: IAsync
    {
        /// <summary>
        /// Convert from string to buffer.
        /// </summary>
        /// <param name="str">The str.</param>
        /// <returns>The convert from string to buffer result.</returns>
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

        /// <summary>
        /// Convert from bytes to buffer.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>The convert from bytes to buffer result.</returns>
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

        /// <summary>
        /// Convert from buffer to string.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <returns>The convert from buffer to string result.</returns>
        public static string ConvertFromBufferToString(IBuffer buffer)
        {
            DataReader reader = DataReader.FromBuffer(buffer);
            byte[] fileContent = new byte[reader.UnconsumedBufferLength];
            reader.ReadBytes(fileContent);
            string text = Encoding.UTF8.GetString(fileContent, 0, fileContent.Length);
            return text;
        }

        /// <summary>
        /// Convert from buffer to byte array.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <returns>The convert from buffer to byte array result.</returns>
        public static byte[] ConvertFromBufferToByteArray(IBuffer buffer)
        {
            DataReader reader = DataReader.FromBuffer(buffer);
            byte[] fileContent = new byte[reader.UnconsumedBufferLength];
            reader.ReadBytes(fileContent);
            return fileContent;
        }

        

        /// <summary>
        /// Convert from buffer to in memory random access stream.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <returns>The convert from buffer to in memory random access stream result.</returns>
        public static  InMemoryRandomAccessStream ConvertFromBufferToInMemoryRandomAccessStream(IBuffer buffer)
        {
            
            var stream = new InMemoryRandomAccessStream();
            uint value = GetResult<uint>( stream.WriteAsync(buffer).AsTask());
            return stream;

        }

        /// <summary>
        /// Convert from byte array to buffer.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>The convert from byte array to buffer result.</returns>
        public static IBuffer ConvertFromByteArrayToBuffer(byte[] bytes)
        {
            return bytes.AsBuffer();
        }

        /// <summary>
        /// Get result t.
        /// </summary>
        /// <typeparam name="T">The type T.</typeparam>
        /// <param name="task">The task.</param>
        /// <returns>The get result t result.</returns>
        public static T GetResult<T>(Task<T> task)
        {
            return AsyncHelper.ci.GetResult<T>(task);
        }
    }
