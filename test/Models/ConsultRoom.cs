using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class ConsultRoom
    {
        public ConsultRoom()
        {
            ConsultInformations = new HashSet<ConsultInformation>();
            Equipment = new HashSet<Equipment>();
        }

        public string ConsultingRoomName { get; set; } = null!;
        public decimal? ConsultantCapacity { get; set; }

        public virtual ICollection<ConsultInformation> ConsultInformations { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
