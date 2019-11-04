using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoLibrosWebApp.Models.Helper
{
    public class LlavePrestamo
    {
        public int IdLector { get; set; }
        public int IdLibro { get; set; }
        public DateTime FechaPrestamo { get; set; }
    }
}
