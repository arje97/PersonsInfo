
using Core.Application.Dtos;
using Core.Application.Interfaces;
using Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Database.Implementations
{
    class PersonReport : Repository<PersonRelation>, IPersonReport
    {
        public PersonReport(PersonDbContext context) : base(context)
        {

        }

        public IEnumerable<ReportDto> Report()
        {
            var result = from db in context.PersonRelations
                         group db by new
                         {
                             db.ConnectionType,
                             db.PersonId,
                             // db.RelatedPersonId
                         }

                    into g
                         select new ReportDto
                         {
                             PersonId = g.Key.PersonId,
                             ConnectionType = g.Key.ConnectionType,
                             //  RelatedPerson=g.Key.RelatedPersonId,
                             //   PersonId = g.Key,
                               Count = g.Count()
                         };

            return result.ToList();

        }


    }

}
