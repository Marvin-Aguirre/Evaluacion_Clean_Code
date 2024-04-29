using System;
using System.Collections.Generic;

namespace WebApplicationTest.Models;

public partial class AsiganacionViaje
{
    public int IdAsiganacion { get; set; }

    public string DescripcionRuta { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public int IdEmpleado { get; set; }

    public int IdRuta { get; set; }

    public int IdBus { get; set; }

    public int IdHorario { get; set; }

    public int AsientosOcupados { get; set; }

    public int AsientosDisponibles { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Bus IdBusNavigation { get; set; } = null!;

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Horario IdHorarioNavigation { get; set; } = null!;

    public virtual Rutum IdRutaNavigation { get; set; } = null!;

    public virtual Usuario? Usuario { get; set; }
}
