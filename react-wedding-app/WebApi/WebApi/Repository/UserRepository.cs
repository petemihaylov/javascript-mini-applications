using WebApi.Contracts;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
         public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext){}
    }
}