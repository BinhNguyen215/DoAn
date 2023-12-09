using _DoAn.Views.Sale;
using _DoAn.Views.Statistic;
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
using _DoAn.Models;
using _DoAn.Views.Supplier;
using _DoAn.Views.Export;
using _DoAn.Views.Product;
using Bunifu.UI.WinForms.BunifuButton;
using _DoAn.Views.Employee;

namespace _DoAn
{
    public partial class Menu : Form
    {
        private string name;
        private string id;
        private string position;
        private Panel leftBorderbtn;
        private Form currentChildForm;
        private BunifuIconButton currentButton;

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

        private void ActiveButton(object senderbtn)
        {
            if (senderbtn != null)
            {
              

                currentButton = (BunifuIconButton)senderbtn;
                //currentButton.BackColor = Color.FromArgb(127, 198, 102);
                currentButton.BackColor = Color.FromArgb(143, 194, 71);
           
 

                //leftBorderbtn.BackColor = color;
                //leftBorderbtn.Location = new Point(0, currentButton.Location.Y);
                //leftBorderbtn.Visible = true;
                //leftBorderbtn.BringToFront();

            }
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

        private void btnSale_Click(object sender, EventArgs e)
        {
            inlicator.Top = ((Control)sender).Top;
            OpenChildForm(new SaleView(id));
            lbName.Text = "Sale";
        }


        private void btnImport_Click(object sender, EventArgs e)
        {
            inlicator.Top = ((Control)sender).Top;
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
            inlicator.Top = ((Control)sender).Top;
            OpenChildForm(new ReceiptsForm(id));
            lbName.Text = "Receipt";
        }

        private void pAyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inlicator.Top = ((Control)sender).Top;
            OpenChildForm(new PaySlipForm(id));
            lbName.Text = "PaySlip";
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            inlicator.Top = ((Control)sender).Top;
            OpenChildForm(new StatisticsView(name));
            lbName.Text = "Dashboard";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            inlicator.Top = ((Control)sender).Top;
            OpenChildForm(new SupplierView());
            lbName.Text = "Suppliers";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            inlicator.Top = ((Control)sender).Top;
            OpenChildForm(new ExportView(id, name));
            lbName.Text = "Export";
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            inlicator.Top = ((Control)sender).Top;
            OpenChildForm(new ProductView());
            lbName.Text = "Product";
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            inlicator.Top = ((Control)sender).Top;
            OpenChildForm(new EmployeeView());
            lbName.Text = "Employee";
        }
    }
}
