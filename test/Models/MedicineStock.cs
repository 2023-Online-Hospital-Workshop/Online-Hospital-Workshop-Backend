using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class MedicineStock
    {
        public string MedicineName { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public DateTime ProductionDate { get; set; }
        public decimal MedicineShelflife { get; set; }
        public decimal? MedicineAmount { get; set; }
        public decimal ThresholdValue { get; set; }
        public DateTime? CleanDate { get; set; }
        public string? CleanAdministrator { get; set; }

        public virtual Administrator MedicineNameNavigation { get; set; } = null!;
    }
}
