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

            return null;
        }

        // POST api/usuari
        [Route("api/usuari/{id?}/{new_pass:alpha}")]
        public HttpResponseMessage PostNewPass(int id, string new_pass)
        {

            return null;
        }


        //GET api/projects
        [Route("api/projects/{place_id?}")]
        public HttpResponseMessage GetProjects_for_place(int place_id)
        {

            return null;
        }

        //GET api/votes
        [Route("api/votes/{user_id?}")]
        public HttpResponseMessage GetVotes_for_user(int user_id)
        {

            return null;
        }

        //PUT api/votes
        [Route("api/votes/{user_id?}/{project_id?}")]
        public HttpResponseMessage PutNewVote(int user_id, int project_id)
        {
            return null;
        }

        //DELETE api/votes
        [Route("api/votes/{user_id?}/{project_id?}")]
        public HttpResponseMessage DeleteVote(int user_id, int project_id)
        {

            return null;
        }

        //GET api/project
        [Route("api/project/{project_id?")]
        public HttpResponseMessage GetProject(int project_id)
        {

            return null;
        }

        //GET api/requests
        [Route("api/requests")]
        public HttpResponseMessage GetWinningRequests()
        {

            return null;
        }

        //GET api/files
        [Route("api/files/{project_id?}")]
        public HttpResponseMessage GetFiles_for_Project(int project_id)
        {

            return null;
        }

        //GET api/author
        [Route("api/author/{project_id?}")]
        public HttpResponseMessage GetAuthor_for_Project(int project_id)
        {

            return null;
        }

        //GET api/rating
        [Route("api/rating/{project_id?}")]
        public HttpResponseMessage GetProject_avg_rating(int project_id)
        {

            return null;
        }

        [Route("api/rating/{user_id?}/{project_id?}")]
        public HttpResponseMessage GetUserRating_for_project (int user_id, int project_id)
        {

            return null;
        }

    }
}
