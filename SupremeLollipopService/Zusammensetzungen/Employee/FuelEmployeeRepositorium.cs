using System.Collections.Generic;

namespace SupremeLollipopService
{
    public class FuelEmployeeRepositorium
    {
        public void Delete(int CustomerId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var returnList = session.QueryOver<User>()
                        .Where(t => t.Id == CustomerId).List()[0];
                    session.Delete(returnList);
                    transaction.Commit();
                }
            }
        }

        public List<User> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var result = session.QueryOver<User>().List();
                return result as List<User>;
            }
        }

        public User GetCustomer(int CustomerId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<User>()
                    .Where(t => t.Id == CustomerId).List()[0];
                return returnList;
            }
        }

        public void SaveOrUpdate(User entity)
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