using System;
using System.Collections.Generic;

namespace hospital_backend.Models
{
    public partial class MedicineDescription
    {
        public MedicineDescription()
        {
            PrescriptionMedicines = new HashSet<PrescriptionMedicine>();
        }

        public string MedicineName { get; set; } = null!;
        public string MedicineType { get; set; } = null!;
        public string? MedicineDescription1 { get; set; }
        public string? ApplicableSymptom { get; set; }

        public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
