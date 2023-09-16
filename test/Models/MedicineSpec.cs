using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class MedicineSpec
    {
        public MedicineSpec()
        {
            Prescriptions = new HashSet<Prescription>();
        }

        public string MedicineName { get; set; } = null!;
        public string MedicineType { get; set; } = null!;
        public string? MedicineDescription { get; set; }
        public string? ApplicableSymptom { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
