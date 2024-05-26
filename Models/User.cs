using System.Collections.Generic;

namespace OnlineCinema.Models
{
    public class User
    {
        public int ID { get; set; } 
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public ICollection<LikedFilm> LikedFilms { get; set; }
    }
}
