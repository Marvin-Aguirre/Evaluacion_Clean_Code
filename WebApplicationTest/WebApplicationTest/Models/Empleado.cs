using System;
using System.Collections.Generic;

namespace WebApplicationTest.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string NombreEmpleado { get; set; } = null!;

    public int IdDepartamento { get; set; }

    public int IdOrganizacion { get; set; }

    public virtual ICollection<AsiganacionViaje> AsiganacionViajes { get; set; } = new List<AsiganacionViaje>();

    public virtual Departamento Departamento { get; set; } = null!;
}
