using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSocialNetwork.Infrastructure.Entities
{
    public class FollowingEntity
    {
        [Key]
        public int FollowingID { get; set; }
        public UserEntity User { get; set; }
        public UserEntity Following { get; set; }
    }
}
