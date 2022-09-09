using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dotnetCore_LineBot.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MessageController
    {
        [HttpGet]
        public string Get(){
            return JsonConvert.SerializeObject(new{});
        }

    }
}