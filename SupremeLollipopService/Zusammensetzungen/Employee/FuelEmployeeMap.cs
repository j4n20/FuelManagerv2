using FluentNHibernate.Mapping;

namespace SupremeLollipopService
{
    public class FuelEmployeeMap : ClassMap<User>
    {
        public FuelEmployeeMap()
        {
            Table("Users");
            Id(x => x.Id).GeneratedBy.Native().Default(0);
            Map(x => x.Username).Length(100).Unique().Not.Nullable();
            Map(x => x.Firstname).Length(100).Not.Nullable();
            Map(x => x.Lastname).Length(100).Not.Nullable();
            Map(x => x.isAdmin).Not.Nullable();
            Map(x => x.Password).Length(100).Not.Nullable();

            Version(x => x.Version).Generated.Always().UnsavedValue("0").Access.Property();
            DynamicUpdate();
            OptimisticLock.Version();
        }
    }
}