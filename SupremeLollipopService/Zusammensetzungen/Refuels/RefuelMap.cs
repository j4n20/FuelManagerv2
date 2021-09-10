using FluentNHibernate.Mapping;

namespace SupremeLollipopService
{
    public class RefuelMap : ClassMap<Refuel>
    {
        public RefuelMap()
        {
            Table("Refuels");
            Id(x => x.Id).GeneratedBy.Native().Default(0);

            Map(x => x.Mileage).Length(100).Unique().Not.Nullable();
            Map(x => x.Date).Length(100).Not.Nullable();
            Map(x => x.Amount).Length(100).Not.Nullable();
            Map(x => x.Price).Length(100).Not.Nullable();

            References(x => x.Car).Column("CarId").Not.Nullable();

            Version(x => x.Version).Generated.Always().UnsavedValue("0").Access.Property();

            DynamicUpdate();
            OptimisticLock.Version();
        }
    }
}