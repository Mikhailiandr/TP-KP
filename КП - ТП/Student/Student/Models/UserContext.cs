using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Student.Models
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("Database1")
        { }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }


        public User GetUser(String name)
        {
           return User.FirstOrDefault(u => u.Email == name);
        }
    }
}