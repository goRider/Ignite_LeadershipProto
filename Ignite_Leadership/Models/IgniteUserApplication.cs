using System;
using System.Collections.Generic;

namespace Ignite_Leadership.Models
{
    public partial class IgniteUserApplication
    {
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

        public virtual IgniteApplicationStatus IgniteApplicationStatus { get; set; }
        public virtual Mgtsemployee MgtsemployeeCodeNavigation { get; set; }
        public virtual QuestionsToAnswer QuestionsToAnswer { get; set; }
    }
}
