﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Sizes_DAL
    {
        public List<Sizes> GetAllSizes()
        {
            using (var context = new Cafe_Context())
            {
                return context.Sizes.ToList();
            }
        }

        public void AddSize(Sizes Size)
        {
            using (var context = new Cafe_Context())
            {
                context.Sizes.Add(Size);
                context.SaveChanges();
            }
        }

        public void UpdateSize(Sizes size)
        {
            using (var context = new Cafe_Context())
            {
                var existingSize = context.Sizes
                    .FirstOrDefault(s => s.SizeName == size.SizeName);

                if (existingSize != null)
                {
                    existingSize.SizePrice = size.SizePrice;

                    context.SaveChanges();
                }
            }
        }


        public void DeleteSize(string SizeName)
        {
            using (var context = new Cafe_Context())
            {
                var Size = context.Sizes.Find(SizeName);
                if (Size != null)
                {
                    context.Sizes.Remove(Size);
                    context.SaveChanges();
                }
            }
        }
    }
}