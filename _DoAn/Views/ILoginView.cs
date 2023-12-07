using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Views
{
    public interface ILoginView
    {
       string username { get; set; }
       string password { get; set; }
       string message { get; set; }
    }
}
