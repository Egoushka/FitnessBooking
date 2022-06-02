using System.Collections.Generic;

namespace FitnessBooking.Core.Models.Dto.Gym
{
    public class GymDto
    {
        public GymDto(Models.Gym gym) : this(gym.Id,gym.Name, gym.Location, gym.Description, gym.Sections)
        {
        }

        public GymDto(int id, string name, string location, string description, ICollection<Models.Section> sections)
        {
            Id = id;
            Name = name;
            Location = location;
            Description = description;
            Sections = sections;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public ICollection<Models.Section> Sections { get; set; }
        
        public static GymDto FromEntityToDto(Models.Gym gym)
        {
            return new GymDto(gym.Id, gym.Name, gym.Location, gym.Description, gym.Sections);
        }
    }
}
