using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Prescription
    {
        public string PrescriptionId { get; set; } = null!;
        public string? MedicineName { get; set; }
        public decimal MedicineDose { get; set; }
        public string? MedicationInstruction { get; set; }
        public decimal MedicinePrice { get; set; }
        public string? Doctor { get; set; }

        public virtual MedicineSpec? MedicineNameNavigation { get; set; }
        public virtual Doctor PrescriptionNavigation { get; set; } = null!;
    }
}
