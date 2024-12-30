﻿using DAL.Entities;
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

        public List<dynamic> GetALLProductSize()
        {
            using (var context = new Cafe_Context())
            {
                var productsize = from pz in context.ProductSizes
                                  join p in context.Product on pz.ProductID equals p.ProductID
                                  join z in context.Sizes on pz.SizeName equals z.SizeName
                                  select new
                                  {
                                      ProductSizeID = pz.ProductSizeID,
                                      SizeName = z.SizeName,
                                      SizePrice = z.SizePrice,
                                      ProductName = p.ProductName,
                                      ProductPrice = p.Price,
                                  };

                return productsize.ToList<dynamic>();
            }
        }

        public void AddProductSize(ProductSize productsize)
        {
            using (var context = new Cafe_Context())
            {
                context.ProductSizes.Add(productsize);
                context.SaveChanges();
            }
        }

        public void UpdateProductSize(ProductSize productsize)
        {
            using (var context = new Cafe_Context())
            {
                var existingProductSizes = context.ProductSizes.Find(productsize.ProductSizeID);
                if (existingProductSizes != null)
                {
                    existingProductSizes.SizeName = productsize.SizeName;
                    existingProductSizes.ProductID = productsize.ProductID;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteProductSize(int productsizeID)
        {
            using (var context = new Cafe_Context())
            {
                var productsize = context.ProductSizes.Find(productsizeID);
                if (productsize != null)
                {
                    context.ProductSizes.Remove(productsize);
                    context.SaveChanges();
                }
            }
        }
    }
}
