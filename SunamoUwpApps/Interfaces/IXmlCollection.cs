namespace apps.Interfaces;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

    /// <summary>
    /// Represents the i xml parser collection type.
    /// </summary>
    public interface IXmlParserCollection
    {
        //void Parse(IEnumerable<XmlElement> node);
        /// <summary>
        /// Parse.
        /// </summary>
        /// <param name="node">The node.</param>
        void Parse(IEnumerable<XElement> node);
        /// <summary>
        /// To xml.
        /// </summary>
        /// <returns>The to xml result.</returns>
        string ToXml();
    }

    /// <summary>
    /// Represents the i xml parser collection enumerable type.
    /// </summary>
    public interface IXmlParserCollectionEnumerable : IXmlParserCollection, IEnumerable
    { 
    }


    /// <summary>
    /// Represents the i xml parser collection enumerable t type.
    /// </summary>
    public interface IXmlParserCollectionEnumerable<T> : IXmlParserCollection, IEnumerable<T>
    {
        /// <summary>
        /// Add.
        /// </summary>
        /// <param name="item">The item.</param>
        void Add(T item);
    }

    /// <summary>
    /// Represents the i xml parser collection with indexer key value type.
    /// </summary>
    public interface IXmlParserCollectionWithIndexer<Key, Value> : IXmlParserCollection, IEnumerable<Value> //IDictionary<Key, Value> //
    {
        /// <summary>
        /// Gets or sets the this key.
        /// </summary>
        Value this[Key key] { get; set; }
    }
