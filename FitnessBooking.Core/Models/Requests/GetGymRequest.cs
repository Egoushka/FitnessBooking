namespace FitnessBooking.Core.Models.Requests
{
    public class GetGymRequest

    {
        public GetGymRequest(string location, string name, GetSectionRequest sectionRequest = null)
        {
            Location = location;
            Name = name;
            SectionRequest = sectionRequest;
        }
        public string Location { get; set; }
        public string Name { get; set; }
        public GetSectionRequest SectionRequest { get; set; }

    }
}