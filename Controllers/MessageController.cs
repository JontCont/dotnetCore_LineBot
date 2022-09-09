using isRock.LineBot;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dotnetCore_LineBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController
    {
        public string channelToken{get; private set;}
            =@"your channel Token";
        public string adminUserID{get; private set;}
            ="your admin User ID";

        [HttpPost]
        public string Post(){
            Bot bot = InitialBots();
            bot.PushMessage(adminUserID, "Push Message !!");
            return JsonConvert.SerializeObject(new { success = true, message = "" });
        }


        //-------------------------//
        private Bot InitialBots(){
            string channelToken = this.channelToken;
            return new Bot(channelToken);
        }


    }
}