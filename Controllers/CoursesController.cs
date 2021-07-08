using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _1911061972_NguyenBinhAn_BigSchool.Models;
using Microsoft.AspNet.Identity;

namespace _1911061972_NguyenBinhAn_BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses
        public ActionResult Index()
        {
            var courses = db.courses.Include(c => c.Category);
            return View(courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.categories, "Id", "name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel course)
        {
            if (ModelState.IsValid)
            {
                var Newcourse = new Course
                {

                    LecturerId = User.Identity.GetUserId(),
                    datetime = course.GetDateTime(),
                    CategoryId = course.CategoryId,
                    place = course.place
                };
                db.courses.Add(Newcourse);
                db.SaveChanges();
                return RedirectToAction("MyCourses","Courses");

            }

            ViewBag.CategoryId = new SelectList(db.categories, "Id", "name", course.CategoryId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.courses.Find(id);

            var viewModel = new CourseViewModel
            {
                Id = course.Id,
                place = course.place,
                date = course.datetime.ToString("dd/M/yyyy"),
                time = course.datetime.ToString("HH:mm"),
                CategoryId = course.CategoryId,
                categories = db.categories
                
            };
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.categories, "Id", "name", course.CategoryId);
            return View(viewModel);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseViewModel course)
        {
            if (ModelState.IsValid)
            {
                var updateCourse = db.courses.Find(course.Id);
                //var Newcourse = new Course
                //{
                //    Id = course.Id,
                //    LecturerId = User.Identity.GetUserId(),
                //    datetime = course.GetDateTime(),
                //    CategoryId = course.CategoryId,
                //    place = course.place
                //};
                // db.Entry(Newcourse).State = EntityState.Modified;
                updateCourse.place = course.place;
                updateCourse.datetime = course.GetDateTime();
                updateCourse.CategoryId = course.CategoryId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.categories, "Id", "name", course.CategoryId);
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.courses.Find(id);
            db.courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var courses = db.attendances.Where(a => a.AttenderId == userId)
                .Select(a => a.Course)
                .Include(l => l.Lecturer)
                .Include(l => l.Category);
            var viewModel = new CoursesListViewModel { UpCourses = courses, showButton = User.Identity.IsAuthenticated };
            return View(viewModel);
        }

        [Authorize]
        public ActionResult MyCourses()
        {
            var userId = User.Identity.GetUserId();
            var courses = db.courses.Where(a => a.LecturerId == userId).Include(a=>a.Category).Include(a=>a.Lecturer);
            var viewModel = new CoursesListViewModel { UpCourses = courses, showButton = false };
            return View(viewModel);
            

        }
    }
}
