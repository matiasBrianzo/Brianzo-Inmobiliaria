using Brianzo_Inmobiliaria.Controllers;

namespace Brianzo_Inmobiliaria.Models
{
    public interface IRepositorioInmueble : IRepositorio<Inmueble>
	{				
		IList<Inmueble> BuscarInmuebles(InmuebleBusqueda ib);
		IList<Inmueble> BuscarInmueblesEstado(InmuebleBusqueda ib);    
		Boolean VerificarDisponibilidad(int id,DateTime fecha_inicio,DateTime fecha_fin);	
	}   
   
}