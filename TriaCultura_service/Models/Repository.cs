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
            //us.SerializeVirtualProperties = serialize;
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

            List<request> request = context.requests.Where(x=> x.place_id == place_id).ToList();

            List<project> projects = context.projects.Where(x => x.id_project == request);
            foreach (project p in projects)
            {
              //  p.SerializeVirtualProperties = serialize;
            }
            return projects;
        } 



    }
}