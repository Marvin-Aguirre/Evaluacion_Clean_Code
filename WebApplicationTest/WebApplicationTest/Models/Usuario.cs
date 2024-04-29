using System;
using System.Collections.Generic;

namespace WebApplicationTest.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? IdRol { get; set; }

    public virtual ICollection<AsiganacionViaje> AsiganacionViajes { get; set; } = new List<AsiganacionViaje>();

    public virtual Rol? IdRolNavigation { get; set; }
}
