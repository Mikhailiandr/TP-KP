using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Student.Models
{
    public class LectureContext : DbContext
    {
        public LectureContext() :
        base("Database1")
        { }

        public DbSet<Lecture> Lecture { get; set; }
    }
}