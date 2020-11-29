using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Users.Data;
using Users.Dtos;
using Users.Models;

namespace Users.Controllers
{
    // api/Users
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            var userItems = _repository.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
        }

        // GET api/users/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<User> GetUserById(int id)
        {
            var userItems = _repository.GetUserById(id);
            if (userItems != null)
            {
                return Ok(_mapper.Map<UserReadDto>(userItems));
            }
            return NotFound();
        }

        // POST api/users
        [HttpPost]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);
            _repository.CreateUser(userModel);
            _repository.SaveChanges();
            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            return CreatedAtRoute(nameof(GetUserById), new { id = userReadDto.id }, userReadDto);
        }

        // PUT api/users/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(userUpdateDto, userModelFromRepo);
            _repository.UpdateUser(userModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        // DELETE api/users/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteUser(userModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}