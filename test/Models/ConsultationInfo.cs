using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class ConsultationInfo
    {
        public string DoctorId { get; set; } = null!;
        public string ClinicName { get; set; } = null!;
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
