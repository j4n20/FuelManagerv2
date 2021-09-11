using System;
using System.Collections.Generic;
using System.ServiceModel;
using SupremeLollipopService.Zusammensetzungen.Enums;
using SupremeLollipopService.Zusammensetzungen.Preisentwicklung;
using SupremeLollipopService.Zusammensetzungen.Verbrauch;

namespace SupremeLollipopService
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "IAuthentificationService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    [ServiceContract]
    public interface IAuthentificationService
    {
        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        FEmployee CheckCredentials(FEmployee user);
        [OperationContract]
        PasswordChangeEnum.Password ChangePassword(FEmployee user, string oldPassword, string newPassword, string repeatedNewPassword);
        [OperationContract]
        List<FEmployee> GetUsers();
        [OperationContract]
        List<Car> GetCars();
        [OperationContract]
        List<Refuel> GetRefuels();
        [OperationContract]
        List<EmployeeToCarRelation> GetEmployeeToCar();

        [OperationContract]
        void SaveOrUpdate(object o);
        [OperationContract]
        bool DeleteUser(int id);
        [OperationContract]
        bool DeleteCar(int CarId);
        [OperationContract]
        bool DeleteRefuel(int RefuelId);
        [OperationContract]
        bool DeleteEmployeeToCarRelation(FEmployee employee);
        [OperationContract]
        bool AddUser(FEmployee user);
        [OperationContract]
        bool AddCar(Car car);
        [OperationContract]
        bool AddRefuel(Refuel refuel);
        [OperationContract]
        bool AddEmployeeToCar(List<EmployeeToCarRelation> relations, FEmployee employee);
        [OperationContract]
        Verbrauch GetVerbrauch();
        [OperationContract]
        Preisentwicklung GetPreisentwicklung();


        // TODO: Hier Dienstvorgänge hinzufügen
    }

    // Verwenden Sie einen Datenvertrag, wie im folgenden Beispiel dargestellt, um Dienstvorgängen zusammengesetzte Typen hinzuzufügen.
    // Sie können im Projekt XSD-Dateien hinzufügen. Sie können nach dem Erstellen des Projekts dort definierte Datentypen über den Namespace "SupremeLollipop.ContractType" direkt verwenden.
    /*[DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }*/
}
