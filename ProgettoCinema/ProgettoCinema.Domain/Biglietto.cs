using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCinema.Domain;
public class Biglietto : BaseDomain
{
    public int Seat { get; set; }
    private decimal price { get; set; }
    public decimal Price { get => price;
        set => price = value * Discount();
    }
    public int CinemaRoomId { get; set; }
    public int PersonId { get; set; }
    public Spettatore Person { get; set; }
    public SalaCinematografica CinemaRoom { get; set; }

    private decimal Discount()
    {
        var discount = 1m;
        if (Person.OverSeventyYear)
        {
            discount = 0.10m;
            return discount;
        }
        if (Person.UnderFiveYear)
        {
            discount = 0.50m;
            return discount;
        }
        return discount;
    }
}
