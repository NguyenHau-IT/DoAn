using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BUS
{
    public class User_BUS
    {
        private User_DAL user_DAL = new User_DAL();

        public List<User> GetALLUser()
        {
            return user_DAL.GetAllUsers();
        }

        public void AddUser(User user)
        {
            user_DAL.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            user_DAL.UpdateUser(user);
        }

        public void DeleteUser(string username)
        {
            user_DAL.DeleteUser(username);
        }

        public bool Login(string username, string password)
        {
            return user_DAL.CheckLogin(username, password);
        }

        public string GetName(string username)
        {
            return user_DAL.GetName(username);
        }

        public dynamic GetInfor(string username)
        {
            return user_DAL.GetInfor(username);
        }
    }
}
