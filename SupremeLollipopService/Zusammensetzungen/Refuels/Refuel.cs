using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SupremeLollipopService
{
    [XmlType("Tanken")]
    [DataContract]
    public class Refuel
    {
        [XmlElement("Kilometerstand")]
        [DataMember]
        public string Mileage { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [XmlElement("Liter")]
        [DataMember]
        public float Amount { get; set; }
        [XmlElement("Bezahlt")]
        [DataMember]
        public float Price { get; set; }
        [DataMember]
        public int Version { get; set; }
        [DataMember]
        public Car Car { get; set; }
        [DataMember]
        public int Id { get; set; }
    }
}