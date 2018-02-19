using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TriaCultura_service.Models
{
    public class Repository
    {
        private static triaculturaCTXEntities context = new triaculturaCTXEntities();
        public static user GetUser(string dni, bool serialize)
        {
            user us = context.users.Where(x => x.dni == dni).SingleOrDefault();
            us.SerializeVirtualProperties = serialize;
            return us;
        }

        public static void ChangePasswd(int user_id, string passwd)
        {
            user us = context.users.Where(x => x.id == user_id).SingleOrDefault();
            us.password = passwd;
            context.SaveChanges();
        }

        public static List<project> GetProjectes(int place_id, bool serialize)
        {
            List<request> requests = context.requests.Where(x=> x.place_id == place_id).ToList();

            List<project> projects = new List<project>();


            foreach (request r in requests)
            {
                projects.Add(r.project);
            }
            foreach (project p in projects)
            {
                p.SerializeVirtualProperties = serialize;
            }

            return projects;
        } 

        public static List<vote> GetVotes(int user_id, bool serialize)
        {
            List<vote> votes = context.votes.Where(x => x.user_id == user_id).OrderBy(x=> x.date).ToList();
         /* foreach (vote v in votes)
            {
                v.SerializeVirtualProperties = serialize;
            }*/
                return votes;
        }

        public static List<request> getAllRequest(bool serialize)
        {
            List<request> requests = context.requests.Where(x => x.is_winner == 1).OrderBy(x=>x.proposed_date).ToList();
           /* foreach (request r in requests)
            {
                r.SerializeVirtualProperties = serialize;
            }*/
            return requests;
        }

        public static user putVote(int user_id, int project_id)
        {
            user u = context.users.Where(x => x.id == user_id).SingleOrDefault();
            project p = context.projects.Where(x=> x.id_project == project_id).SingleOrDefault();
            vote v = new vote();
            v.project_id = p.id_project;
            v.user_id = u.id;
            v.date = DateTime.Now;
            context.votes.Add(v);
            context.SaveChanges();
            return u;
        }

        public static void removeVote(int user_id, int project_id)
        {
            vote v = context.votes.Where(x=> x.user_id == user_id && x.project_id == project_id).SingleOrDefault();
            context.votes.Remove(v);
            context.SaveChanges();

        }

        public static List<file> getfiles(int project_id, bool serialize)
        {
            List<file> files = context.files.Where(x => x.project_id == project_id).ToList();
            /*foreach (file f in files)
            {
                f.SerializeVirtualProperties = serialize;
            }*/
            return files;
        }

        public static author getAuthorWhereProject(int project_id)
        {
            project p = context.projects.Where(x=> x.id_project == project_id).SingleOrDefault();
            author a = p.author;
            return a;
        }
        
        public static int getCountRating(int project_id)
        {
            List<rating> ratings = context.ratings.Where(x => x.project_id == project_id).ToList();
            
            if (ratings.Count > 0)
            {
                int total = (int)ratings.Select(x => x.rate).Sum();
                return total / ratings.Count;
            }
            return 0;
        }
        public static List<rating> getRatingsWhereAuthor(int user_id)
        {
            List<rating> ratings = context.ratings.Where(x => x.user_id == user_id).ToList();
            return ratings;
        }


    }
}