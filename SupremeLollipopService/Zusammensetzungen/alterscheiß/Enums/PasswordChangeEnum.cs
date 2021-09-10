using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremeLollipopService.Zusammensetzungen.Enums
{
    public class PasswordChangeEnum
    {
        public enum Password: ushort
        {
            OldPasswordNotCorrect = 0,
            NewPasswordNotMatching = 1,
            InputEmpty = 2,
            ChangedSuccessfully = 3,
            CannotUseSamePassword = 4,
            DatabaseError = 5
        }
    }
}
