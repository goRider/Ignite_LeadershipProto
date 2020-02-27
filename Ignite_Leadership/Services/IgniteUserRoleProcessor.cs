using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Ignite_Leadership.Models;
using Microsoft.Extensions.Configuration;

namespace Ignite_Leadership.Services
{
    public class IgniteUserRoleProcessor
    {
        private string _tableName;
        private string _connectionString;
        private IConfiguration _configuration;

        public IgniteUserRoleProcessor(IConfiguration configuration, string connectionString)
        {
            _configuration = configuration;
            _connectionString = connectionString;
        }

        public string ConnectionString
        {
            get { return "Server=DESKTOP-U64RJVE\\SQLEXPRESS;Database=infr_common;Trusted_Connection=True;MultipleActiveResultSets=true"; }
        }

        public IgniteUserRoleProcessor()
        {
            
        }

        public async Task<bool> AddIgniteRoleType(IgniteUserRoleType roleType)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                _tableName = "ibs.IgniteUserRoleType";
                string newSql = "INSERT INTO ibs.IgniteUserRoleType(IgniteUserRoleTypeId, IgniteUserRoleTypeName) VALUES (1, 'HR'), (2, 'Manager'), (3, 'Regular Employee')";
                await connection.QueryAsync(newSql);
            }

            return true;
        }
    }
}
