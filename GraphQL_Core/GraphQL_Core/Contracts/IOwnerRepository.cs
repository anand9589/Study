using GraphQL_Core.Entities;

namespace GraphQL_Core.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
    }
}
