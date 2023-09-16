using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Registration
    {
        public string PatientId { get; set; } = null!;
        public string DoctorId { get; set; } = null!;
        public DateTime AppointmentTime { get; set; }
        public string? Description { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
    }
}
