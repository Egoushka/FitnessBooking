namespace FitnessBooking.Core.Models.Dto.SectionSchedule
{
    public class UpdateSectionScheduleDto
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
    }
}