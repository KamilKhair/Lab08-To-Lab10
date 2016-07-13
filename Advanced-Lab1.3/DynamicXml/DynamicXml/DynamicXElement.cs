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

            if (element != null && element.IsEmpty)
            {
                return base.TryGetMember(binder, out result);
            }
            result = new DynamicXElement(element);
            return true;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            var name = (string)indexes[0];
            var index = (int)indexes[1];

            if (name.GetType() != typeof(string) || index.GetType() != typeof(int) || indexes.Length != 2)
            {
                result = null;
                return false;
            }

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
