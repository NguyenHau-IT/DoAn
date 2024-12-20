using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CF_Table_DAL
    {
        public List<dynamic> GetAllTables()
        {
            using (var context = new Cafe_Context())
            {
                var cf_table = from cf in context.CF_Table
                               join a in context.Areas on cf.AreaID equals a.AreaID
                               select new
                               {
                                   TableID = cf.TableID,
                                   TableName = cf.TableName,
                                   AreaName = a.AreaName
                               }; return cf_table.ToList<dynamic>();
            }
        }

        public CF_Table GetTableById(string tableId)
        {
            using (var context = new Cafe_Context())
            {
                return context.CF_Table.FirstOrDefault(t => t.TableID == tableId);
            }
        }

        public void AddTable(CF_Table table)
        {
            using (var context = new Cafe_Context())
            {
                context.CF_Table.Add(table);
                context.SaveChanges();
            }
        }

        public void UpdateTable(CF_Table table)
        {
            using (var context = new Cafe_Context())
            {
                var existingTable = context.CF_Table.Find(table.TableID);
                if (existingTable != null)
                {
                    existingTable.TableName = table.TableName;
                    existingTable.AreaID = table.AreaID;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteTable(string tableId)
        {
            using (var context = new Cafe_Context())
            {
                var table = context.CF_Table.FirstOrDefault(t => t.TableID == tableId);
                if (table != null)
                {
                    context.CF_Table.Remove(table);
                    context.SaveChanges();
                }
            }
        }
    }
}
