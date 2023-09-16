using System;
using System.Collections.Generic;

namespace hospital_backend.Models
{
    public partial class Prescription
    {
        public string PrescriptionId { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public string? DoctorId { get; set; }

        public virtual Doctor? Doctor { get; set; }
    }
}
