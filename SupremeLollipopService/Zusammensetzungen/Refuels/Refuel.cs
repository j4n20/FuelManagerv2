using System;
using System.Runtime.Serialization;

namespace SupremeLollipopService
{
    [DataContract]
    public class Refuel
    {
        [DataMember]
        public string Mileage { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public float Amount { get; set; }
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