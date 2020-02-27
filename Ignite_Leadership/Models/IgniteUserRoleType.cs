using System;
using System.Collections.Generic;

namespace Ignite_Leadership.Models
{
    public partial class IgniteUserRoleType
    {
        public int IgniteUserRoleTypeId { get; set; }
        public string IgniteUserRoleTypeName { get; set; }

        public virtual IgniteUserRoleTypeMgtsemployee IgniteUserRoleTypeMgtsemployee { get; set; }
    }
}
