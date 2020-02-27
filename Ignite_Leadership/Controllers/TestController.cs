using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ignite_Leadership.DTOs;
using Ignite_Leadership.Models;
using Ignite_Leadership.Services;
using Ignite_Leadership.Utilities.PasswordHasher;
using Microsoft.AspNetCore.Mvc;
using RandomNameGeneratorLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ignite_Leadership.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private EmployeeProcessor _employeeProcessor;

        public TestController(EmployeeProcessor employeeProcessor)
        {
            _employeeProcessor = employeeProcessor;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<MgtsemployeeDTO>> GetEmployees()
        {
            var empList = await _employeeProcessor.GetEmployeesAsync();
            return empList.ToList();
        }

        [HttpGet("add")]
        public async Task<string> AddedResult()
        {
            // Test Names
            Random random = new Random();
            var randomName = new PersonNameGenerator(random);
            var fname = randomName.GenerateRandomFemaleFirstName();
            var lname = randomName.GenerateRandomLastName();


            var myPassHasher = new MyPasswordHasher();
            var createdSalt = myPassHasher.CreateSalt(8);

            var _employeeProcessor = new EmployeeProcessor();
            var newEmployee = new Mgtsemployee
            {
                FirstName = fname,
                LastName = lname,
                LawsonCompanyCode = "0001",
                Smtpaddress = fname + "." + lname + "@maritz.com",
                FullName = fname + " " + lname,
                MgtsloginId = "OKELLOG",
                Title = "Business Analyst II",
                ActiveFlag = "1",
                HideFromApplications = "0",
                Password = "WorkPlat21",
                ExchangeMiddleInitial = true,
                ExchangeExcludeFromExportFlag = "0"
            };
            await _employeeProcessor.AddEmployee(newEmployee);

            return "Completed";
        }
    }
}
