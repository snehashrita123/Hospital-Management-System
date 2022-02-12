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
    [RoutePrefix("api/BloodTypeUnit")]
    public class BloodTypeUnitController : ApiController
    {
        HMSContext DB = new HMSContext();



        // [Route("ShowBlood")]



        [HttpGet]



        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DB.bloodType.ToList());
        }



        [HttpGet]



        public HttpResponseMessage Get(int id)
        {



            var entity = DB.bloodType.FirstOrDefault(s => s.BloodId == id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Blood with Id {id} not found");
            }
        }


        [Route("ShowBloodUnit")]
        [HttpGet]
        public HttpResponseMessage GetBloodUnit()
        {
            var sum = DB.bloodType.Sum(r => r.BloodUnit);
            return Request.CreateResponse(HttpStatusCode.OK, sum);
        }



        [HttpPost]
        public HttpResponseMessage Post([FromBody] BloodType obj)
        {
            try
            {
                BloodType UL = new BloodType();
                if (UL.BloodId == 0)
                {
                    UL.BloodTypes = obj.BloodTypes;
                    UL.BloodUnit = obj.BloodUnit;



                    DB.bloodType.Add(UL);
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



        [HttpPut]
        public HttpResponseMessage Put([FromUri] int id, [FromBody] BloodType obj)
        {
            try
            {
                BloodType UL = DB.bloodType.FirstOrDefault(s => s.BloodId == id);
                if (UL == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Blood with blood id " + id.ToString() + "not found to update");
                }
                else
                {
                    UL.BloodTypes = obj.BloodTypes;
                    UL.BloodUnit = obj.BloodUnit;
                    DB.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, UL);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }



        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var entity = DB.bloodType.FirstOrDefault(s => s.BloodId == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "blood with Id = " + id.ToString() + " not found to delete");
                }
                else
                {
                    DB.bloodType.Remove(entity);
                    DB.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
