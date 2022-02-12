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
    [RoutePrefix("api/Ambulance")]
    public class AmbulanceController : ApiController
    {
        HMSContext DB = new HMSContext();
        [Route("ShowAmbulance")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DB.ambulance.ToList());
        }
        public HttpResponseMessage Get(int no)
        {
            var entity = DB.ambulance.FirstOrDefault(s => s.AmbulanceNo == no);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Ambulance with AmbulanceNo {no} not found");
            }
        }



        [Route("InsertAmbulance")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Ambulance obj)
        {
            //if (DB.ambulance.Any(a => a.CallForDetails == obj.CallForDetails))
            //{
            // return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            //}
            try
            {
                Ambulance UL = new Ambulance();
                if (UL.AmbulanceNo == 0)
                {
                    UL.OwnerName = obj.OwnerName;
                    UL.CallForDetails = obj.CallForDetails;
                    DB.ambulance.Add(UL);
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
        public HttpResponseMessage Put([FromUri] int no, [FromBody] Ambulance obj)
        {
            try
            {
                Ambulance UL = DB.ambulance.FirstOrDefault(s => s.AmbulanceNo == no);
                if (UL == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Ambulance with ambulance no " + no.ToString() + "not found to update");
                }
                else
                {
                    UL.OwnerName = obj.OwnerName;
                    UL.CallForDetails = obj.CallForDetails;
                    DB.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, UL);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }



        }



        //[HttpDelete]
        //public HttpResponseMessage Delete(int no)
        //{
        //    try
        //    {
        //        var entity = DB.ambulance.FirstOrDefault(s => s.AmbulanceNo == no);
        //        if (entity == null)
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Ambulance with ambulance no = " + no.ToString() + " not found to delete");
        //        }
        //        else
        //        {
        //            DB.ambulance.Remove(entity);
        //            DB.SaveChanges();
        //            return Request.CreateResponse(HttpStatusCode.OK);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }



        //}
    }
}
