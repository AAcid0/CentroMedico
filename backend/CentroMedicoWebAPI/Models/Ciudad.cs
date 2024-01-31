using System;
using System.Collections.Generic;

namespace CentroMedicoWebAPI.Models;

public partial class Ciudad
{
    public int CiudadId { get; set; }

    public string NombreCiudad { get; set; } = null!;

    public int? DepartamentoId { get; set; }

    public virtual Departamento? Departamento { get; set; }
}
