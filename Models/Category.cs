using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1911061972_NguyenBinhAn_BigSchool.Models
{
    public class Category
    {
        public int Id { set; get; }
        public string name { set; get; }

        public List<Course> courses { set; get; }
    }
}