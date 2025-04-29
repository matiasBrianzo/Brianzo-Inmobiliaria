using Brianzo_Inmobiliaria.Controllers;

namespace Brianzo_Inmobiliaria.Models
{
    public interface IRepositorioPago : IRepositorio<Pago>
	{		
		IList<Pago> PagosPorContrato(int id);
		IList<Pago> PagosContratoPorInquilino(int id);
	}   
   
}