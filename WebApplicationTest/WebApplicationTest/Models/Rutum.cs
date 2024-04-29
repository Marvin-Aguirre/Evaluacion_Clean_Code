using System;
using System.Collections.Generic;

namespace WebApplicationTest.Models;

public partial class Rutum
{
    public int IdRuta { get; set; }

    public string Origen { get; set; } = null!;

    public string Destino { get; set; } = null!;

    public virtual ICollection<AsiganacionViaje> AsiganacionViajes { get; set; } = new List<AsiganacionViaje>();
}
