using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCinema.Domain;
public class SalaCinematografica : BaseDomain
{
    public string Name { get; set; }
    public byte RoomCapacity { get; set; }
    public byte OccupiedSeats { get; set; }
    public int CinemaId { get; set; }
    public int FilmId { get; set; }
    public Film Film { get; set; }
    public Cinema Cinema { get; set; }
    public ICollection<Biglietto> Tickets { get; set; }
}
