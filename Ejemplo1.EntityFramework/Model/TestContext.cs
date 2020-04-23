namespace Ejemplo1.EntityFramework.Model
{
    using System.Data.Entity;

    public partial class TestContext : DbContext
    {
        public TestContext()
            : base("name=TestContext")
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Alumno>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Alumno>()
                .Property(e => e.FechaNacimiento)
                .IsUnicode(false);
        }
    }
}
