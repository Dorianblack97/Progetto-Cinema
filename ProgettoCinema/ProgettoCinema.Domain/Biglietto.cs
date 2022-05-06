using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCinema.Domain;
public class Biglietto : BaseDomain
{
    public int Seat { get; set; }
    private decimal price { get; set; }
    public decimal Price { get; set; }
    [Display(Name = "Sala")]
    public int CinemaRoomId { get; set; }
    [Display(Name = "Spettatore")]
    public int PersonId { get; set; }

    public Spettatore? Person { get; set; } = default;
    public SalaCinematografica? CinemaRoom { get; set; } = default;

}
