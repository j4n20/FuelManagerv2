using System;
using System.Collections.Generic;
using SupremeLollipopService.Zusammensetzungen.Enums;
using SupremeLollipopService.Zusammensetzungen.Verbrauch;
using SupremeLollipopService.Zusammensetzungen.Preisentwicklung;


namespace SupremeLollipopService
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Klassennamen "AuthentificationService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    public class AuthentificationService : IAuthentificationService
    {
        /*public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }*/

        public Verbrauch GetVerbrauch() {
            return null;
        }

        public Preisentwicklung GetPreisentwicklung()
        {
            return null;
        }

        public FEmployee CheckCredentials(FEmployee user)
        {
            user.Username = user.Username.ToLower();
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnUser = session.QueryOver<FEmployee>()
                   .Where(t => t.Username == user.Username).SingleOrDefault();
                if (returnUser != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(user.Password, returnUser.Password))
                    {
                        return returnUser;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public PasswordChangeEnum.Password ChangePassword(FEmployee user, string oldPassword, string newPassword, string repeatedNewPassword)
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                try
                {
                    var returnUser = session.QueryOver<FEmployee>()
                        .Where(t => t.Username == user.Username).SingleOrDefault();
                    if (newPassword != user.Password)// && newPassword != "" && repeatedNewPassword == newPassword)
                    {
                        if (newPassword != "")
                        {
                            if (repeatedNewPassword == newPassword)
                            {
                                if (BCrypt.Net.BCrypt.Verify(oldPassword, returnUser.Password))
                                {
                                    using (var transaction = session.BeginTransaction())
                                    {
                                        try
                                        {
                                            returnUser.Password = BCrypt.Net.BCrypt.ValidateAndReplacePassword(oldPassword, returnUser.Password, newPassword);
                                            session.Update(returnUser);
                                            transaction.Commit();
                                            return PasswordChangeEnum.Password.ChangedSuccessfully;
                                        }

                                        catch (Exception e)
                                        {
                                            return PasswordChangeEnum.Password.DatabaseError;
                                        }
                                    }
                                }
                                else
                                {
                                    return PasswordChangeEnum.Password.OldPasswordNotCorrect;
                                }
                            }
                            else
                            {
                                return PasswordChangeEnum.Password.NewPasswordNotMatching;
                            }

                        }
                        else
                        {
                            return PasswordChangeEnum.Password.InputEmpty;
                        }

                    }
                    else
                    {
                        return PasswordChangeEnum.Password.CannotUseSamePassword;
                    }
                }
                catch (Exception e)
                {

                    return PasswordChangeEnum.Password.InputEmpty;
                }

            }
        }
        public List<FEmployee> GetUsers()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var result = session.QueryOver<FEmployee>().List();
                return result as List<FEmployee>;
            }

        }

        public List<Car> GetCars()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var result = session.QueryOver<Car>().List();
                return result as List<Car>;
            }
        }

        public List<Refuel> GetRefuels()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var result = session.QueryOver<Car>().List();
                return result as List<Refuel>;
            }
        }

        public List<EmployeeToCarRelation> GetEmployeeToCar()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var result = session.QueryOver<EmployeeToCarRelation>().List();
                return result as List<EmployeeToCarRelation>;
            }
        }

        public List<Car> GetEmployeeToCarById(FEmployee employee)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var result = session.QueryOver<EmployeeToCarRelation>().Where(t => t.FEmployee.Id == employee.Id).List();
                return result as List<Car>;
            }
        }

        public void SaveOrUpdate(object o)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(o);
                    transaction.Commit();
                }
            }
        }
        public bool DeleteUser(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var returnList = session.QueryOver<FEmployee>()
                      .Where(t => t.Id == id).List()[0];
                        session.Delete(returnList);
                        transaction.Commit();
                        return true;
                    }
                    catch (NHibernate.Exceptions.GenericADOException)
                    {
                        return false;
                    }

                }
            }
        }

        public bool DeleteCar(int CarId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var returnList = session.QueryOver<Car>()
                      .Where(t => t.Id == CarId).List()[0];
                        session.Delete(returnList);
                        transaction.Commit();
                        return true;
                    }
                    catch (NHibernate.Exceptions.GenericADOException)
                    {
                        return false;
                    }

                }
            }
        }

        public bool DeleteRefuel(int RefuelId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var returnList = session.QueryOver<Car>()
                      .Where(t => t.Id == RefuelId).List()[0];
                        session.Delete(returnList);
                        transaction.Commit();
                        return true;
                    }
                    catch (NHibernate.Exceptions.GenericADOException)
                    {
                        return false;
                    }

                }
            }
        }

        public bool AddUser(FEmployee user)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    var checkeduser = session.QueryOver<FEmployee>().Where(x => x.Id == user.Id).SingleOrDefault();
                    if (checkeduser != null)
                    {
                        if (user.Id != 0)
                        {
                            user.Password = checkeduser.Password;
                            using (var transaction = session.BeginTransaction())
                            {
                                checkeduser.Username = user.Username;
                                checkeduser.Firstname = user.Firstname;
                                checkeduser.Lastname = user.Lastname;
                                checkeduser.Password = user.Password;
                                checkeduser.EmployeeNo = user.EmployeeNo;
                                checkeduser.isAdmin = user.isAdmin;
                                checkeduser.Id = user.Id;

                                session.SaveOrUpdate(checkeduser);
                                transaction.Commit();
                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        String passwort = BCrypt.Net.BCrypt.HashPassword(user.Password);
                        user.Password = passwort;
                        using (var transaction = session.BeginTransaction())
                        {
                            session.SaveOrUpdate(user);
                            transaction.Commit();
                            return true;
                        }
                    }
                }
            }
            catch (NHibernate.Exceptions.GenericADOException)
            {
                return false;
            }
        }


        public bool AddCar(Car car)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    var checkedcar = session.QueryOver<Car>().Where(x => x.Id == car.Id).SingleOrDefault();
                    if (checkedcar != null)
                    {
                        if (car.Id != 0)
                        {
                            using (var transaction = session.BeginTransaction())
                            {
                                checkedcar.LicensePlate = car.LicensePlate;
                                checkedcar.Vendor = car.Vendor;
                                checkedcar.Model = car.Model;
                                checkedcar.Id = car.Id;

                                session.SaveOrUpdate(checkedcar);
                                transaction.Commit();
                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        using (var transaction = session.BeginTransaction())
                        {
                            session.SaveOrUpdate(car);
                            transaction.Commit();
                            return true;
                        }
                    }
                }
            }
            catch (NHibernate.Exceptions.GenericADOException)
            {
                return false;
            }
        }

        public bool AddRefuel(Refuel refuel)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    var checkedrefuel = session.QueryOver<Refuel>().Where(x => x.Id == refuel.Id).SingleOrDefault();
                    if (checkedrefuel != null)
                    {
                        if (refuel.Id != 0)
                        {
                            using (var transaction = session.BeginTransaction())
                            {
                                checkedrefuel.Mileage = refuel.Mileage;
                                checkedrefuel.Date = refuel.Date;
                                checkedrefuel.Amount = refuel.Amount;
                                checkedrefuel.Price = refuel.Price;
                                checkedrefuel.Car = refuel.Car;
                                checkedrefuel.Id = refuel.Id;

                                session.SaveOrUpdate(checkedrefuel);
                                transaction.Commit();
                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        using (var transaction = session.BeginTransaction())
                        {
                            session.SaveOrUpdate(refuel);
                            transaction.Commit();
                            return true;
                        }
                    }
                }
            }
            catch (NHibernate.Exceptions.GenericADOException)
            {
                return false;
            }
        }

        public bool AddEmployeeToCar(List<EmployeeToCarRelation> relations, FEmployee employee)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    try
                    {
                        var deleteList = session.QueryOver<EmployeeToCarRelation>().Where(x => x.FEmployee.Id == employee.Id).List();
                        foreach (var x in deleteList)
                        {
                            session.Delete(x);

                        }
                        transaction.Commit();
                        session.Clear();
                        relations.ForEach(a => session.Save(a));
                        return true;
                    }

                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public bool DeleteEmployeeToCarRelation(FEmployee employee)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var returnList = session.QueryOver<EmployeeToCarRelation>()
                      .Where(t => t.FEmployee.Id == employee.Id).List();
                        foreach (var relation in returnList)
                        {
                            session.Delete(relation);
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (NHibernate.Exceptions.GenericADOException)
                    {
                        return false;
                    }
                }
            }
        }

        /*public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }*/

    }
}
