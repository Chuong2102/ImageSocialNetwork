using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ImageSocialNetwork.Infrastructure.Entities;

namespace ImageSocialNetwork.Infrastructure.Commands
{
    public class AddUserCommand : IRequest<int>
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }

        public AddUserCommand(UserEntity user)
        {
            this.Username = user.UserName;
            this.Fullname = user.FullName;
            this.Email = user.Email;
            this.Phone = user.Phone;
            this.Gender = user.Gender;
            this.DateOfBirth = user.DateOfBirth;
            this.Password = user.Account.Password;


        }
    }
}
