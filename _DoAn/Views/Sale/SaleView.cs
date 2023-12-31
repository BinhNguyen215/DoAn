using _DoAn.Presenters;
using _DoAn.Views.Import;
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
using System.Windows.Markup;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace _DoAn.Views.Sale
{
    public partial class SaleView : Form, ISaleView
    {
        SalePresenter salePresenter;
        private string _unit, _coef, _price;

        Dictionary<string, string> _values = new Dictionary<string, string>();

        public SaleView()
        {
            InitializeComponent();
            salePresenter = new SalePresenter(this);
            this.DoubleBuffered = true;
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
        public string Employee_id
        {
            get { return _id; }
        }
        public SaleView(string id) : this()
        {
            this._id = id;
        }

        public string ValueLv1
        {
            get { return lbValueLv1.Text; }
            set { lbValueLv1.Text = value; }
        }
        public string ValueLv2
        {
            get { return lbValueLv2.Text; }
            set { lbValueLv2.Text = value; }
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
        string ISaleView.Price { get => _price; set => _price = value; }
        public string Unit_Name
        {
            get { return _unit; }
            set
            {
                _unit = value;
            }
        }

        public string lbUnitLv1
        {
            get { return lbLv1.Text; }
            set
            {
                lbLv1.Text = value;
            }
        }
        public string lbUnitLv2
        {
            get { return lbLv2.Text; }
            set
            {
                lbLv2.Text = value;
            }
        }
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

        public BunifuDataGridView dgvAllBill { get => dgvAllBills; set => dgvAllBills = value; }
        public string Coef { get => _coef; set => _coef = value; }
        bool IsPressedCreateBill;

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            //salePresenter.CalculateAfterAddToCart();
            if (dgvCart.Rows.Count > 0)
            {
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
                    IsPressedCreateBill = true;
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
            salePresenter.Print(e);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            salePresenter.DeleteDatainDataGridview();
            salePresenter.ClearInformation();
            salePresenter.CalculateTotalPrice();
            btnDelete.Enabled = false;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure cancel all information?", "Notification", MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                salePresenter.ClearData();
                btnCancel.Enabled = false;
            }
        }

        private void txtFind_TextChange(object sender, EventArgs e)
        {
            if (lbViewAllBill.Text == "View all bills")
            {
                salePresenter.SearchInformation(txtFind.Text);
            }
            else
            {
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
                salePresenter.CalculateTotalPrice();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
            panelLv2.Show();

            if(salePresenter.AddDataToDataGridview())
            {
                checkBoxLv2.Checked = checkBoxLv1.Checked = false;
                salePresenter.CalculateTotalPrice();
                salePresenter.ClearInformation();
            }
            lbLv1.Text = lbLv2.Text = "Undefine";
            lbSoldOutLv1.Visible = lbSoldOutLv2.Visible = false;
            btnAdd.Enabled = false;
            checkBoxLv2.Enabled = checkBoxLv1.Enabled = false;
            txtQuantities.Enabled = false;

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
                txtFind.Text = string.Empty;
                gpProduct.Hide();
                salePresenter.GetBill();
                gpAllBill.Show();
                lbViewAllBill.Text = "Selling";
                txtFind.PlaceholderText = "Search bill by ID, name or phone";
                gbCart.Hide();
                gpInvoce.Hide();
                gpProperties.Hide();
                bunifuGroupBox4.Show();
                btnAdd.Hide();
                btnDelete.Hide();
            }
            else
            {
                txtFind.Text = string.Empty;
                salePresenter.GetProduct();
                gpProduct.Show();
                gpAllBill.Hide();
                lbViewAllBill.Text = "View all bills";
                txtFind.PlaceholderText = "Search product by ID, name";
                gbCart.Show();
                gpInvoce.Show();
                gpProperties.Show();
                bunifuGroupBox4.Hide();
                btnAdd.Show();
                btnDelete.Show();
            }
        }

        private void SaleView_Load(object sender, EventArgs e)
        {
            salePresenter.GetProduct();
            btnCreateBill.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
            btnCancel.Enabled = false;
            bunifuGroupBox4.Hide();
            gpAllBill.Hide();
        }

        private void txtQuantities_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Text = txtPhone.Text.Remove(txtPhone.Text.Length - 1);
            }
            else
            if (txtQuantities.Text != "")
            {
                int temp = int.Parse(txtQuantities.Text);// baasc
                if (temp > 0)
                {
                    if((checkBoxLv1.Checked &&  temp > int.Parse(lbValueLv1.Text.Split(' ')[0])||(checkBoxLv2.Checked && temp > int.Parse(lbValueLv2.Text.Split(' ')[0]))))
                    {
                        MessageBox.Show("Enter number less than number of products that is available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQuantities.Text = "0";
                        btnAdd.Enabled = false;

                    }
                    else
                {

                    btnAdd.Enabled = true;
                }
                }
            }
            else
            {
                btnAdd.Enabled = false;
            }

        }
      
        private void dgvListProduct_DoubleClick(object sender, EventArgs e)
        {
            checkBoxLv2.Enabled = checkBoxLv1.Enabled = true;
            txtQuantities.Enabled = true;
            if (IsPressedCreateBill)
            {
                IsPressedCreateBill = false;
            }

            btnAdd.Enabled = false;
            lbValueLv1.Visible = lbValueLv2.Visible = false;


             _coef = dgvListProduct.CurrentRow.Cells[7].Value.ToString();
            if (salePresenter.RetriveProduct(dgvListProduct.CurrentRow.Index, dgvListProduct.CurrentRow.Cells[0].Value.ToString()
                  , dgvListProduct.CurrentRow.Cells[1].Value.ToString(), dgvListProduct.CurrentRow.Cells[2].Value.ToString(), dgvListProduct.CurrentRow.Cells[3].Value.ToString(),
                  dgvListProduct.CurrentRow.Cells[4].Value.ToString(), dgvListProduct.CurrentRow.Cells[5].Value.ToString(), dgvListProduct.CurrentRow.Cells[6].Value.ToString()))
            {

                if (lbLv1.Text.Equals(lbLv2.Text)) { panelLv2.Hide(); }
                else { panelLv2.Show(); }

                if (salePresenter.CheckSoldOutLv1())
                {

                    checkBoxLv1.Checked = false;
                    lbSoldOutLv1.Visible = true;
                    checkBoxLv1.Enabled = false;
                    lbValueLv1.Visible = false;
                    if (!IsPressedCreateBill)
                    {
                        lbSoldOutLv1.Visible = false;
                        lbValueLv1.Text += " Available";
                        lbValueLv1.Visible = true;
                    }
                    btnAdd.Enabled = false;
                }
                else
                {
                    checkBoxLv1.Enabled = true;
                    lbSoldOutLv1.Visible = false;
                    btnAdd.Enabled = true;
                    lbValueLv1.Text += " Available";
                    lbValueLv1.Visible = true;
                }

                if (salePresenter.CheckSoldOutLv2())
                {
                   /* salePresenter.CheckSoldOutLv1();//*/
                    checkBoxLv2.Checked = false;
                    lbSoldOutLv2.Visible = true;
                    checkBoxLv2.Enabled = false;
                    lbValueLv2.Visible = false;
                    if (!IsPressedCreateBill)
                    {
                        lbSoldOutLv2.Visible = false;
                        lbValueLv2.Text += " Available";
                        lbValueLv2.Visible = true;
                    }
                    btnAdd.Enabled = false;
                }
                else
                {
                    checkBoxLv2.Enabled = true;
                    checkBoxLv2.Checked = true;
                    lbSoldOutLv2.Visible = false;
                    btnAdd.Enabled = true;
                    lbValueLv2.Text += " Available";
                    lbValueLv2.Visible = true;
                }
            }
        }
        private void checkBoxLv2_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            if (checkBoxLv2.Checked == true)
            {
                checkBoxLv1.Checked = false;
                _unit = lbUnitLv2;
                _price = (int.Parse(_price) / int.Parse(_coef)).ToString();
            }
        }

        private void dgvCart_DoubleClick(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
        }

        private void dgvAllBills_DoubleClick(object sender, EventArgs e)
        {
            if (salePresenter.LoadDetailBill(dgvAllBills.CurrentRow.Cells[0].Value.ToString()))
            {
                salePresenter.CalculateTotalPrice();
                salePresenter.ClearInformation();
                btnAdd.Enabled = false;
            }
        }

       
        private void checkBoxLv1_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            if (checkBoxLv1.Checked == true)
            {
                checkBoxLv2.Checked = false;
                _unit = lbUnitLv1;
                _price = (int.Parse(_price) * int.Parse(_coef)).ToString();
            }
        }



        private void btnNotificationRed_Click(object sender, EventArgs e)
        {
            ImportView importForm = new ImportView();
            importForm.ShowDialog();
        }
    }
       
}
