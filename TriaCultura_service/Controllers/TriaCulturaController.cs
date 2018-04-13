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
        [Route("api/usuari/{dni?}")]
        public HttpResponseMessage GetUser_by_dni(string dni)
        {
            var user = TriaCulturaRepository.GetUser(dni, true);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, user);
            return response;
        }

        // PUT api/usuari
        [Route("api/usuari/")]
        public HttpResponseMessage PutNewPass([FromBody]user u)
        {
            var user = TriaCulturaRepository.ChangeUsr(u);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, user);
            return response;
        }

        //GET api/current
        [Route("api/current")]
        public HttpResponseMessage GetCurrent()
        {
            int i = 4; //puesto a mano de momento, es el "place" actualmente en _disputa_
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, i);
            return response;
        }


        //GET api/projects
        [Route("api/projects/{place_id?}")]
        public HttpResponseMessage GetProjects_for_place(int place_id)
        {
            var places = TriaCulturaRepository.GetProjectes(place_id, true);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, places);
            return response;
        }

        //GET api/project/
        [Route("api/project/{project_id?}")]
        public HttpResponseMessage getProject(int project_id)
        {
            var project = TriaCulturaRepository.getProjectById(project_id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, project);
            return response;
        }

        //GET api/votes
        [Route("api/votes/{user_id?}")]
        public HttpResponseMessage GetVotes_for_user(int user_id)
        {
            var votes = TriaCulturaRepository.GetVotes(user_id, true);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, votes);

            return response;
        }

        //GET api/vote
        [Route("api/vote/{user_id?}/{project_id?}")]
        public HttpResponseMessage getVote_by_ids(int user_id, int project_id)
        {
            var vote = TriaCulturaRepository.getVote(user_id, project_id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, vote);
            return response;
        }

        //POST api/votes
        [Route("api/votes/{user_id}/{project_id}")]
        public HttpResponseMessage PostNewVote(int user_id, int project_id)
        {
            var vote = TriaCulturaRepository.postVote(user_id,project_id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, vote);

            return response;
        }

        //DELETE api/votes
        [Route("api/votes/{id?}")]
        public HttpResponseMessage DeleteVote(int id)
        {
            TriaCulturaRepository.removeVote(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        //GET api/winningrequests
        [Route("api/winningrequests")]
        public HttpResponseMessage GetWinningRequests()
        {

            var requests = TriaCulturaRepository.getAllRequest(true);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requests);
            return response;
        }

        //GET api/files
        [Route("api/files/{project_id?}")]
        public HttpResponseMessage GetFiles_for_Project(int project_id)
        {
            var files = TriaCulturaRepository.getfiles(project_id, false);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, files);

            return response;
        }

        //GET api/file
        [Route("api/file/{file_id?}")]
        public HttpResponseMessage GetSingleFile(int file_id)
        {
            var file = TriaCulturaRepository.getSingleFile(file_id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, file);
            return response;
        }

        //GET api/author
        [Route("api/author/{project_id?}")]
        public HttpResponseMessage GetAuthor_for_Project(int project_id)
        {
            var author = TriaCulturaRepository.getAuthorWhereProject(project_id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, author);

            return response;
        }

        //GET api/rating
        [Route("api/rating/{project_id?}")]
        public HttpResponseMessage GetProject_avg_rating(int project_id)
        {
            var avg_rating = TriaCulturaRepository.getCountRating(project_id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, avg_rating);

            return response;
        }

        [Route("api/rating/{user_id?}/{project_id?}")]
        public HttpResponseMessage GetUserRating_for_project (int user_id, int project_id)
        {
            var rating = TriaCulturaRepository.getRatingsWhereAuthor(user_id,project_id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, rating);

            return response;
        }

        [Route("api/rating/")]
        public HttpResponseMessage PutUserRating_for_project([FromBody]rating r)
        {
            var rating = TriaCulturaRepository.putRating(r);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, rating);
            return response;
            
        }

        //GET api/rating/last_id
        //[Route("api/rating/last_id")]
        //public HttpResponseMessage GetLastIdRating()
        //{
        //    var rating_id = TriaCulturaRepository.last_rating_id();
        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, rating_id);
        //    return response;
        //}

    }
}
