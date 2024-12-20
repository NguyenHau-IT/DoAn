using DAL.Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Area_BUS
    {
        private Area_DAL area_DAL = new Area_DAL();

        public List<Area> GetAreas()
        {
            return area_DAL.GetAllArea();
        }

        public void AddArea(Area area)
        {
            area_DAL.AddArea(area);
        }

        public void UpdateArea(Area area)
        {
            area_DAL.UpdateArea(area);
        }

        public void DeleteArea(string areaID)
        {
            area_DAL.DeleteArea(areaID);
        }

    }
}
