using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HOSPITAL_MANAGEMENT_SYSTEM.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Controllers
{
    [RoutePrefix("api/BloodDonor")]
    public class BloodDonorController : ApiController
    {
        HMSContext DB = new HMSContext();

        [Route("BloodDonor")]
        [HttpGet]
        public HttpResponseMessage Get()
        {

            return Request.CreateResponse(HttpStatusCode.OK, DB.bloodDonor.ToList());
        }

        public HttpResponseMessage Get(int id)
        {

            var entity = DB.bloodDonor.FirstOrDefault(s => s.DonorID == id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Blood Donor with DonorId {id} not found");
            }
        }

        [Route("InsertBloodDonor")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] BloodDonor donor)
        {
            //HttpResponseMessage msg = null;

            if (DB.bloodDonor.Any(a => a.DonorPhoneNumber == donor.DonorPhoneNumber))
            {
                return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            }
            try
            {
                BloodDonor UL = new BloodDonor();
                if (UL.DonorID == 0)
                {
                    UL.DonorName = donor.DonorName;
                    UL.DonorAge = donor.DonorAge;
                    UL.DonorGender = donor.DonorGender;
                    UL.DonorAddress = donor.DonorAddress;
                    UL.DonorBloodtype = donor.DonorBloodtype;
                    UL.DonorPhoneNumber = donor.DonorPhoneNumber;
                    UL.Email = donor.Email;
                    UL.DonorWeight = donor.DonorWeight;
                    UL.Ishealthy = donor.Ishealthy;

                    DB.bloodDonor.Add(UL);
                    DB.SaveChanges();
                    //return new Response
                    //{ Status = "Success", Message = "Record SuccessFully Saved." };
                    //var msg = Request.CreateResponse(HttpStatusCode.Created, Reg);

                }
                var msg = Request.CreateResponse(HttpStatusCode.Created, donor);
                return msg;
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put([FromUri] int id, [FromBody] BloodDonor donor)
        {
            try
            {
                BloodDonor UL = DB.bloodDonor.FirstOrDefault(s => s.DonorID == id);
                if (UL == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Blood Donor with Id " + id.ToString() + "not found to update");
                }
                else
                {
                    UL.DonorName = donor.DonorName;
                    UL.DonorAge = donor.DonorAge;
                    UL.DonorGender = donor.DonorGender;
                    UL.DonorAddress = donor.DonorAddress;
                    UL.DonorBloodtype = donor.DonorBloodtype;
                    UL.DonorPhoneNumber = donor.DonorPhoneNumber;
                    UL.Email = donor.Email;
                    UL.DonorWeight = donor.DonorWeight;
                    UL.Ishealthy = donor.Ishealthy;

                    DB.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, UL);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

       // [Route("deleteBloodDonor")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var entity = DB.bloodDonor.FirstOrDefault(s => s.DonorID == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Blood Donor with DonorId = " + id.ToString() + " not found to delete");
                }
                else
                {
                    DB.bloodDonor.Remove(entity);
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
