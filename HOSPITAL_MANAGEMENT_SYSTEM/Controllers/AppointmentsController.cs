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
    [RoutePrefix("api/appointments")]
    public class AppointmentsController : ApiController
    {
        HMSContext DB = new HMSContext();
        [HttpGet]
        [Route("getdoctors")]
        public IHttpActionResult getDoctorBySpeciality(string search)
        {
            //List<DoctorDetails> result = DB.DoctorInfo.Where(x => x.Speciality.Equals(search)).ToList();
            IQueryable<string> result = from item in DB.DoctorInfo
                                        where item.Speciality.Equals(search)
                                        select item.Name;
            if (!result.Any())
            {
                return Ok(new { status = 400, isSuccess = false, message = "Doctor does not exist" });
            }
            else
            {


                return Ok(result);
            }
        }


        [HttpGet]
        [Route("getdays")]
        public IHttpActionResult getDaysByDoctorName(string search2)
        {
            //List<DoctorDetails> result = DB.DoctorInfo.Where(x => x.Speciality.Equals(search)).ToList();
            IQueryable<string> result = from item in DB.DoctorInfo
                                        where item.Name.Equals(search2)
                                        select item.WorkingDays;
            if (!result.Any())
            {
                return Ok(new { status = 400, isSuccess = false, message = "Doctor does not exist" });
            }
            else
            {


                return Ok(result);
            }
        }

        [HttpGet]
        [Route("getdata")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DB.AppointmentInfo.ToList());
        }


        [HttpGet]
        [Route("searchappointmentdetails")]
        public IHttpActionResult Get(string search)
        {
            List<AppointmentDetails> result = DB.AppointmentInfo.Where(x => x.email.Equals(search)).ToList();
            if (result.Count == 0)
            {
                return Ok(new { status = 400, isSuccess = false, message = "Email does not exist" });
            }
            else
            {


                return Ok(result);
            }
        }


        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Put([FromUri] int id, [FromBody] AppointmentDetails appointmentDetails)
        {
            try
            {
                AppointmentDetails entity = DB.AppointmentInfo.FirstOrDefault(s => s.appointment_ID == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Appointment with Id " + id.ToString() + "not found to update");
                }
                else
                {
                    entity.patientName = appointmentDetails.patientName;
                    entity.email = appointmentDetails.email;
                    entity.Speciality = appointmentDetails.Speciality;
                    entity.doctorName = appointmentDetails.doctorName;
                    entity.day = appointmentDetails.day;
                    entity.date = appointmentDetails.date;
                    entity.time = appointmentDetails.time;
                    DB.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("bookappointment")]
        public HttpResponseMessage Post([FromBody] AppointmentDetails appointmentDetails)
        {
            AppointmentDetails AD = new AppointmentDetails();


            AD.patientName = appointmentDetails.patientName;
            AD.email = appointmentDetails.email;
            AD.Speciality = appointmentDetails.Speciality;
            AD.doctorName = appointmentDetails.doctorName;
            AD.day = appointmentDetails.day;
            AD.date = appointmentDetails.date;
            AD.time = appointmentDetails.time;


            DB.AppointmentInfo.Add(AD);
            DB.SaveChanges();
            var msg = Request.CreateResponse(HttpStatusCode.Created, appointmentDetails);
            return msg;





        }


        [HttpDelete]
        [Route("remove")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {


                var entity = DB.AppointmentInfo.FirstOrDefault(s => s.appointment_ID == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Appointment with Id = " + id.ToString() + " not found to delete");
                }
                else
                {
                    DB.AppointmentInfo.Remove(entity);
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
