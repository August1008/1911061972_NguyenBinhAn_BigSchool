using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1911061972_NguyenBinhAn_BigSchool.Models
{
    public class CourseViewModel
    {
        private string place { set; get; }
        public string date { set; get; }
        public string time{ set; get; }
        public  Category Category { set; get; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", date, time));
        }
    }
}