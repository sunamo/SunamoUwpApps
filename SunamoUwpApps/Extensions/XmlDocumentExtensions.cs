namespace apps.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Storage;

    /// <summary>
    /// Represents the xml document extensions type.
    /// </summary>
    public static class XmlDocumentExtensions// : IAsync
    {
        /// <summary>
        /// Load.
        /// </summary>
        /// <param name="xmlDocument">The xml document.</param>
        /// <param name="file">The file.</param>
        /// <returns>The load result.</returns>
        public static XmlDocument Load(this XmlDocument xmlDocument, string file)
        {
            XmlDocument xd2 = new XmlDocument();
            StorageFile storageFile = AsyncHelper.ci.GetResult<StorageFile>(StorageFile.GetFileFromPathAsync(file).AsTask());
            xd2.LoadXml(TFApps.ReadFile( storageFile));
            return xd2;
        }

       
    }
