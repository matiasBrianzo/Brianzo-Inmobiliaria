using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brianzo_Inmobiliaria.Models;

public class Login
{
    [DataType(DataType.EmailAddress)]
    [Display(Name ="Email")]
    public string Mail { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }
    
}

