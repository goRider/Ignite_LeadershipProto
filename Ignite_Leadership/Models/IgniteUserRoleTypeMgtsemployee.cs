using System;
using System.Collections.Generic;

namespace Ignite_Leadership.Models
{
    public partial class IgniteUserRoleTypeMgtsemployee
    {
        public int IgniteUserRoleTypeId { get; set; }
        public int MgtsemployeeCode { get; set; }

        public virtual IgniteUserRoleType IgniteUserRoleType { get; set; }
        public virtual Mgtsemployee IgniteUserRoleTypeNavigation { get; set; }
    }
}
