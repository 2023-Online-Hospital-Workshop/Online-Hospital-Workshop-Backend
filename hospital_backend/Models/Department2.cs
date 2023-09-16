using System;
using System.Collections.Generic;

namespace hospital_backend.Models
{
    public partial class Department2
    {
        public Department2()
        {
            Doctors = new HashSet<Doctor>();
        }

        public string DepartmentName { get; set; } = null!;
        public string? DepartmentDescription { get; set; }

        public virtual Disease? Disease { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
