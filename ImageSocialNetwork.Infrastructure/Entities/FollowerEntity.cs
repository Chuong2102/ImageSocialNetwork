using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSocialNetwork.Infrastructure.Entities
{
    public class FollowerEntity
    {
        [Key]
        public int FollowerID { get; set; }
        public UserEntity Follower { get; set; }
        public UserEntity Following { get; set; }

    }
}
