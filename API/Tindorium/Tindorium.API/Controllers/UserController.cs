using Microsoft.AspNetCore.Mvc;
using Tindorium.Data;

namespace Tindorium.API.Controllers
{
    [ApiController]
    [Route("[controller]")]//localhost:7157/User 
    public class UserController : ControllerBase //[controller] == User
    {
        private UserRepository _userRepository;
        public UserController(UserRepository userRepository) //Scoped -> 
        {
            _userRepository = userRepository;
        }
        //Get, POST, 
        [HttpGet]
        [Route("Ping")]
        public string Ping() //localhost:7157/User/Ping
        {
            return "PONG";
        }

        [HttpGet]
        [Route("Pong")]//localhost:7157/User/Pong/123/asd
        public string Pong()
        {
            return "PING";
        }

        [HttpGet]
        [Route("GetUser")]//localhost:7157/User/GetUser?id=12
        public string GetUser(int id)
        {
            return "pārstrādāts " + id;
        }

        [HttpPost]
        [Route("AddUser")]
        public User AddUser([FromBody] UserDTO user)//localhost:7157/User/AddUser    body-> {"name": "vārds"}
        {
            var userEntity = new User()
            {
                Name = user.Name,
                Surname = user.Surname,
                Age = user.Age

            };
            _userRepository.Add(userEntity);
            return userEntity;
        }

        [HttpPost]
        [Route("Test")]
        public string Test()//https://localhost:7157/User/Test
        {
            return "test data";
        }
    }
}

public class UserDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
}