using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HOSPITAL_MANAGEMENT_SYSTEM.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Controllers
{
    [RoutePrefix("api/PatientsInsert")]
    public class PatientsController : ApiController
    {
        HMSContext DB = new HMSContext();

        [HttpGet]

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DB.patientrecord.ToList());
        }

        [HttpGet]

        public HttpResponseMessage Get(int id)
        {

            var entity = DB.patientrecord.FirstOrDefault(s => s.PateintID == id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Patient with Id {id} not found");


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

        [HttpPut]

        public HttpResponseMessage Put([FromUri] int id, [FromBody] Patient_Details patient)
        {

            try
            {
                Patient_Details entity = DB.patientrecord.FirstOrDefault(s => s.PateintID == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient with Id " + id.ToString() + "not found to update");
                }
                else
                {
                    entity.FirstName = patient.FirstName;
                    entity.LastName = patient.LastName;
                    entity.Age = patient.Age;
                    entity.gender = patient.gender;
                    entity.ContactNumber = patient.ContactNumber;
                    entity.Address = patient.Address;
                    entity.Email = patient.Email;
                    entity.Symptoms = patient.Symptoms;
                    entity.Ward = patient.Ward;


                    DB.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
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