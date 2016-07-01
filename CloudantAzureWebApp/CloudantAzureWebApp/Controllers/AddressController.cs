using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CloudantAzureWebApp.Controllers
{
    public class AddressController : ApiController
    {
        // GET: api/Address
        public string Get()
        {
            return Helpers.CloudantCounterRequest.GetGeoPoints("-111", "40");
        }
    }
}
