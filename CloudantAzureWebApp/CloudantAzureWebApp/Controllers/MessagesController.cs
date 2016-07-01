using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CloudantAzureWebApp.Controllers
{
    public class MessagesController : ApiController
    {
        // GET: api/Messages/:text
        public string Get(string id)
        {            
            return Helpers.CloudantCounterRequest.SearchMessage(id);
        }
    }
}
