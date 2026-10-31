using System;
using System.Collections.Generic;

namespace Tarea6.Data;

public partial class Estudiante
{
    public int EstudianteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Dirrecion { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FechaNacimiento { get; set; } = null!;
}
