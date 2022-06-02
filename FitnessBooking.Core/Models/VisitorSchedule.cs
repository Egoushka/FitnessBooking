using System;

namespace FitnessBooking.Core.Models
{
    public class VisitorSchedule
    {
        public int Id { get; set; }
        public int SectionScheduleId { get; set; }
        public DateTime Day { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public virtual SectionSchedule SectionSchedule { get; set; }
        public virtual User User { get; set; }
    }
}