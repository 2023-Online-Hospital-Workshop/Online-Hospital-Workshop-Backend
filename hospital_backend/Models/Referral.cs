using System;
using System.Collections.Generic;

namespace hospital_backend.Models
{
    public partial class Referral
    {
        public string DoctorId { get; set; } = null!;
        public string PatientId { get; set; } = null!;
        public string? Disease { get; set; }
        public DateTime? ReferralTime { get; set; }
        public string? ReferralHospital { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
    }
}
