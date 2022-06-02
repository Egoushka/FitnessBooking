namespace FitnessBooking.Core.Models.Dto.Section
{
    public class UpdateSectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int GymId { get; set; }
    }
}