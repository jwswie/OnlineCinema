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

        List<LikedFilm> likedFilms = new List<LikedFilm>() { };

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string filmName)
        {
            var films = await _context.Films.ToListAsync();

            var filteredFilms = films.AsQueryable();

            if (!string.IsNullOrEmpty(filmName))
            {
                filteredFilms = filteredFilms.Where(f => f.FilmName.ToLower().Contains(filmName.ToLower()));
            }

            if (likedFilms.Count > 0)
            {
                return View(new List<Film>() { likedFilms[0].Film });
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
            likedFilms.Add(new LikedFilm() {UserID = userId,FilmID = filmId });
            var likedfilm = await _context.LikedFilms.ToListAsync();
            var checklikedfilm = likedFilms.Where(l => l.UserID == userId && l.FilmID == filmId);
            if (checklikedfilm == null)
            {
                _context.LikedFilms.Add(new LikedFilm { UserID = userId, FilmID = filmId });
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}