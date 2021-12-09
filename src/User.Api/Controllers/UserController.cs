﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Api.Models.Request;
using User.Api.Models.Response;
using User.Core.Domain;
using User.Service.Dto;
using User.Service.Services;

namespace User.Api.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, 
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // POST: api/v1/users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] PostUserRequest request)
        {
            var response = new PostUserResponse();

            var dto = _mapper.Map<PostUserRequest, UserDto>(request);

            var result = await _userService.AddUser(dto);

            response = _mapper.Map<UserDomain, PostUserResponse>(result);

            return Created($"{Request.Host.Value}{Request.Path}/{response.UserId}", response);
        }


        // GET: api/v1/users
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request)
        {
            var response = new GetUsersResponse();

            return Ok(response);
        }


        // GET: api/v1/users/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromQuery] int id)
        {
            var response = new GetUserResponse();

            return Ok(response);
        }


        // PUT: api/v1/users/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromQuery]int id,[FromBody] PutUserRequest request)
        {
            var response = new PutUserResponse();

            return Ok(response);
        }


        // DELETE: api/v1/users/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {

            return Ok();
        }


    }
}