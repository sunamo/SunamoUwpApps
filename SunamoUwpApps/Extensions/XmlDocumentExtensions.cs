namespace apps.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Storage;

    public static class XmlDocumentExtensions// : IAsync
    {
        public static XmlDocument Load(this XmlDocument xd, string file)
        {
            XmlDocument xd2 = new XmlDocument();
            StorageFile storageFile = AsyncHelper.ci.GetResult<StorageFile>(StorageFile.GetFileFromPathAsync(file).AsTask());
            xd2.LoadXml(TFApps.ReadFile( storageFile));
            return xd2;
        }

       
    }
