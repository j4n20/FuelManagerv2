using FluentNHibernate.Mapping;

namespace SupremeLollipopService
{
    public class CarMap : ClassMap<Car>
    {
        public CarMap()
        {
            Table("Cars");
            Id(x => x.Id).GeneratedBy.Native().Default(0);
            Map(x => x.Model).Length(100).Unique().Not.Nullable();
            Map(x => x.LicensePlate).Length(100).Not.Nullable();
            Map(x => x.Vendor).Length(100).Not.Nullable();
            Version(x => x.Version).Generated.Always().UnsavedValue("0").Access.Property();

            DynamicUpdate();
            OptimisticLock.Version();
        }
    }
}