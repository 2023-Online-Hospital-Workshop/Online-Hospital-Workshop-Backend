using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Equipment
    {
        public string ConsultingRoomName { get; set; } = null!;
        public decimal EquipmentType { get; set; }
        public decimal EquipmentAmount { get; set; }

        public virtual ConsultRoom ConsultingRoomNameNavigation { get; set; } = null!;
    }
}
