using Tarea3_GestionEmpleados__C4F794_.Models;
using Microsoft.EntityFrameworkCore;

namespace Tarea3_GestionEmpleados__C4F794_.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Salario)
                .HasPrecision(18, 2);
        }
    }
}