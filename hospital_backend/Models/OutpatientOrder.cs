using System;
using System.Collections.Generic;

namespace hospital_backend.Models
{
    public partial class OutpatientOrder
    {
        public string OrderId { get; set; } = null!;
        public string? PatientId { get; set; }
        public DateTime OrderTime { get; set; }

        public virtual Patient? Patient { get; set; }
    }
}
