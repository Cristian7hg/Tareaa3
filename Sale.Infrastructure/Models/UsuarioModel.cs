using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Infrastructure.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string Telefono { get; set; }
        public int DepartmentId { get; set; }

    }
}
