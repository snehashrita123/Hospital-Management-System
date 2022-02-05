using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HOSPITAL_MANAGEMENT_SYSTEM.Models;


namespace HOSPITAL_MANAGEMENT_SYSTEM.Controllers
{

    //[EnableCors("*", "*", "POST")]
    [RoutePrefix("api/Doctors")]

    public class DoctorsController : ApiController
    {
        HMSContext DB = new HMSContext();



        [Route("ShowDoctor")]
        [HttpGet]
        public HttpResponseMessage Get()
        {

            return Request.CreateResponse(HttpStatusCode.OK, DB.doctor.ToList());
        }

        public HttpResponseMessage Get(int id)
        {

            var entity = DB.doctor.FirstOrDefault(s => s.DoctorID == id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Doctor with Id {id} not found");



            }
        }


        [Route("InsertDoctor")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Doctor doc)
        {
            HttpResponseMessage msg = null;
            try
            {
                Doctor UL = new Doctor();
                if (UL.DoctorID == 0)
                {
                    UL.Name = doc.Name;
                    UL.Gender = doc.Gender;
                    UL.PhoneNumber = doc.PhoneNumber;
                    UL.Email = doc.Email;
                    UL.WorkingDays = doc.WorkingDays;
                    UL.Speciality = doc.Speciality;
                    UL.Experience = doc.Experience;


                    DB.doctor.Add(UL);
                    DB.SaveChanges();
                    //return new Response
                    //{ Status = "Success", Message = "Record SuccessFully Saved." };
                    //var msg = Request.CreateResponse(HttpStatusCode.Created, Reg);

                }
                //var msg = Request.CreateResponse(HttpStatusCode.Created, doc);
                return msg;
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put([FromUri] int id, [FromBody] Doctor doc)
         {
            try
            {
                Doctor UL = DB.doctor.FirstOrDefault(s => s.DoctorID == id);
                if (UL == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor with Id " + id.ToString() + "not found to update");
                }
                else
                {

                    UL.Name = doc.Name;
                    UL.Gender = doc.Gender;
                    UL.PhoneNumber = doc.PhoneNumber;
                    UL.Email = doc.Email;
                    UL.WorkingDays = doc.WorkingDays;
                    UL.Speciality = doc.Speciality;
                    UL.Experience = doc.Experience;

                    DB.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, UL);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }


        [Route("deleteDoctor")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {



                var entity = DB.doctor.FirstOrDefault(s => s.DoctorID == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor with Id = " + id.ToString() + " not found to delete");
                }
                else
                {
                    DB.doctor.Remove(entity);
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