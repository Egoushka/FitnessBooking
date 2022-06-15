namespace FitnessBooking.Core.Models.Dto.Section
{
    public class SectionDto
    {
        public SectionDto(Models.Section section) : this(section.Id, section.Name, section.TypeId, section.GymId)
        {
        }

        public SectionDto(int id, string name, int typeId, int gymId)
        {
            Id = id;
            Name = name;
            TypeId = typeId;
            GymId = gymId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int GymId { get; set; }


        public static Models.Section FromDtoToEntity(SectionDto section)
        {
            return new Models.Section
            {
                Id = section.Id,
                GymId = section.GymId,
                TypeId = section.TypeId,
                Name = section.Name
            };
        }
    }
}