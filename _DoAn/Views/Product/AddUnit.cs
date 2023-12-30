using _DoAn.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DoAn.Views.Product
{
    public partial class AddUnit : Form, IAddUnit
    {
        AddUnitPresenter addUnitPresenter;
        ProductView productView;
        public AddUnit()
        {
            addUnitPresenter = new AddUnitPresenter(this);
            InitializeComponent();
        }

        public AddUnit(Form parent)
        {
            this.productView = (ProductView)parent;
        }

        public string SmallUnit { get => tbxSmallUnit.Text ; set => tbxSmallUnit.Text =value; }
        public string BigUnit { get =>  tbxBigUnit.Text; set => tbxBigUnit.Text = value; }
        public string Coef { get =>  tbxCoef.Text; set => tbxCoef.Text = value; }

        public void ClearData()
        {
            tbxBigUnit.Clear();
            tbxCoef.Clear();
            tbxSmallUnit.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (addUnitPresenter.AddUnit())
            {
                MessageBox.Show("Add new unit successfully!");
                ClearData();
            }
            else
            {
                MessageBox.Show("Can not add new unit !");
            }
        }
    }
}
