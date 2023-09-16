using System;
using System.Collections.Generic;

namespace hospital_backend.Models
{
    public partial class MedicinePurchase
    {
        public string MedicineName { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public DateTime ProductionDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string? AdministratorId { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal PurchasePrice { get; set; }

        public virtual Administrator? Administrator { get; set; }
    }
}
