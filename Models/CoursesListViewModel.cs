using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1911061972_NguyenBinhAn_BigSchool.Models
{
    public class CoursesListViewModel
    {
        public IEnumerable<Course> UpCourses { set; get; }
        public bool showButton { set; get; }
    }
}