using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Ignite_Leadership.DTOs;
using Ignite_Leadership.Models;
using Microsoft.Extensions.Configuration;

namespace Ignite_Leadership.Services
{
    public class IgniteUserApplicationProcessor
    {
        private string _connectionString;
        private string _tableName;
        private IConfiguration _configuration;
        private IDbConnection _connection;

        // Application Status are listed from Not started, Incomp Preq, Complete Prequal, Not Qual, Start Qual, Endorse, Hold, Selected, Request Manager

        public IgniteUserApplicationProcessor()
        {
            
        }

        public IgniteUserApplicationProcessor(IConfiguration configuration, string connectionString, IDbConnection connection)
        {
            _configuration = configuration;
            _connectionString = connectionString;
            _connection = connection;
        }

        private List<IgniteUserApplicationMap> IgniteUserApplications { get; set; }

        public List<IgniteUserApplicationMap> GetIgniteApplicationsWithEndorsedStatus()
        {
            return IgniteUserApplications;
        }

        public List<IgniteUserApplicationMap> GetIgniteApplicationsWithEndorsedAndHoldStatus()
        {
            return IgniteUserApplications;
        }
    }
}
