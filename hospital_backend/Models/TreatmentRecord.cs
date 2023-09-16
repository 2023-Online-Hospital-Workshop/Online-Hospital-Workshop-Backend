using System;
using System.Collections.Generic;

namespace hospital_backend.Models
{
    public partial class TreatmentRecord
    {
        public string DiagnosisRecordId { get; set; } = null!;
        public string? DoctorId { get; set; }
        public string? PatientId { get; set; }
        public string? LeaveNoteId { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
