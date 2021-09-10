using FluentNHibernate.Mapping;
namespace SupremeLollipopService
{
    public class EmployeeToCarRelationMap : ClassMap<EmployeeToCarRelation>
    {
        public EmployeeToCarRelationMap()
        {
            Table("EmployeeToAreaRelations");

            Id(x => x.Id).GeneratedBy.Native().Default(0);

            References<Car>(x => x.Area).Column("CarId").Not.Nullable();
            References<FEmployee>(x => x.Employee).Column("EmployeeId").Not.Nullable();
        }
    }
}