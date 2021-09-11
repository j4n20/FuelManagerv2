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
        public Car Car { get; set; } = new Car();
        [DataMember]
        public FEmployee FEmployee { get; set; } = new FEmployee();

    }
}
