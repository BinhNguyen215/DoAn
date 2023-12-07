using _DoAn.Views.Import;
using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _DoAn.Models;
using System.Windows.Forms;

namespace _DoAn.Presenters
{
    public class ImportPresenter
    {
        IImportView importview;
        Import import = new Import();

        public ImportPresenter(IImportView view)
        {
            importview = view;
        }
        public bool GetProduct()
        {
            DataTable dt = new DataTable();
            dt = import.GetProductData();
            importview.gvProductData.DataSource = dt;
            return true;
        }
        public bool GetSuplier()
        {
            foreach (string item in import.GetSuplier())
            {
                importview.cbData.Add(item);
            }
            return true;
        }
        public bool ClearInformation()
        {
            importview.ProductId = "";
            importview.ProductName = "";
            importview.ImportPrice = "";
            importview.Quantity = "";
            importview.Total = "";

            return true;
        }
        public bool RetriveProduct(int index, string id, string name)
        {
            if (index != -1)
            {
                ClearInformation();
                importview.ProductId = id;
                importview.ProductName = name;
            }
            return true;
        }
        public bool RetriveData(int index, string id, string name, string importprice, string quantity, string total)
        {
            if (index != -1)
            {
                ClearInformation();
                importview.ProductId = id;
                importview.ProductName = name;
                importview.ImportPrice = importprice;
                importview.Quantity = quantity;
                importview.Total = total;
            }
            return true;
        }
        public bool AddDataToDataGridview()
        {
            if (CheckInformation())
            {
                bool found = false;
                if (importview.gvDetailProductData.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in importview.gvDetailProductData.Rows)
                    {
                        if (Convert.ToString(row.Cells[0].Value) == importview.ProductId)
                        {
                            row.Cells[3].Value = (int.Parse(importview.Quantity) + Convert.ToInt16(row.Cells[3].Value.ToString()));
                            row.Cells[4].Value = (double.Parse(importview.Total) + Convert.ToDouble(row.Cells[4].Value.ToString()));
                            found = true;
                            return true;
                        }
                    }
                    if (!found)
                    {
                        importview.gvDetailProductData.Rows.Add(importview.ProductId, importview.ProductName, importview.ImportPrice, importview.Quantity, importview.Total);
                        return true;
                    }
                }
                else
                {
                    importview.gvDetailProductData.Rows.Add(importview.ProductId, importview.ProductName, importview.ImportPrice, importview.Quantity, importview.Total);
                    return true;
                }
                return true;
            }
            else
            {
                importview.message = "Please check infromation again";
                return false;
            }
        }
        public bool CalculateTotal()
        {
            if (importview.Quantity != "" && importview.ImportPrice != "")
            {
                if (Convert.ToInt32(importview.Quantity) > 0)
                {
                    double total = Convert.ToDouble(importview.ImportPrice) * Convert.ToInt32(importview.Quantity);
                    importview.Total = total.ToString();
                }
            }
            return true;
        }

