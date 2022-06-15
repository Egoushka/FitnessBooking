using System;
using System.ComponentModel.DataAnnotations;
using FitnessBooking.Core.Models.Dto.VisitorSchedule;
using FitnessBooking.Core.Models.Requests;

namespace FitnessBooking.Core.Models
{
    public class VisitorSchedule
    {
        public VisitorSchedule()
        {
        }

        public VisitorSchedule(UpdateVisitorScheduleDto visitorScheduleDto) :
            this(visitorScheduleDto.Id,
                visitorScheduleDto.SectionScheduleId,
                visitorScheduleDto.Day,
                visitorScheduleDto.UserId,
                visitorScheduleDto.StatusId)
        {
        }

        public VisitorSchedule(NewVisitorScheduleDto visitorScheduleDto) :
            this(
                visitorScheduleDto.SectionScheduleId,
                visitorScheduleDto.Day,
                visitorScheduleDto.UserId,
                visitorScheduleDto.StatusId)
        {
        }

        public VisitorSchedule(RemoveVisitorScheduleDto visitorScheduleDto) :
            this(visitorScheduleDto.Id,
                visitorScheduleDto.StatusId)
        {
        }

        public VisitorSchedule(int id, int userId)
        {
            Id = id;
            UserId = userId;
        }

        public VisitorSchedule(int sectionScheduleId, DateTime day, int userId, int statusId)
        {
            SectionScheduleId = sectionScheduleId;
            Day = day;
            UserId = userId;
            StatusId = statusId;
        }

        public VisitorSchedule(int id, int sectionScheduleId, DateTime day, int userId, int statusId)
        {
            Id = id;
            SectionScheduleId = sectionScheduleId;
            Day = day;
            UserId = userId;
            StatusId = statusId;
        }

        [Key] public int Id { get; set; }

        public int SectionScheduleId { get; set; }
        public DateTime Day { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public virtual SectionSchedule SectionSchedule { get; set; }
        public virtual User User { get; set; }

        public bool IsAppreciateToRequest(GetVisitorScheduleRequest request)
        {
            return Id == request.Id &&
                   request.UserId == UserId &&
                   request.SectionScheduleId == SectionScheduleId;
        }
    }
}