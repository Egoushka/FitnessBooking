using System;
using System.ComponentModel.DataAnnotations;
using FitnessBooking.Core.Models.Dto.SectionSchedule;
using FitnessBooking.Core.Models.Requests;

namespace FitnessBooking.Core.Models
{
    public class SectionSchedule
    {
        public SectionSchedule()
        {
        }

        public SectionSchedule(SectionScheduleDto sectionSchedule) :
            this(sectionSchedule.Id, sectionSchedule.SectionId, sectionSchedule.StartHour, sectionSchedule.EndHour)
        {
        }

        public SectionSchedule(int id, int sectionId, TimeSpan? startHour, TimeSpan? endHour)
        {
            Id = id;
            SectionId = sectionId;
            StartHour = startHour;
            EndHour = endHour;
        }

        [Key] public int Id { get; set; }

        public int SectionId { get; set; }
        public TimeSpan? StartHour { get; set; }
        public TimeSpan? EndHour { get; set; }

        public bool IsAppreciateToRequest(GetSectionScheduleRequest other)
        {
            return (StartHour?.Equals(other.StartHour) ?? true) &&
                   (EndHour?.Equals(other.EndHour) ?? true) &&
                   SectionId == other.SectionId;
        }
    }
}