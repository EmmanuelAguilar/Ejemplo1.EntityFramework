using Ejemplo1.EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo1.EntityFramework
{
    public partial class Form2 : Form
    {
        public int id = 0;
        public Form1 form;
        private Alumno modelAlumno = new Alumno();

        public Form2(int id, Form1 frm1)
        {
            this.id = id;
            this.form = frm1;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtId.Text = this.id.ToString();

            if (this.id > 0)
            {
                //Actualizar
                var alumno = modelAlumno.obtener(id);
                txtId.Text = alumno.id.ToString();
                txtNombre.Text = alumno.Nombre;
                txtApellido.Text = alumno.Apellido;
                txtFechaNacimiento.Text = alumno.FechaNacimiento;
                if (alumno.Sexo != 0)
                {
                    rdMasculino.Checked = true;
                    rdFemenino.Checked = false;
                }
                else
                {
                    rdMasculino.Checked = false;
                    rdFemenino.Checked = true;
                }
            }
            else
            {
                lbId.Visible = false;
                txtId.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {            
                var alumno = new Alumno
                {
                    id = Convert.ToInt32(txtId.Text),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    FechaNacimiento = txtFechaNacimiento.Text,
                    Sexo = rdMasculino.Checked ? 1 : 0
                };

                modelAlumno.guardar(alumno);
                this.form.cargarAlumnos();
                this.Close();            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar este registro?", "Confirmar acción", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modelAlumno.eliminar(this.id);
                this.form.cargarAlumnos();
                this.Close();
            }
        }
    }
}
