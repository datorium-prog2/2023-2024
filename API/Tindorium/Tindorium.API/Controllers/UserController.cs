using Microsoft.AspNetCore.Mvc;

namespace Tindorium.API.Controllers
{
    [ApiController]
    [Route("[controller]")]//localhost:7157/User 
    public class UserController : ControllerBase //[controller] == User
    {
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
        [Route("GetUser")]
        public string GetUser(int id)
        {
            return "pārstrādāts " + id;
        }
    }
}
