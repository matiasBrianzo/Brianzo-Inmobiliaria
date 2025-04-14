using Brianzo_Inmobiliaria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Brianzo_Inmobiliaria.Controllers;

public class InquilinosController : Controller
{
	private readonly IRepositorioInquilino repositorio;
	private readonly IConfiguration config;

	public InquilinosController(IRepositorioInquilino repo, IConfiguration config)
	{
		this.repositorio = repo;
		this.config = config;
	}

	// GET: Inquilino
	[Route("[controller]/Index")]
	public ActionResult Index()
	{
		try
		{
			var lista = repositorio.ObtenerTodos();
			ViewBag.Id = TempData["Id"];
			// TempData es para pasar datos entre acciones
			// ViewBag/Data es para pasar datos del controlador a la vista
			// Si viene alguno valor por el tempdata, lo paso al viewdata/viewbag
			if (TempData.ContainsKey("Mensaje"))
				ViewBag.Mensaje = TempData["Mensaje"];
			return View(lista);
		}
		catch (Exception ex)
		{// Poner breakpoints para detectar errores
			
			throw  ;
		}
	}
	// GET: Inquilino/Details/5
	public ActionResult Details(int id)
	{
		try
		{
			var lista = repositorio.ObtenerPorId(id);
			ViewBag.Mensaje = TempData["Mensaje"];
			return View(lista);
		}
		catch (Exception ex)
		{// Poner breakpoints para detectar errores
			
			throw  ;
		}
	}

	// GET: Inquilino/Edit/5
	public ActionResult Edit(int id)
	{
		try
		{
			var entidad = repositorio.ObtenerPorId(id);
			return View(entidad);//pasa el modelo a la vista
		}
		catch (Exception ex)
		{//poner breakpoints para detectar errores
			
			throw  ;
		}
	}

	// POST: Inquilino/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	//public ActionResult Edit(int id, IFormCollection collection)
	public ActionResult Edit(int id, Inquilino entidad)
	{
		// Si en lugar de IFormCollection ponemos Propietario, el enlace de datos lo hace el sistema
		Inquilino? p = null;
		try
		{
			p = repositorio.ObtenerPorId(id);
			////////////////////////////////////////
			p.Nombre = entidad.Nombre;
			p.Apellido = entidad.Apellido;
			p.Dni = entidad.Dni;
			p.Telefono = entidad.Telefono;
			repositorio.Modificacion(p);
			TempData["editado"] = "Si";
			return RedirectToAction(nameof(Index));
		}
		catch (Exception ex)
		{//poner breakpoints para detectar errores
			
			throw  ;
		}
	}

	// GET: Inquilino/Create
	public ActionResult Create()
	{
		try
		{
			return View();
		}
		catch (Exception ex)
		{//poner breakpoints para detectar errores
			
			throw  ;
		}
	}
	// POST: Inquilino/Create
	[HttpPost]
	//[ValidateAntiForgeryToken]
	public ActionResult Create(Inquilino inquilino)
	{
		try
		{
			if (ModelState.IsValid)// Pregunta si el modelo es válido
			{
				// Reemplazo de clave plana por clave con hash
				/*propietario.Clave = Convert.ToBase64String(KeyDerivation.Pbkdf2(
						password: propietario.Clave,
						salt: System.Text.Encoding.ASCII.GetBytes(config["Salt"]),
						prf: KeyDerivationPrf.HMACSHA1,
						iterationCount: 1000,
						numBytesRequested: 256 / 8));*/
				repositorio.Alta(inquilino);
				TempData["Id"] = inquilino.Id_Inquilino;
				TempData["creado"] = "Si";
				return RedirectToAction(nameof(Index));
			}
			else
				return View(inquilino);
		}
		catch (Exception ex)
		{//poner breakpoints para detectar errores
			
			throw  ;
		}
	}

	// GET: Inquilino/Delete/5
	public ActionResult Delete(int id)
	{
		try
		{
			var entidad = repositorio.ObtenerPorId(id);
			return View(entidad);
		}
		catch (Exception ex)
		{//poner breakpoints para detectar errores
			
			throw  ;
		}
	}

	// POST: Inquilino/Delete/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Delete(int id, Propietario entidad)
	{
		try
		{
			repositorio.Baja(id);
			TempData["eliminado"] = "Si";
			return RedirectToAction(nameof(Index));
		}
		catch (Exception ex)
		{//poner breakpoints para detectar errores
			
			throw  ;
		}
	}
}