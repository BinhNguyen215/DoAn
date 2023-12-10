using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using _DoAn.Presenters;
using Bunifu.UI.WinForms;
using _DoAn.Presenters;
using _DoAn.Presenters.cImport;

namespace _DoAn.Views.Import
{
    public partial class ImportView : Form, IImportView
    {
        public ImportView()
        {
            InitializeComponent();
        }
        private string _id;
        private string _name;
        public string ProductId
        {
            get { return txtProductId.Text; }
            set { txtProductId.Text = value; }
        }
        public string SuplierName
        {
            get { return cbSuplier.GetItemText(cbSuplier.SelectedItem); }
            set { cbSuplier.Text = value; }
        }

        public string EmployeeID
        {
            get { return _id; }
        }

        public string TotalPriceProduct
        {
            get { return lbTotal.Text; }
            set { lbTotal.Text = value; }
        }
        public string ImportPrice
        {
            get { return txtImportPrice.Text; }
            set { txtImportPrice.Text = value; }
        }
        public string Quantity
        {
            get { return txtQuantity.Text; }
            set { txtQuantity.Text = value; }
        }
        public string Total
        {
            get { return txtTotal.Text; }
            set { txtTotal.Text = value; }
        }

        public ComboBox.ObjectCollection cbData
        {
            get
            {
                return cbSuplier.Items;
            }
        }
        private string _message;
        public string message
        {
            get { return _message; }
            set
            {
                _message = value;
            }
        }
        public string Search
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        string IImportView.ProductName
        {
            get { return txtProductName.Text; }
            set { txtProductName.Text = value; }
        }

        public string EmployeeName { get { return _name; } }

        BunifuDataGridView IImportView.gvProductData
        {
            get { return dtgvProduct; }
            set { dtgvProduct = value; }
        }
        BunifuDataGridView IImportView.gvDetailProductData
        {
            get { return dtgvData; }
            set { dtgvData = value; }
        }

        public ImportView(string id, string name) : this()
        {
            this._id = id;
            this._name = name;
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {
            ImportPresenter importPresenter = new ImportPresenter(this);
            importPresenter.GetProduct();
            importPresenter.GetSuplier();
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;
            btnCreate.Enabled = false;
        }

        private void dtgvProduct_DoubleClick(object sender, EventArgs e)
        {
            ImportPresenter importPresenter = new ImportPresenter(this);
            importPresenter.RetriveProduct(dtgvProduct.CurrentRow.Index, dtgvProduct.CurrentRow.Cells[0].Value.ToString()
                , dtgvProduct.CurrentRow.Cells[1].Value.ToString());
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            ImportPresenter importPresenter = new ImportPresenter(this);
            Command add = new AddCommand(importPresenter);
            Command delete = new DeleteCommand(importPresenter);
            Command cancel = new CancelCommand(importPresenter);
            Command edit = new EditCommand(importPresenter, 0);
            Invorker invorker = new Invorker(add, delete, cancel, edit);
            if (invorker.AddData())
            {

                btnAdd.Enabled = false;
                btnCancel.Enabled = true;
                btnCreate.Enabled = true;
            }
            else
            {
                MessageBox.Show(_message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnAdd.Enabled = true;
            }
        }
       
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            ImportPresenter importPresenter = new ImportPresenter(this);
            if (System.Text.RegularExpressions.Regex.IsMatch(txtQuantity.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Text = txtQuantity.Text.Remove(txtQuantity.Text.Length - 1);
            }
            else
                importPresenter.CalculateTotal();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ImportPresenter importPresenter = new ImportPresenter(this);
            importPresenter.SearchInformation(txtSearch.Text);
        }

        private void dtgvData_DoubleClick(object sender, EventArgs e)
        {
            ImportPresenter importPresenter = new ImportPresenter(this);
            importPresenter.RetriveData(dtgvData.CurrentRow.Index, dtgvData.CurrentRow.Cells[0].Value.ToString()
                , dtgvData.CurrentRow.Cells[1].Value.ToString(), dtgvData.CurrentRow.Cells[2].Value.ToString(),
                dtgvData.CurrentRow.Cells[3].Value.ToString(), dtgvData.CurrentRow.Cells[4].Value.ToString());
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ImportPresenter importPresenter = new ImportPresenter(this);
            Command add = new AddCommand(importPresenter);
            Command delete = new DeleteCommand(importPresenter);
            Command cancel = new CancelCommand(importPresenter);
            Command edit = new EditCommand(importPresenter, 0);
            Invorker invorker = new Invorker(add, delete, cancel, edit);
            if (invorker.DeleteData())
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                if (!importPresenter.CheckDB())
                {
                    btnCreate.Enabled = false;
                    btnCancel.Enabled = false;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ImportPresenter importPresenter = new ImportPresenter(this);
            Command edit = new EditCommand(importPresenter, dtgvData.CurrentRow.Index);
            Command add = new AddCommand(importPresenter);
            Command delete = new DeleteCommand(importPresenter);
            Command cancel = new CancelCommand(importPresenter);
            Invorker invorker = new Invorker(add, delete, cancel, edit);
            if (invorker.EditData())
            {
                btnEdit.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                MessageBox.Show(_message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ImportPresenter importPresenter = new ImportPresenter(this);
            Command add = new AddCommand(importPresenter);
            Command delete = new DeleteCommand(importPresenter);
            Command cancel = new CancelCommand(importPresenter);
            Command edit = new EditCommand(importPresenter, 0);
            Invorker invorker = new Invorker(add, delete, cancel, edit);
            if (invorker.CancelData())
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnCancel.Enabled = false;
                btnDelete.Enabled = false;
                btnCreate.Enabled = false;
            }
            else
                btnCancel.Enabled = true;
        }
        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            ImportPresenter importPresenter = new ImportPresenter(this);
            if (importPresenter.CheckSuplier())
            {
                if (importPresenter.AddDataToDB())
                {
                    DialogResult dr = MessageBox.Show(_message, "Notification", MessageBoxButtons.YesNo,
                  MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                        PrintDialog printDialog = new PrintDialog();

                        PrintDocument printDocument = new PrintDocument();

                        printDialog.Document = printDocument;
                        printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(Createform);
                        DialogResult result = printDialog.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            printDocument.Print();

                        }
                    }
                    importPresenter.ClearData();
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnCancel.Enabled = false;
                    btnDelete.Enabled = false;
                    btnCreate.Enabled = false;
                }
                else
                {
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show(_message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        } 
    
  
        public void Createform(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ImportPresenter importPresenter = new ImportPresenter(this);
            importPresenter.Print(e);
        }

        private void dtgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //btnDelete.Enabled = true;
        }

        private void txtImportPrice_TextChanged(object sender, EventArgs e)
        {
            ImportPresenter importPresenter = new ImportPresenter(this);
            if (System.Text.RegularExpressions.Regex.IsMatch(txtImportPrice.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtImportPrice.Text = txtImportPrice.Text.Remove(txtImportPrice.Text.Length - 1);
            }
            else
                importPresenter.CalculateTotal();
        }

        private void dtgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
