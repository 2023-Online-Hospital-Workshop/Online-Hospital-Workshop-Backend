using System;
using System.Collections.Generic;

namespace hospital_backend.Models
{
    public partial class PrescriptionMedicine
    {
        public string PrescriptionId { get; set; } = null!;
        public string MedicineName { get; set; } = null!;
        public decimal MedicineDose { get; set; }
        public string? MedicationInstruction { get; set; }
        public decimal MedicinePrice { get; set; }

        public virtual MedicineDescription MedicineNameNavigation { get; set; } = null!;
    }
}
