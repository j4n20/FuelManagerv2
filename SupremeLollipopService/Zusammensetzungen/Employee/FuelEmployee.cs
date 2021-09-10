using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SupremeLollipopService
{
    [DataContract]
    public class FuelEmployee
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
        public bool isAdmin { get; set; }
        [DataMember]
        public int Version { get; set; }
        [DataMember]
        public int Id { get; set; }
    }
}
