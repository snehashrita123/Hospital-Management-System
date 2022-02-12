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
    [RoutePrefix("api/doctors")]
    public class DoctorsController : ApiController
    {
        HMSContext DB = new HMSContext();




        [Route("ShowDoctor")]
        [HttpGet]
        public HttpResponseMessage Get()
        {



            return Request.CreateResponse(HttpStatusCode.OK, DB.DoctorInfo.ToList());
        }



        public HttpResponseMessage Get(int id)
        {



            var entity = DB.DoctorInfo.FirstOrDefault(s => s.DoctorID == id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Doctor with Id {id} not found");




            }
        }





        [HttpPost]
        public HttpResponseMessage Post([FromBody] DoctorDetails doc)
        {
            //HttpResponseMessage msg = null;
            try
            {
                DoctorDetails UL = new DoctorDetails();
                if (UL.DoctorID == 0)
                {
                    UL.Name = doc.Name;
                UL.PhoneNumber = doc.PhoneNumber;
                UL.Email = doc.Email;
                UL.WorkingDays = doc.WorkingDays;
                UL.Speciality = doc.Speciality;
                UL.Experience = doc.Experience;




                DB.DoctorInfo.Add(UL);
                DB.SaveChanges();
                    //return new Response
                    //{ Status = "Success", Message = "Record SuccessFully Saved." };
                    //var msg = Request.CreateResponse(HttpStatusCode.Created, Reg);



                }
                var msg = Request.CreateResponse(HttpStatusCode.Created, doc);
                return msg;
            }
            catch (Exception ex)
            {



                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }



        [HttpPut]
        public HttpResponseMessage Put([FromUri] int id, [FromBody] DoctorDetails doc)
        {
            try
            {
                DoctorDetails UL = DB.DoctorInfo.FirstOrDefault(s => s.DoctorID == id);
                if (UL == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor with Id " + id.ToString() + "not found to update");
                }
                else
                {



                    UL.Name = doc.Name;
                    //UL.Gender = doc.Gender;
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





        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {




                var entity = DB.DoctorInfo.FirstOrDefault(s => s.DoctorID == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor with Id = " + id.ToString() + " not found to delete");
                }
                else
                {
                    DB.DoctorInfo.Remove(entity);
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
