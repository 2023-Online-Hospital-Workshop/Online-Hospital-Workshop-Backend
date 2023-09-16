using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class LeaveNoteApp
    {
        public string LeaveNoteId { get; set; } = null!;
        public DateTime LeaveApplicationTime { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public string? LeaveNoteRemark { get; set; }
    }
}
