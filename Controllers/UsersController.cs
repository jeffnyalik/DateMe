using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatingAPI.Data.DataContext;
using DatingAPI.Dtos;
using DatingAPI.Interface;
using DatingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingAPI.Controllers
{   
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {   
        private readonly IUserRepository repository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository repository, IMapper mapper)  
        {
            this.repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult>GetUsers()
        {
            var users = await repository.GetUsers();
            var res = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetUser(int id)
        {
            var user = await repository.GetUser(id);
            var userToreturn = _mapper.Map<UserForDetailsDto>(user);
            if(user == null)
            {
                return BadRequest("User not found");
            }
            return Ok(userToreturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateUser(int id, UserForUpdateDto userForUpdateDto)
        {
            var userFromRepo = await repository.GetUser(id);
            if(userFromRepo == null)
            {
                return Unauthorized();
            }
            _mapper.Map(userForUpdateDto, userFromRepo);
            await repository.SaveAll();
            return Ok(new {
                message = StatusCode(201)
            });
        }
    }
}