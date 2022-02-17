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
    [RoutePrefix("api/Feedbacks")]
    public class FeedbacksController : ApiController
    {
        HMSContext DB = new HMSContext();
        [Route("ShowFeedback")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DB.feedback.ToList());
        }
        public HttpResponseMessage Get(string Phnno)
        {
            var entity = DB.feedback.FirstOrDefault(s => s.PhoneNumber == Phnno);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Feedback of Phone number {Phnno} not found");
            }
        }

        [Route("InsertFeedback")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Feedback obj)
        {
            try
            {
                Feedback UL = new Feedback();
                if (UL.FeedbackId == 0)
                {
                    UL.Name = obj.Name;
                    UL.PhoneNumber = obj.PhoneNumber;
                    UL.Rating = obj.Rating;
                    UL.Comment = obj.Comment;
                    DB.feedback.Add(UL);
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
