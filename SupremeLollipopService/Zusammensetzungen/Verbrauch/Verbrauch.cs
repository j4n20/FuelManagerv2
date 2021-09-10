using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SupremeLollipopService.Zusammensetzungen.Verbrauch
{
    [DataContract]
    public class Verbrauch
    {
        [DataMember]
        public Car Car{ get; set; }
        [DataMember]
        public Refuel Refuels{ get; set; }
        [DataMember]
        public double AveragePrice { set; get; }

    }
}