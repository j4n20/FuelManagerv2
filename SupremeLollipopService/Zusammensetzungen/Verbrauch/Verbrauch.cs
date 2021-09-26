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
        public double FirstMileage { get; set; }
        [DataMember]
        public double LastMileage { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public double AverageVerbrauch { set; get; }
        [DataMember]
        public double AveragePreis { set; get; }
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