using System;
using System.Collections.Generic;

namespace WebApplicationTest.Models;

public partial class Horario
{
    public int IdHorario { get; set; }

    public DateOnly InicioHorario { get; set; }

    public DateOnly FinHorario { get; set; }

    public virtual ICollection<AsiganacionViaje> AsiganacionViajes { get; set; } = new List<AsiganacionViaje>();
}
