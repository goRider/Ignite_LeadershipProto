using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ignite_Leadership.DTOs;
using Microsoft.Extensions.Configuration;

namespace Ignite_Leadership.Services
{
    public class ResultJoinProcessor
    {
        private string _connectionString;
        private string _tableName;
        private IConfiguration _configuration;

        public string ConnectionString
        {
            get { return "Server=DESKTOP-U64RJVE\\SQLEXPRESS;Database=infr_common;Trusted_Connection=True;MultipleActiveResultSets=true"; }
        }

        public List<MgtsEmployeesToIgniteApplication> MgtsEmployeesToIgniteApplications { get; set; }

        public List<MgtsEmployeesToIgniteApplication> GetMgtsEmployeesWithoutIgniteApplications()
        {
            return MgtsEmployeesToIgniteApplications;
        }


    }
}
