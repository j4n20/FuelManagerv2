using FluentNHibernate.Mapping;
namespace SupremeLollipopService
{
    public class EmployeeToCarRelationMap : ClassMap<EmployeeToCarRelation>
    {
        public EmployeeToCarRelationMap()
        {
            Table("EmployeeToCarRelations");

            Id(x => x.Id).GeneratedBy.Native().Default(0);

            References<Car>(x => x.Car).Column("CarId").Not.Nullable();
            References<FEmployee>(x => x.FEmployee).Column("EmployeeId").Not.Nullable();
        }
    }
}