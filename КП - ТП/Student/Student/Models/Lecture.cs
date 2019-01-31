using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student.Models
{
    public class Lecture
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lecturetext { get; set; }
        public DateTime date { get; set; }
    }
}