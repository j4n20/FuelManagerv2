using System.Collections.Generic;

namespace SupremeLollipopService
{
    public class EmployeeToCarsRelationsRepositorium
    {
        public void Delete(int EmployeeToAreaRelationId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var returnList = session.QueryOver<EmployeeToCarRelation>()
                        .Where(t => t.Id == EmployeeToAreaRelationId).List()[0];
                    session.Delete(returnList);
                    transaction.Commit();
                }
            }
        }

        public List<EmployeeToCarRelation> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var result = session.QueryOver<EmployeeToCarRelation>().List();
                return result as List<EmployeeToCarRelation>;
            }
        }

        public EmployeeToCarRelation GetEmployeeToAreaRelation(int EmployeeToAreaRelationId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<EmployeeToCarRelation>()
                    .Where(t => t.Id == EmployeeToAreaRelationId).List()[0];
                return returnList;
            }
        }

        public void SaveOrUpdate(EmployeeToCarRelation entity)
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