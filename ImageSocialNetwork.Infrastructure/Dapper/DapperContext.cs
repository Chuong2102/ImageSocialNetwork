using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSocialNetwork.Infrastructure.Dapper
{
    public class DapperContext
    {
        IConfiguration configuration { get; set; }
        string connectionString { get; set; }

        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("ConnectionStringName");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
