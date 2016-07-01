using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CloudantAzureWebApp.Controllers
{
    public class ErrorsController : ApiController
    {
        // GET: api/Errors
        public string Get()
        {
            return Helpers.CloudantCounterRequest.GetCount("facetErrors", "errors");
        }
    }
}
