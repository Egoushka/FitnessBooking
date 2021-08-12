namespace FitnessBooking.Core.Models.Infrastructure
{
    public class EnvironmentDetails
    {
        public EnvironmentDetails()
        {
        }

        public string Name { get; set; }
        public string ApplicationName { get; set; }
        public string WebsiteBaseUri { get; set; }
        public string APIBaseUri { get; set; }
    }
}