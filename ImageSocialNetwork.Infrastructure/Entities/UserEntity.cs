using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSocialNetwork.Infrastructure.Entities
{
    public class UserEntity
    {
        [Key]
        public int UserID { get; set; }

        public string UserName { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        public int Gender { get; set; }
        public DateTime LasLogin { get; set; }
        public AccountEntity Account { get; set; }

    }
}
