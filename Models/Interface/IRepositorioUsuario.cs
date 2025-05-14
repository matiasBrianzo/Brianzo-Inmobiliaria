using Brianzo_Inmobiliaria.Controllers;

namespace Brianzo_Inmobiliaria.Models
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
	{		
		Usuario ObtenerPorEmail(string mail);
		int CambiarPassword(int id, String pass);
	}   
   
}