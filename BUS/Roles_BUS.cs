using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BUS
{
    public class Role_BUS
    {
        private Role_DAL role_DAL = new Role_DAL();

        public List<Role> GetALLRole()
        {
            return role_DAL.GetAllRoles();
        }

        public void AddRole(Role role)
        {
            role_DAL.AddRole(role);
        }

        public void UpdateRole(Role role)
        {
            role_DAL.UpdateRole(role);
        }

        public void DeleteRole(string roleID)
        {
            role_DAL.DeleteRole(roleID);
        }
    }
}
