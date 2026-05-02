using Tarea3_GestionEmpleados__C4F794_.Models;

namespace Tarea3_GestionEmpleados__C4F794_.Repositories
{
    public interface IEmpleadoRepository
    {
        List<Empleado> ObtenerTodos();
        Empleado ObtenerPorId(int id);
        List<Empleado> BuscarPorNombreODepartamento(string termino);
        List<Empleado> ObtenerPaginado(int pagina, int tamano, string? busqueda);
        int ContarTotal(string? busqueda);
        void Agregar(Empleado empleado);
        void Actualizar(Empleado empleado);
    }
}
