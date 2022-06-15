namespace FitnessBooking.Core.Models.Dto.VisitorSchedule
{
    public class RemoveVisitorScheduleDto
    {
        public RemoveVisitorScheduleDto(Models.VisitorSchedule visitorSchedule) :
            this(visitorSchedule.Id, visitorSchedule.StatusId)
        {
        }

        public RemoveVisitorScheduleDto(int id, int statusId)
        {
            Id = id;
            StatusId = statusId;
        }

        public int Id { get; set; }
        public int StatusId { get; set; }
    }
}