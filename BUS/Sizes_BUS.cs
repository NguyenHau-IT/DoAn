using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BUS
{
    public class Sizes_BUS
    {
        private Sizes_DAL Size_DAL = new Sizes_DAL();

        public List<Sizes> GetALLSize()
        {
            return Size_DAL.GetAllSizes();
        }

        public void AddSize(Sizes Size)
        {
            Size_DAL.AddSize(Size);
        }

        public void UpdateSize(Sizes Size)
        {
            Size_DAL.UpdateSize(Size);
        }

        public void DeleteSize(string SizeName)
        {
            Size_DAL.DeleteSize(SizeName);
        }
    }
}
