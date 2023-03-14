using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageSocialNetwork.Infrastructure.Entities
{
    public class AccountEntity
    {
        [Key]
        public int AcountID { get; set; }
        [StringLength(30)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public string Role { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }

    }
}
