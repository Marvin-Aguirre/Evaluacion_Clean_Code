using System;
using System.Collections.Generic;

namespace WebApplicationTest.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string DescripcionRol { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
