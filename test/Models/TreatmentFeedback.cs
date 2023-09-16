using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class TreatmentFeedback
    {
        public string PatientId { get; set; } = null!;
        public string DoctorId { get; set; } = null!;
        public decimal? TreatmentScore { get; set; }
        public string? CommentDetail { get; set; }
        public string? FollowUpMatters { get; set; }

        public virtual Doctor Patient { get; set; } = null!;
        public virtual Patient PatientNavigation { get; set; } = null!;
    }
}
