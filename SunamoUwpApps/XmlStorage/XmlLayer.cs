namespace apps.XmlStorage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Globalization;
using Windows.Storage;
using System.IO;
using Windows.Storage.Streams;

    public static class XmlLayer //: IAsync
    {
static Type type = typeof(XmlLayer);
        static StorageFolder sf2 = null;
        static XmlLayer()
        {
        }
        static OuterObjectMapping _tMap = null;
        public static OuterObjectMapping tMap
        {
            get
            {
                return _tMap;
            }
            set
            {
                _tMap = value;
                _conn = new XmlConnection(value);
            }
        }
        public static XmlConnection _conn = null;
        public static XmlConnection conn
        {
            get
            {
                return _conn;
            }
        }
        public static string extOfDB;
        public static PluralConverter pluralConverter;
        public static bool SaveImmediately = true;
        //public static IRandomAccessStream storageFile;
        public static StorageFile sf = null;
        /// <summary>
        /// Může se ukládat pouze když věci neukládám okamžitě, resp. nemusí se používat pouze takhle ale je to zbytečné mrhání výpočetním výkonem
        /// Bezparametrová metoda není, v opačném případě se soubor nemusí uzavírat
        /// </summary>
        public static void CloseDbFile(IXmlParserCollection xml)
        {
            SaveDbFile(xml);
        }
        public static void SaveDbFile(IXmlParserCollection content)
        {
            TFApps.SaveFile(content.ToXml(), sf);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public static  string ReadDbFile()
        {
            return TFApps.ReadFile(sf);
        }
        public static OuterObjectMapping GenerateMapping<T>()
        {
            OuterObjectMapping outersMapping = new OuterObjectMapping();
            var MappedType = typeof(T);
            string TableName = MappedType.Name;
            var tableAttr = (OuterObjectAttribute)System.Reflection.CustomAttributeExtensions
                .GetCustomAttribute(MappedType.GetTypeInfo(), typeof(OuterObjectAttribute), true);
            var props = from p in MappedType.GetRuntimeProperties()
                        where ((p.GetMethod != null && p.GetMethod.IsPublic) || (p.SetMethod != null && p.SetMethod.IsPublic))// || (p.GetMethod != null && p.GetMethod.IsStatic) || (p.SetMethod != null && p.SetMethod.IsStatic))
                        select p;
            foreach (var property in props)
            {
                var ignore = property.GetCustomAttributes(typeof(IgnoreAttribute), true).Count() > 0;
                if (property.CanWrite && !ignore)
                {
                    outersMapping.propertyInfos.Add(property);
                    var primaryKey = property.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0;
                    if (primaryKey)
                    {
                        if (outersMapping.primaryKey == null)
                        {
                            outersMapping.primaryKey = property;
                        }
                        else
                        {
                            if (AppLangHelper.currentUICulture.TwoLetterISOLanguageName == "cs")
                            {
                                ThrowEx.Custom("Program se pokouší vytvořit tabulku se 2mi primárními klíči");
                            }
                            else
                            {
                                ThrowEx.Custom("The program is attempting to create a table with two primary keys");
                            }
                        }
                    }
                }
            }
            tMap = outersMapping;
            return outersMapping;
        }
        public static void RenameDbFile(string value)
        {
            AsyncHelperApps.ci.GetResult( sf.RenameAsync(value + extOfDB, NameCollisionOption.GenerateUniqueName));
            sf = sf2.CreateFileAsync(value + extOfDB, CreationCollisionOption.OpenIfExists).AsTask().Result;
        }
        /// <summary>
        /// Pouze odstrní aktuální soubor, je pak na mě abych si otevřel zdejšími metodami jinou DB
        /// </summary>
        public static void DeleteDbFile()
        {
            FSApps.DeleteFile(sf);
        }
        public static T GetResult<T>(Task<T> task)
        {
            return AsyncHelper.ci.GetResult<T>(task);
        }
    }
