using System;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace DynamicXml
{
    public class DynamicXElement : DynamicObject
    {
        private DynamicXElement(XElement element)
        {
            Element = element;
        }

        public XElement Element { get; }

        public static dynamic Create(XElement element)
        {
            return new DynamicXElement(element);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var name = binder.Name;

            var element = Element.Element(name);
            if (element == null)
            {
                result = null;
                return false;
            }
            result = new DynamicXElement(element);
            return true;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            var name = (string)indexes[0];//This might throw an InvalidCastException, or an IndexOutOfRangeException
            var index = (int)indexes[1];

            //The first two conditions will always be true, provided execution reaches this line
            if (name.GetType() != typeof(string) || index.GetType() != typeof(int) || indexes.Length != 2 /*and at this point there is no need to check for this condition*/)
            {
                result = null;
                return false;
            }

            //What happens if an empty collection is returned? an IndexOutOfRangeException is thrown
            var elements = Element.Elements(name).ToList();
            result = new DynamicXElement(elements.ElementAt(index));
            return true;
        }

        public override string ToString()
        {
            return Element.Value;
        }
    }
}
