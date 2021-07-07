using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace _1911061972_NguyenBinhAn_BigSchool.Models
{
    public class Following
    {
        [Key]
        [Column(Order=1)]
        public string FollowerId { set; get; }
        [Key]
        [Column(Order = 2)]
        public string FolloweeId { set; get; }

        public ApplicationUser Follower { set; get; }
        public ApplicationUser Followee { set; get; }
    }
}