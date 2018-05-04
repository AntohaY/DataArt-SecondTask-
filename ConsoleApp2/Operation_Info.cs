using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp2
{
    class Operation_Info
    {

        [XmlElement("Type_Of_Operation")]
        public string Type { get; set; }

        [XmlElement("Amount")]
        public int Amount { get; set; }

        [XmlElement("Date")]
        public DateTime Date { get; set; }

        

    }
}
