using System.IO;
using UniversalYouTubeExtractor;
using wsf;
namespace UniversalYouTubeExtractor
{
    public class AacAudioExtractor : IExtractAudio
    {
static Type type = typeof(AacAudioExtractor);
        private readonly Stream fileStream;
        private int aacProfile;
        private int channelConfig;
        private int sampleRateIndex;
        public AacAudioExtractor(string path, Stream stream)
        {
            this.VideoPath = path;
            fileStream = stream; // new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read, 64 * 1024);
        }
        public string VideoPath { get; private set; }
        public void Dispose()
        {
            this.fileStream.Dispose();
        }
        public void WriteChunk(byte[] chunk, uint timeStamp)
        {
            if (chunk.Length < 1)
            {
                return;
            }
            if (chunk[0] == 0)
            {
                // Header
                if (chunk.Length < 3)
                {
                    return;
                }
                ulong bits = (ulong)BigEndianBitConverter.ToUInt16(chunk, 1) << 48;
                aacProfile = BitOperations.Read(ref bits, 5) - 1;
                sampleRateIndex = BitOperations.Read(ref bits, 4);
                channelConfig = BitOperations.Read(ref bits, 4);
                if (aacProfile < 0 || aacProfile > 3)
                    ThrowEx.Custom(AudioExtractionException("Unsupported AAC profile.");
                if (sampleRateIndex > 12)
                    ThrowEx.Custom(AudioExtractionException("Invalid AAC sample rate index.");
                if (channelConfig > 6)
                    ThrowEx.Custom(AudioExtractionException("Invalid AAC channel configuration.");
            }
            else
            {
                // Audio data
                int dataSize = chunk.Length - 1;
                ulong bits = 0;
                BitOperations.Write(ref bits, 12, 0xFFF);
                BitOperations.Write(ref bits, 1, 0);
                BitOperations.Write(ref bits, 2, 0);
                BitOperations.Write(ref bits, 1, 1);
                BitOperations.Write(ref bits, 2, aacProfile);
                BitOperations.Write(ref bits, 4, sampleRateIndex);
                BitOperations.Write(ref bits, 1, 0);
                BitOperations.Write(ref bits, 3, channelConfig);
                BitOperations.Write(ref bits, 1, 0);
                BitOperations.Write(ref bits, 1, 0);
                BitOperations.Write(ref bits, 1, 0);
                BitOperations.Write(ref bits, 1, 0);
                BitOperations.Write(ref bits, 13, 7 + dataSize);
                BitOperations.Write(ref bits, 11, 0x7FF);
                BitOperations.Write(ref bits, 2, 0);
                fileStream.Write(BigEndianBitConverter.GetBytes(bits), 1, 7);
                fileStream.Write(chunk, 1, dataSize);
            }
        }
    }
}