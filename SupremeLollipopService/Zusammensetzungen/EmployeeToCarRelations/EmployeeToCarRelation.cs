using System.Runtime.Serialization;

namespace SupremeLollipopService
{
    [DataContract]
    public class EmployeeToCarRelation
    {
        /*[DataMember]
        public string AreaId { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }*/
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Car Area { get; set; } = new Car();
        [DataMember]
        public FEmployee Employee { get; set; } = new FEmployee();

    }
}
