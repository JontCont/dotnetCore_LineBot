using System.Text;
using isRock.LineBot;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dotnetCore_LineBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController: ControllerBase
    {
        public string channelToken{get; private set;}
            =@"/MuwA0g7s5mT9vBzzihsVH0JigeA2dQSO1ETashy34az/yc8j1BGS5/CSzPQionIXwfliqhEVcFCctom2S50La+uPAvK85miNgx8ZaYJdmhkeFDfSvlQ0+A9r9gp3fnAXAbYWKTgxuWMqFpXevvFmQdB04t89/1O/w1cDnyilFU=";
        public string adminUserID{get; private set;}
            ="Uf4a2b3a58cb64f1c8987aff14e0e54c4";

        [HttpPost]
        public string Post(){
            Bot bot = InitialBots();
            List<MessageBase> repMessage = new List<MessageBase>();
            StringBuilder strBuilder = new StringBuilder();
            string strBody = "";
            
            try{
                //取得 http Post 
                using (StreamReader reader = new(Request.Body, System.Text.Encoding.UTF8))
                {
                    strBody = reader.ReadToEndAsync().Result;
                    if (reader == null || string.IsNullOrEmpty(strBody))
                        return JsonConvert.SerializeObject(new { success = false, message = "error : message empty " });
                }
            }catch(Exception ex){
                bot.PushMessage(adminUserID, ex.Message);
                return JsonConvert.SerializeObject(new { success = false, message = ex.Message });
            }

            //RawData(should be JSON)
            var ReceivedMessage = Utility.Parsing(strBody);
            if (ReceivedMessage == null) return JsonConvert.SerializeObject(new { success = false, message = "error : message empty " });

            var LineEvent = ReceivedMessage.events.FirstOrDefault();
            if (LineEvent == null)
            {
                return JsonConvert.SerializeObject(new { success = false, message = "error : not found event ! " });
            }
            ReplyBotsMessage(bot,LineEvent);

            return JsonConvert.SerializeObject(new { success = true, message = "" });
        }


        //-------------------------//
        private Bot InitialBots(){
            string channelToken = this.channelToken;
            return new Bot(channelToken);
        }

        private void ReplyBotsMessage(Bot bot,Event lineEvent)
        {
            TextMessage textMessage = new ("");

            switch (lineEvent.type)
            {
                case "join":
                    textMessage = new TextMessage($"大家好啊~");
                    break;
                case "message":
                    string text = lineEvent.message.text;
                    if (text == null) break;
                    textMessage =  new TextMessage($"您回應是 : {text}");
                    break;
            }
            if(string.IsNullOrEmpty(textMessage.text)){
                textMessage = new ($"你回覆的訊息無法判讀，請重新輸入!!");
            }
            bot.ReplyMessage(lineEvent.replyToken, textMessage);
        }

    }
}