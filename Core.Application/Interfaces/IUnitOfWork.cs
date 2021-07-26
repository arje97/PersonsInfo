using Core.Application.Interfaces.Repositories;

namespace Core.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IPersonRepository PersonRepository { get; }
        public IPhoneNumberRepository PhoneNumberRepository { get; }
        public IPersonReport PersonReport { get; }
    }
}