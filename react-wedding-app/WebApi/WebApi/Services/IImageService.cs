using System;
using System.Linq;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IImageService
    {
        public Image AddImage(Image image);

        public Image DeleteImage(Guid id);
        
        public Image GetImageById(Guid id);

        public IQueryable<Image> GetImages();
    }
}