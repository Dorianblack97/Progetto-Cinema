using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCinema.Domain;
public class Cinema : BaseDomain
{
    public string Name { get; set; }
    public float Profit { get; set; } = default;
    public ICollection<SalaCinematografica>? CinemaRooms { get; set; } = default;
}
