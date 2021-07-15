using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
        {
            private readonly IImageService _imageService;

            public ImageController(IImageService imageService)
            {
                _imageService = imageService;
            }


            // GET api/image
            [HttpGet]
            public ActionResult<IEnumerable<Image>> GetAllImages()
            {
                var images = _imageService.GetImages();
                if (images != null) return Ok(images);
                return NotFound();
            }
            
            // POST api/image
            [Authorize]
            [HttpPost]
            public ActionResult<Image> CreateImage(Image image)
            {
                var images = _imageService.AddImage(image);
                
                if (images != null) return Ok(images);
                return NotFound();
            }

            // GET api/image/{id}
            [HttpGet("{id}", Name = "GetImageById")]
            public ActionResult<Image> GetImageById(Guid id)
            {
                return Ok(_imageService.GetImageById(id));
            }


            // DELETE api/image/{id}
            [Authorize]
            [HttpDelete("{id}")]
            public ActionResult<Image> DeleteImage(Guid id)
            {
                var image = _imageService.DeleteImage(id);
                return image != null ? Ok(image) : BadRequest();
            }
        }
    
}