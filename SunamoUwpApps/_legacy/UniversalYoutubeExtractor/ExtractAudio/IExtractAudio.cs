using System;

namespace UniversalYouTubeExtractor
{
    public interface IExtractAudio : IDisposable
    {
        string VideoPath { get; }

        /// <exception cref="AudioExtractionException">An error occured while writing the chunk.</exception>
        void WriteChunk(byte[] chunk, uint timeStamp);
    }
}