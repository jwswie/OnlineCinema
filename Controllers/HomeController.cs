﻿using Microsoft.AspNetCore.Mvc;
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


        public async Task<IActionResult> Index(string filmName, List<string> genres, int releaseYear)
        {
            var films = await _context.Films.ToListAsync();

            var filteredFilms = films.AsQueryable();

            if (!string.IsNullOrEmpty(filmName))
            {
                filteredFilms = filteredFilms.Where(f => f.FilmName.ToLower().Contains(filmName.ToLower()));
            }

            if (genres.Any())
            {
               filteredFilms = filteredFilms.Where(f => genres.Contains(f.FilmGenre));
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

        public async Task<IActionResult> Like(int filmId, int userId)
        {
            bool checkLikedFilm = await _context.LikedFilms.AnyAsync(l => l.UserID == userId && l.FilmID == filmId);

            if (!checkLikedFilm)
            {
                _context.LikedFilms.Add(new LikedFilm { UserID = userId, FilmID = filmId });
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

    }
}