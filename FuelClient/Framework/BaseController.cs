using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SupremeLollipopClient.Framework
{
    class BaseController
    {
        public ICommand NewCommand { get; set; }
    }
}
