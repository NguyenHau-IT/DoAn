﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Area_DAL
    {
        public List<Area> GetAllArea()
        {
            using (var context = new Cafe_Context())
            {
                return context.Areas.ToList();
            }
        }

        public void AddArea(Area area)
        {
            using (var context = new Cafe_Context())
            {
                context.Areas.Add(area);
                context.SaveChanges();
            }
        }

        public void UpdateArea(Area area)
        {
            using (var context = new Cafe_Context())
            {
                var existingArea = context.Areas.Find(area.AreaID);
                if (existingArea != null)
                {
                    existingArea.AreaName = area.AreaName;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteArea(string areaID)
        {
            using (var context = new Cafe_Context())
            {
                var area = context.Areas.Find(areaID);
                if (area != null)
                {
                    context.Areas.Remove(area);
                    context.SaveChanges();
                }
            }
        }
    }
}