using System;
using System.Collections.Generic;

namespace hospital_backend.Models
{
    public partial class MedicineSell
    {
        public string MedicineName { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public decimal SellingPrice { get; set; }
    }
}
