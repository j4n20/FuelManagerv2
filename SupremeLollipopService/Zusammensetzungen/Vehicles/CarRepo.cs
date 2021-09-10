using System.Collections.Generic;

namespace SupremeLollipopService
{
    public class CarRepo
    {
        public void Delete(int CarId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var returnList = session.QueryOver<Car>()
                        .Where(t => t.Id == CarId).List()[0];
                    session.Delete(returnList);
                    transaction.Commit();
                }
            }
        }

        public List<Car> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var result = session.QueryOver<Car>().List();
                return result as List<Car>;
            }
        }

        public Car GetCar(int ArticleId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<Car>()
                    .Where(t => t.Id == ArticleId).List()[0];
                return returnList;
            }
        }

        public void SaveOrUpdate(Car entity)
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