namespace FitnessBooking.Core.Models.Dto.Coach
{
    public class CoachDto
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int UserId { get; set; }
        
        public static CoachDto FromEntityToDto(Models.Coach coach)
        {
            return new CoachDto
            {
                Id = coach.Id,
                SectionId = coach.SectionId,
                UserId = coach.UserId
            };
        }
    }
}
