using System;
using System.Collections.Generic;

namespace WebApplicationTest.Models;

public partial class Bus
{
    public int IdBus { get; set; }

    public int Capacidad { get; set; }

    public virtual ICollection<AsiganacionViaje> AsiganacionViajes { get; set; } = new List<AsiganacionViaje>();
}
