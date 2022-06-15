using System;

namespace FitnessBooking.Core.Models.Dto.VisitorSchedule
{
    public class NewVisitorScheduleDto
    {
        public NewVisitorScheduleDto(Models.VisitorSchedule visitorSchedule) :
            this(visitorSchedule.UserId, visitorSchedule.Day, visitorSchedule.SectionScheduleId,
                visitorSchedule.StatusId)
        {
        }

        public NewVisitorScheduleDto(int userId, DateTime day, int sectionScheduleId, int statusId)
        {
            UserId = userId;
            Day = day;
            SectionScheduleId = sectionScheduleId;
            StatusId = statusId;
        }

        public int UserId { get; set; }
        public DateTime Day { get; set; }
        public int SectionScheduleId { get; set; }
        public int StatusId { get; set; }
    }
}