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

namespace _DoAn.Views.Accountant
{
    public partial class AddReceiptsForm : Form, IAddReceiptsForm
    {
        private string _id;
        private bool _isNew; //có phải phiếu mới hay ko, true là phiếu mới, false là chỉnh sửa phiếu cũ
        private string receipts_id;
        public AddReceiptsForm()
        {
            InitializeComponent();
        }
        public string Employee
        {
            get { return _id; }
        }

        public string Receipts_id
        {
            get { return receipts_id; }
        }
        public AddReceiptsForm(bool isNew, string id) : this()
        {
            this._isNew = isNew;
            this._id = id;
        }

        public AddReceiptsForm(bool isNew, string employee_id, string receipts_id, string content, string value, string date, string status) : this()
        {
            this._isNew = isNew;
            this._id = employee_id;
            this.receipts_id = receipts_id;

            AddReceiptsPresenter addReceiptsPresenter = new AddReceiptsPresenter(this);
            addReceiptsPresenter.RetriveData(content, value, date, status);

        }
        public string Content
        {
            get { return txtContent.Text; }
            set { txtContent.Text = value; }
        }
        public string Date
        {
            get { return dateTimePicker1.Text.ToString(); }
            set { dateTimePicker1.Text = value; }
        }

        public string Value
        {
            get { return txtValue.Text; }
            set { txtValue.Text = value; }
        }
        public string Status
        {
            get { return cbStatus.Text; }
            set { cbStatus.Text = value; }
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

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            AddReceiptsPresenter addReceiptsPresenter = new AddReceiptsPresenter(this);
            if (this._isNew)
            {
                if (addReceiptsPresenter.AddDataToDB())
                {
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                }
                else { MessageBox.Show(_message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else
            {
                if (addReceiptsPresenter.UpdateData())
                {
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else { MessageBox.Show(_message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            }
        }
        private void AddReceiptsForm_Load(object sender, EventArgs e)
        {
            if (!this._isNew)
            {
                txtContent.Enabled = false;
                txtValue.Enabled = false;
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Hide();

        }
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtValue.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValue.Text = txtValue.Text.Remove(txtValue.Text.Length - 1);
            }
        }

       
    }
}