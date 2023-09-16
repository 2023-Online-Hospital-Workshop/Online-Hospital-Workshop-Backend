using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class TransferTreatment
    {
        public string DoctorId { get; set; } = null!;
        public string PatientId { get; set; } = null!;
        public string Diease { get; set; } = null!;
        public DateTime? RferralTime { get; set; }
        public string? ReferralHospital { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
    }
}
