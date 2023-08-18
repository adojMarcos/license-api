using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviroment.Infrastructure.Data
{
    public interface IDbConector
    {
        public IDbConnection CreateConnection();
    };

    public class DbConnector : IDbConector
    {
        private readonly IConfiguration _configuration;

        public DbConnector(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            string _conectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(_conectionString);
        }
    }
}
