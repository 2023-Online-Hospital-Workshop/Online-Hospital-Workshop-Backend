using System;
using System.Collections.Generic;

namespace hospital_backend.Models
{
    public partial class ConsultationInfo
    {
        public string DoctorId { get; set; } = null!;
        public string ClinicName { get; set; } = null!;
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual ConsultingRoom ClinicNameNavigation { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
    }
}
