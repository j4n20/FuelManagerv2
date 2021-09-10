using System.Runtime.Serialization;

namespace SupremeLollipopService
{
    [DataContract]
    public class Car
    {
        [DataMember]
        public string LicensePlate { get; set; }
        [DataMember]
        public string Vendor { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public int Version { get; set; }
        [DataMember]
        public int Id { get; set; }
    }
}
