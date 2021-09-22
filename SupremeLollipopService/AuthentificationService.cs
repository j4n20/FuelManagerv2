using System;
using System.Collections.Generic;
using System.Linq;
using SupremeLollipopService.Zusammensetzungen.Enums;
using SupremeLollipopService.Zusammensetzungen.Preisentwicklung;
using SupremeLollipopService.Zusammensetzungen.Verbrauch;



namespace SupremeLollipopService
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Klassennamen "AuthentificationService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    public class AuthentificationService : IAuthentificationService
    {
        /*public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }*/

        public List<Verbrauch> GetVerbrauch(Car car)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                //x => new {x.OrderDate.Year, x.OrderDate.Month}

                return session.Query<Refuel>().Where(x => x.Car.Id == car.Id).GroupBy(x => new { x.Date.Year, x.Date.Month }).Select(g => new Verbrauch()
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Car = car,
                    LastMileage = float.Parse(g.Max(i => i.Mileage)),
                    FirstMileage = float.Parse(g.Min(i => i.Mileage)),
                    AverageVerbrauch = g.Sum(i => i.Amount) / (float.Parse(g.Max(i => i.Mileage)) - float.Parse(g.Min(i => i.Mileage))) * 100
                    // i.Mileage.LastOrDefault(y => y.Equals() - i.Mileage.FirstOrDefault())
                }).OrderByDescending(g => g.Month).ToList();
            }
        }


            public List<Verbrauch> GetPreisentwicklung(Car car)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                //x => new {x.OrderDate.Year, x.OrderDate.Month}

                return session.Query<Refuel>().Where(x => x.Car.Id == car.Id).GroupBy(x => new { x.Date.Year, x.Date.Month }).Select(g => new Verbrauch()
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Car = car,
                    AveragePreis = g.Sum(i => i.Price) / g.Sum(i => i.Amount)
                    // i.Mileage.LastOrDefault(y => y.Equals() - i.Mileage.FirstOrDefault())
                }).OrderByDescending(g => g.Month).ToList();
            }
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

        public List<EmployeeToCarRelation> GetEmployeeToCarById(FEmployee employee)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var result = session.QueryOver<EmployeeToCarRelation>().Where(t => t.FEmployee.Id == employee.Id).List();
                return result as List<EmployeeToCarRelation>;
            }
        }

        public List<Refuel> GetRefuelById(Car car)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var result = session.QueryOver<Refuel>().Where(t => t.Car.Id == car.Id).List();
                return result as List<Refuel>;
            }
        }

        public List<Car> GetUnconnectedCars()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var employeeToCarRelations = session.QueryOver<EmployeeToCarRelation>().List();
                List<Car> usedCars = new List<Car>();
                foreach (var entry in employeeToCarRelations)
                {
                    usedCars.Add(entry.Car);
                }
                var cars = session.QueryOver<Car>().List();
                List<Car> unconnectedCars = new List<Car>();

                foreach (var car in cars)
                {
                    if (!usedCars.Contains(car))
                    {
                        unconnectedCars.Add(car);
                    }
                }
                return unconnectedCars;
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
                        var returnList = session.QueryOver<Refuel>()
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

        public bool AddRefuelXML(DateTime date, string mileage, float amount, float price)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var checkedrefuel = session.QueryOver<Refuel>().SingleOrDefault();
                using (var transaction = session.BeginTransaction())
                {
                    checkedrefuel.Mileage = mileage;
                    checkedrefuel.Date = date;
                    checkedrefuel.Amount = amount;
                    checkedrefuel.Price = price;
                    //checkedrefuel.Car.Id = carId;
                    //checkedrefuel.Id = ;

                    session.SaveOrUpdate(checkedrefuel);
                    transaction.Commit();
                    return true;
                }
            }
        }

        
        public bool AddEmployeeToCar(EmployeeToCarRelation relation)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var checkedEmpToCar = session.QueryOver<EmployeeToCarRelation>().Where(x => x.Id == relation.Id).SingleOrDefault();
                        if (checkedEmpToCar != null)
                        {
                            if (checkedEmpToCar.Id != 0)
                            {
                                try
                                {

                                    checkedEmpToCar.Car = relation.Car;
                                    checkedEmpToCar.FEmployee = relation.FEmployee;

                                    checkedEmpToCar.Id = relation.Id;

                                    session.SaveOrUpdate(checkedEmpToCar);
                                    transaction.Commit();
                                    return true;

                                }

                                catch
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {

                            session.SaveOrUpdate(relation);
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

        public bool DeleteEmployeeToCarRelation(Car car)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var returnList = session.QueryOver<EmployeeToCarRelation>()
                      .Where(t => t.Car.Id == car.Id).List();
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
