using System;

namespace FitnessBooking.Core.Models.Requests
{
    public class GetSectionScheduleRequest
    {
        public GetSectionScheduleRequest(int? id, int? sectionId, TimeSpan? startHour, TimeSpan? endHour)
        {
            Id = id;
            SectionId = sectionId;
            StartHour = startHour;
            EndHour = endHour;
        }

        public int? Id { get; set; }
        public int? SectionId { get; set; }
        public TimeSpan? StartHour { get; set; }
        public TimeSpan? EndHour { get; set; }
    }
}