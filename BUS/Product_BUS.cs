using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BUS
{
    public class Product_BUS
    {
        private Product_DAL product_DAL = new Product_DAL();

        public List<dynamic> GetALLProduct()
        {
            return product_DAL.GetAllProducts();
        }

        public void AddProduct(DAL.Entities.Product product)
        {
            product_DAL.AddProduct(product);
        }

        public void UpdateProduct(DAL.Entities.Product product)
        {
            product_DAL.UpdateProduct(product);
        }

        public void DeleteProduct(string productID)
        {
            product_DAL.DeleteProduct(productID);
        }

        public List<dynamic> SearchID(string searchID)
        {
            return product_DAL.SearchID(searchID);
        }

        public List<dynamic> Filter(string CategoryID)
        {
            return product_DAL.Filter(CategoryID);
        }
    }
}
