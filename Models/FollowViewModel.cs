using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1911061972_NguyenBinhAn_BigSchool.Models
{
    public class FollowViewModel
    {
        public IEnumerable<ApplicationUser> followings { set; get; }
        public bool showFol { set; get; }
    }
}