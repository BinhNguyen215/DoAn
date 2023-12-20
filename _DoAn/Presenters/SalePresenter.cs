using _DoAn.Models;
using _DoAn.Views.Sale;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DoAn.Presenters
{
    public class SalePresenter
    {
        ISaleView saleview;
        Bill bill = new Bill();

        public SalePresenter(ISaleView view)
        {
            saleview = view;
        }
        public bool GetProduct()
        {
            DataTable dt = new DataTable();
            dt = bill.GetProductData();
            saleview.dgv_ListProduct.DataSource = dt;
            return true;
        }
        public bool GetBill()
        {
            DataTable dt = new DataTable();
            dt = bill.GetBillData();
            saleview.dgv_ListProduct.DataSource = dt;
            return true;
        }
        public bool ClearInformation()
        {
            saleview.Product_id = "";
            saleview.Product_Name = "";
            saleview.Price = "";
            saleview.Quantities = "";
            saleview.Unit_Name = "";
            return true;
        }

        public bool RetriveProduct(int index, string id, string name, string price,string unit, string quan="1")
        {
            if (index != -1)
            {
                ClearInformation();
                saleview.Product_id = id;
                saleview.Product_Name = name;
                saleview.Price = price;
                saleview.Quantities = quan;
                saleview.Unit_Name=unit;
            }
            return true;
        }

        public bool AddDataToDataGridview()//*
        {
            if (CheckInformation())
            {
                bool found = false;
                if (saleview.dgvCart.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in saleview.dgvCart.Rows)
                    {
                        if (Convert.ToString(row.Cells[0].Value) == saleview.Product_id && row.Cells[4].Value==saleview.Unit_Name)
                        {
                            row.Cells[3].Value = (int.Parse(saleview.Quantities) *Convert.ToInt16(row.Cells[3].Value.ToString()));
                            found = true;
                            return true;
                        }

                    }
                    if (!found)
                    { 
                        saleview.dgvCart.Rows.Add(saleview.Product_id, saleview.Product_Name, saleview.Price, saleview.Quantities,saleview.Unit_Name);
                        return true;
                    }

                }
                else
                {
                    saleview.dgvCart.Rows.Add(saleview.Product_id, saleview.Product_Name, saleview.Price, saleview.Quantities, saleview.Unit_Name);
                    return true;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool LoadDetailBill(string bill_id)
        {
            DataTable dt = new DataTable();
            dt = bill.GetDetailBill(bill_id);
            saleview.dgvDetailBill.DataSource = dt;
            return true;
        }

        public bool CalculateTotalPrice()
        {
            double sum = 0;
            for (int i = 0; i < saleview.dgvCart.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(saleview.dgvCart.Rows[i].Cells[2].Value) * Convert.ToDouble(saleview.dgvCart.Rows[i].Cells[3].Value);
            }
            saleview.BillValue = sum.ToString();
            return true;
        }

        public bool CheckInformation()
        {
            if (string.IsNullOrEmpty(saleview.Product_id))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(saleview.Product_Name))
                return false;
            else if (string.IsNullOrEmpty(saleview.Price))
                return false;
            else if (string.IsNullOrEmpty(saleview.Quantities))
                return false;
            else if (string.IsNullOrEmpty(saleview.Unit_Name))
                return false;
            else
                return true;
        }

        public bool SearchInformation(string search)
        {
            DataTable dt = new DataTable();
            dt = bill.SearchData(search);
            saleview.dgv_ListProduct.DataSource = dt;
            return true;
        }

        public bool SearchBill(string search)
        {
            DataTable dt = new DataTable();
            dt = bill.SearchBill(search);
            saleview.dgv_ListProduct.DataSource = dt;
            return true;
        }
        public bool DeleteDatainDataGridview()
        {
            foreach (DataGridViewRow item in saleview.dgvCart.SelectedRows)
            {
                DataGridViewRow row = saleview.dgvCart.Rows[item.Index];
                saleview.dgvCart.Rows.RemoveAt(item.Index);

            }
            return true;
        }
        public bool AddDataToDB()
        {
            string id = bill.AddData(saleview.Employee, saleview.Cus_Name, saleview.Phone, saleview.BillValue);

            ///auto add receipts
            string contentReceipt = "Bill ID: " + id;
            string status = "Completed";
            bill.AutoCreateReceipts(saleview.Employee, contentReceipt, saleview.BillValue, status, "");
            ///end
            ///
            if (saleview.dgvCart.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in saleview.dgvCart.Rows)
                {
                    if (Convert.ToString(row.Cells[0].Value) != "")
                    {
                        /* bill.AddDetailData(id, row.Cells[0].Value.ToString(),  row.Cells[2].Value.ToString(),
                           row.Cells[3].Value.ToString());*/

                        DetailBill detailBill = new DetailBill();
                        detailBill.AddDetailData(id, row.Cells[0].Value.ToString(), row.Cells[2].Value.ToString(),
                         row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString());

                        bill.UpdateProduct(row.Cells[3].Value.ToString(), row.Cells[0].Value.ToString(), row.Cells[4].Value.ToString());

                    }
                }
                saleview.message = "Created bill successfully. Do you want to print this bill?";
                return true;
            }
            else
            {
                saleview.message = "Not yet add product into cart. Please try again.";
                return false;
            }
        }
        public bool ClearData()
        {
            ClearInformation();
            saleview.Cus_Name = "";
            saleview.Phone = "";
            saleview.BillValue = "";
            saleview.dgvCart.Rows.Clear();
            saleview.dgvCart.Refresh();
            return true;
        }
        public bool Print(System.Drawing.Printing.PrintPageEventArgs e) //*
        {
            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up
            Font fontBold = new Font("Courier New", 18, FontStyle.Bold);
            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString("Green Beauty", new Font("Courier New", 18, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY);

            graphic.DrawString("Addresss: 136, Linh Trung, Thủ Đức, TP Thủ Đức", font, new SolidBrush(Color.Black), startX, 40);

            graphic.DrawString("Phone: 1900 1555".PadRight(40) + "Employee: " + saleview.Employee, font, new SolidBrush(Color.Black), startX, 60);
            graphic.DrawString("RETAIL BILL".PadRight(40), fontBold, new SolidBrush(Color.Black), 270, 90);

            offset = offset + 120;
            graphic.DrawString("Customer: " + saleview.Cus_Name, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, 120);
            graphic.DrawString("Phone: " + saleview.Phone, new Font("Courier New", 12), new SolidBrush(Color.Black), startX, 140);

            string top = "Product".PadRight(40) + "Quantities".PadRight(20) + "Total".PadRight(20);
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("-------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            if (saleview.dgvCart.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in saleview.dgvCart.Rows)
                {
                    if (Convert.ToString(row.Cells[0].Value) != "")
                    {
                        string Name = row.Cells[1].Value.ToString();
                        int Quantities = int.Parse(row.Cells[3].Value.ToString());
                        //float UnitPrice = float.Parse(row.Cells[2].Value.ToString());
                        float Total = float.Parse(row.Cells[2].Value.ToString());

                        graphic.DrawString(Name, font, new SolidBrush(Color.Black), startX, startY + offset);
                        graphic.DrawString(Quantities.ToString(), font, new SolidBrush(Color.Black), 460, startY + offset);
                        // graphic.DrawString(UnitPrice.ToString(), font, new SolidBrush(Color.Black), 440, startY + offset);
                        graphic.DrawString(Total.ToString(), font, new SolidBrush(Color.Black), 630, startY + offset);
                        offset = offset + (int)fontHeight + 5; //make the spacing consistent       
                    }
                }
                float total = 0f;
                float productTotal = float.Parse(saleview.BillValue);
                total = productTotal;
                offset = offset + 20;
                graphic.DrawString("Total: ".PadRight(60) + total.ToString("###,###"), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            }
            return true;
        }
    }
}
