using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstMCPApp.Models;

namespace MyFirstMCPApp.Controllers
{
    public class MovieController : Controller
    {
        // GET: MovieController
        public ActionResult Index()
        {
            List<Movie> Movielist = MovieDbRepository.GetMovieList();

            return View(Movielist);
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }
            Movie movie = MovieDbRepository.GetMovieById(id);
            return View(movie);

        }
        // GET: MovieController/Create
        public ActionResult Create()
        {
            Movie movie = new Movie();
            return View(movie);
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Movie pmovie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MovieDbRepository.AddNewMovie(pmovie);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)

            {

                return RedirectToAction("Index");

            }

            Movie movie = MovieDbRepository.GetMovieById(id);

            return View(movie);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Movie pmovie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MovieDbRepository.UpdateMovie(pmovie);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (id <= 0)
            {
                return RedirectToActionPermanent("Index");
            }
            Movie movie = MovieDbRepository.GetMovieById(id);
            return View(movie);
        }
    }
}

        

