using System.Collections.Generic;

namespace SupremeLollipopService
{
    public class RefuelRepo
    {
        public void Delete(int OrderId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var returnList = session.QueryOver<Refuel>()
                        .Where(t => t.Id == OrderId).List()[0];
                    session.Delete(returnList);
                    transaction.Commit();
                }
            }
        }

        public List<Refuel> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var result = session.QueryOver<Refuel>().List();
                return result as List<Refuel>;
            }
        }

        public Refuel GetOrder(int OrderId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<Refuel>()
                    .Where(t => t.Id == OrderId).List()[0];
                return returnList;
            }
        }

        public void SaveOrUpdate(Refuel entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
            }
        }
    }
}