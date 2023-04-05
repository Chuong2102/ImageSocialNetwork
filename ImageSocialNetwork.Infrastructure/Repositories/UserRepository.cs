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

        public async Task<int> AddUserAsync(string Username, string Password, string Fullname, string Phone, int Gender, string Email, DateTime DateOfBirth)
        {
            var parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Username", Username));
            parameters.Add(new SqlParameter("@Fullname", Fullname));
            parameters.Add(new SqlParameter("@Email", Email));
            parameters.Add(new SqlParameter("@Phone", Phone));
            parameters.Add(new SqlParameter("@Gender", Gender));
            parameters.Add(new SqlParameter("@DateOfBirth", DateOfBirth));
            parameters.Add(new SqlParameter("@Password", Password));

            var result = await Task.Run(() => dbContext.Database.ExecuteSqlRawAsync(
                @"exec proc_AddUserAndAccount @Username, @Fullname, @Email, @Phone, @Gender, @DateOfBirth, @Password", parameters.ToArray()
            ));

            return result;
        }
    }
}
