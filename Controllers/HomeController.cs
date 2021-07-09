using _1911061972_NguyenBinhAn_BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace _1911061972_NguyenBinhAn_BigSchool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var upCourse = _dbContext.courses.Include(c => c.Lecturer).Include(c => c.Category).Where(c => c.datetime > DateTime.Now);  // lay ra danh sach khoa hoc
            var Attendings = _dbContext.attendances.Where(a => a.AttenderId == userId).ToList();           // lay ra danh sach khoa hoc user dang tham gia
            var viewModel = new CoursesListViewModel { UpCourses = upCourse, showButton = User.Identity.IsAuthenticated };
            viewModel.showAtend = new List<bool>();
            foreach(Course course in viewModel.UpCourses)                   // tao danh sach khoa hoc
            {                                                               // neu dang tham gia thi showAtend[i] = true, nguoc lai la false
                if (Attendings.Any(a=>a.CourseId == course.Id))        
                    viewModel.showAtend.Add(true);
                else
                    viewModel.showAtend.Add(false);
            }
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}