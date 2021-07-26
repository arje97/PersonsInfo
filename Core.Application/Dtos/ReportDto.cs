using Core.Domain;

namespace Core.Application.Dtos
{
    public  class ReportDto
    {
        public int Count { get; set; }
        public int PersonId { get; set; }
       // public int RelatedPerson { get; set; }
        public ConnectionType ConnectionType { get; set; }
    }
}
