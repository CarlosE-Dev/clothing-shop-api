using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserCustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserCustomerController(IMapper mapper, IUserService service)
        {
            _mapper = mapper;
            _userService = service;
        }

        [Authorize(Roles = "customer, admin")]
        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<User>> RegisterUser(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userService.Create(user);

            userDto.Password = "";

            return CreatedAtAction("RegisterUser", userDto);
        }

    }
}
