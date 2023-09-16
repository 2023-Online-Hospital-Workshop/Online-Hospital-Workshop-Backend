using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class ConsultInformation
    {
        public string DoctorId { get; set; } = null!;
        public string ClinicName { get; set; } = null!;
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual ConsultRoom Doctor { get; set; } = null!;
        public virtual Doctor DoctorNavigation { get; set; } = null!;
    }
}
