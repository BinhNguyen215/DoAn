using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void btnSale_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SaleForm(id));
            lbName.Text = "Sale";
        }

        private void bunifuButton11_Click(object sender, EventArgs e)
        {

        }
    }

}
