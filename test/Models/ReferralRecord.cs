using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class ReferralRecord
    {
        public string? LeaveNoteId { get; set; }
        public string? PatientId { get; set; }
        public string? DoctorId { get; set; }
        public string DiagnosisRecordId { get; set; } = null!;

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
