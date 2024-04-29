using System;
using System.Collections.Generic;

namespace WebApplicationTest.Models;

public partial class Organizacion
{
    public int IdOrganizacion { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
