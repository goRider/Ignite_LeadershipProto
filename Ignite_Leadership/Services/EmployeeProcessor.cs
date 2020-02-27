using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Ignite_Leadership.DTOs;
using Ignite_Leadership.Models;
using Microsoft.Extensions.Configuration;

namespace Ignite_Leadership.Services
{
    public class EmployeeProcessor
    {
        private string _connectionString;
        private string _tableName;
        private IConfiguration _configuration;

        public EmployeeProcessor(IConfiguration configuration, string connectionString)
        {
            _configuration = configuration;
            _connectionString = connectionString;
        }

        public string ConnectionString
        {
            get { return "Server=DESKTOP-U64RJVE\\SQLEXPRESS;Database=infr_common;Trusted_Connection=True;MultipleActiveResultSets=true"; }
        }

        public EmployeeProcessor()
        {
        }

        public IDbConnection GetConnection()
        {
            //_connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            var connectionString = ConnectionString;
            var conn = new SqlConnection(connectionString);
            return conn;
        }

        public List<MgtsemployeeDTO> MgtsemployeeDtos { get; set; }

        public async Task<List<MgtsemployeeDTO>> GetEmployeesAsync()
        {
            _tableName = "ibs.MGTSEmployee";
            var query = @"SELECT TOP 1000 * FROM  ibs.MGTSEmployee";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var employees = await connection.QueryAsync<Mgtsemployee>(query);
                var empList = employees.ToList();

                MgtsemployeeDtos = (from mgtsemployee in empList
                    orderby mgtsemployee.LastName
                    select new MgtsemployeeDTO()).ToList();

                return MgtsemployeeDtos;
            }
        }

        public async Task<bool> AddEmployee(Mgtsemployee employee)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                _tableName = "ibs.MGTSEmployee";
                string sql = "INSERT INTO " + _tableName +
                 " (FirstName, LastName, LawsonCompanyCode, Smtpaddress, FullName, MgtsloginId, Title, ActiveFlag, HideFromApplications, Password, ExchangeMiddleInitial, ExchangeExcludeFromExportFlag) " +
                 "VALUES(@FirstName, @LastName, @LawsonCompanyCode, @Smtpaddress, @FullName, @MgtsloginId, @Title, @ActiveFlag, @HideFromApplications, @Password, @ExchangeMiddleInitial, @ExchangeExcludeFromExportFlag)";

                

                var returnId = await connection.QueryAsync<int>(sql, employee);
                
                employee.MgtsemployeeCode = returnId.SingleOrDefault();

            }
            return true;
        }
    }
}
