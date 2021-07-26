using Core.Domain;

namespace Core.Application.Dtos
{
    public class AddPersonRelationDto
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public ConnectionType ConnectionType { get; set; }
    }
}
