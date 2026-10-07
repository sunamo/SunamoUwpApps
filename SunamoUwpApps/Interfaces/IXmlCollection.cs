namespace apps.Interfaces;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

    public interface IXmlParserCollection
    {
        //void Parse(IEnumerable<XmlElement> node);
        void Parse(IEnumerable<XElement> node);
        string ToXml();
    }

    public interface IXmlParserCollectionEnumerable : IXmlParserCollection, IEnumerable
    { 
    }


    public interface IXmlParserCollectionEnumerable<T> : IXmlParserCollection, IEnumerable<T>
    {
        void Add(T item);
    }

    public interface IXmlParserCollectionWithIndexer<Key, Value> : IXmlParserCollection, IEnumerable<Value> //IDictionary<Key, Value> //
    {
        Value this[Key key] { get; set; }
    }
