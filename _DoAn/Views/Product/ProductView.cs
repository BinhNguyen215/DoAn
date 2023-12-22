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
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            setEnableF();
        }
        private void setEnableF ()
        {
            txtDescription.Enabled = false;
            txtOriginal.Enabled = false;
            txtProductName.Enabled = false;
            txtProductId.Enabled = false;
            txtPrice.Enabled = false;
            cbProductType.Enabled = false;
            cbUnit.Enabled = false;
        }
        private void setEnableT()
        {
            txtDescription.Enabled = true;
            txtOriginal.Enabled = true;
            txtProductName.Enabled = true;
            txtPrice.Enabled = true;
            cbProductType.Enabled = true;
            cbUnit.Enabled = true;
            
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
        int index = 0;// xem đã ấn nút add chưa 1 - có, 0 - chưa, 2 - ấn edit rồi
        private void btnAdd_Click(object sender, EventArgs e)
        {
            setEnableT();
            lbNofiWrite.Visible = true;
            index = 1;
            btnVisible(false, false, false);
            btnDone.Enabled= false;
            btnDone.Visible = true;
            ProductPresenter productPresenter = new ProductPresenter(this);
            productPresenter.ClearInformation();
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
            setEnableT();
            index = 2;
            btnAdd.Visible=false;
            btnEdit.Visible=false;
            btnDelete.Visible=false;
            btnDone.Visible = true;
            btnDone.Enabled=true;
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

            if(index==1)
            {
                if (productPresenter.CheckInformation())
                {
                    btnDone.Enabled = true;
                }    
                else
                {
                    btnDone.Enabled = false;
                }    
            }   
            if(!string.IsNullOrEmpty(cbUnit.Text))//*
            {
                string[] unitSlip= cbUnit.Text.Split('/');
                lbUnitSmall.Text = unitSlip[0];
                lbUnitBig.Text = unitSlip[1];
            }
            else
            {
                lbUnitBig.Text = "Undefine";
                lbUnitSmall.Text = "Undefine";
            }
        }
        private void btnVisible(bool add,bool edit,bool delete)//*
        {
            btnAdd.Visible = add;
            btnEdit.Visible = edit;
            btnDelete.Visible = delete;
        }
        private void btnEnable(bool add, bool edit, bool delete)//*
        {
            btnAdd.Enabled = add;
            btnEdit.Enabled = edit;
            btnDelete.Enabled = delete;
        }
        private void dtgvProduct_DoubleClick(object sender, EventArgs e)
        {
            index = 0; // dùng để phân biệt xem sự kiện click của nút nào gọi btnDone
            setEnableF();
            if (dtgvProduct.CurrentRow.Cells[0].Value.ToString() != "")
            {
                btnVisible(true, true, true);
                btnDone.Visible = false;
                btnEnable(true, true, true);
                lbNofiWrite.Visible = false;
            }
            else
            {
                btnEnable(false, false, false);
                lbNofiWrite.Visible = true;
            }
            //*
            ProductPresenter productPresenter = new ProductPresenter(this);
            productPresenter.RetriveProduct(dtgvProduct.CurrentRow.Index, dtgvProduct.CurrentRow.Cells[0].Value.ToString()
                , dtgvProduct.CurrentRow.Cells[1].Value.ToString(), dtgvProduct.CurrentRow.Cells[2].Value.ToString(),
                dtgvProduct.CurrentRow.Cells[3].Value.ToString(), dtgvProduct.CurrentRow.Cells[4].Value.ToString(),
                dtgvProduct.CurrentRow.Cells[5].Value.ToString() +"/"+ dtgvProduct.CurrentRow.Cells[6].Value.ToString(), dtgvProduct.CurrentRow.Cells[7].Value.ToString());
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            if (index == 1)
            {
                ProductPresenter productPresenter = new ProductPresenter(this);
                if (productPresenter.AddData())
                {
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    productPresenter.ClearInformation();
                    productPresenter.GetProduct();
                    productPresenter.ClearInformation();
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                index = 0;
            }
            
            if (index==2) //ấn edit
            {
                ProductPresenter productPresenter = new ProductPresenter(this);
                if (productPresenter.CheckInformationEdit())
                {
                    if (productPresenter.EditData())
                    {
                        MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        productPresenter.GetProduct();
                        productPresenter.ClearInformation();
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
                index = 0;
            }
            btnVisible(true, true, true);
            btnDone.Visible = false;
            setEnableF();
            lbNofiWrite.Visible = false;

        }
    }
}
