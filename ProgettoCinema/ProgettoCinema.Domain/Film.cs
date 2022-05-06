using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public int? CinemaRoomId { get; set; } = default;
    [Display (Name = "Genere")]
    public int FilmGenreId { get; set; }
    public int Duration { get; set; }
    public ICollection<SalaCinematografica>? CinemaRooms { get; set; } = default;
    public GenereFilm? FilmGenre { get; set; } = default;
}
