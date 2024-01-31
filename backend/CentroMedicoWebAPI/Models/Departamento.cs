using System;
using System.Collections.Generic;

namespace CentroMedicoWebAPI.Models;

public partial class Departamento
{
    public int DepartamentoId { get; set; }

    public string NombreDepartamento { get; set; } = null!;

    public virtual ICollection<Ciudad> Ciudads { get; } = new List<Ciudad>();
}
