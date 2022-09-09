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
            =@"/MuwA0g7s5mT9vBzzihsVH0JigeA2dQSO1ETashy34az/yc8j1BGS5/CSzPQionIXwfliqhEVcFCctom2S50La+uPAvK85miNgx8ZaYJdmhkeFDfSvlQ0+A9r9gp3fnAXAbYWKTgxuWMqFpXevvFmQdB04t89/1O/w1cDnyilFU=";
        public string adminUserID{get; private set;}
            ="Uf4a2b3a58cb64f1c8987aff14e0e54c4";

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