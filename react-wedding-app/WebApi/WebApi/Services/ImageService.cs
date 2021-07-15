using System;
using System.Linq;
using AutoMapper;
using WebApi.Contracts;
using WebApi.Models;

namespace WebApi.Services
{
    public class ImageService : IImageService
    {
        
        private readonly IRepositoryWrapper _repository;

        public ImageService( IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public Image AddImage(Image image)
        {
            image.Id = Guid.NewGuid();
            _repository.Image.Create(image);
            _repository.Save();
            return image;
        }

        public Image DeleteImage(Guid id)
        {
            var image = GetImageById(id);
            _repository.Image.Delete(image);
            _repository.Save();
            return image;
        }

        public Image GetImageById(Guid id)
        {
            try
            {

                return _repository.Image.FindByCondition(i => i.Id.Equals(id)).First();
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IQueryable<Image> GetImages()
        {
            return _repository.Image.FindAll();
        }
    }
}