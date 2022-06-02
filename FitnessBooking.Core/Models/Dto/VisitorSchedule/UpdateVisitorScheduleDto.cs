using System;

namespace FitnessBooking.Core.Models.Dto.VisitorSchedule
{
    public class UpdateVisitorScheduleDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Day { get; set; }
        public int SectionScheduleId { get; set; }
        public int StatusId { get; set; }
    }
}