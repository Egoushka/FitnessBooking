namespace FitnessBooking.Core.Models.Dto.SectionSchredule
{
    public class UpdateSectionSchreduleDto
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
    }
}