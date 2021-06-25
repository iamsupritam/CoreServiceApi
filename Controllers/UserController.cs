using System.Collections.Generic;
using AutoMapper;
using CoreServiceApi.Data;
using CoreServiceApi.DataTransferModels;
using CoreServiceApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CoreServiceApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private IMapper _mapper;

        public UserController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;    
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<UserReadDto>> GetAllUsers()
        {
            var userItems = _repository.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
        }

        [HttpGet("{id}", Name ="GetUserById")]
        public ActionResult <UserReadDto> GetUserById(int id)
        {
            var userItem = _repository.GetUserById(id);
            if(userItem != null)
            {
                return Ok(_mapper.Map<UserReadDto>(userItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("login")]
        public ActionResult <UserReadDto> GetLoginUser(string username, string password)
        {
            var userDetails = _repository.GetLoginUser(username, password);
            if(userDetails == null)
            {
                return NotFound();
            }

            UserReadDto userResponseModel = _mapper.Map<UserReadDto>(userDetails);
            return Ok(userResponseModel);
        }

        [HttpPost]
        public ActionResult <UserReadDto> CreateUser (UserCreateDto user)
        {
            var userModel = _mapper.Map<User>(user);
            _repository.CreateUser(userModel);
            _repository.SaveChanges();
            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            return CreatedAtRoute(nameof(GetUserById), new {id = userReadDto.Id}, userReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult <UserReadDto> UpdateUser (int id, UserUpdateDto user)
        {
            var userToUpdate = _repository.GetUserById(id);
            if(userToUpdate == null)
            {
                return NotFound();
            }

            _mapper.Map(user, userToUpdate);

            _repository.UpdateUser(userToUpdate);
            _repository.SaveChanges();
            
            var userReadDto = _mapper.Map<UserReadDto>(userToUpdate);
            //return NoContent();
            //return Ok(userReadDto);
            return CreatedAtRoute(nameof(GetUserById), new {id = id}, userReadDto);
        }
    }
}