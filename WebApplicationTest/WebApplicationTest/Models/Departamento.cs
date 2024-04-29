using System;
using System.Collections.Generic;

namespace WebApplicationTest.Models;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string NombreDepto { get; set; } = null!;

    public int IdOrganizacion { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual Organizacion IdOrganizacionNavigation { get; set; } = null!;
}
