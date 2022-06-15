namespace FitnessBooking.Core.Models.Requests
{
    public class GetVisitorScheduleRequest
    {
        public GetVisitorScheduleRequest(int? id, int? userId, int? sectionScheduleId)
        {
            Id = id;
            UserId = userId;
            SectionScheduleId = sectionScheduleId;
        }

        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? SectionScheduleId { get; set; }
    }
}