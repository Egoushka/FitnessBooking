using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessBooking.Core.Models.Dto.Coach
{
    public class CoachDto
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int UserId { get; set; }
    }
}
