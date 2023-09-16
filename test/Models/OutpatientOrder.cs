using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class OutpatientOrder
    {
        public string OrderId { get; set; } = null!;
        public string? PatientId { get; set; }
        public DateTime OrderTime { get; set; }

        public virtual Patient? Patient { get; set; }
    }
}
