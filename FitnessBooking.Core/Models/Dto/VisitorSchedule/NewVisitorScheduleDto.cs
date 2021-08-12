using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessBooking.Core.Models.Dto.VisitorSchedule
{
    public class NewVisitorScheduleDto
    {
        public int UserId { get; set; }
        public DateTime Day { get; set; }
        public int SectionScheduleId { get; set; }
        public int StatusId { get; set; }
    }
}
