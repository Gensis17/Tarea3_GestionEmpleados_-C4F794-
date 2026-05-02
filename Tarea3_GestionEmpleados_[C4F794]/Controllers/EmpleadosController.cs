using Microsoft.AspNetCore.Mvc;
using Tarea3_GestionEmpleados__C4F794_.Models;
using Tarea3_GestionEmpleados__C4F794_.Repositories;

namespace Tarea3_GestionEmpleados__C4F794_.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoRepository _repo;

        public EmpleadosController(IEmpleadoRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(string? busqueda, int pagina = 1)
        {
            int tamano = 5;

            var empleados = _repo.ObtenerPaginado(pagina, tamano, busqueda);
            int total = _repo.ContarTotal(busqueda);

            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling((double)total / tamano);
            ViewBag.Busqueda = busqueda;
            ViewBag.Total = total;

            return View(empleados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                empleado.Activo = true;
                _repo.Agregar(empleado);
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        public IActionResult Edit(int id)
        {
            var emp = _repo.ObtenerPorId(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repo.Actualizar(empleado);
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        [HttpPost]
        public IActionResult ToggleActivo(int id)
        {
            var emp = _repo.ObtenerPorId(id);
            emp.Activo = !emp.Activo;
            _repo.Actualizar(emp);

            return RedirectToAction("Index");
        }
    }
}
