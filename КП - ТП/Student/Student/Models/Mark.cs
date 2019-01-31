using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student.Models
{
    public class Mark
    {
        public int id { get; set; }
        public int mark { get; set; }

        public User user { get; set; }
        public int Userid { get; set; }

        public Test test { get; set; }
        public int Testid { get; set; }
    }
}