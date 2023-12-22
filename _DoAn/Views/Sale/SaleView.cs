using _DoAn.Presenters;
using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace _DoAn.Views.Sale
{
    public partial class SaleView : Form, ISaleView
    {

        public SaleView()
        {
            InitializeComponent();
        }

        public string Find
        {
            get { return txtFind.Text; }
            set { txtFind.Text = value; }
        }
        public string Cus_Name
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public string Phone
        {
            get { return txtPhone.Text; }
            set { txtPhone.Text = value; }
        }
        private string _id;
        public string Employee
        {
            get { return _id; }
        }
        public SaleView(string id) : this()
        {
            this._id = id;
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

        BunifuDataGridView ISaleView.dgv_ListProduct
        {
            get { return dgvListProduct; }
            set { dgvListProduct = value; }
        }

        BunifuDataGridView ISaleView.dgvCart
        {
            get { return dgvCart; }
            set { dgvCart = value; }
        }

        string ISaleView.Product_id { get; set; }
        string ISaleView.Product_Name { get; set; }
        string ISaleView.Price { get; set; }
        string ISaleView.Unit_Name { get; set; }

        public string Quantities
        {
            get { return txtQuantities.Text; }
            set
            {
                txtQuantities.Text = value;
            }
        }
       
       
        public string BillValue
        {
            get { return lbTotal.Text; }
            set { lbTotal.Text = value; }
        }

        BunifuDataGridView ISaleView.dgvDetailBill
        {
            get { return dgvDetailBill; }
            set { dgvDetailBill = value; }
        }
      

        private void dgvListProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            checkBoxLv1.Checked = false;
            checkBoxlv2.Checked = false;
            btnAdd.Enabled = false;

            lbLv2.Enabled = true;
            lbLv1.Enabled = true;
            txtQuantities.Enabled = true;
            txtQuantities.Text = "1";
            lbLv2.Text = dgvListProduct.CurrentRow.Cells[3].Value.ToString();
            lbLv1.Text = dgvListProduct.CurrentRow.Cells[4].Value.ToString();
        }

       
        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count > 0)
            {
                SalePresenter salePresenter = new SalePresenter(this);
                if (salePresenter.AddDataToDB())
                {
                    salePresenter.GetProduct();

                    DialogResult dr = MessageBox.Show(_message, "Notification", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                        PrintDialog printDialog = new PrintDialog();
                        PrintDocument printDocument = new PrintDocument();

                        printDialog.Document = printDocument;
                        printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(Createbill); DialogResult result = printDialog.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            printDocument.Print();

                        }
                    }

                    salePresenter.ClearData();
                    btnCreateBill.Enabled = false;
                    btnDelete.Enabled = false;
                    btnAdd.Enabled = false;
                    btnCancel.Enabled = false;
                }
                else
                {
                    MessageBox.Show(_message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Not yet add product into cart. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Createbill(object sender, PrintPageEventArgs e)
        {
            SalePresenter salePresenter = new SalePresenter(this);
            salePresenter.Print(e);
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SalePresenter salePresenter = new SalePresenter(this);
            if (salePresenter.RetriveProduct(dgvCart.CurrentRow.Index, dgvCart.CurrentRow.Cells[0].Value.ToString()
                 , dgvCart.CurrentRow.Cells[1].Value.ToString(), dgvCart.CurrentRow.Cells[2].Value.ToString(), Unit, Quantities.ToString())) // (index,id,price,unitlv1,unitlv2)
            {
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            SalePresenter salePresenter = new SalePresenter(this);
            salePresenter.DeleteDatainDataGridview();
            salePresenter.CalculateTotalPrice();
            btnDelete.Enabled = false;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure cancel all information?", "Notification", MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                SalePresenter salePresenter = new SalePresenter(this);
                salePresenter.ClearData();
                btnCancel.Enabled = false;
            }
        }

        private void txtFind_TextChange(object sender, EventArgs e)
        {
            if (lbViewAllBill.Text == "View all bills")
            {
                SalePresenter salePresenter = new SalePresenter(this);
                salePresenter.SearchInformation(txtFind.Text);
            }
            else
            {
                SalePresenter salePresenter = new SalePresenter(this);
                salePresenter.SearchBill(txtFind.Text);
            }
        }

        private void txtName_TextChange(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhone.Text))
            {
                btnCreateBill.Enabled = true;
            }
            else
            {
                btnCreateBill.Enabled = false;
            }
        }

        private void txtPhone_TextChange(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Text = txtPhone.Text.Remove(txtPhone.Text.Length - 1);
            }
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhone.Text))
            {
                btnCreateBill.Enabled = true;
            }
            else
            {
                btnCreateBill.Enabled = false;
            }
        }

        private void dgvCart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3)
            {
                MessageBox.Show("Only edit in column Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvCart.CurrentRow.Cells[e.ColumnIndex].Value = _textEdit;
            }
            else
            {
                SalePresenter salePresenter = new SalePresenter(this);
                salePresenter.CalculateTotalPrice();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
            SalePresenter salePresenter = new SalePresenter(this);
            if (salePresenter.AddDataToDataGridview())
            {
                checkBoxLv1.Checked = checkBoxlv2.Checked = false;
                salePresenter.CalculateTotalPrice();
                salePresenter.ClearInformation();
                btnAdd.Enabled = false;
            }
        }
        private string _textEdit = "";

        private void dgvCart_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (lbViewAllBill.Text == "View all bills")
            {
                _textEdit = dgvCart.CurrentRow.Cells[e.ColumnIndex].Value.ToString();
            }
        }

        private void lbViewAllBill_Click(object sender, EventArgs e)
        {
                if (lbViewAllBill.Text == "View all bills")
                {
                    SalePresenter salePresenter = new SalePresenter(this);
                    salePresenter.GetBill();
                    lbViewAllBill.Text = "Selling";
                    bunifuGroupBox1.Text = "All bills";
                    txtFind.PlaceholderText = "Search bill by ID, name or phone";
                    bunifuGroupBox2.Hide();
                    bunifuGroupBox3.Hide();
                    bunifuGroupBox4.Show();
                    btnAdd.Hide();
                    btnDelete.Hide();
                }
                else
                {
                    SalePresenter salePresenter = new SalePresenter(this);
                    salePresenter.GetProduct();
                    lbViewAllBill.Text = "View all bills";
                    bunifuGroupBox1.Text = "Product table";
                    txtFind.PlaceholderText = "Search product by ID, name";
                    bunifuGroupBox2.Show();
                    bunifuGroupBox3.Show();
                    bunifuGroupBox4.Hide();
                    btnAdd.Show();
                    btnDelete.Show();
                }
        }

        private void dgvListProduct_DoubleClick(object sender, EventArgs e)
        {
            if (lbViewAllBill.Text == "Selling")
            {
                SalePresenter salePresenter = new SalePresenter(this);
                if (salePresenter.LoadDetailBill(dgvListProduct.CurrentRow.Cells[0].Value.ToString()))
                {
                     salePresenter.CalculateTotalPrice();
                     salePresenter.ClearInformation();
                     btnAdd.Enabled = false;
                }
            }
        }

        private void SaleView_Load(object sender, EventArgs e)
        {
            SalePresenter salePresenter = new SalePresenter(this);
            salePresenter.GetProduct();
            btnCreateBill.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
            btnCancel.Enabled = false;
            bunifuGroupBox4.Hide();
        }

 
        
      
        private string Unit;
        private void checkBoxlv2_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if(checkBoxlv2.Checked)
            {
                checkBoxLv1.Checked = false;
                Unit = lbLv2.Text;
                SalePresenter salePresenter = new SalePresenter(this);

                if (salePresenter.RetriveProduct(dgvListProduct.CurrentRow.Index, dgvListProduct.CurrentRow.Cells[0].Value.ToString()
                  , dgvListProduct.CurrentRow.Cells[1].Value.ToString()
                  ,(int.Parse(dgvListProduct.CurrentRow.Cells[2].Value.ToString()) / int.Parse(dgvListProduct.CurrentRow.Cells[5].Value.ToString())).ToString()
                  , Unit, Quantities))
                {
                    btnAdd.Enabled = true;
                }
            }
           
        }

        private void checkBoxLv1_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (checkBoxLv1.Checked)
            {
                checkBoxlv2.Checked = false;
                Unit = lbLv1.Text;
                SalePresenter salePresenter = new SalePresenter(this);
                if (salePresenter.RetriveProduct(dgvListProduct.CurrentRow.Index, dgvListProduct.CurrentRow.Cells[0].Value.ToString()
                  , dgvListProduct.CurrentRow.Cells[1].Value.ToString(), dgvListProduct.CurrentRow.Cells[2].Value.ToString(), Unit, Quantities))
                {
                    btnAdd.Enabled = true;
                }
            }
        }
    }
}
