using System;
using System.Collections.Generic;

namespace hospital_backend.Models
{
    public partial class Administrator
    {
        public Administrator()
        {
            MedicinePurchases = new HashSet<MedicinePurchase>();
            MedicineStocks = new HashSet<MedicineStock>();
        }

        public string AdministratorId { get; set; } = null!;
        public string? Name { get; set; }
        public bool? Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Contact { get; set; }

        public virtual ICollection<MedicinePurchase> MedicinePurchases { get; set; }
        public virtual ICollection<MedicineStock> MedicineStocks { get; set; }
    }
}
