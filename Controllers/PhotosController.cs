using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DatingAPI.Dtos;
using DatingAPI.Helpers;
using DatingAPI.Interface;
using DatingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DatingAPI.Controllers
{   
    [Authorize]
    [ApiController]
    [Route("api/users/{userId}/[controller]")]
    public class PhotosController : ControllerBase
    {   
        private readonly IUserRepository repo;
        private readonly IMapper mapper;
        private readonly IOptions<CloudinarySettings> cloudinaryConfig;
        private readonly Cloudinary cloudinary;

        public PhotosController(
            IUserRepository repo,
            IMapper mapper,
            IOptions<CloudinarySettings> cloudinaryConfig
            )
        {
            this.repo = repo;
            this.mapper = mapper;
            this.cloudinaryConfig = cloudinaryConfig;

            Account acc = new Account(
                cloudinaryConfig.Value.CloudName,
                cloudinaryConfig.Value.ApiKey,
                cloudinaryConfig.Value.ApiSecret
            );

            cloudinary = new Cloudinary(acc);
        }

        [HttpGet("{id}", Name = "GetPhoto")]
        public async Task<IActionResult>GetPhoto(int id)
        {
            var fromRepo = await repo.GetPhoto(id);
            if(fromRepo == null)
            {
                return NotFound();
            }
            var photo = mapper.Map<PhotoForReturnDto>(fromRepo);
            return Ok(photo);
        }

        [HttpPost]
        public async Task<IActionResult>AddPhotoForUser(int userId, [FromForm] PhotoCreatingDto photoCreatingDto)
        {
            var userRepo = await repo.GetUser(userId);
            if(userRepo == null){
                return Unauthorized();
            }
            var file = photoCreatingDto.File;
            var uploadResult = new ImageUploadResult();
            if(file.Length > 0){
                using(var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                    };
                    uploadResult = cloudinary.Upload(uploadParams);
                }
            }
            photoCreatingDto.Url = uploadResult.Url.ToString();
            photoCreatingDto.PublicId = uploadResult.PublicId;
            var photo = mapper.Map<Photo>(photoCreatingDto);
            if(!userRepo.Photos.Any(u => u.IsMain)){photo.IsMain = true;}
            userRepo.Photos.Add(photo);
            if(await repo.SaveAll())
            {   
                var photoToReturn = mapper.Map<PhotoForReturnDto>(photo);
                return CreatedAtAction("GetPhoto", new {id = photo.Id}, photoToReturn);
            }
            return BadRequest("Could not add the photo");
        }

        [HttpPost("{id}/setMain")]
        public async Task<IActionResult>SetMainPhoto(int UserId, int id)
        {
            var userFromRepo = await repo.GetUser(UserId);
            if(userFromRepo == null)
            {
                return Unauthorized();
            }

            if(!userFromRepo.Photos.Any(p => p.Id == id))
            {
                return Unauthorized();
            }
            var photoFromRepo = await repo.GetPhoto(id);
            if(photoFromRepo.IsMain)
            {
                return BadRequest("This is already the main Photo");
            }

            var CurrentMainPhoto = await repo.GetMainPhotoForUser(UserId);
            CurrentMainPhoto.IsMain = false;
            photoFromRepo.IsMain = true;
            if(await repo.SaveAll())
            {
                return NoContent();
            }

            return BadRequest("Could not set photo to main");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeletePhoto(int UserId, int id)
        {
            var user = await repo.GetUser(UserId);
            if(user == null)
            {
                return Unauthorized();
            }
            if(!user.Photos.Any(p => p.Id == id))
            {
                return Unauthorized();
            }
            
            var photoRepo = await repo.GetPhoto(id);
            if(photoRepo.IsMain)
            {
                return BadRequest("Main photo cannot be deleted");
            }

            if(photoRepo.PublicId != null)
            {
                var deleteParams = new DeletionParams(photoRepo.PublicId);
                var res = cloudinary.Destroy(deleteParams);
                if(res.Result == "ok")
                {
                    repo.Delete(photoRepo);
                }
            }

            if(photoRepo.PublicId == null)
            {
                repo.Delete(photoRepo);
            }

            
            if(await repo.SaveAll())
            {
                return Ok();
            }
            return BadRequest("Failed to delete photo");
        }
    }
}