using _1911061972_NguyenBinhAn_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1911061972_NguyenBinhAn_BigSchool.Controllers.Api
{
    public class CoursesController : ApiController
    {
        private ApplicationDbContext db;
        public CoursesController()
        {
            db = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userid = User.Identity.GetUserId();
            var course = db.courses.Find(id);
            if(course.IsCanceled)
            {
                return NotFound();
            }
            course.IsCanceled = true;
            db.SaveChanges();
            return Ok();
        }
    }
}
