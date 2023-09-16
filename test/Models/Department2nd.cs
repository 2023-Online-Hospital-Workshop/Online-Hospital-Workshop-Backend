using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Department2nd
    {
        public Department2nd()
        {
            Diseases = new HashSet<Disease>();
        }

        public string DepartmentName { get; set; } = null!;
        public string? DepartmentDescription { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual ICollection<Disease> Diseases { get; set; }
    }
}
