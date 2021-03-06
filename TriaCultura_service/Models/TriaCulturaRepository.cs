﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TriaCultura_service.Models
{
    public class TriaCulturaRepository
    {
        private static triaculturaCTXEntities context = new triaculturaCTXEntities();
        public static user GetUser(string dni, bool serialize)
        {
            user us = context.users.Where(x => x.dni == dni).SingleOrDefault();
            us.SerializeVirtualProperties = serialize;
            foreach (rating r in us.ratings)
            {
                r.project.SerializeVirtualProperties = false;
            }
            foreach (vote v in us.votes)
            {
                v.project.SerializeVirtualProperties = false;
            }
            return us;
        }

        public static user ChangeUsr(user u)
        {
            context.users.Where(x => x.id == u.id).SingleOrDefault().password = u.password;
            context.users.Where(x => x.id == u.id).SingleOrDefault().email = u.email;
            context.SaveChanges();
            
            return context.users.Where(x => x.id == u.id).SingleOrDefault();
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
                foreach(file f in p.files)
                {
                    f.SerializeVirtualProperties = false;
                }
                foreach (vote v in p.votes)
                {
                    v.SerializeVirtualProperties = false;
                }
                p.author.SerializeVirtualProperties = false;
                p.SerializeVirtualRatings = false;
            }

            return projects;
        } 

        public static List<vote> GetVotes(int user_id, bool serialize)
        {
            List<vote> votes = context.votes.Where(x => x.user_id == user_id).OrderBy(x=> x.date).ToList();
         foreach (vote v in votes)
            {
                foreach (file f in v.project.files)
                {
                    f.SerializeVirtualProperties = false;
                }
            }
                return votes;
        }

        public static vote getVote(int user_id, int project_id)
        {
            vote v = context.votes.Where(x => x.user_id == user_id && x.project_id == project_id).SingleOrDefault();
            foreach (file f in v.project.files)
            {
                f.SerializeVirtualProperties = false;
            }
            return v;
        }

        public static List<request> getAllRequest(bool serialize)
        {
            List<request> requests = context.requests.Where(x => x.is_winner == 1).OrderBy(x=>x.proposed_date).ToList();
           /* foreach (request r in requests)
            {
                r.SerializeVirtualProperties = serialize;
            }*/

            foreach (request r in requests)
            {
                foreach (file f in r.project.files)
                {
                    f.SerializeVirtualProperties = false;
                }
                r.place.SerializeVirtualProperties = false;
                r.place.place_has_capacity = null;
            }

            return requests;
        }

        public static vote postVote(int user_id, int project_id)
        {
            vote v = new vote();
            v.id_vote = 0;
            v.date = DateTime.Now;
            v.user_id = user_id;
            v.project_id = project_id;
            context.votes.Add(v);
            context.SaveChanges();
            return context.votes.Where(x => x.project_id == v.project_id && x.user_id == v.user_id).SingleOrDefault();
        }

        public static void removeVote(int vote_id)
        {
            vote v = context.votes.Where(x => x.id_vote == vote_id).SingleOrDefault();
            context.votes.Remove(v);
            context.SaveChanges();

        }

        public static List<file> getfiles(int project_id, bool serialize)
        {
            List<file> files = null;
            try
            {
                files = context.files.Where(x => x.project_id == project_id).ToList();
            } catch (Exception ex)
            {
                /*?*/
            }
            foreach (file f in files)
            {
                f.SerializeVirtualProperties = false;
                f.project.SerializeVirtualProperties = false;
            }
            return files;
        }

        public static file getSingleFile(int file_id)
        {
            file f = null;
            try
            {
                f = context.files.Where(x => x.id_file == file_id).SingleOrDefault();
            } catch (Exception e)
            {
                /*?*/
            }
            f.SerializeVirtualProperties = true;
            return f;
        }

        public static author getAuthorWhereProject(int project_id)
        {
            project p = context.projects.Where(x=> x.id_project == project_id).SingleOrDefault();
            author a = p.author;
            a.SerializeVirtualProperties = false;
            return a;
        }
        
        public static double getCountRating(int project_id)
        {
            List<rating> ratings = context.ratings.Where(x => x.project_id == project_id).ToList();
            
            if (ratings.Count > 0)
            {
                double total = (double)ratings.Select(x => x.rate).Sum();
                return (double)total / ratings.Count;
            }
            return 0;
        }

        public static List<request> getVotedProjects(int user_id)
        {
            List<vote> valid_votes = context.votes.Where(x => x.user_id == user_id).ToList();
            List<request> results = new List<request>();
            foreach (vote v in valid_votes)
            {
                List<request> requests = v.project.requests.ToList();

                foreach (request r in requests)
                {
                    DateTime dt = (DateTime)r.proposed_date;
                    if (dt.Month == v.date.Month)
                    {
                        results.Add(r);
                    }
                } 

            }

            foreach (request r in results)
            {
                r.project.SerializeVirtualRatings = false;
                r.project.SerializeVirtualProperties = false;
            }
            return results;
        }

        public static List<rating> getRatingsWhereAuthor(int user_id)
        {
            List<rating> ratings = context.ratings.Where(x => x.user_id == user_id).ToList();
            foreach (rating r in ratings)
            {
                foreach (file f in r.project.files)
                {
                    f.SerializeVirtualProperties = false;
                }
            }
            return ratings;
        }
        public static rating getRatingsWhereAuthor(int user_id, int project_id)
        {
            rating rating = context.ratings.Where(x => x.user_id == user_id && x.project_id == project_id).SingleOrDefault();
            foreach (file f in rating.project.files)
            {
                f.SerializeVirtualProperties = false;
            }
            return rating;
        }

        public static project getProjectById(int project_id)
        {
            project p = context.projects.Where(x => x.id_project == project_id).SingleOrDefault();
            p.SerializeVirtualProperties = true;
            foreach (rating r in p.ratings)
            {
                r.SerializeVirtualProperties = false;
            }

            return p;
        }

        public static int count_votes (int proj_id)
        {
            return context.projects.Where(x => x.id_project == proj_id).SingleOrDefault().votes.Count;
        }

        public static rating putRating (rating r)
        {
                if (r.id_rating != 0 || context.ratings.Where(x => x.project_id == r.project_id && x.user_id == r.user_id).SingleOrDefault() != null)
                {
                    context.ratings.Where(x => x.project_id == r.project_id && x.user_id == r.user_id).SingleOrDefault().rate = r.rate;
                    context.ratings.Where(x => x.project_id == r.project_id && x.user_id == r.user_id).SingleOrDefault().comment = r.comment;
                }            
            else 
            {
                context.ratings.Add(r);
            }
            if (r.project != null)
            {
                r.project.SerializeVirtualProperties = false;
            }
            context.SaveChanges();
            return context.ratings.Where(x=> x.id_rating == r.id_rating).SingleOrDefault();
        }

        public static int last_rating_id ()
        {
            return context.ratings.ToList().Last().id_rating;
        }

    }
}