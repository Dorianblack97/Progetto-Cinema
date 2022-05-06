using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCinema.Domain;
public class Spettatore : BaseDomain
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthdate { get; set; }
    public int? TicketId { get; set; } = null;
    private bool overSeventyYear { get; set; }
    public bool OverSeventyYear
    {
        get => overSeventyYear;
        set => overSeventyYear = IsOverSeventy();
    }
    private bool underFiveYear { get; set; }
    public bool UnderFiveYear
    {
        get => underFiveYear;
        set => underFiveYear = IsUnderFiveYear();
    }

    public Biglietto? Ticket { get; set; } = null;

    private bool IsUnderFiveYear()
    {
        return Birthdate.AddYears(5) > DateTime.Now;
    }

    private bool IsOverSeventy()
    {
        return Birthdate.AddYears(70) < DateTime.Now;
    }
}
