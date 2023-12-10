using _DoAn.Presenters;
using _DoAn.Views.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DoAn.Views.Employee
{
    public partial class NewEmployeeView : Form,INewEmployee
    {
        public NewEmployeeView()
        {
            InitializeComponent();
        }
        private bool _isNew;
        private string employeeID;

        public NewEmployeeView(bool isNew) : this()
        {
            this._isNew = isNew;
        }

        public NewEmployeeView(bool isNew, string employee_id, string name,
            string phone, string address, string citizenID,
            string email, string position, string username, string password) : this()
        {
            this._isNew = isNew;
            this.employeeID = employee_id;

            NewEmployeePresenter newEmployeePresenter = new NewEmployeePresenter(this);
            newEmployeePresenter.RetriveData(name, phone, citizenID, position, email, address, username, password);
        }
        public string Nametext
        {
            get { return tbName.Text; }
            set
            {
                tbName.Text = value;
            }
        }
        public string Emailtext
        {
            get
            {
                return tbEmail.Text;

            }
            set
            {
                tbEmail.Text = value;

            }
        }
        public string Citizen_idtext
        {
            get
            {
                return tbCitizenID.Text;
            }
            set
            {
                tbCitizenID.Text = value;
            }
        }
        public string Addresstext
        {
            get
            {
                return tbAddress.Text;
            }
            set
            {
                tbAddress.Text = value;
            }
        }
        public string Positiontext
        {
            get
            {
                return cbPosition.Text;
            }
            set
            {
                cbPosition.Text = value;
            }
        }
        public string PhoneNumtext
        {
            get
            {
                return tbPhone.Text;

            }
            set
            {
                tbPhone.Text = value;

            }
        }


        public string Username
        {
            get
            {
                return tbUsername.Text;
            }
            set
            {
                tbUsername.Text = value;
            }
        }
        public string Password
        {
            get
            {
                return tbPassword.Text;
            }
            set
            {
                tbPassword.Text = value;
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


        string INewEmployee.employee_id { get { return employeeID; } }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NewEmployeePresenter newEmployeePresenter = new NewEmployeePresenter(this);
            if (this._isNew)
            {

                if (newEmployeePresenter.AddData())
                {
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

                    this.Hide();
                }
                else
                {
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

                }

            }
            else
            {
                if (newEmployeePresenter.EditData())
                {
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

                    this.Hide();
                }
                else
                {
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

                }

            }
        }
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void NewEmployeeView_Load(object sender, EventArgs e)
        {
            if (this._isNew)
            {
                tbUsername.Hide();
                tbPassword.Hide();
                lbUsername.Hide();
                lbPassword.Hide();
            }
            btnSave.Enabled = false;
        }
        bool bPhone = false, bCitizenID = false, bEmail=false;
        private void tbPhone_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbPhone.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPhone.Text = tbPhone.Text.Remove(tbPhone.Text.Length - 1);
               
            }
            else
            {
                if(tbPhone.Text.Length!=10&& tbPhone.Text.Length != 11)
                {
                    lbNofiPhone.Visible = true;
                    bPhone = false;
                }
                else
                {
                    lbNofiPhone.Visible = false;
                    bPhone = true;
                }          
            }
            btnSaveEnable();

        }

        private void btnSaveEnable()
        {
            NewEmployeePresenter newEmployeePresenter = new NewEmployeePresenter(this);
            if (newEmployeePresenter.CheckInformation()&&bPhone && bCitizenID && bEmail)
            {
                btnSave.Enabled = true;
            }
            else btnSave.Enabled = false;
        }
        private void tbName_TextChanged(object sender, EventArgs e)
        {
            btnSaveEnable();
        }

        private void cbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSaveEnable();

        }

        private void tbAddress_TextChanged(object sender, EventArgs e)
        {
            btnSaveEnable();

        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            btnSaveEnable();

        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            btnSaveEnable();

        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbEmail.Text, @"@"))
            {
                lbNofiEmail.Visible = false;
                bEmail = true;
               
            }
            else
            {
                lbNofiEmail.Visible = true;
                bEmail = false;
            }
            if (bPhone && bCitizenID && bEmail) btnSave.Enabled = true;
            else btnSave.Enabled = false;
            btnSaveEnable();

        }

        private void tbCitizenID_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbCitizenID.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCitizenID.Text = tbCitizenID.Text.Remove(tbCitizenID.Text.Length - 1);
            }
            else
            {
                if (tbCitizenID.Text.Length != 9  && tbCitizenID.Text.Length != 12)
                {
                    lbNofiCitizenId.Visible = true;
                    bCitizenID = false;
                }
                else
                {
                    lbNofiCitizenId.Visible = false;
                    bCitizenID = true;
                }
            }
            btnSaveEnable();

        }
    }
}
