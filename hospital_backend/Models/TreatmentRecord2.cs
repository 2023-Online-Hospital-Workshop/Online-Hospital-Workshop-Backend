using System;
using System.Collections.Generic;

namespace hospital_backend.Models
{
    public partial class TreatmentRecord2
    {
        public string DiagnoseId { get; set; } = null!;
        public DateTime? DiagnoseTime { get; set; }
    }
}
