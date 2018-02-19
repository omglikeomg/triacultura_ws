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

        public static void ChangePasswd(string dni, string passwd)
        {
            user us = context.users.Where(x => x.dni == dni).SingleOrDefault();
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
            foreach (vote v in votes)
            {
                v.SerializeVirtualProperties = serialize;
            }
                return votes;
        }

        public static List<request> getAllRequest(bool serialize)
        {
            List<request> requests = context.requests.Where(x => x.is_winner == 1).OrderBy(x=>x.proposed_date).ToList();
            foreach (request r in requests)
            {
                r.SerializeVirtualProperties = serialize;
            }
            return requests;
        }

        public static void putVote(int user_id, int project_id)
        {
            user u = context.users.Where(x => x.id == user_id).SingleOrDefault();
            project p = context.projects.Where(x=> x.id_project == project_id).SingleOrDefault();
            vote v = new vote();

        }



    }
}