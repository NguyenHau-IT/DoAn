using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class User_DAL
    {
        public List<User> GetAllUsers()
        {
            using (var context = new Cafe_Context())
            {
                return context.Users.ToList();
            }
        }

        public void AddUser(User user)
        {
            using (var context = new Cafe_Context())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            using (var context = new Cafe_Context())
            {
                var existingUsers = context.Users.Find(user.UserName);
                if (existingUsers != null)
                {
                    existingUsers.UserName = user.UserName;
                    existingUsers.Userpassword = user.Userpassword;
                    existingUsers.FullName = user.FullName;
                    existingUsers.Phone = user.Phone;
                    existingUsers.IdentityCard = user.IdentityCard;
                    existingUsers.RoleID = user.RoleID;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteUser(string username)
        {
            using (var context = new Cafe_Context())
            {
                var user = context.Users.Find(username);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        public bool CheckLogin(string username, string password)
        {
            using (var context = new Cafe_Context())
            {
                var user = context.Users.FirstOrDefault(u => u.UserName == username);

                if (user != null)
                {
                    if (user.Userpassword == password)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public String GetName(string username)
        {
            try
            {
                using (var context = new Cafe_Context())
                {
                    var user = (from u in context.Users
                                where u.UserName == username
                                select new
                                {
                                    FullName = u.FullName
                                }).FirstOrDefault();

                    return user?.FullName ?? "User not found";
                }
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
        }
       
        public dynamic GetInfor(string username)
        {
            using (var context = new Cafe_Context())
            {
                var user = (from u in context.Users
                            join r in context.Roles on u.RoleID equals r.RoleID
                            where u.UserName == username
                            select new
                            {
                                u.FullName,
                                u.Phone,
                                u.IdentityCard,
                                r.RoleName
                            }).FirstOrDefault();
                return user;
            }
        }
    }
}

