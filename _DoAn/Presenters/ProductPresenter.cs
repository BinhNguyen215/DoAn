using _DoAn.Models;
using _DoAn.Views.Product;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DoAn.Presenters
{
    public class ProductPresenter
    {
        IProductView productview;
        Product product = new Product();
        public List<KeyValuePair<string, int>> listUnit;


        public ProductPresenter(IProductView view)
        {
            productview = view;
            listUnit = new List<KeyValuePair<string, int>>();
        }
        public bool GetProductType()
        {
            foreach (string item in product.GetProductType())
            {
                productview.cbData.Add(item);
            }
            return true;
        }

        public bool GetProduct()
        {
            DataTable dt = new DataTable();
            dt = product.GetProductData();
            productview.gvData.DataSource = dt;
            return true;
        }
        public bool ClearInformation()
        {
            productview.ProductID = "";
            productview.ProductName = "";
            productview.ProductType = null;
            productview.Price = "";
            productview.Description = "";
            productview.Original = "";
            productview.Unit = null;
            return true;
        }
        public bool RetriveProduct(int index, string id, string name, string pri, string des, string ori, string unit, string type)
        {
            if (index != -1)
            {
                ClearInformation();
                productview.ProductID = id;
                productview.ProductName = name;
                productview.ProductType = type;
                productview.Price = pri;
                productview.Description = des;
                productview.Original = ori;
                productview.Unit = unit;
            }
            return true;
        }

        public bool AddData()
        {

            if (product.AddProduct(productview.ProductName, productview.Price, productview.Description, productview.Original, productview.Unit, productview.ProductType))
            {
                productview.message = "Add new product successfully";
                return true;
            }
            else
            {
                productview.message = "Add new product fail";
                return false;
            }
        }
        public bool DeleteData()
        {
            if (product.DeleteProduct(productview.ProductID))
            {
                productview.message = "Deleted product successfully";
                return true;
            }
            else
            {
                productview.message = "Deleted product fail";
                return false;
            }
        }

        public bool EditData()
        {
            if (product.UpdateProduct(productview.ProductID, productview.ProductName, productview.Price, productview.Description, productview.Original, productview.Unit, productview.ProductType))
            {
                productview.message = "Update product successfully";
                return true;
            }
            else
            {
                productview.message = "Update product fail";
                return false;
            }
        }
        public bool CheckInformation()
        {
            if (productview.ProductID != "" || productview.ProductName == "" ||
            productview.ProductType == "" ||
            productview.Price == "" ||
            productview.Description == "" ||
            productview.Original == "" ||
            productview.Unit == "")
            {
                return false;
            }
            return true;
        }
        public bool CheckInformationEdit()
        {
            if (productview.ProductID == "" ||
            productview.ProductName == "" ||
            productview.ProductType == "" ||
            productview.Price == "" ||
            productview.Description == "" ||
            productview.Original == "" ||
            productview.Unit == "")
            {
                return false;
            }
            else
                return true;
        }
        //bao
        /*public bool CheckStockQuantity(int productId)
        {
            int stockQuantity = product.GetDataQuantity(productId); // Hàm này trả về số lượng hàng tồn kho dựa trên productId
            if (stockQuantity <= 0)
            {
                ProductView.ShowAlert($"Sản phẩm {productId} sắp hết hàng! Số lượng còn lại: {stockQuantity}");
                return true;
            }
            return false;
        }*/

        public void GetProductUnit()
        {
            SqlDataReader dr = product.GetProductUnit();
            while (dr.Read())
            {
                string key = dr["Unit"].ToString();
                int value = int.Parse(dr["Coef"].ToString());
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(key,value);
                listUnit.Add(pair);
                productview.cbunit.Add(dr["Unit"]);
            }
            productview.cbunit.Add("Add another unit...");
        }

       /* public string setCoef(string key2Find)
        {
            KeyValuePair<string, int> pairUnit2Find = listUnit.Find(kvp => kvp.Key.Equals(key2Find));
            return pairUnit2Find.Value.ToString();
        }*/


    }
}
