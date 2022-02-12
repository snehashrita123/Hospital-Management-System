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
    [RoutePrefix("api/Ambulance")]
    public class VaccinationController : ApiController
    {
        HMSContext DB = new HMSContext();
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DB.vacc_registration.ToList());
        }
        public HttpResponseMessage Get(string no)
        {
            var entity = DB.vacc_registration.FirstOrDefault(s => s.AadharCard_Number == no);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Registration with AadharCard {no} not found");
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Vacc_reg obj)
        {
            try
            {
                Vacc_reg UL = new Vacc_reg();
                if (UL.vacc_id == 0)
                {
                    UL.AadharCard_Number = obj.AadharCard_Number;
                    UL.Name = obj.Name;
                    UL.Gender = obj.Gender;
                    UL.YOB = obj.YOB;

                    DB.vacc_registration.Add(UL);
                    DB.SaveChanges();
                }
                var msg = Request.CreateResponse(HttpStatusCode.Created, obj);
                return msg;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
