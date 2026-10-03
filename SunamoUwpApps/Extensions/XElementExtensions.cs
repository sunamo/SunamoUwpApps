using System;
using System.Collections.Generic;
using System.Xml.Linq;
namespace apps;
    public static class XElementExtensions
    {
static Type type = typeof(XElementExtensions);
        public static XElement XPathSelectElement(this XElement xe, string xpath)
        {
            if (!xpath.StartsWith(AllStrings.slash))
            {
                ThrowEx.Custom("Argument xpath in XElementExtensions.XPathSelectElement dont start with slash (/)");
            }
            var parts = SH.Split(xpath, AllStrings.slash);
            List<XPathPart> xpps = new List<XPathPart>();
            foreach (var part in parts)
            {
                xpps.Add(new XPathPart(part));
            }
            XElement actual = xe;
            foreach (var item in xpps)
            {
                if (actual == null)
                {
                    return null;
                }
                if (item.attName != null)
                {
                    actual = XHelper.GetElementOfNameWithAttr(actual, item.tag, item.attName, item.attValue);
                }
                else
                {
                    actual = XHelper.GetElementOfName(actual, item.tag);
                }
            }
            return actual;
        }
    }
