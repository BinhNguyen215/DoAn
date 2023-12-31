using _DoAn.Models;
using _DoAn.Views.Sale;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DoAn.Presenters
{
    public class SalePresenter
    {
        ISaleView saleview;
        Bill bill = new Bill();
        string quanLv1, quanLv2;
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
            saleview.dgvAllBill.DataSource = dt;
            return true;
        }
        public bool ClearInformation()
        {
            saleview.Product_id = "";
            saleview.Product_Name = "";
            saleview.Price = "";
            saleview.Quantities = "";
            saleview.Unit_Name = "";

            saleview.ValueLv1 = "Undefine";
            saleview.ValueLv2 = "Undefine";
            return true;
        }
        public bool CheckSoldOutLv1()
        {
            if (int.Parse(saleview.ValueLv1) > 0) return false;
            return true;
        }
        public bool CheckSoldOutLv2()
        {
            if (saleview.ValueLv2!="Undefine"&&!(saleview.ValueLv2 == "") && int.Parse(saleview.ValueLv2) > 0) return false;
           /* if (!CheckSoldOutLv1(
            {
                saleview.ValueLv2 = saleview.Coef;
                saleview.ValueLv1= (int.Parse(saleview.ValueLv1)-1).ToString();
            } */   
                return true;
        }
        public bool RetriveProduct(int index, string id, string name, string price,string valueLv2,string unit2,string valueLv1,string unit1)
        {
            if (index != -1)
            {
                ClearInformation();
                saleview.Product_id = id;
                saleview.Product_Name = name;
                saleview.Price = price;
                saleview.lbUnitLv1 = unit1;
                saleview.lbUnitLv2 = unit2;
                saleview.ValueLv1 = valueLv1;
                if(valueLv2 != "")
                saleview.ValueLv2 = (int.Parse(valueLv2) + int.Parse(valueLv1) *int.Parse(saleview.Coef)).ToString();

                if (saleview.dgvCart.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in saleview.dgvCart.Rows)
                    {
                        if (row.Cells[0].Value.Equals(saleview.Product_id) && row.Cells[4].Value.Equals(saleview.lbUnitLv1))
                        {
                            saleview.ValueLv1 = (int.Parse(saleview.ValueLv1) - int.Parse(row.Cells[3].Value.ToString())).ToString();//box= box- a
                            saleview.ValueLv2 = (int.Parse(saleview.ValueLv2) - int.Parse(row.Cells[3].Value.ToString()) * int.Parse(saleview.Coef)).ToString();
                            
                        }
                        else if (row.Cells[0].Value.Equals(saleview.Product_id) && row.Cells[4].Value.Equals(saleview.lbUnitLv2))
                        {
                            //Code cũ
                            saleview.ValueLv2 = (int.Parse(saleview.ValueLv2) - int.Parse(row.Cells[3].Value.ToString())).ToString();//pill=pill-a
                            saleview.ValueLv1 = (int.Parse(saleview.ValueLv2) / int.Parse(saleview.Coef)).ToString();//BOX = box/coef
                        }
                    }
                }
            }
            return true;
        }
        public bool AddDataToDataGridview()//*
        {
            string _2rdQuantities;

            if (saleview.Unit_Name == saleview.lbUnitLv2 && int.Parse(saleview.Quantities) >= int.Parse(saleview.Coef))
            {
                bool found = false;
                _2rdQuantities = (int.Parse(saleview.Quantities) / int.Parse(saleview.Coef)).ToString();
                saleview.Quantities = (int.Parse(saleview.Quantities) % int.Parse(saleview.Coef)).ToString();

                if (saleview.dgvCart.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in saleview.dgvCart.Rows)
                    {

                        if (row.Cells[0].Value.ToString().Equals(saleview.Product_id) && row.Cells[4].Value.Equals(saleview.lbUnitLv1))
                        {
                            row.Cells[3].Value = (int.Parse(_2rdQuantities) + int.Parse(row.Cells[3].Value.ToString()));
                            found = true;
                        }

                    }
                    if (!found)
                    {
                        saleview.dgvCart.Rows.Add(saleview.Product_id, saleview.Product_Name, (int.Parse(saleview.Price)*int.Parse(saleview.Coef)).ToString(), _2rdQuantities, saleview.lbUnitLv1);
                    }

                }
                else
                {
                    saleview.dgvCart.Rows.Add(saleview.Product_id, saleview.Product_Name, (int.Parse(saleview.Price) * int.Parse(saleview.Coef)).ToString(), _2rdQuantities, saleview.lbUnitLv1);
                }
            }
            if (CheckInformation())
            {
                
                bool found= false;
                if (saleview.dgvCart.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in saleview.dgvCart.Rows)
                    {

                        if (row.Cells[0].Value.ToString().Equals(saleview.Product_id) && row.Cells[4].Value.Equals(saleview.Unit_Name))
                        {
                            row.Cells[3].Value = (int.Parse(saleview.Quantities) + int.Parse(row.Cells[3].Value.ToString()));
                            if (saleview.Unit_Name == saleview.lbUnitLv2 && int.Parse(row.Cells[3].Value.ToString()) >= int.Parse(saleview.Coef))///fix sau khi thêm
                            {
                                _2rdQuantities = (int.Parse(row.Cells[3].Value.ToString()) / int.Parse(saleview.Coef)).ToString();
                                row.Cells[3].Value = (int.Parse(row.Cells[3].Value.ToString()) % int.Parse(saleview.Coef)).ToString();
                                if (row.Cells[3].Value.ToString() == "0") saleview.dgvCart.Rows.RemoveAt(row.Index);
                                foreach (DataGridViewRow row2 in saleview.dgvCart.Rows) 
                                {
                                    if (row2.Cells[0].Value.ToString().Equals(saleview.Product_id) && row2.Cells[4].Value.Equals(saleview.lbUnitLv1))
                                    {
                                        row2.Cells[3].Value = (int.Parse(_2rdQuantities) + int.Parse(row2.Cells[3].Value.ToString()));
                                        found = true;
                                    }
                                }
                            }
                            found = true;
                            return true;
                        }

                    }
                    if (!found&&saleview.Quantities!="0")
                    {
                        saleview.dgvCart.Rows.Add(saleview.Product_id, saleview.Product_Name, saleview.Price, saleview.Quantities,saleview.Unit_Name);
                        return true;
                    }

                }
                else
                {   if(saleview.Quantities != "0")
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
            saleview.dgvAllBill.DataSource = dt;
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
        public void CalculateUpdate(string id,string quantity, string unit)
        {
            string _coef = bill.getCoef(id);
            if(unit=="lv1")// Nếu bán Box/Bottle
            {
                quanLv1 = (int.Parse(quanLv1) - int.Parse(quantity)).ToString();//Box= box -a
            }
            else //Nếu bán pill
            {
                    if (int.Parse(quantity) < int.Parse(_coef)) //A dưới giá trị Coef
                    {
                        if (int.Parse(quantity) < int.Parse(quanLv2))//--------------------------- Trường hợp 1 : A < giá trị data.Pill
                        {
                            quanLv2 = (int.Parse(quanLv2) - int.Parse(quantity)).ToString(); // Pil=Pill -a
                        }
                        else //---------------------------------------------------------------------------------------Trường hợp 2 A >= giá trị data.Pill
                        {
                            quanLv2 = (int.Parse(quanLv2) + int.Parse(_coef) - int.Parse(quantity)).ToString(); // Pill = Pill + coef - a
                            quanLv1 = (int.Parse(quanLv1) - 1).ToString();//Box= box -1
                        }
                    }
                    else// A trên giá trị Coef
                    {
                        if (int.Parse(quantity) % int.Parse(_coef) < int.Parse(quanLv2)) //Trường hợp 3: nếu a % coef dưới giá trị dataBill
                        {
                            quanLv2 = (int.Parse(quanLv2) - int.Parse(quantity) % int.Parse(_coef)).ToString(); // Pil = Pil- a %coef
                            quanLv1 = (int.Parse(quanLv1) - int.Parse(quantity) / int.Parse(_coef)).ToString();//Box= box -a/Coef
                        }
                        else //--------------------------------------------------------------------------------------- Trường hợp 4: a%coef  hơn hoặc bằng giá trị data.Pill
                        {
                            quanLv2 = (int.Parse(quanLv2) + int.Parse(_coef) - int.Parse(quantity) % int.Parse(_coef)).ToString(); // Pil = Pil + coef- a %coef
                            quanLv1 = (int.Parse(quanLv1) - int.Parse(quantity) / int.Parse(_coef) - 1).ToString();//BOX = box - a\coef-1
                        }
                    }
            }
        }
        public bool AddDataToDB()
        {
            string id = bill.AddData(saleview.Employee_id, saleview.Cus_Name, saleview.Phone, saleview.BillValue);

            ///auto add receipts
            string contentReceipt = "Bill ID: " + id;
            string status = "Completed";
            bill.AutoCreateReceipts(saleview.Employee_id, contentReceipt, saleview.BillValue, status, "");
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
                        //
                        DataTable dt = bill.getUnit(row.Cells[0].Value.ToString());
                        string whatUnit = "";
                        if (row.Cells[4].Value.ToString() == dt.Rows[0]["Unit_Namelv1"].ToString())
                        {
                            whatUnit = "lv1";
                        }
                        else
                        {
                            whatUnit = "lv2";
                        }
                        quanLv1 = bill.getQuanLv1(row.Cells[0].Value.ToString());
                        quanLv2 = bill.getQuanLv2(row.Cells[0].Value.ToString());
                        CalculateUpdate(row.Cells[0].Value.ToString(), row.Cells[3].Value.ToString(),whatUnit);
                        //
                        bill.UpdateProduct(row.Cells[0].Value.ToString(), quanLv1,quanLv2);//
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

            graphic.DrawString("Green Pharmacy", new Font("Courier New", 18, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY);

            graphic.DrawString("Addresss: 136, Linh Trung, Thủ Đức, TP Thủ Đức", font, new SolidBrush(Color.Black), startX, 40);

            graphic.DrawString("Phone: 1900 1555".PadRight(40) + "Employee: " + saleview.Employee_id, font, new SolidBrush(Color.Black), startX, 60);
            graphic.DrawString("RETAIL BILL".PadRight(40), fontBold, new SolidBrush(Color.Black), 270, 90);

            offset = offset + 120;
            graphic.DrawString("Customer: " + saleview.Cus_Name, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, 120);
            graphic.DrawString("Phone: " + saleview.Phone, new Font("Courier New", 12), new SolidBrush(Color.Black), startX, 140);

            string top = "Product".PadRight(40) + "Quantities".PadRight(20) + "Unit Price".PadRight(20);
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
                graphic.DrawString("Note:...............................................................", font, new SolidBrush(Color.Black), startX, startY + offset);

            }
            return true;
        }
        public bool CheckQuantity()
        {
            DataTable dt = new DataTable();
            dt = bill.GetProductOffer();
            return dt.Rows.Count>0;
        }
    }
}
