using _1911061972_NguyenBinhAn_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _1911061972_NguyenBinhAn_BigSchool.DTOs;

namespace _1911061972_NguyenBinhAn_BigSchool.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var attendance = new Attendance { CourseId = attendanceDto.CourseId, AttenderId = User.Identity.GetUserId() };
            _dbContext.attendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
