using UniversalYouTubeExtractor;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using wsf.Net;

namespace UniversalYouTubeExtractor

    public class YouTubeVideo : YouTubeDownloader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YouTubeVideo"/> class.
        /// </summary>
        /// <param name="video">The video to download.</param>
        /// <param name="savePath">The path to save the video.</param>
        /// <param name="bytesToDownload">An optional value to limit the number of bytes to download.</param>
        /// <exception cref="ArgumentNullException"><paramref name="video"/> or <paramref name="savePath"/> is <c>null</c>.</exception>
        public YouTubeVideo(Format video, StorageFile savePath, int? bytesToDownload = null)
            : base(video, savePath, bytesToDownload)
        { }

        /// <summary>
        /// Occurs when the downlaod progress of the video file has changed.
        /// </summary>
        public event EventHandler<DownloadProgressEventArgs> DownloadProgressChanged;

        /// <summary>
        /// Starts the video download.
        /// </summary>
        /// <exception cref="IOException">The video file could not be saved.</exception>
        /// <exception cref="WebException">An error occured while downloading the video.</exception>
#if DEBUG
        double previousD = 0;
#endif

        /// <summary>
        /// Stáhne soubor po částech, vyvolává událost DownloadProgressChanged
        /// </summary>
        public async override Task<string> DoWork()
        {
            this.OnDownloadStarted(EventArgs.Empty);

            HttpWebRequest request = WebRequest.CreateHttp(this.Video.DownloadUrl);

            request.Method = "GET";

            if (this.BytesToDownload.HasValue)
            {
                Task<Stream> rsTask = request.GetRequestStreamAsync();

                //rsTask.Wait();
                Stream stream = await rsTask;
                byte[] rangeHeaderBytes = Encoding.UTF8.GetBytes(.Format2("Range: bytes={0}-{1}", 0, this.BytesToDownload.Value - 1));
                stream.Write(rangeHeaderBytes, 0, rangeHeaderBytes.Length);
            }

            // the following code is alternative, you may implement the function after your needs
            var responseTask = request.GetResponseAsync();
            using (var response = await responseTask)
            {
                using (Stream source = response.GetResponseStream())
                {
                    var target = await SavePath.OpenStreamForWriteAsync();
                    using (target)
                    {
                        var buffer = new byte[1024];
                        bool cancel = false;
                        int bytes;
                        int copiedBytes = 0;

                        while (!cancel && (bytes = source.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            target.Write(buffer, 0, bytes);

                            copiedBytes += bytes;

                            double value = (copiedBytes * 1.0 / response.ContentLength) * 100;
#if DEBUG
#endif
                            var eventArgs = new DownloadProgressEventArgs(value);

                            if (this.DownloadProgressChanged != null)
                            {
                                this.DownloadProgressChanged(this, eventArgs);

                                if (eventArgs.Cancel)
                                {
                                    cancel = true;
                                }
                            }
                        }
                        //target.Flush();
                    }
                }

            }
            this.OnDownloadFinished(EventArgs.Empty);

            return null;
        }

        public async Task DoWorkWithHttpClient(string uri)
        {
            HttpClient httpClient = new HttpClient();
            if (this.BytesToDownload.HasValue)
            {
                httpClient.DefaultRequestHeaders.Range = new System.Net.Http.Headers.RangeHeaderValue(0, this.BytesToDownload.Value - 1);
            }

            Stream stream = await httpClient.GetStreamAsync(uri);
            Task<Stream> task = SavePath.OpenStreamForWriteAsync();
            //ts.Wait();
            Stream target = await task;
            await stream.CopyToAsync(target);
            target.Flush();
            target.Dispose();
            return;
        }
    }
}