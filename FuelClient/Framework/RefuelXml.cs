using FuelClient.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FuelClient.Framework
{
    [XmlType("Tanken")]
    public class RefuelXml
    {
        [XmlElement("Kilometerstand")]
        public string Mileage { get; set; }

        [XmlAttribute("Datum")]
        public DateTime Date { get; set; }

        [XmlElement("Liter")]
        public float Amount { get; set; }

        [XmlElement("Bezahlt")]
        public float Price { get; set; }

        [XmlAttribute("Fahrzeug")]
        public string Kennzeichen { get; set; }

    }
}
