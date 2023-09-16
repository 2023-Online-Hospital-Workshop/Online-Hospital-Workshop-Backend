using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Disease
    {
        public string SecondaryDepartmentId { get; set; } = null!;
        public string Symptom { get; set; } = null!;
        public string DeseaseName { get; set; } = null!;
        public string? CureMethod { get; set; }

        public virtual Department2nd SecondaryDepartment { get; set; } = null!;
    }
}
