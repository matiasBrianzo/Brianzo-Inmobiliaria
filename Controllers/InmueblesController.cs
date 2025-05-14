using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brianzo_Inmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brianzo_Inmobiliaria.Controllers;

[Authorize]
public class InmueblesController : Controller
{

    private readonly IRepositorioInmueble repoInmuble;
    private readonly IRepositorioTipo repoTipo;
    private readonly IRepositorioUso repoUso;
    private readonly IRepositorioPropietario repoPropietario;
    private readonly IConfiguration config;

    public InmueblesController(IRepositorioInmueble repo, IRepositorioTipo repTipo, IRepositorioUso repUso, IRepositorioPropietario repoPro, IConfiguration config)
    {
        this.repoInmuble = repo;
        this.repoTipo = repTipo;
        this.repoUso = repUso;
        this.repoPropietario = repoPro;
        this.config = config;
    }

    // GET: Inmuebles
    [Route("[controller]/Index")]
    public ActionResult Index()
    {
        var lista = repoInmuble.ObtenerTodos();
        return View(lista);
    }

    // GET: Inmuebles/Details/5
    public ActionResult Details(int id)
    {
        try
        {
            var lista = repoInmuble.ObtenerPorId(id);
            ViewBag.Mensaje = TempData["Mensaje"];
            return View(lista);
        }
        catch (Exception ex)
        {// Poner breakpoints para detectar errores

            throw;
        }
    }

    // GET: Inmuebles/Create
    public ActionResult Create()
    {
        ViewBag.listaPropietarios = repoPropietario.ObtenerTodos();
        ViewBag.listaTipos = repoTipo.ObtenerTodos();
        ViewBag.listaUsos = repoUso.ObtenerTodos();
        return View();
    }

    // POST: Inmuebles/Create
    [ValidateAntiForgeryToken]
    public ActionResult Create(Inmueble inmueble)
    {
        repoInmuble.Alta(inmueble);

        TempData["creado"] = "Si";

        return RedirectToAction(nameof(Index));
    }

    // GET: Inmuebles/Edit/5
    public ActionResult Edit(int id)
    {
        ViewBag.listaPropietarios = repoPropietario.ObtenerTodos();
        ViewBag.listaTipos = repoTipo.ObtenerTodos();
        ViewBag.listaUsos = repoUso.ObtenerTodos();

        var lista = repoInmuble.ObtenerPorId(id);
        ViewBag.Mensaje = TempData["Mensaje"];

        return View(lista);
    }

    // POST: Inmuebles/Edit/5

    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Inmueble inmueble)
    {
        repoInmuble.Modificacion(inmueble);
        TempData["editado"] = "Si";
        return RedirectToAction(nameof(Index));
    }

    // GET: Inmuebles/Delete/5
    [Authorize(policy: "Administrador")]
    [HttpGet]
    public ActionResult Delete(int id)
    {
        var lista = repoInmuble.ObtenerPorId(id);
        ViewBag.Mensaje = TempData["Mensaje"];

        return View(lista);
    }

    // POST: Inmuebles/Delete/5
    [Authorize(policy: "Administrador")]
[HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Inmueble inmueble)
    {
        repoInmuble.Baja(id);
        TempData["Eliminado"] = "Si";
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    public ActionResult BuscarInmuebles()
    {
        var lista = repoInmuble.ObtenerTodos();
        ViewBag.listaTipos = repoTipo.ObtenerTodos();
        ViewBag.listaUsos = repoUso.ObtenerTodos();
        ViewBag.Mensaje = TempData["Mensaje"];
        return View(lista);
    }

    [HttpPost]
    public ActionResult BuscarInmuebles(InmuebleBusqueda ib)
    {
        var lista = repoInmuble.BuscarInmuebles(ib);
        ViewBag.listaTipos = repoTipo.ObtenerTodos();
        ViewBag.listaUsos = repoUso.ObtenerTodos();
        ViewBag.Mensaje = TempData["Mensaje"];
        return View(lista);
    }


    [HttpGet]
    public ActionResult InmueblesEstados()
    {
        ViewBag.listaPropietarios = repoPropietario.ObtenerTodos();
        var lista = repoInmuble.ObtenerTodos();
        ViewBag.Mensaje = TempData["Mensaje"];
        return View(lista);
    }

    [HttpPost]
    public ActionResult InmueblesEstados(InmuebleBusqueda ib)
    {
        ViewBag.listaPropietarios = repoPropietario.ObtenerTodos();
        var lista = repoInmuble.BuscarInmueblesEstado(ib);
        return View(lista);
    }

    [HttpGet]
    public ActionResult InmueblesContratos()
    {
        var lista = repoInmuble.ObtenerTodos();
        return View(lista);
    }

    [HttpPost]

    public ActionResult InmueblesContratos(InmuebleBusqueda ib)
    {
        var lista = repoInmuble.BuscarInmuebles(ib);
        return View(lista);
    }


}
