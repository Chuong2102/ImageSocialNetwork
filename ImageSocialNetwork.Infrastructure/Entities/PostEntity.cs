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
        public string Text { get; set; }
        public UserEntity User { get; set; }

    }
}
