using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML.Messaging;

namespace ChatBotWhatsApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChatBotController : ControllerBase

    {
        //Recibe los datos de validación 
        [HttpGet]
        [Route("enviaMensaje")]
        //Recibimos los parametros que envia WhatsApp
        //public async Task enviaMensaje()
        //{
        //    var phoneNumberTo = new PhoneNumber("whatsapp:+5217774394440");
        //    var phoneNumberFrom = new PhoneNumber("whatsapp:+14155238886");
        //    const string AccountSid = "ACb69bc36957290e6082dda7e3d6a855c6";
        //    const string AuthToken = "[AuthToken]";

        //    TwilioClient.Init(AccountSid, AuthToken);

        //    var text = "Hola Latino.NET";
        //    var whatsAppTextMessage = await MessageResource.CreateAsync(
        //        from: phoneNumberFrom,
        //        to: phoneNumberTo,
        //        body: text);

        //    // string jsonPayload = JsonConvert.SerializeObject(whatsAppTextMessage);
        //   // string jsonPayload = JsonSerializer.Serialize(whatsAppTextMessage)
            
        //    var logSer = System.Text.Json.JsonSerializer.Serialize(whatsAppTextMessage);

            // A WhatsApp media message can only contain one media attachment.
            // Any additional attachments will be ignored.
            /*    var media = new string[]
                {
                    "https://picsum.photos/400",
                    "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerBlazes.mp4",
                    "https://download.samplelib.com/mp3/sample-12s.mp3",
                    "http://www.africau.edu/images/default/sample.pdf",
                    "http://www.w3.org/2002/12/cal/vcard-examples/john-doe.vcf"
                };

                foreach (var item in media)
                {
                    var url = new List<Uri>() { new Uri(item) };
                    var whatsAppMediaMessage = await MessageResource.CreateAsync(
                        from: phoneNumberFrom,
                        to: phoneNumberTo,
                        mediaUrl: url);
                    Console.WriteLine(JsonSerializer.Serialize(whatsAppMediaMessage));
                }*/
      //  }
        //// static void Main(string[] args)
        public async Task enviaMensaje()
        {
            var accountSid = "ACb69bc36957290e6082dda7e3d6a855c6";
            var authToken = "1d88803f2056bb628ef94fb2b32fde92";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
              new PhoneNumber("whatsapp:+5217774394440"));
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
            messageOptions.Body = "Ya vamos a dormirrr";


            var message = await MessageResource.CreateAsync(messageOptions);
            // Console.WriteLine(message.Body);
        }


        [HttpPost]
        [Route("recibirMensaje")]
        public async Task recibirMensaje()
        {
            //var twiml = TwilioService.GetTwilioMessage(message);
             await enviaMensaje();
        }

    }
}

