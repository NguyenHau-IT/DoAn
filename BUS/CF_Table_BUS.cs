using DAL.Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CF_Table_BUS
    {
        private CF_Table_DAL table_DAL = new CF_Table_DAL();

        public List<dynamic> GetALLTables()
        {
            return table_DAL.GetAllTables();
        }

        public CF_Table GetTableById(string tableId)
        {
            return table_DAL.GetTableById(tableId);
        }

        public void AddTable(CF_Table table)
        {
            table_DAL.AddTable(table);
        }

        public void UpdateTable(CF_Table table)
        {
            table_DAL.UpdateTable(table);
        }

        public void DeleteTable(string tableId)
        {
            table_DAL.DeleteTable(tableId);
        }
    }
}
