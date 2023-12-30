using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Views.Product
{
    public interface IAddUnit
    {
        string SmallUnit { get; set; }
        string BigUnit { get; set; }
        string Coef { get; set; }
    }
}
