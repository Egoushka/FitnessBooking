using System;

namespace FitnessBooking.Core.Models.Dto.SectionSchedule
{
    public class SectionScheduleDto
    {
        public SectionScheduleDto(Models.SectionSchedule sectionSchedule) :
            this(sectionSchedule.Id, sectionSchedule.SectionId, sectionSchedule.StartHour, sectionSchedule.EndHour)
        {
        }

        public SectionScheduleDto(int id, int sectionId, TimeSpan? startHour, TimeSpan? endHour)
        {
            Id = id;
            SectionId = sectionId;
            StartHour = startHour;
            EndHour = endHour;
        }

        public int Id { get; set; }
        public int SectionId { get; set; }
        public TimeSpan? StartHour { get; set; }
        public TimeSpan? EndHour { get; set; }
    }
}