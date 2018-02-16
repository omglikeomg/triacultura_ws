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

        // GET api/usuari
        [Route("api/usuari/{dni:alpha}")]
        public HttpResponseMessage GetUser_by_dni(string dni)
        {

        }

        // POST api/usuari
        [Route("api/usuari/{id?}/{new_pass:alpha}")]
        public HttpResponseMessage PostNewPass(int id, string new_pass)
        {

        }


        //GET api/projects
        [Route("api/projects/{place_id?}")]
        public HttpResponseMessage GetProjects_for_place(int place_id)
        {

        }

        //GET api/votes
        [Route("api/votes/{user_id?}")]
        public HttpResponseMessage GetVotes_for_user(int user_id)
        {

        }

        //PUT api/votes
        [Route("api/votes/{user_id?}/{project_id?}")]
        public HttpResponseMessage PutNewVote(int user_id, int project_id)
        {

        }

        //DELETE api/votes
        [Route("api/votes/{user_id?}/{project_id?}")]
        public HttpResponseMessage DeleteVote(int user_id, int project_id)
        {

        }

        //GET api/project
        [Route("api/project/{project_id?")]
        public HttpResponseMessage GetProject(int project_id)
        {

        }

        //GET api/requests
        [Route("api/requests")]
        public HttpResponseMessage GetWinningRequests()
        {

        }

        //GET api/files
        [Route("api/files/{project_id?}")]
        public HttpResponseMessage GetFiles_for_Project(int project_id)
        {

        }

        //GET api/author
        [Route("api/author/{project_id?}")]
        public HttpResponseMessage GetAuthor_for_Project(int project_id)
        {

        }

        //GET api/rating
        [Route("api/rating/{project_id?}")]
        public HttpResponseMessage GetProject_avg_rating(int project_id)
        {

        }

        [Route("api/rating/{user_id?}/{project_id?}")]
        public HttpResponseMessage GetUserRating_for_project (int user_id, int project_id)
        {

        }

    }
}
