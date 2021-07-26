namespace Core.Domain
{
    public class PersonRelation
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int RelatedPersonId{ get; set; }
        public Person RelatedPerson { get; set; }
        public ConnectionType ConnectionType { get; set; }

    }
}
