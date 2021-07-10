using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using _1911061972_NguyenBinhAn_BigSchool.Models;
using _1911061972_NguyenBinhAn_BigSchool.DTOs;
using Microsoft.AspNet.Identity;

namespace _1911061972_NguyenBinhAn_BigSchool.Controllers
{

    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext db;

        public FollowingsController()
        {
            db  = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (db.followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exist");
            var following = new Following { FollowerId = userId, FolloweeId = followingDto.FolloweeId };
            db.followings.Add(following);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFollowing(string id)
        {
            var userId = User.Identity.GetUserId();
            var following = db.followings.SingleOrDefault(a => a.FollowerId == userId && a.FolloweeId == id);
            if (following == null)
                return NotFound();
            db.followings.Remove(following);
            db.SaveChanges();
            return Ok();
        }
       
    }
}
