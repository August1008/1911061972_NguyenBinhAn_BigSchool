using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1911061972_NguyenBinhAn_BigSchool.Models
{
    public class Attendance
    {
        [Key]
        [Column(Order =1)]
        public int CourseId { set; get; }
        public Course Course { set; get; }

        [Key]
        [Column(Order =2)]
        public string AttenderId { set; get; }
        public ApplicationUser Attender { set; get; }
    }
}