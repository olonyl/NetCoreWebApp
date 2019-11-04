using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class Prestamo
    {
        [Display(Name = "Estudiante")]
        [Required(ErrorMessage = "El Estudiante es requerido")]
        public int IdLector { get; set; }
        public Estudiante Lector { get; set; }
        [Display(Name = "Libro")]
        [Required(ErrorMessage = "El Libro es requerido")]
        public int IdLibro { get; set; }
        public Libro Libro { get; set; }
        [Required(ErrorMessage = "La Fecha de Prestamo es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaPrestamo { get; set; }
        [Required(ErrorMessage = "La Fecha de Devolucion es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaDevolucion { get; set; }
        public bool Devuelto { get; set; }
    }
}
