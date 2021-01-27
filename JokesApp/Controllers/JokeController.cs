using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokesApp.Services;
using JokesApp.Models;

namespace JokesApp.Controllers
{
    public class JokeController : Controller
    {
        // GET: JokeController
        public async Task<IActionResult> Index(JokeService jokeService)
        {
            List<Joke> jokes = await jokeService.getJokes();

            return View(jokes);
        }

        // GET: JokeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JokeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JokeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JokeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JokeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JokeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JokeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
