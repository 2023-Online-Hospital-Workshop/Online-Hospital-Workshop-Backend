using System;
using System.Collections.Generic;

namespace hospital_backend.Models
{
    public partial class Equipment
    {
        public string ConsultingRoomName { get; set; } = null!;
        public string EquipmentType { get; set; } = null!;
        public decimal? EquipmentAmount { get; set; }

        public virtual ConsultingRoom ConsultingRoomNameNavigation { get; set; } = null!;
    }
}
