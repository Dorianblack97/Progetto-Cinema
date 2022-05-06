using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCinema.Domain;
public class Film : BaseDomain
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Producer { get; set; }
    public int CinemaRoomId { get; set; }
    public int FilmGenreId { get; set; }
    public int Duration { get; set; }
    public ICollection<SalaCinematografica> CinemaRooms { get; set; }
    public GenereFilm FilmGenre { get; set; }
}
