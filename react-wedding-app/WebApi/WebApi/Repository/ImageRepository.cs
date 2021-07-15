using WebApi.Contracts;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repository
{
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
         public ImageRepository(RepositoryContext repositoryContext) : base(repositoryContext){}
    }
}