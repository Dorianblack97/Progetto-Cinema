using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCinema.Domain;
public class SalaCinematografica : BaseDomain
{
    public string Name { get; set; }
    public byte RoomCapacity { get; set; }
    public byte OccupiedSeats { get; set; }
    private float profit { get; set; }
    public float Profit { get => profit; set => profit = CalculateProfit(); }
    [Display(Name = "Cinema")]
    public int CinemaId { get; set; }
    [Display(Name = "Film")]
    public int? FilmId { get; set; } = default;
    public Film? Film { get; set; } = default;
    public Cinema? Cinema { get; set; } = default;
    public ICollection<Biglietto>? Tickets { get; set; } = default;

    private float CalculateProfit()
    {
        var profit = 0f;
        foreach (var ticket in Tickets)
        {
            profit += ticket.Price;
        }
        return profit;
    }
}
