using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _1911061972_NguyenBinhAn_BigSchool.Models
{
    public class Course
    {
        public int Id { set; get; }
        public ApplicationUser Lecturer { get; set; }
        [Required]
        [StringLength(255)]
        public string place { get; set; }
        public DateTime datetime { set; get; }
        public Category Category { set; get; }
        [ForeignKey("Category")]
        public int CategoryId { set; get; }

    }
}