using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSocialNetwork.Infrastructure.Entities
{
    public class PostEntity
    {
        [Key]
        public int PostID { get; set; }
        public string Caption { get; set; }
        public DateTime CreationDate { get; set; }
        public UserEntity User { get; set; }
        public int TotalLikes { get; set; }
        public int TotalComments { get; set; }

    }
}
