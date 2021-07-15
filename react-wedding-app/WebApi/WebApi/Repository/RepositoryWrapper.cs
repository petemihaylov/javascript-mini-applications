using System.Threading.Tasks;
using WebApi.Contracts;
using WebApi.Data;

namespace WebApi.Repository
{
    
    public class RepositoryWrapper : IRepositoryWrapper 
    { 
        private RepositoryContext _repoContext; 
        private IImageRepository _image;
        private IUserRepository _user;
        private IParticipantRepository _participant;
        
        
        public IImageRepository Image 
        { 
            get 
            { 
                if (_image == null) 
                { 
                    _image = new ImageRepository(_repoContext); 
                } 
                return _image; 
            } 
        } 
        public IUserRepository User 
        { 
            get 
            { 
                if (_user == null) 
                { 
                    _user = new UserRepository(_repoContext); 
                } 
                return _user; 
            } 
        } 

        public IParticipantRepository Participant 
        { 
            get 
            { 
                if (_participant == null) 
                { 
                    _participant = new ParticipantRepository(_repoContext); 
                } 
                return _participant; 
            } 
        } 

        
        public RepositoryWrapper(RepositoryContext repositoryContext) 
        { 
            _repoContext = repositoryContext; 
        } 
        
        public void Save() 
        {
            _repoContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
        
        
    }
}
