using System;

namespace YoutubeExtractor
{
    public static class BitHelper
    {
        public static byte[] CopyBlock(byte[] bytes, int offset, int length)
        {
            int startByte = offset / 8;
            int endByte = (offset + length - 1) / 8;
            int shiftA = offset % 8;
            int shiftB = 8 - shiftA;
            var dst = new byte[(length + 7) / 8];

            if (shiftA == 0)
            {
                Buffer.BlockCopy(bytes, startByte, dst, 0, dst.Length);
            }

            else
            {
                int index;

                for (index = 0; index < endByte - startByte; index++)
                {
                    dst[index] = (byte)(bytes[startByte + index] << shiftA | bytes[startByte + index + 1] >> shiftB);
                }

                if (index < dst.Length)
                {
                    dst[index] = (byte)(bytes[startByte + index] << shiftA);
                }
            }

            dst[dst.Length - 1] &= (byte)(0xFF << dst.Length * 8 - length);

            return dst;
        }

        public static void CopyBytes(byte[] dst, int dstOffset, byte[] src)
        {
            Buffer.BlockCopy(src, 0, dst, dstOffset, src.Length);
        }

        public static int Read(ref ulong value, int length)
        {
            int result = (int)(value >> 64 - length);
            value <<= length;
            return result;
        }

        public static int Read(byte[] bytes, ref int offset, int length)
        {
            int startByte = offset / 8;
            int endByte = (offset + length - 1) / 8;
            int skipBits = offset % 8;
            ulong bits = 0;

            for (int index = 0; index <= Math.Min(endByte - startByte, 7); index++)
            {
                bits |= (ulong)bytes[startByte + index] << 56 - index * 8;
            }

            if (skipBits != 0)
            {
                Read(ref bits, skipBits);
            }

            offset += length;

            return Read(ref bits, length);
        }

        public static void Write(ref ulong destination, int length, int value)
        {
            ulong mask = 0xFFFFFFFFFFFFFFFF >> 64 - length;
            destination = destination << length | (ulong)value & mask;
        }
    }
}