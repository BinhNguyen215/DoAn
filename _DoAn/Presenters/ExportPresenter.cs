using _DoAn.Models;
using _DoAn.Views.Export;
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
    public class ExportPresenter
    {
        IExport exportview;
        Export export = new Export();


        public ExportPresenter(IExport view)
        {
            exportview = view;
        }

        public bool GetProduct()
        {
            DataTable dt = new DataTable();
            dt = export.GetProductData();
            exportview.gvProductData.DataSource = dt;
            return true;
        }

        public bool ClearInformation()
        {
            exportview.ProductId = "";
            exportview.ProductName = "";
            exportview.ExportPrice = "";
            exportview.Quantity = "";
            exportview.Total = "";
            exportview.ExportReason = "";

            return true;
        }
        public bool RetriveProduct(int index, string id, string name, string price)
        {
            if (index != -1)
            {
                ClearInformation();
                exportview.ProductId = id;
                exportview.ProductName = name;
                exportview.ExportPrice = price;
            }
            return true;
        }
        public bool RetriveData(int index, string id, string name, string exportprice, string quantity, string total)
        {
            if (index != -1)
            {
                ClearInformation();
                exportview.ProductId = id;
                exportview.ProductName = name;
                exportview.ExportPrice = exportprice;
                exportview.Quantity = quantity;
                exportview.Total = total;
            }
            return true;
        }
        public bool AddDataToDataGridview()
        {
            if (CheckInformation())
            {
                bool found = false;
                if (exportview.gvDetailProductData.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in exportview.gvDetailProductData.Rows)
                    {
                        if (Convert.ToString(row.Cells[0].Value) == exportview.ProductId)
                        {
                            row.Cells[3].Value = (int.Parse(exportview.Quantity) + Convert.ToInt16(row.Cells[3].Value.ToString()));
                            row.Cells[4].Value = (double.Parse(exportview.Total) + Convert.ToDouble(row.Cells[4].Value.ToString()));
                            found = true;
                            return true;
                        }
                    }
                    if (!found)
                    {
                        exportview.gvDetailProductData.Rows.Add(exportview.ProductId, exportview.ProductName, exportview.ExportPrice, exportview.Quantity, exportview.Total);
                        return true;
                    }
                }
                else
                {
                    exportview.gvDetailProductData.Rows.Add(exportview.ProductId, exportview.ProductName, exportview.ExportPrice, exportview.Quantity, exportview.Total);
                    return true;
                }
                return true;
            }
            else
            {
                exportview.message = "Please check infromation again";
                return false;
            }
        }
        public bool CalculateTotal()
        {
            if (exportview.Quantity != "")
            {
                if (Convert.ToInt32(exportview.Quantity) > 0)
                {
                    double total = Convert.ToDouble(exportview.ExportPrice) * Convert.ToInt32(exportview.Quantity);
                    exportview.Total = total.ToString();
                }
            }
            return true;
        }
        public bool CalculateTotalPrice()
        {
            double sum = 0;
            for (int i = 0; i < exportview.gvDetailProductData.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(exportview.gvDetailProductData.Rows[i].Cells[4].Value);
            }
            exportview.TotalPriceProduct = sum.ToString();
            return true;
        }
        public bool CheckInformation()
        {
            if (string.IsNullOrEmpty(exportview.ProductId))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(exportview.ProductName))
                return false;
            else if (string.IsNullOrEmpty(exportview.ExportPrice))
                return false;
            else if (string.IsNullOrEmpty(exportview.Quantity))
                return false;
            else
                return true;
        }
        public bool SearchInformation(string search)
        {
            DataTable dt = new DataTable();
            dt = export.SearchData(search);
            exportview.gvProductData.DataSource = dt;
            return true;
        }
        public bool DeleteDatainDataGridview()
        {
            foreach (DataGridViewRow item in exportview.gvDetailProductData.SelectedRows)
            {
                DataGridViewRow row = exportview.gvDetailProductData.Rows[item.Index];
                exportview.gvDetailProductData.Rows.RemoveAt(item.Index);
            }
            return true;
        }
        public bool EditData(int index)
        {
            if (CheckInformation())
            {
                DataGridViewRow newDataRow = exportview.gvDetailProductData.Rows[index];
                newDataRow.Cells[0].Value = exportview.ProductId;
                newDataRow.Cells[1].Value = exportview.ProductName;
                newDataRow.Cells[2].Value = exportview.ExportPrice;
                newDataRow.Cells[3].Value = exportview.Quantity;
                newDataRow.Cells[4].Value = exportview.Total;
                return true;
            }
            else
            {
                exportview.message = "Please check infromation again";
                return false;
            }
        }
        public bool ClearData()
        {
            ClearInformation();
            exportview.TotalPriceProduct = "";
            exportview.ExportReason = "";
            exportview.gvDetailProductData.Rows.Clear();
            exportview.gvDetailProductData.Refresh();
            return true;
        }
        public bool AddDataToDB()
        {
            string id = export.AddData(exportview.EmployeeID, exportview.ExportReason, exportview.TotalPriceProduct);

            if (exportview.gvDetailProductData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in exportview.gvDetailProductData.Rows)
                {
                    if (Convert.ToString(row.Cells[0].Value) != "")
                    {
                        DetailExport detailExport = new DetailExport();
                        detailExport.AddDetailData(row.Cells[0].Value.ToString(), id, row.Cells[2].Value.ToString(),
                          row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString());
                        /*export.AddDetailData(row.Cells[0].Value.ToString(), id, row.Cells[2].Value.ToString(),
                          row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString());*/
                        export.UpdateProduct(row.Cells[3].Value.ToString(), row.Cells[0].Value.ToString());
                    }
                }
                exportview.message = "Created export form successfully. Do you want to print this form?";
                return true;
            }
            else
            {
                exportview.message = "Check information again";
                return false;
            }
        }
        public bool CheckDB()
        {
            if (exportview.gvDetailProductData.Rows.Count > 1)
            {
                return true;
            }
            else
                return false;

        }
        public bool Print(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString("Green Beauty - Export Form", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);

            graphic.DrawString("Addresss: 136, Linh Trung, Thủ Đức, TP Thủ Đức", font, new SolidBrush(Color.Black), startX, 40);

            graphic.DrawString("Phone: 1900 1555".PadRight(40) + "Employee: " + exportview.EmployeeName, font, new SolidBrush(Color.Black), startX, 60);
            offset = offset + 50;
            string top = "Product".PadRight(20) + "Quantities".PadRight(20) + "Unit Price".PadRight(20) + "Total".PadRight(10);
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("-------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            if (exportview.gvDetailProductData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in exportview.gvDetailProductData.Rows)
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
                float productTotal = float.Parse(exportview.TotalPriceProduct);
                total = productTotal;
                offset = offset + 20;
                graphic.DrawString("Total: ".PadRight(60) + total.ToString("###,###"), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            }
            return true;
        }
        public bool CheckReason()
        {
            if (exportview.ExportReason == "")
            {
                exportview.message = "Not yet enter the reason export. Please try again!";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
