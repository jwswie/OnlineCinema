using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineCinema.Models;

namespace OnlineCinema.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;


        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(string filmName, string genre, int releaseYear)
        {
            var films = await _context.Films.ToListAsync();

            var filteredFilms = films.AsQueryable();

            if (!string.IsNullOrEmpty(filmName))
            {
                filteredFilms = filteredFilms.Where(f => f.FilmName.ToLower().Contains(filmName.ToLower()));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                filteredFilms = filteredFilms.Where(f => f.FilmGenre == genre);
            }

            if (releaseYear > 1872) 
            {
                filteredFilms = filteredFilms.Where(f => f.ReleaseYear == releaseYear);
            }

            return View(filteredFilms);
        }

        public async Task<IActionResult> FilmPage(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }
    }
}
