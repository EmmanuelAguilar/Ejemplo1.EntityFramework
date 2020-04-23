namespace Ejemplo1.EntityFramework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    [Table("Alumno")]
    public partial class Alumno
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        public int Sexo { get; set; }

        [Required]
        [StringLength(10)]
        public string FechaNacimiento { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Alumno> listar()
        {
            var alumnos = new List<Alumno>();
            try
            {
                using (var contexto = new TestContext())
                {
                    alumnos = contexto.Alumno.ToList();
                }
            }
            catch(Exception)
            {
                throw;
            }
            return alumnos;
        }

        public void guardar(Alumno oAlumno)
        {
            var alumnos = new List<Alumno>();
            try
            {
                using (var contexto = new TestContext())
                {
                    if (oAlumno.id > 0)
                    {
                        //Existe el alumno, actualizar registro
                        contexto.Entry(oAlumno).State = EntityState.Modified;
                    }
                    else
                    {
                        //No existe, Guardar nuevo registro
                        contexto.Entry(oAlumno).State = EntityState.Added;
                    }
                    contexto.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void eliminar(int id)
        {
            var alumnos = new List<Alumno>();
            try
            {
                using (var contexto = new TestContext())
                {
                    contexto.Entry(new Alumno { id = id }).State = EntityState.Deleted;
                    contexto.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public  Alumno obtener(int id)
        {
            var alumno = new Alumno();
            try
            {
                using (var contexto = new TestContext())
                {
                    alumno = contexto.Alumno.Where(x => x.id == id).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return alumno;
        }
    }
}
