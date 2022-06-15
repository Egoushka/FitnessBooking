using System;

namespace FitnessBooking.Core.Models.Dto.VisitorSchedule
{
    public class VisitorScheduleDto
    {
        public VisitorScheduleDto(Models.VisitorSchedule visitorSchedule) :
            this(visitorSchedule.Id, visitorSchedule.UserId, visitorSchedule.Day, visitorSchedule.SectionScheduleId,
                visitorSchedule.StatusId)
        {
        }

        public VisitorScheduleDto(int id, int userId, DateTime day, int sectionScheduleId, int statusId)
        {
            Id = id;
            UserId = userId;
            Day = day;
            SectionScheduleId = sectionScheduleId;
            StatusId = statusId;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Day { get; set; }
        public int SectionScheduleId { get; set; }
        public int StatusId { get; set; }
    }
}