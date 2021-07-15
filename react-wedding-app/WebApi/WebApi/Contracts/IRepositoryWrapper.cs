using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Contracts
{
    public interface IRepositoryWrapper 
    { 
        IImageRepository Image { get; } 
        IUserRepository User { get; }
        IParticipantRepository Participant { get; }
        void Save();
        Task SaveAsync();
    }
}
