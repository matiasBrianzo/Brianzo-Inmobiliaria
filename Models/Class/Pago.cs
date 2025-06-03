using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brianzo_Inmobiliaria.Models;

public class Pago
{
    [Key]
    [Display(Name = "N°")]
    public int Id_Pago { get; set; } 

    [Required, Display(Name = "Fecha de Pago")]
    public DateTime Fecha { get; set; }


    [Required]
    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public Decimal Importe { get; set; }


    [Required,Display(Name ="Contrato")]
    public int Id_Contrato{ get; set; }
    [ForeignKey(nameof(Id_Contrato))]
    public Contrato? Contrato { get; set; }

}