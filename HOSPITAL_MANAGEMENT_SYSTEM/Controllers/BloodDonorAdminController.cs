using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using HOSPITAL_MANAGEMENT_SYSTEM.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/BloodDonorAdmin")]
    public class BloodDonorAdminController : ApiController
    {
        HMSContext DB = new HMSContext();

        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DB.bloodDonor.Count());

        }
    }
}
