using _DoAn.Models;
using _DoAn.Views.Product;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Presenters
{
    public class ProductPresenter
    {
        IProductView productview;
        Product product = new Product();


        public ProductPresenter(IProductView view)
        {
            productview = view;
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
    }
}
