using WebApi.Contracts;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repository
{
    public class ParticipantRepository : RepositoryBase<Participant>, IParticipantRepository
    {
         public ParticipantRepository(RepositoryContext repositoryContext) : base(repositoryContext){}
    }
}