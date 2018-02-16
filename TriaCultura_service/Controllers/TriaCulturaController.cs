using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TriaCultura_service.Models;

namespace TriaCultura_service.Controllers
{
    public class TriaCulturaController : ApiController
    {
        // GET api/factures/{id}/{id2}
        [Route("api/factures/{start_id?}/{end_id?}")]
        public HttpResponseMessage Get(int start_id, int end_id)
        {
            var invoices = Repository.GetInvoices(start_id, end_id, true);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, invoices);
            return response;
        }

        [Route("api/facturesTra/{track_id?}")]
        public HttpResponseMessage Get_by_Track(int track_id)
        {
            var invoices = Repository.GetInvoicesTrack(track_id, true);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, invoices);
            return response;
        }

        [Route("api/facturesCli/{customer_id?}")]
        public HttpResponseMessage Get_by_Customer(int customer_id)
        {
            var invoices = Repository.GetInvoicesClient(customer_id, true);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, invoices);
            return response;

        }
    }
