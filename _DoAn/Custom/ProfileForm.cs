using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DoAn.Custom
{
    public partial class ProfileForm : Form
    {
        private string _name;
        private string _position;
        private string _id;
        public ProfileForm(string name, string position, string id)
        {
            this._name = name;
            this._position = position;
            this._id = id;
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            txtID.Text = _id;
            txtName.Text = _name;
            txtPosition.Text = _position;
            txtID.Enabled = false;
            txtName.Enabled = false;
            txtPosition.Enabled = false;
        }
    }
}
