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
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        HMSContext DB = new HMSContext();



        [Route("ShowUser")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DB.UserLogin.ToList());
        }



        public HttpResponseMessage Get(int id)
        {



            var entity = DB.UserLogin.FirstOrDefault(s => s.UserId == id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"User with Id {id} not found");



            }
        }



        [Route("Login")]
        [HttpPost]

        public IHttpActionResult Post(Login login)
        {
           var log = DB.UserLogin.Where(x => x.Email.Equals(login.Email) && x.Password.Equals(login.Password)).FirstOrDefault();

            if (log == null)
            {
                return Ok(new { status = 401, isSuccess = false, message = "Invalid User", });
            }
            else

                return Ok(new { status = 200, isSuccess = true, message = "User Login successfully", UserDetails = log });
        }





        [Route("InsertUser")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Register Reg)
        {
            // HttpResponseMessage msg=null;
            try
            {
                AppUser UL = new AppUser();
                if (UL.UserId == 0)
                {
                    UL.FirstName = Reg.FirstName;
                    UL.LastName = Reg.LastName;
                    UL.PhoneNumber = Reg.PhoneNumber;
                    UL.Email = Reg.Email;
                    UL.Password = Reg.Password;





                    DB.UserLogin.Add(UL);
                    DB.SaveChanges();
                    // return new Response
                    // { Status = "Success", Message = "Record SuccessFully Saved." };
                    // var msg = Request.CreateResponse(HttpStatusCode.Created, Reg);

                }
                var msg = Request.CreateResponse(HttpStatusCode.Created, Reg);
                return msg;
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

            }
            //return new Response
            //{ Status = "Error", Message = "Invalid Data." };
            //}
        }
        [Route("ForgotPassword")]
        [HttpPut]
        public HttpResponseMessage Put([FromUri] string email, [FromBody] Login login)
        {
            try
            {
                AppUser entity = DB.UserLogin.FirstOrDefault(s => s.Email == email);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with Email " + email.ToString() + "not found to update");
                }
                else
                {
                    string NewPassword = "sp5678";
                    //log.Email = login.Email;
                    entity.Password = NewPassword;

                      DB.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }





        }
    }
}