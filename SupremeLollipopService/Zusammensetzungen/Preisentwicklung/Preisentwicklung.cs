using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SupremeLollipopService.Zusammensetzungen.Preisentwicklung
{
    [DataContract]
    public class Preisentwicklung
    {
        [DataMember]
        public DateTime Datum{ get; set; }
        [DataMember]
        public Car Car{ get; set; }
        [DataMember]
        public Refuel Refuels { set; get; }
    }
}
