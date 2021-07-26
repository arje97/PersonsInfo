using Core.Application.Interfaces;
using Core.Application.Interfaces.Repositories;

namespace Infrastructure.Database.Implementations
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly IPersonRepository personRepository;
        private readonly IPhoneNumberRepository phoneNumberRepository;
        private readonly IPersonReport personReport;

        public UnitOfWork( IPersonRepository personRepository,IPhoneNumberRepository phoneNumberRepository,IPersonReport personReport)
        {
        
            this.personRepository = personRepository;
            this.phoneNumberRepository = phoneNumberRepository;
            this.personReport = personReport;
        }
        // IPersonRepository IUnitOfWork.PersonRepository { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IPersonRepository PersonRepository { get => personRepository;  }

        public IPhoneNumberRepository PhoneNumberRepository { get => phoneNumberRepository; }
        public IPersonReport PersonReport { get => personReport; }
    }



}
