using System;

namespace FitnessBooking.Core.Models.Infrastructure
{
    public class SectionSchedule
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
    }
}