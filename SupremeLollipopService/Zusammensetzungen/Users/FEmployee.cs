using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SupremeLollipopService
{
    [DataContract]
    public class FEmployee
    {
        //Benutzername ohne groß und kleinschreibung beachten
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string Lastname { get; set; }
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public bool isAdmin { get; set; }
        [DataMember]
        public int Version { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public IList<Car> ToCars { get; set; }
    }
}
