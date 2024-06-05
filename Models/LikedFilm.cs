namespace OnlineCinema.Models
{
    public class LikedFilm
    {
        public int UserID { get; set; }
        public int FilmID { get; set; }
        public User User { get; set; }
        public Film Film { get; set; }
    }
}