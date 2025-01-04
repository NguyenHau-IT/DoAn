using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BUS
{
    public class User_BUS
    {

        public List<dynamic> GetALLUser()
        {
            using (var context = new Cafe_Context())
            {
                var users = from u in context.Users
                               join r in context.Roles on u.RoleID equals r.RoleID
                               select new
                               {
                                   UserName = u.UserName,
                                   Userpassword = u.Userpassword,
                                   FullName = u.FullName,
                                   Phone = u.Phone,
                                   IdentityCard = u.IdentityCard,
                                   RoleName = r.RoleName
                               };

                return users.ToList<dynamic>();
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

        public bool Login(string username, string password)
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

        public bool CheckRole(string username)
        {
            using (var context = new Cafe_Context())
            {
                var user = context.Users.FirstOrDefault(u => u.UserName == username);

                if (user != null)
                {
                    if (user.RoleID == "R1")
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public string GetName(string username)
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
        if (string.IsNullOrEmpty(username))
        {
            return null;
        }

        using (var context = new Cafe_Context())
        {
            var result = (from u in context.Users
                          join r in context.Roles on u.RoleID equals r.RoleID
                          where u.UserName == username
                          select new
                          {
                              u.FullName,
                              u.Phone,
                              u.IdentityCard,
                              r.RoleName
                          }).FirstOrDefault();

            if (result == null) return null;

            dynamic userInfo = new ExpandoObject();
            userInfo.FullName = result.FullName;
            userInfo.Phone = result.Phone;
            userInfo.IdentityCard = result.IdentityCard;
            userInfo.RoleName = result.RoleName;

            return userInfo;
        }
    }

    public User FindByID(string id)
        {
            using (var idEmploy = new Cafe_Context())
            {
                return idEmploy.Users.SingleOrDefault(p => p.IdentityCard == id);
            }
        }

        public User FindByName(string name)
        {
            using (var nameEmploy = new Cafe_Context())
            {
                return nameEmploy.Users.SingleOrDefault(n => n.FullName.ToLower() == name.ToLower());
            }
        }
    }
}
