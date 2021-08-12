using FitnessBooking.Core.Models.Dto.Section;
using System.Collections.Generic;

namespace FitnessBooking.Core.Models.Requests
{
    public class GetGymRequest

    {
        public GetGymRequest(string location, string name, GetSectionRequest sectionRequest = null)
        {
            this.Location = location;
            this.Name = name;
            this.SectionRequest = sectionRequest;
        }
        public string Location { get; set; }
        public string Name { get; set; }
        public GetSectionRequest SectionRequest { get; set; }

    }
}