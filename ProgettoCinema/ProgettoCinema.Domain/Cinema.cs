using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCinema.Domain;
public class Cinema : BaseDomain
{
    public string Name { get; set; }
    public decimal Profit { get; set; }
    public ICollection<SalaCinematografica> Cinemas { get; set; }
}
