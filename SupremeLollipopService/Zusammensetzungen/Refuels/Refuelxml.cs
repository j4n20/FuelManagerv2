using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SupremeLollipopService.Zusammensetzungen.Refuels
{
    
    [XmlType("Tanken")]
    public class Refuelxml
    {
        [XmlElement("Kilometerstand")]
        public string Mileage { get; set; }

        [XmlElement("Datum")]
        public DateTime Date { get; set; }

        [XmlElement("Liter")]
        public float Amount { get; set; }

        [XmlElement("Bezahlt")]
        public float Price { get; set; }

        [XmlElement("Fahrzeug")]
        public Car Car { get; set; }

    }
}
