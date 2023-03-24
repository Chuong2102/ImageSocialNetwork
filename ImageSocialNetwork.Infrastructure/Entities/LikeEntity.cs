using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSocialNetwork.Infrastructure.Entities
{
    public class LikeEntity
    {
        [Key]
        public int LikeID { get; set; }
        public UserEntity User { get; set; }
        public PostEntity Post { get; set; }
        public int TotalLikes { get; set; }
    }
}
