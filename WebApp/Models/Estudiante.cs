using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class Estudiante
    {
        public int IdLector { get; set; }
        [Required(ErrorMessage = "El CI es requerido")]
        public string CI { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        [Display(Name = "Estudiante")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La Direccion es requerida")]
        public string Dierccion { get; set; }
        [Required(ErrorMessage = "La Carrera es requerida")]
        public string Carrera { get; set; }
        [Required(ErrorMessage = "La Edad es requerida")]
        public int Edad { get; set; }
    }
}
