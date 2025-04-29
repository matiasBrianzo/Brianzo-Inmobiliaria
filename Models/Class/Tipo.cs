using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brianzo_Inmobiliaria.Models;

public class Tipo
{
    [Key]
    public int Id_Tipo { get; set; }
    [Required, Display(Name = "Tipo de Inmmueble")]
    public string? Nombre { get; set; }
    
}

