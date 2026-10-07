namespace apps.XmlStorage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Storage;

    public class XmlConnection
    {
        Type type = typeof(XmlConnection);
        OuterObjectMapping tMap = null;

        public XmlConnection(OuterObjectMapping tMap)
        {
            this.tMap = tMap;
        }

        public void CreateTableAsync<T>(IXmlParserCollectionEnumerable<T> emptyCol) where T : new()
        {
            XmlLayer.SaveDbFile(emptyCol);
        }

        /// <summary>
        /// Před použitím této metody si musíš najít správný prvek pomocí LINQ a tento prvek následně předat do A1
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="flat"></param>
        public void UpdateAsync<T>(T flat,  IXmlParserCollectionEnumerable<T> elements) where T : new()
        {
            Type type = typeof(T);
            PropertyInfo pi2 = type.GetRuntimeProperty(tMap.primaryKey.Name);
            string value = pi2.GetValue(flat).ToString();
            string hledaneID = tMap.primaryKey.GetValue(flat).ToString();

            foreach (var item in elements)
            {
                string primaryKeyValue = tMap.primaryKey.GetValue(item).ToString();
                if (hledaneID == primaryKeyValue)
                {
                    foreach (var propertyInfo in tMap.propertyInfos)
                    {
                        //PropertyInfo pi = type.GetRuntimeProperty(tMap.primaryKey.Name);
                        propertyInfo.SetValue(item, propertyInfo.GetValue(flat));
                    }
                    break;
                }
                
            }

            XmlLayer.SaveDbFile(elements);

            //type.Pro
        }

        public  T GetAsync<T>(object value, IXmlParserCollectionEnumerable<T> elements) where T : new()
        {
            string path = value.ToString();
            foreach (T item in elements)
            {
                string primaryKeyValue = tMap.primaryKey.GetValue(item).ToString();
                if (path == primaryKeyValue)
                {
                    return item;
                }
            }
            return default(T);
        }

        public void DropTableAsync<T>(IXmlParserCollectionEnumerable<T> emptyElements)
        {
            XmlLayer.SaveDbFile(emptyElements);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_flats"></param>
        /// <param name="elements"></param>
        public void InsertAllAsync<T>(IEnumerable<T> _flats, IXmlParserCollectionEnumerable<T> elements)
        {
            // Nejdříve zjistím které ID mám v A2
            List<string> ids = new List<string>();
            foreach (T item in elements)
            {
                ids.Add(tMap.primaryKey.GetValue(item).ToString());
            }
            // Poté přidám jen ty elementy z A1 které v A2 nejsou
            foreach (var item in _flats)
            {
                string id = tMap.primaryKey.GetValue(item).ToString();
                if (!ids.Contains(id))
                {
                    elements.Add(item);
                }
            }

            XmlLayer.SaveDbFile(elements);
        }

        public List<T> QueryAsync<T>(string path)
        {
            ThrowEx.NotImplementedMethod();
            return null;
        }
    }
