using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("admin")]
    [ApiController]
    public class UserAdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserAdminController(IMapper mapper, IUserService service)
        {
            _mapper = mapper;
            _userService = service;
        }


        [Authorize(Roles = "admin")]
        [Route("userlist")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = _mapper.Map<IEnumerable<AdminUserDTO>>(await _userService.GetAllAsync());

            foreach(var user in users)
            {
                user.Password = "";
            }

            return Ok(users);
        }

        [Authorize(Roles = "admin")]
        [Route("userlist/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(long id)
        {
            var user = _mapper.Map<AdminUserDTO>(await _userService.GetById(id));

            if (user == null)
            {
                return NotFound();
            }

            user.Password = "";

            return Ok(user);
        }

        [Authorize(Roles = "admin")]
        [Route("userlist/delete/{id}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegisteredUser(long id)
        {
            try
            {
                await _userService.Delete(id);
            }
            catch
            {
                return NotFound("User not found!");
            }

            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<User>> PostProduct(AdminUserDTO adminDto)
        {
            var admin = _mapper.Map<User>(adminDto);
            await _userService.Create(admin);

            admin.Password = "";

            return CreatedAtAction("GetUsers", new { id = admin.Id }, admin);
        }
    }
}
