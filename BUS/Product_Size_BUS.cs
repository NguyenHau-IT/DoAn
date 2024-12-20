using DAL.Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Product_Size_BUS
    {
        private Product_Size_DAL product_size = new Product_Size_DAL();

        public List<ProductSize> GetALLProductSize()
        {
            return product_size.GetAllProductSize();
        }

        public void AddProductSize(ProductSize productSize)
        {
            product_size.AddProductSize(productSize);
        }

        public void UpdateProductSize(ProductSize productSize)
        {
            product_size.UpdateProductSize(productSize);
        }

        public void DeleteProductSize(string productsizeID)
        {
            product_size.DeleteProductSize(productsizeID);
        }
    }
}
