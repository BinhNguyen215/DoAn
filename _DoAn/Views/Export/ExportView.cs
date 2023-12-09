using _DoAn.Presenters;
using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DoAn.Views.Export
{
    public partial class ExportView : Form, IExport
    {
        private string _id;
        private string _name;
        private string _message;
        public string ProductId { get => tbxProductID.Text; set => tbxProductID.Text = value; }
        string IExport.ProductName { get => tbxProductName.Text; set => tbxProductName.Text = value; }

        public string EmployeeID => _id;

        public string TotalPriceProduct { get => lbTotal.Text; set => lbTotal.Text = value; }
        public string ExportPrice { get => tbxUnitPrice.Text; set => tbxUnitPrice.Text = value; }
        public string Quantity { get => tbxQuantity.Text; set => tbxQuantity.Text = value; }
        string IExport.Total { get => tbxTotalPrice.Text; set => tbxTotalPrice.Text = value; }
        public string message { get => _message; set => _message = value; }
        public string Search { get => tbxSearch.Text; set => tbxSearch.Text = value; }
        public string ExportReason { get => tbxReasonExport.Text; set => tbxReasonExport.Text = value; }

        public string EmployeeName => _name;

        public BunifuDataGridView gvProductData { get => dtgvProduct; set => dtgvProduct = value; }
        public BunifuDataGridView gvDetailProductData { get => dtgvData; set => dtgvData = value; }

        public ExportView()
        {
            InitializeComponent();
        }

        public ExportView(string id, string name) : this()
        {
            this._id = id;
            this._name = name;
        }
        private void ExportForm_Load(object sender, EventArgs e)
        {
            ExportPresenter exportPresenter = new ExportPresenter(this);
            exportPresenter.GetProduct();
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;
            btnCreateForm.Enabled = false;
        }

        private void dtgvProduct_DoubleClick(object sender, EventArgs e)
        {
            ExportPresenter exportPresenter = new ExportPresenter(this);
            exportPresenter.RetriveProduct(dtgvProduct.CurrentRow.Index, dtgvProduct.CurrentRow.Cells[0].Value.ToString()
                , dtgvProduct.CurrentRow.Cells[1].Value.ToString(), dtgvProduct.CurrentRow.Cells[2].Value.ToString());
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }


        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            ExportPresenter exportPresenter = new ExportPresenter(this);
            if (exportPresenter.AddDataToDataGridview())
            {
                exportPresenter.CalculateTotalPrice();
                exportPresenter.ClearInformation();
                btnAdd.Enabled = false;
                btnCancel.Enabled = true;
                btnCreateForm.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = true;
                MessageBox.Show(_message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void dtgvData_DoubleClick(object sender, EventArgs e)
        {

            ExportPresenter exportPresenter = new ExportPresenter(this);
            exportPresenter.RetriveData(dtgvData.CurrentRow.Index, dtgvData.CurrentRow.Cells[0].Value.ToString()
                , dtgvData.CurrentRow.Cells[1].Value.ToString(), dtgvData.CurrentRow.Cells[2].Value.ToString(),
                dtgvData.CurrentRow.Cells[3].Value.ToString(), dtgvData.CurrentRow.Cells[4].Value.ToString());
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

        }
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            ExportPresenter exportPresenter = new ExportPresenter(this);
            if (exportPresenter.EditData(dtgvData.CurrentRow.Index))
            {
                btnEdit.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                exportPresenter.CalculateTotalPrice();
                exportPresenter.ClearInformation();
            }
            else
            {
                MessageBox.Show(_message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            ExportPresenter exportPresenter = new ExportPresenter(this);
            if (exportPresenter.DeleteDatainDataGridview())
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;

                if (!exportPresenter.CheckDB())
                {
                    btnCreateForm.Enabled = false;
                    btnCancel.Enabled = false;
                }
                exportPresenter.CalculateTotalPrice();
                exportPresenter.ClearInformation();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ExportPresenter exportPresenter = new ExportPresenter(this);
            if (exportPresenter.CheckReason())
            {
                if (exportPresenter.AddDataToDB())
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
                    exportPresenter.ClearData();
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnCancel.Enabled = false;
                    btnDelete.Enabled = false;
                    btnCreateForm.Enabled = false;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ExportPresenter exportPresenter = new ExportPresenter(this);
            if (exportPresenter.ClearData())
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnCancel.Enabled = false;
                btnDelete.Enabled = false;
                btnCreateForm.Enabled = false;
            }
            else
                btnCancel.Enabled = true;
        }
        public void Createform(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ExportPresenter exportPresenter = new ExportPresenter(this);
            exportPresenter.Print(e);
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            ExportPresenter exportPresenter = new ExportPresenter(this);
            exportPresenter.SearchInformation(tbxSearch.Text);
        }

        private void tbxQuantity_TextChanged(object sender, EventArgs e)
        {

            ExportPresenter exportPresenter = new ExportPresenter(this);
            if (System.Text.RegularExpressions.Regex.IsMatch(tbxQuantity.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxQuantity.Text = tbxQuantity.Text.Remove(tbxQuantity.Text.Length - 1);
            }
            else
                exportPresenter.CalculateTotal();

        }

       







        /* private void dtgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
{
// btnDelete.Enabled = true;
}*/

        /* private void dtgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {

         }*/

    }
}
