using _DoAn.Presenters;
using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace _DoAn.Views.Supplier
{
    public partial class SupplierView : Form,ISupplier
    {
        SupplierPresenter suplierPresenter ;

        public SupplierView()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            suplierPresenter = new SupplierPresenter(this);
        }

        public string SuplierId { get => tbxSuplierId.Text; set => tbxSuplierId.Text = value; }
        public string SuplierName { get => tbxSupplierName.Text; set => tbxSupplierName.Text = value; }
        public string SuplierPhone { get => tbxPhoneNumber.Text; set => tbxPhoneNumber.Text = value; }
        public string SuplierAddress { get => tbxAddress.Text; set => tbxAddress.Text = value; }
        public string SuplierEmail { get => tbxEmail.Text; set => tbxEmail.Text = value; }
        private string _message;
        public string message { get => _message; set => _message = value; }
        public BunifuDataGridView gvData { get => dtgvSupplier; set => dtgvSupplier = value; }

        private void SuplierForm_Load(object sender, EventArgs e)
        {
            suplierPresenter.GetSuplier();
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dtgvsuplier_DoubleClick(object sender, EventArgs e)
        {

            suplierPresenter.RetriveSuplier(dtgvSupplier.CurrentRow.Index, dtgvSupplier.CurrentRow.Cells[0].Value.ToString()
                , dtgvSupplier.CurrentRow.Cells[1].Value.ToString(), dtgvSupplier.CurrentRow.Cells[2].Value.ToString(),
                dtgvSupplier.CurrentRow.Cells[3].Value.ToString(), dtgvSupplier.CurrentRow.Cells[4].Value.ToString());
            if (dtgvSupplier.CurrentRow.Cells[0].Value.ToString() != "")
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (suplierPresenter.AddData())
            {
                MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                suplierPresenter.ClearInformation();
                suplierPresenter.GetSuplier();
            }
            else
            {
                MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAdd.Enabled = true;
            }
        }
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (suplierPresenter.CheckInformationEdit())
            {
                if (suplierPresenter.EditData())
                {
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    suplierPresenter.ClearInformation();
                    suplierPresenter.GetSuplier();
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
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this supplier?", "Question", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (suplierPresenter.DeleteData())
                {
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    suplierPresenter.GetSuplier();
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    suplierPresenter.ClearInformation();
                }
            }
        }

        private void tbxSupplierName_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbxPhoneNumber.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxPhoneNumber.Text = tbxPhoneNumber.Text.Remove(tbxPhoneNumber.Text.Length - 1);
            }
            
            if (suplierPresenter.CheckInformation())
                btnAdd.Enabled = true;
            else
                btnAdd.Enabled = false;
        }

        private void tbxEmail_Leave(object sender, EventArgs e)
        {
            string email = tbxEmail.Text.Trim();

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(email, emailPattern) && !string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email is not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxEmail.Focus();
            }
        }
    }
}
