using System;
using System.Collections.Generic;

namespace CentroMedicoWebAPI.Models;

public partial class Paciente
{
    public int PacienteId { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string TipoDocumento { get; set; } = null!;

    public string NumeroDocumento { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string CiudadResidencia { get; set; } = null!;
}
