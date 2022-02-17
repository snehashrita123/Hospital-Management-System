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

    [RoutePrefix("api/Bills")]

    public class BillsController : ApiController
    {
        HMSContext DB = new HMSContext();

        [Route("ShowBill")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DB.bill1.ToList());
        }
        public HttpResponseMessage Get(int id)
        {
            var entity = DB.bill1.FirstOrDefault(s => s.PaymentID == id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Payment with Id {id} not found");

            }
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Bill b)
        {
            //HttpResponseMessage msg = null;
            try
            {
                Bill UL = new Bill();
                // if (UL.PaymentID == 0)
                // {

                UL.Name = b.Name;
                UL.PhoneNumber = b.PhoneNumber;
                UL.Email = b.Email;
                UL.WardCharge = b.WardCharge;
                UL.DocCharge = b.DocCharge;
                UL.Days = b.Days;
                UL.BillAmount = b.BillAmount;

                DB.bill1.Add(UL);
                DB.SaveChanges();
                var msg = Request.CreateResponse(HttpStatusCode.Created, b);
                return msg;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
