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
    [RoutePrefix("api/BloodRequest")]
    public class BloodRequestController : ApiController
    {
        HMSContext DB = new HMSContext();

        //[Route("BloodRequestShow")]
        [HttpGet]
        
        public HttpResponseMessage Get()
        {

            return Request.CreateResponse(HttpStatusCode.OK, DB.bloodRequest.ToList());
        }

        
        public HttpResponseMessage Get(int id)
        {

            var entity = DB.bloodRequest.FirstOrDefault(s => s.RequestID == id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Blood Requester with RequestId {id} not found");
            }
        }
        [Route("searchdata")]
        public IHttpActionResult Get(string search)
        {
            List<BloodRequest> result = DB.bloodRequest.Where(x => x.RequestorPhoneNumber.Equals(search)).ToList();
            if (result.Count == 0)
            {
                return Ok(new { status = 400, isSuccess = false, message = "Phone Number does not exist" });
            }
            else
            {
                return Ok(result);
            }
        }



        //[Route("InsertBloodRequest")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] BloodRequest requestor)
        {
            //HttpResponseMessage msg = null;

            if (DB.bloodRequest.Any(a => a.RequestorPhoneNumber == requestor.RequestorPhoneNumber))
            {
                return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            }
            try
            {
                BloodRequest UL = new BloodRequest();
                if (UL.RequestID== 0)
                {
                    UL.RequestorName = requestor.RequestorName;
                    UL.RequestorAge = requestor.RequestorAge;
                    UL.RequestorGender = requestor.RequestorGender;
                    UL.RequestorPhoneNumber = requestor.RequestorPhoneNumber;
                    UL.Email = requestor.Email;
                    UL.RequestorAddress = requestor.RequestorAddress;
                    UL.RequestedBloodtype = requestor.RequestedBloodtype;
                    UL.IsActive = requestor.IsActive;
                    UL.RequestedOn = requestor.RequestedOn;

                    DB.bloodRequest.Add(UL);
                    DB.SaveChanges();
                    //return new Response
                    //{ Status = "Success", Message = "Record SuccessFully Saved." };
                    //var msg = Request.CreateResponse(HttpStatusCode.Created, Reg);

                }
                var msg = Request.CreateResponse(HttpStatusCode.Created, requestor);
                return msg;
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put([FromUri] int id, [FromBody] BloodRequest requestor)
        {
            try
            {
                BloodRequest UL = DB.bloodRequest.FirstOrDefault(s => s.RequestID == id);
                if (UL == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Blood Requestor with Id " + id.ToString() + "not found to update");
                }
                else
                {
                    UL.RequestorName = requestor.RequestorName;
                    UL.RequestorAge = requestor.RequestorAge;
                    UL.RequestorGender = requestor.RequestorGender;
                    UL.RequestorPhoneNumber = requestor.RequestorPhoneNumber;
                    UL.Email = requestor.Email;
                    UL.RequestorAddress = requestor.RequestorAddress;
                    UL.RequestedBloodtype = requestor.RequestedBloodtype;
                    UL.IsActive = requestor.IsActive;
                    UL.RequestedOn = requestor.RequestedOn;

                    DB.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, UL);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //[Route("deleteBloodRequestor")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var entity = DB.bloodRequest.FirstOrDefault(s => s.RequestID == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Blood Requestor with RequestId = " + id.ToString() + " not found to delete");
                }
                else
                {
                    DB.bloodRequest.Remove(entity);
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
