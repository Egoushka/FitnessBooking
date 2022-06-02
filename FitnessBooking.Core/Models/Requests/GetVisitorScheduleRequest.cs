namespace FitnessBooking.Core.Models.Requests
{
    public class GetVisitorScheduleRequest
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? VisitorScheduleId { get; set; }
        public GetVisitorScheduleRequest(int? id, int? userId, int? visitorScheduleId)
        {
            Id = id;
            UserId = userId;
            VisitorScheduleId = visitorScheduleId;
        }
    }
}
