using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MeetingManagerAPI.Providers;

namespace MeetingManagerAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/MeetingManager")]
    public class MeetingManagerController : Controller
    {        
        [HttpGet]
        public string ProcessChat(string question)
        {
            var temphearder = this.Request.Headers.Keys;
            string sKeyValue = string.Empty;
            if (temphearder.Contains("MMMessageId"))
                sKeyValue = this.Request.Headers["MMMessageId"];
            else
                sKeyValue = Guid.NewGuid().ToString();
            return new ScheduleMeetingProvider().GetChatResponse(question, sKeyValue);
        }
    }
}