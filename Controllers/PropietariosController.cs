using Brianzo_Inmobiliaria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Brianzo_Inmobiliaria.Controllers;

public class PropietariosController : Controller
{
	private readonly IRepositorioPropietario repositorio;
	private readonly IConfiguration config;

	public PropietariosController(IRepositorioPropietario repo, IConfiguration config)
	{
		// Sin inyección de dependencias y sin usar el config (quitar el parámetro repo del ctor)
		//this.repositorio = new RepositorioPropietario();
		// Sin inyección de dependencias y pasando el config (quitar el parámetro repo del ctor)
		//this.repositorio = new RepositorioPropietario(config);
		// Con inyección de dependencias
		this.repositorio = repo;
		this.config = config;
	}

	// GET: Propietario
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
	// GET: PROPIETARIOS/Details/5
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
	// GET: Propietario
	[Route("[controller]/Lista")]
	public ActionResult Lista(int pagina = 1)
	{
		try
		{
			var tamaño = 5;
			var lista = repositorio.ObtenerLista(Math.Max(pagina, 1), tamaño);
			ViewBag.Pagina = pagina;
			var total = repositorio.ObtenerCantidad();
			ViewBag.TotalPaginas = total % tamaño == 0 ? total / tamaño : total / tamaño + 1;
			// TempData es para pasar datos entre acciones
			// ViewBag/Data es para pasar datos del controlador a la vista
			// Si viene alguno valor por el tempdata, lo paso al viewdata/viewbag
			ViewBag.Id = TempData["Id"];
			if (TempData.ContainsKey("Mensaje"))
				ViewBag.Mensaje = TempData["Mensaje"];
			return View(lista);
		}
		catch (Exception ex)
		{// Poner breakpoints para detectar errores
			
			throw  ;
		}
	}


	// GET: Propietario/Edit/5
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

	// POST: Propietario/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	//public ActionResult Edit(int id, IFormCollection collection)
	public ActionResult Edit(int id, Propietario entidad)
	{
		// Si en lugar de IFormCollection ponemos Propietario, el enlace de datos lo hace el sistema
		Propietario? p = null;
		try
		{
			p = repositorio.ObtenerPorId(id);
			////////////////////////////////////////
			p.Nombre = entidad.Nombre;
			p.Apellido = entidad.Apellido;
			p.Dni = entidad.Dni;
			p.Email = entidad.Email;
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

	// GET: Propietario/Buscar/5
	[Route("[controller]/Buscar/{q}", Name = "Buscar")]
	public IActionResult Buscar(string q)
	{
		try
		{
			var res = repositorio.BuscarPorNombre(q);
			return Json(new { Datos = res });
		}
		catch (Exception ex)
		{
			return Json(new { Error = ex.Message });
		}
	}

	// GET: Propietario/Create
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
	// POST: Propietario/Create
	[HttpPost]
	//[ValidateAntiForgeryToken]
	public ActionResult Create(Propietario propietario)
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
				repositorio.Alta(propietario);
				TempData["Id"] = propietario.Id_Propietario;
				TempData["creado"] = "Si";
				return RedirectToAction(nameof(Index));
			}
			else
				return View(propietario);
		}
		catch (Exception ex)
		{//poner breakpoints para detectar errores
			
			throw  ;
		}
	}

	// GET: Propietario/Delete/5
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

	// POST: Propietario/Delete/5
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


