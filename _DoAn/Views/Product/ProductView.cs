using _DoAn.Presenters;
using Bunifu.UI.WinForms;
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
    public partial class ProductView : Form, IProductView
    {
        public ProductView()
        {
            InitializeComponent();
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {

        }
        public ComboBox.ObjectCollection cbData
        {
            get
            {
                return cbProductType.Items;
            }
        }

        string IProductView.ProductID
        {
            get { return (txtProductId.Text); }
            set { txtProductId.Text = value.ToString(); }
        }
        string IProductView.ProductName
        {
            get { return txtProductName.Text; }
            set { txtProductName.Text = value; }
        }
        string IProductView.Price
        {
            get { return (txtPrice.Text); }
            set { txtPrice.Text = value.ToString(); }
        }
        string IProductView.Unit
        {
            get { return cbUnit.Text; }
            set { cbUnit.Text = value; }
        }
        string IProductView.Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
        string IProductView.Original
        {
            get { return txtOriginal.Text; }
            set { txtOriginal.Text = value; }
        }
        string IProductView.ProductType
        {
            get { return cbProductType.GetItemText(cbProductType.SelectedItem); }
            set { cbProductType.Text = value; }
        }
        private string _message;
        string IProductView.message
        {
            get { return _message; }
            set
            {
                _message = value;
            }
        }
        BunifuDataGridView IProductView.gvData
        {
            get { return dtgvProduct; }
            set { dtgvProduct = value; }
        }

        private void ProductView_Load(object sender, EventArgs e)
        {
            ProductPresenter productPresenter = new ProductPresenter(this);
            productPresenter.GetProductType();
            productPresenter.GetProduct();
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void ProductView_DoubleClick(object sender, EventArgs e)
        {
            if (dtgvProduct.CurrentRow.Cells[0].Value.ToString() != "")
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }

            ProductPresenter productPresenter = new ProductPresenter(this);
            productPresenter.RetriveProduct(dtgvProduct.CurrentRow.Index, dtgvProduct.CurrentRow.Cells[0].Value.ToString()
                , dtgvProduct.CurrentRow.Cells[1].Value.ToString(), dtgvProduct.CurrentRow.Cells[2].Value.ToString(),
                dtgvProduct.CurrentRow.Cells[3].Value.ToString(), dtgvProduct.CurrentRow.Cells[4].Value.ToString(),
                dtgvProduct.CurrentRow.Cells[5].Value.ToString(), dtgvProduct.CurrentRow.Cells[6].Value.ToString());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductPresenter productPresenter = new ProductPresenter(this);
            if (productPresenter.AddData())
            {
                MessageBox.Show(_message, "Notification", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                productPresenter.ClearInformation();
                productPresenter.GetProduct();
                productPresenter.ClearInformation();
            }
            else
            {
                MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this product?", "Question", MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                ProductPresenter productPresenter = new ProductPresenter(this);
                if (productPresenter.DeleteData())
                {
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    productPresenter.GetProduct();
                    productPresenter.ClearInformation();
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    lbNofiWrite.Visible = true;
                }
                else
                {
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ProductPresenter productPresenter = new ProductPresenter(this);
            if (productPresenter.CheckInformationEdit())
            {
                if (productPresenter.EditData())
                {
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    productPresenter.GetProduct();
                    productPresenter.ClearInformation();
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    lbNofiWrite.Visible = true;
                }
                else
                {
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Please check information again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnEdit.Enabled = true;
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            ProductPresenter productPresenter = new ProductPresenter(this);
            if (System.Text.RegularExpressions.Regex.IsMatch(txtPrice.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Text = txtPrice.Text.Remove(txtPrice.Text.Length - 1);
            }
            if (txtProductName.Text.Length > 0)
            { 
                lbNofiWrite.Visible= false;
            }
            else
                lbNofiWrite.Visible = true;

            if (productPresenter.CheckInformation())
            {
                btnAdd.Enabled = true;
            }    
            else
            {
                btnAdd.Enabled = false;
            }    
        }

        private void dtgvProduct_DoubleClick(object sender, EventArgs e)
        {
            if (dtgvProduct.CurrentRow.Cells[0].Value.ToString() != "")
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                lbNofiWrite.Visible = false;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                lbNofiWrite.Visible = true;
            }

            ProductPresenter productPresenter = new ProductPresenter(this);
            productPresenter.RetriveProduct(dtgvProduct.CurrentRow.Index, dtgvProduct.CurrentRow.Cells[0].Value.ToString()
                , dtgvProduct.CurrentRow.Cells[1].Value.ToString(), dtgvProduct.CurrentRow.Cells[2].Value.ToString(),
                dtgvProduct.CurrentRow.Cells[3].Value.ToString(), dtgvProduct.CurrentRow.Cells[4].Value.ToString(),
                dtgvProduct.CurrentRow.Cells[5].Value.ToString(), dtgvProduct.CurrentRow.Cells[6].Value.ToString());
        }
    }
}
