using System;
using System.Collections.Generic;

namespace hospital_backend.Models
{
    public partial class ConsultingRoom
    {
        public ConsultingRoom()
        {
            ConsultationInfos = new HashSet<ConsultationInfo>();
            Equipment = new HashSet<Equipment>();
        }

        public string ConsultingRoomName { get; set; } = null!;
        public decimal? ConsultantCapacity { get; set; }

        public virtual ICollection<ConsultationInfo> ConsultationInfos { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
