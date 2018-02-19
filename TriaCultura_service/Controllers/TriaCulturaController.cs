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

        // GET api/usuari
        [Route("api/usuari/{dni:alpha}")]
        public HttpResponseMessage GetUser_by_dni(string dni)
        {
            var user = Repository.GetUser(dni, true);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, user);
            return response;
        }

        // POST api/usuari
        [Route("api/usuari/{id?}/{new_pass:alpha}")]
        public HttpResponseMessage PostNewPass(int id, string new_pass)
        {
            var user = Repository.ChangePasswd(id, new_pass);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, user);
            return response;
        }


        //GET api/projects
        [Route("api/projects/{place_id?}")]
        public HttpResponseMessage GetProjects_for_place(int place_id)
        {
            var places = Repository.GetProjectes(place_id, true);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, places);
            return response;
        }

        //GET api/votes
        [Route("api/votes/{user_id?}")]
        public HttpResponseMessage GetVotes_for_user(int user_id)
        {
            var votes = Repository.GetVotes(user_id, true);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, votes);

            return response;
        }

        //PUT api/votes
        [Route("api/votes/{user_id?}/{project_id?}")]
        public HttpResponseMessage PostNewVote(int user_id, int project_id)
        {
            var vote = Repository.postVote(user_id, project_id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, vote);

            return response;
        }

        //DELETE api/votes
        [Route("api/votes/{user_id?}/{project_id?}")]
        public HttpResponseMessage DeleteVote(int user_id, int project_id)
        {
            Repository.removeVote(user_id, project_id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        //GET api/project
        //[Route("api/project/{project_id?")]
        //public HttpResponseMessage GetProject(int project_id)
        //{
        //    var project = Repository.get

        //    return response;
        //}

        //GET api/winningrequests
        [Route("api/winningrequests")]
        public HttpResponseMessage GetWinningRequests()
        {

            var requests = Repository.getAllRequest(true);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requests);
            return response;
        }

        //GET api/files
        [Route("api/files/{project_id?}")]
        public HttpResponseMessage GetFiles_for_Project(int project_id)
        {
            var files = Repository.getfiles(project_id, false);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, files);

            return null;
        }

        //GET api/author
        [Route("api/author/{project_id?}")]
        public HttpResponseMessage GetAuthor_for_Project(int project_id)
        {
            var author = Repository.getAuthorWhereProject(project_id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, author);

            return response;
        }

        //GET api/rating
        [Route("api/rating/{project_id?}")]
        public HttpResponseMessage GetProject_avg_rating(int project_id)
        {
            var avg_rating = Repository.getCountRating(project_id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, avg_rating);

            return response;
        }

        [Route("api/rating/{user_id?}/{project_id?}")]
        public HttpResponseMessage GetUserRating_for_project (int user_id, int project_id)
        {
            var rating = Repository.getRatingsWhereAuthorAndProject(user_id,project_id);

            return response;
        }

    }
}
