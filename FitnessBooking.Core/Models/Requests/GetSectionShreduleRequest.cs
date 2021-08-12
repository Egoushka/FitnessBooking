using System;

namespace FitnessBooking.Core.Models.Requests
{
    public class GetSectionShreduleRequest
    {
        public GetSectionShreduleRequest(int? id, int? sectionId, TimeSpan? startHour, TimeSpan? endHour)
        {
            this.Id = id;
            this.SectionId = sectionId;
            this.StartHour = startHour;
            this.EndHour = endHour;
        }
        public int? Id { get; set; }
        public int? SectionId { get; set; }
        public TimeSpan? StartHour { get; set; }
        public TimeSpan? EndHour { get; set; }
    }
}