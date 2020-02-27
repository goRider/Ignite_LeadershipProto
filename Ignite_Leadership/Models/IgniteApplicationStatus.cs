using System;
using System.Collections.Generic;

namespace Ignite_Leadership.Models
{
    public partial class IgniteApplicationStatus
    {
        public IgniteApplicationStatus()
        {
            IgniteUserApplication = new HashSet<IgniteUserApplication>();
        }

        public int IgniteApplicationStatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<IgniteUserApplication> IgniteUserApplication { get; set; }
    }
}
