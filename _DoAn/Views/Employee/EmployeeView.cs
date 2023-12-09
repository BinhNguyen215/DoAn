using _DoAn.Presenters;
using Bunifu.UI.WinForms;
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
    public partial class EmployeeView : Form,IManageEmployeeView
    {
        public EmployeeView()
        {
            InitializeComponent();
        }
        private string _employee_id;

        private string _message;
        public string message
        {
            get { return _message; }
            set
            {
                _message = value;
            }
        }

        BunifuDataGridView IManageEmployeeView.dgvEmployee
        {
            get { return dgvEmployee; }
            set { dgvEmployee = value; }
        }

        public string employee_id
        {
            get { return _employee_id; }
            set
            {
                _employee_id = value;

            }
        }

        private void EmployeeView_Load(object sender, EventArgs e)
        {
            EmployeePresenter employeePresenter = new EmployeePresenter(this);
            employeePresenter.LoadListEmployee();

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            lbShow.Font = new Font(lbShow.Font, FontStyle.Bold);
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this._employee_id = dgvEmployee.CurrentRow.Cells[0].Value.ToString();
            if (dgvEmployee.CurrentRow.Cells[0].Value.ToString() == "")
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewEmployeeView newEmployee = new NewEmployeeView(true);
            newEmployee.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (btnEdit.Enabled.ToString() == "True")
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                 NewEmployeeView newEmployee = new NewEmployeeView(false,
                    dgvEmployee.CurrentRow.Cells[0].Value.ToString(),
                    dgvEmployee.CurrentRow.Cells[1].Value.ToString(),
                    dgvEmployee.CurrentRow.Cells[2].Value.ToString(),
                    dgvEmployee.CurrentRow.Cells[3].Value.ToString(),
                    dgvEmployee.CurrentRow.Cells[4].Value.ToString(),
                    dgvEmployee.CurrentRow.Cells[5].Value.ToString(),
                    dgvEmployee.CurrentRow.Cells[6].Value.ToString(),
                     dgvEmployee.CurrentRow.Cells[7].Value.ToString(),
                    dgvEmployee.CurrentRow.Cells[8].Value.ToString());

                newEmployee.Show(); 
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            EmployeePresenter employeePresenter = new EmployeePresenter(this);
            employeePresenter.SearchInformation(tbSearch.Text);

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure delete this employee?", "Notification", MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                EmployeePresenter employeePresenter = new EmployeePresenter(this);

                if (employeePresenter.DeleteData())
                {
                    employeePresenter.LoadListEmployee();
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(_message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lbShow_Click(object sender, EventArgs e)
        {
            EmployeePresenter employeePresenter = new EmployeePresenter(this);
            employeePresenter.LoadListEmployee();

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            lbShow.Font = new Font(lbShow.Font, FontStyle.Bold);
        }
    }
}
