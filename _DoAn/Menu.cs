using _DoAn.Views.Sale;
using _DoAn.Views.Statistic;
using _DoAn.Views.Employee;
using _DoAn.Views.Product;
using _DoAn.Views.Employee;
using _DoAn.Views.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _DoAn.Views.Accountant;
using _DoAn.Views.Import;
using _DoAn.Views.MenuDropDown;
using TheArtOfDev.HtmlRenderer.Adapters.Entities;

namespace _DoAn
{
    public partial class Menu : Form
    {
        private string name;
        private string id;
        private string position;
        private Panel leftBorderbtn;
        private Form currentChildForm;
        public Menu()
        { 
            InitializeComponent();
            leftBorderbtn = new Panel();
            leftBorderbtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderbtn);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        public Menu(string id, string name, string position) : this()
        {
            this.id = id;
            this.name = name;
            this.position = position;
        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
           
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

       

        private void bunifuButton11_Click(object sender, EventArgs e)
        {

        }

     

        private void bunifuButton4_Click(object sender, EventArgs e)
        {

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductView());
            lbName.Text = "Product";
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SaleView(id));
            lbName.Text = "Sale";
        }


        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ImportView(id, name));
            lbName.Text = "Import";
        }

        private void btnAccountant_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(rjDropdownMenu1, sender);
        }

        private void DropdownMenu_VisibleChanged(object sender, EventArgs e, Control ctrl)
        {
            RJDropdownMenu dropdownMenu = (RJDropdownMenu)sender;
            if (!DesignMode)
            {
            }
        }

        private void Open_DropdownMenu(RJDropdownMenu dropdownMenu ,object sender)
        {
            Control control = (Control)sender;
            dropdownMenu.VisibleChanged += new EventHandler((sender2, ev)
                => DropdownMenu_VisibleChanged(sender2, ev, control));
            dropdownMenu.Show(control, control.Width - dropdownMenu.Width, control.Height);
        }

        private void recieptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReceiptsForm(id));
            lbName.Text = "Receipt";
        }

        private void pAyToolStripMenuItem_Click(object sender, EventArgs e)
         {
            OpenChildForm(new PaySlipForm(id));
            lbName.Text = "PaySlip";
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StatisticsView(name));
            lbName.Text = "Dashboard";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EmployeeView());
            lbName.Text = "Employee";
        }

    }
}
