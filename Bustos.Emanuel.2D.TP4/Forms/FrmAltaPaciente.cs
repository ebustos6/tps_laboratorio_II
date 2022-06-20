using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Forms
{
    public partial class FrmAltaPaciente : Form,ILimpiar
    {
        public FrmAltaPaciente()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Vacia los textboxes.
        /// </summary>
        public void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtObraSocial.Text = string.Empty;
        }

        /// <summary>
        /// Invoca al formulario anterior y cierre este.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmABM c = new FrmABM(false);
            c.Show();
            this.Close();

        }

        /// <summary>
        /// Valida los datos ingresados, crea un paciente y limpia el form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtObraSocial.Text, out int aux))
                {
                    if (Consultorio.CrearPaciente(txtNombre.Text, txtApellido.Text, aux))
                    {
                        MessageBox.Show("Paciente creado exitosamente.", "Alta Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("El nombre o apellido ingresado es invalido o el numero de obra social que intenta ingresar ya existe.", "Alta Paciente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Limpiar();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un numero de Obra Social valido.", "Alta Paciente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Limpiar();
            }
        }

        /// <summary>
        /// Modifica el aspecto del form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAltaPaciente_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.lblApellido.ForeColor = Color.White;
            this.lblNombre.ForeColor = Color.White;
            this.lblObraSocial.ForeColor = Color.White;
        }
    }
}
