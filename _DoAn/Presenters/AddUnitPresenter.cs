using _DoAn.Models;
using _DoAn.Views.Accountant;
using _DoAn.Views.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Presenters
{
    public class AddUnitPresenter
    {
        IAddUnit addUnitView;
        Product product = new Product();

        public AddUnitPresenter(IAddUnit addUnitView)
        {
            this.addUnitView = addUnitView;
        }

        public bool AddUnit()
        {
            if (product.AddUnitToDB(addUnitView.BigUnit,addUnitView.SmallUnit,addUnitView.Coef))
            {
                return true;
            }
            return false;
        }
    }
}
