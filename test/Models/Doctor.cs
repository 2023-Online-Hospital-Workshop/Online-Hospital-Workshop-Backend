using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            ConsultInformations = new HashSet<ConsultInformation>();
            ReferralRecords = new HashSet<ReferralRecord>();
            Registrations = new HashSet<Registration>();
            TransferTreatments = new HashSet<TransferTreatment>();
            TreatmentFeedbacks = new HashSet<TreatmentFeedback>();
        }

        public string DoctorId { get; set; } = null!;
        public string? Name { get; set; }
        public decimal? Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Title { get; set; }
        public string? Contact { get; set; }
        public string? SecondaryDepartment { get; set; }

        public virtual Department2nd DoctorNavigation { get; set; } = null!;
        public virtual Prescription? Prescription { get; set; }
        public virtual ICollection<ConsultInformation> ConsultInformations { get; set; }
        public virtual ICollection<ReferralRecord> ReferralRecords { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
        public virtual ICollection<TransferTreatment> TransferTreatments { get; set; }
        public virtual ICollection<TreatmentFeedback> TreatmentFeedbacks { get; set; }
    }
}
