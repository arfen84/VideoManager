using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoManager.Models;

namespace VideoManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<VideoContext>());
            //using (var context = new VideoContext())
            //{
            //    context.Database.Initialize(force: true);
            //}
            
            return View();
        }

        [HttpPut]
        public void AddPut(Movie movie)
        {
            if (movie!=null)
            {
                Create(movie);
            }
        }

        [HttpPost]
        public void AddPost(Movie movie)
        {
            if (movie != null)
            {
                Movie moviefound = vc.Movies.Where(m => m.ID == movie.ID).FirstOrDefault();
                moviefound.Link = movie.Link;
                Update(moviefound);
            }
        }

        [HttpGet]
        //[Route("Home/{ID:int}")]
        public string GetDesc(int ID) //tested
        {
            string result = null;
            Movie movieNew = Read(ID);
            result = movieNew.Description;
            return result;
        }

        [HttpGet]
        public string GetLink(int ID) //tested
        {
            string result = null;
            Movie movieNew = Read(ID);
            result = movieNew.Link;
            return result;
        }

        [HttpDelete]
        public void DelFilm(Movie movie) //tested
        {
            Delete(movie);
        }

        VideoContext vc = new VideoContext();
        Movie mov;
        private void Create(Movie model)  //tested
        {
            vc.Movies.Add(model);
            vc.SaveChanges();
        }
        private Movie Read(int ID)  
        {
            Movie movie = vc.Movies.Where(i => i.ID == ID).FirstOrDefault();
            return movie;
        }
        private void Update (Movie movie)
        {
            if (movie != null)
            {
                vc.Movies.Attach(movie);
                var entry = vc.Entry(movie);
                entry.Property(e => e.Link).IsModified = true;
                vc.SaveChanges();
            }
        }
        private void Delete (Movie movie)  //tested
        {
            if (movie != null)
            {
                mov = vc.Movies.Where(m => m.ID == movie.ID).FirstOrDefault();
                vc.Movies.Remove(mov);
                vc.SaveChanges();
            }
        }
    }
}