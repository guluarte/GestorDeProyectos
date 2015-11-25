using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTerminal.Models
{
    public class Nota
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Texto")]
        public string Texto { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }
        [Display(Name = "Proyecto")]
        public Guid ProyectoId { get; set; }
    }

    public class Requerimiento
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [MinLength(5)]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [Display(Name = "Proyecto")]
        public Guid ProyectoId { get; set; }
        [Required]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }
    }

    public class Documento
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Proyecto")]
        [Required]
        public Guid ProyectoId { get; set; }
        [Required]
        [Display(Name = "Texto")]
        public string Texto { get; set; }
        [Required]
        [Display(Name = "Fecha de creacion")]
        public DateTime FechaCreacion { get; set; }
        [Display(Name = "Fecha de modificacion")]
        public DateTime? FechaModificacion { get; set; }

    }

    public class Proyecto
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Notas")]
        public List<Nota> Notas { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }
        [Display(Name = "Activo")]
        public bool Activo { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [Display(Name = "Tareas")]
        public List<Tarea> Tareas { get; set; }
        [Display(Name = "Metas")]
        public List<Meta> Metas { get; set; }
        [Display(Name = "Repositorios")]
        public List<Repositorio> Repositorios { get; set; }
        [Display(Name = "Documentos")]
        public List<Documento> Documentos { get; set; }
        [Display(Name = "Requerimientos")]
        public List<Requerimiento> Requerimientos { get; set; }
    }

    public class Meta
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Fecha de completacion planeada")]
        public DateTime FechaCompletacionPlaneada { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Fecha de completacion Actual")]
        public DateTime? FechaCompletacionActual { get; set; }
        [Required]
        public Guid ProyectoId { get; set; }
    }

    public class Tarea
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [Display(Name = "Proyecto")]
        [Required]
        public Guid ProyectoId { get; set; }
        [Display(Name = "Tarea Activa")]
        public bool Activa { get; set; }
        [Required]
        [Display(Name = "Fecha de creacion")]
        public DateTime Fecha { get; set; }
        [Display(Name = "Fecha de completacion")]
        public DateTime? FechaCompleatacion { get; set; }
    }

    public class Repositorio
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Direccion Web")]
        public string Url { get; set; }
        [Required]
        public Guid ProyectoId { get; set; }
    }
}