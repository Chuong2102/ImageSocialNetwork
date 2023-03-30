using ImageSocialNetwork.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.EF;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ImageSocialNetwork.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        ImageSocialDbContext dbContext;
        public UserRepository(ImageSocialDbContext db)
        {
            this.dbContext = db;
        }

        public async Task<int> AddUserAsync(UserEntity user)
        {
            var parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Username", user.UserName));
            parameters.Add(new SqlParameter("@Fullname", user.FullName));
            parameters.Add(new SqlParameter("@Email", user.Email));
            parameters.Add(new SqlParameter("@Phone", user.Phone));
            parameters.Add(new SqlParameter("@Gender", user.Gender));
            parameters.Add(new SqlParameter("@DateOfBirth", user.DateOfBirth));
            parameters.Add(new SqlParameter("@Password", user.Account.Password));

            var result = await Task.Run(() => dbContext.Database.ExecuteSqlRawAsync(
                @"exec proc_AddUserAndAccount @Username, @Fullname, @Email, @Phone, @Gender, @DateOfBirth, @Password", parameters.ToArray()
            ));

            return result;
        }
    }
}
