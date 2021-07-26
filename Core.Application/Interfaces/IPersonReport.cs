using Core.Application.Dtos;
using Core.Application.Interfaces.Repositories;
using Core.Domain;
using System.Collections.Generic;

namespace Core.Application.Interfaces
{
    public interface IPersonReport: IRepository<PersonRelation>
    {
        IEnumerable<ReportDto> Report();
    }
}