        public bool CalculateTotalPrice()
        {
            double sum = 0;
            for (int i = 0; i < importview.gvDetailProductData.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(importview.gvDetailProductData.Rows[i].Cells[4].Value);
            }
            importview.TotalPriceProduct = sum.ToString();
            return true;
        }
        public bool CheckInformation()
        {
            if (string.IsNullOrEmpty(importview.ProductId))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(importview.ProductName))
                return false;
            else if (string.IsNullOrEmpty(importview.ImportPrice))
                return false;
            else if (string.IsNullOrEmpty(importview.Quantity))
                return false;
            else
                return true;
        }
        public bool SearchInformation(string search)
        {
            DataTable dt = new DataTable();
            dt = import.SearchData(search);
            importview.gvProductData.DataSource = dt;
            return true;
        }
        public bool DeleteDatainDataGridview()
        {
            foreach (DataGridViewRow item in importview.gvDetailProductData.SelectedRows)
            {
                DataGridViewRow row = importview.gvDetailProductData.Rows[item.Index];
                importview.gvDetailProductData.Rows.RemoveAt(item.Index);
            }
            return true;
        }
        public bool EditData(int index)
        {
            if (CheckInformation())
            {
                DataGridViewRow newDataRow = importview.gvDetailProductData.Rows[index];
                newDataRow.Cells[0].Value = importview.ProductId;
                newDataRow.Cells[1].Value = importview.ProductName;
                newDataRow.Cells[2].Value = importview.ImportPrice;
                newDataRow.Cells[3].Value = importview.Quantity;
                newDataRow.Cells[4].Value = importview.Total;
                ClearInformation();
                return true;
            }
            else
            {
                importview.message = "Please check information again.";
                return false;
            }
        }
        public bool ClearData()
        {
            ClearInformation();
            importview.TotalPriceProduct = "";
            importview.SuplierName = null;
            importview.gvDetailProductData.Rows.Clear();
            importview.gvDetailProductData.Refresh();
            return true;
        }
        public bool CheckDB()
        {
            if (importview.gvDetailProductData.Rows.Count > 1)
            {
                return true;
            }
            else
                return false;

        }
        public bool CheckSuplier()
        {
            if (importview.SuplierName == "")
            {
                importview.message = "Not yet select supplier. Please try again!";
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool AddDataToDB()
        {
            string id = import.AddData(importview.EmployeeID, importview.SuplierName, importview.TotalPriceProduct);

            string contentReceipt = "Import ID: " + id;
            string status = "Completed";
            import.AutoCreatePaySlip(importview.EmployeeID, contentReceipt, importview.TotalPriceProduct, status, "");

            if (importview.gvDetailProductData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in importview.gvDetailProductData.Rows)
                {
                    if (Convert.ToString(row.Cells[0].Value) != "")
                    {
                        DetailImport detailImport = new DetailImport();
                        detailImport.AddDetailData(row.Cells[0].Value.ToString(), id, row.Cells[2].Value.ToString(),
                         row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString());
                        import.UpdateProduct(row.Cells[3].Value.ToString(), row.Cells[0].Value.ToString());
                    }
                }
                importview.message = "Created import form successfully. Do you want to print this form?";
                return true;
            }
            else
            {
                importview.message = "Check information again";
                return false;
            }
        }
        public bool Print(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString("Green Beauty", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);

            graphic.DrawString("Addresss: 136, Linh Trung, Thủ Đức, TP Thủ Đức", font, new SolidBrush(Color.Black), startX, 40);

            graphic.DrawString("Phone: 1900 1555".PadRight(40) + "Employee: " + importview.EmployeeName, font, new SolidBrush(Color.Black), startX, 60);
            offset = offset + 50;
            string top = "Product".PadRight(20) + "Quantities".PadRight(20) + "Unit Price".PadRight(20) + "Total".PadRight(10);
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("-------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            if (importview.gvDetailProductData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in importview.gvDetailProductData.Rows)
                {
                    if (Convert.ToString(row.Cells[0].Value) != "")
                    {
                        string Name = row.Cells[1].Value.ToString();
                        int Quantities = int.Parse(row.Cells[3].Value.ToString());
                        float UnitPrice = float.Parse(row.Cells[2].Value.ToString());
                        float Total = float.Parse(row.Cells[4].Value.ToString());

                        graphic.DrawString(Name, font, new SolidBrush(Color.Black), startX, startY + offset);
                        graphic.DrawString(Quantities.ToString(), font, new SolidBrush(Color.Black), 260, startY + offset);
                        graphic.DrawString(UnitPrice.ToString(), font, new SolidBrush(Color.Black), 440, startY + offset);
                        graphic.DrawString(Total.ToString(), font, new SolidBrush(Color.Black), 630, startY + offset);
                        offset = offset + (int)fontHeight + 5; //make the spacing consistent       
                    }
                }
                float total = 0f;
                float productTotal = float.Parse(importview.TotalPriceProduct);
                total = productTotal;
                offset = offset + 20;
                graphic.DrawString("Total: ".PadRight(60) + total.ToString("###,###"), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            }
            return true;
        }
    }
}

