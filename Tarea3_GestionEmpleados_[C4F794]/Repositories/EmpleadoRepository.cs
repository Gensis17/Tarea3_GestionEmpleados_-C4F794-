using Tarea3_GestionEmpleados__C4F794_.Data;
using Tarea3_GestionEmpleados__C4F794_.Models;

namespace Tarea3_GestionEmpleados__C4F794_.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly AppDbContext _context;

        public EmpleadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Empleado> ObtenerTodos()
        {
            return _context.Empleados.ToList();
        }

        public Empleado ObtenerPorId(int id)
        {
            var emp = _context.Empleados.Find(id);

            if (emp == null)
                throw new Exception("Empleado no encontrado");

            return emp;
        }

        public List<Empleado> BuscarPorNombreODepartamento(string termino)
        {
            termino = termino.ToLower();

            return _context.Empleados
                .Where(e => e.Nombre.ToLower().Contains(termino) ||
                            e.Apellidos.ToLower().Contains(termino) ||
                            e.Departamento.ToLower().Contains(termino))
                .ToList();
        }

        public List<Empleado> ObtenerPaginado(int pagina, int tamano, string? busqueda)
        {
            var query = _context.Empleados.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                busqueda = busqueda.ToLower();

                query = query.Where(e =>
                    e.Nombre.ToLower().Contains(busqueda) ||
                    e.Apellidos.ToLower().Contains(busqueda) ||
                    e.Departamento.ToLower().Contains(busqueda));
            }

            return query
                .Skip((pagina - 1) * tamano)
                .Take(tamano)
                .ToList();
        }

        public int ContarTotal(string? busqueda)
        {
            var query = _context.Empleados.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                busqueda = busqueda.ToLower();

                query = query.Where(e =>
                    e.Nombre.ToLower().Contains(busqueda) ||
                    e.Apellidos.ToLower().Contains(busqueda) ||
                    e.Departamento.ToLower().Contains(busqueda));
            }

            return query.Count();
        }

        public void Agregar(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
        }

        public void Actualizar(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            _context.SaveChanges();
        }
    }
}
