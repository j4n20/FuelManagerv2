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
        public int Month { get; set; }
        [DataMember]
        public float FirstMileage { get; set; }
        [DataMember]
        public float LastMileage { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public float AverageVerbrauch { set; get; }
        [DataMember]
        public string Date {
            get
            {
                return $"{Month} {"/"} {Year}";
            }
            set
            {

            }
        }

    }
}