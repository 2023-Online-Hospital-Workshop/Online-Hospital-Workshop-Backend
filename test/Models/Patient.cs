using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Patient
    {
        public Patient()
        {
            MedicineOuts = new HashSet<MedicineOut>();
            OutpatientOrders = new HashSet<OutpatientOrder>();
            ReferralRecords = new HashSet<ReferralRecord>();
            Registrations = new HashSet<Registration>();
            TransferTreatments = new HashSet<TransferTreatment>();
            TreatmentFeedbacks = new HashSet<TreatmentFeedback>();
        }

        public string PatientId { get; set; } = null!;
        public string? Name { get; set; }
        public bool? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Contact { get; set; }

        public virtual ICollection<MedicineOut> MedicineOuts { get; set; }
        public virtual ICollection<OutpatientOrder> OutpatientOrders { get; set; }
        public virtual ICollection<ReferralRecord> ReferralRecords { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
        public virtual ICollection<TransferTreatment> TransferTreatments { get; set; }
        public virtual ICollection<TreatmentFeedback> TreatmentFeedbacks { get; set; }
    }
}
