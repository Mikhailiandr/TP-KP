using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Student.Models
{
    public class TestContext : DbContext
    {
        public TestContext()  :
        base("Database1") 
        { }

        public DbSet<Test> Test { get; set; }
        public DbSet<Mark> Mark { get; set; }
    }
}