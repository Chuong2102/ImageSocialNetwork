using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSocialNetwork.Infrastructure.Entities
{
    public class CommentEntity
    {
        [Key]
        public int CommentID { get; set; }
        public UserEntity User { get; set; }
        public PostEntity Post { get; set; }
        public string Text { get; set; }
        public int RepliedCommentID { get; set; }
    }
}
