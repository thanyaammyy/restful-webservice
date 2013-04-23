using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataModelLib.Helper
{
    public class Medallias
    {
        private List<Medallia> _items = new List<Medallia>();

        [XmlElement("Medallia", Namespace = "")]
        public List<Medallia> Items { get { return _items; } set { _items = value; } }
    }

}
