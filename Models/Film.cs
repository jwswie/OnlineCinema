using System.Collections.Generic;

namespace OnlineCinema.Models
{
    public class Film
    {
        public int ID { get; set; }
        public string FilmName { get; set; }
        public string FilmPoster { get; set; }
        public int ReleaseYear { get; set; }
        public string FilmDescription { get; set; }
        public string FilmTrailer { get; set; }
        public string Director { get; set; }
        public string Scenarist { get; set; }
        public string Actors { get; set; }
        public ICollection<LikedFilm> LikedFilms { get; set; }
    }
}
