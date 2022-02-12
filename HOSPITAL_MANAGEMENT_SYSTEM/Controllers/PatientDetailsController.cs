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
    [RoutePrefix("api/PatientDetails")]
    public class PatientDetailsController : ApiController
    {
        HMSContext DB = new HMSContext();

        [HttpGet]
        public IHttpActionResult Get(string search)
        {
            List<Patient_Details> result = DB.patientrecord.Where(x => x.Email.Equals(search)).ToList();
            if (result.Count == 0)
            {
                return Ok(new { status = 400, isSuccess = false, message = "Email does not exist" });
            }
            else
            {

                return Ok(result);
            }
        }



        [HttpPost]
        public HttpResponseMessage Post([FromBody] Patient_Details patient)
        {
            try
            {
                Patient_Details PD = new Patient_Details();
                PD.FirstName = patient.FirstName;
                PD.LastName = patient.LastName;
                PD.Age = patient.Age;
                PD.gender = patient.gender;
                PD.ContactNumber = patient.ContactNumber;
                PD.Address = patient.Address;
                PD.Email = patient.Email;
                PD.Symptoms = patient.Symptoms;
                PD.Ward = patient.Ward;
                DB.patientrecord.Add(PD);

                DB.SaveChanges();
                var msg = Request.CreateResponse(HttpStatusCode.Created, patient);
                return msg;


            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

       

        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            try
            {

                using (HMSContext dbContext = new HMSContext())
                {
                    var entity = DB.patientrecord.FirstOrDefault(s => s.PateintID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        DB.patientrecord.Remove(entity);
                        DB.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);

                    }
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}