using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Role_DAL
    {
        public List<Role> GetAllRoles()
        {
            using (var context = new Cafe_Context())
            {
                return context.Roles.ToList();
            }
        }

        public void AddRole(Role role)
        {
            using (var context = new Cafe_Context())
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }

        public void UpdateRole(Role role)
        {
            using (var context = new Cafe_Context())
            {
                var existingRoles = context.Roles.Find(role.RoleID);
                if (existingRoles != null)
                {
                    existingRoles.RoleID = role.RoleName;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteRole(string roleID)
        {
            using (var context = new Cafe_Context())
            {
                var role = context.Roles.Find(roleID);
                if (role != null)
                {
                    context.Roles.Remove(role);
                    context.SaveChanges();
                }
            }
        }
    }
}
