using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace _1911061972_NguyenBinhAn_BigSchool.Models
{
    public class CourseViewModel
    {
        public int Id { set; get; }
        [Required]
        public string place { set; get; }
        [Required]
        [FutureDate(ErrorMessage = "Ngày nhập phải lớn hơn ngày hiện tại")]
        public string date { set; get; }
        [Required]
        [ValidTime(ErrorMessage ="Nhập giờ theo định dạng HH:mm")]
        public string time { set; get; }
        [Required]
        public  int CategoryId { set; get; }
        public IEnumerable<Category> categories { set; get; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", date, time));
        }
    }
}