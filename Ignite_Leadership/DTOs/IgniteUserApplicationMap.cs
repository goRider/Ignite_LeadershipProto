using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.FluentMap.Mapping;
using Ignite_Leadership.Models;

namespace Ignite_Leadership.DTOs
{
    public class IgniteUserApplicationMap : EntityMap<IgniteUserApplication>
    {
        public IgniteUserApplicationMap()
        {
            Map(i => i.IgniteApplicationStatus).Ignore();
            Map(i => i.MgtsemployeeCodeNavigation).Ignore();
            Map(i => i.QuestionsToAnswer).Ignore();
        }

        public int IgniteApplicationId { get; set; }
        public DateTime ApplicationCreationDate { get; set; }
        public string ManagerName { get; set; }
        public string BuName { get; set; }
        public string LocationName { get; set; }
        public bool EmployementOverOneYear { get; set; }
        public bool BachelorDegreeQualifier { get; set; }
        public bool BachelorDegreePursuing { get; set; }
        public DateTime? PreQualificationQuestionsCompletionDate { get; set; }
        public bool ArePrequalificationQuestionComplete { get; set; }
        public DateTime? ManagerStatusChangeDate { get; set; }
        public bool AreQualificationQuestionsComplete { get; set; }
        public int IgniteApplicationStatusId { get; set; }
        public int MgtsemployeeCode { get; set; }
    }
}
