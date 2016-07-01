using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CloudantAzureWebApp.Controllers
{
    public class CityController : ApiController
    {
        // GET: api/City
        public string Get()
        {
            return Helpers.CloudantCounterRequest.GetCount("facetCity", "city");
        }
    }
}
