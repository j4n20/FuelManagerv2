using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FuelClient.Framework
{
    class BaseController
    {
        public ICommand NewCommand { get; set; }
    }
}
