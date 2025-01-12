﻿using System;
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

        public List<dynamic> GetALLProduct()
        {
            using (var context = new Cafe_Context())
            {
                var products = from p in context.Product
                               join c in context.Categories on p.CategoryID equals c.CategoryID
                               select new
                               {
                                   ProductID = p.ProductID,
                                   ProductName = p.ProductName,
                                   Price = p.Price,
                                   CategoryName = c.CategoryName,
                                   Description = p.Description,
                                   Images = p.Images
                               };

                return products.ToList<dynamic>();
            }
        }

        public void AddProduct(DAL.Entities.Product product)
        {
            using (var context = new Cafe_Context())
            {
                context.Product.Add(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(DAL.Entities.Product product)
        {
            using (var context = new Cafe_Context())
            {
                var existingProduct = context.Product.Find(product.ProductID);
                if (existingProduct != null)
                {
                    existingProduct.ProductName = product.ProductName;
                    existingProduct.Price = product.Price;
                    existingProduct.CategoryID = product.CategoryID;
                    existingProduct.Description = product.Description;
                    existingProduct.Images = product.Images;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteProduct(string productId)
        {
            using (var context = new Cafe_Context())
            {
                var product = context.Product.Find(productId);
                if (product != null)
                {
                    context.Product.Remove(product);
                    context.SaveChanges();
                }
            }
        }

        public List<dynamic> SearchID(string searchID)
        {
            using (var context = new Cafe_Context())
            {
                var products = from p in context.Product
                               join c in context.Categories on p.CategoryID equals c.CategoryID
                               where p.ProductID == searchID
                               select new
                               {
                                   ProductID = p.ProductID,
                                   ProductName = p.ProductName,
                                   Price = p.Price,
                                   CategoryName = c.CategoryName,
                                   Description = p.Description,
                                   Images = p.Images
                               };

                return products.ToList<dynamic>();
            }
        }

        public List<dynamic> Filter(string CategoryID)
        {
            using (var context = new Cafe_Context())
            {
                var products = from p in context.Product
                               join c in context.Categories on p.CategoryID equals c.CategoryID
                               where p.CategoryID == CategoryID
                               select new
                               {
                                   ProductID = p.ProductID,
                                   ProductName = p.ProductName,
                                   Price = p.Price,
                                   CategoryName = c.CategoryName,
                                   Description = p.Description,
                                   Images = p.Images
                               };

                return products.ToList<dynamic>();
            }
        }
    }
}
