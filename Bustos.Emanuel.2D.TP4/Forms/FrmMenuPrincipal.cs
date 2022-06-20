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
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cierra la aplicacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Instancia un FrmCalendario y cierra este form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalendario_Click(object sender, EventArgs e)
        {
            FrmCalendario c = new FrmCalendario();
            c.Show();
            this.Close();
        }

        /// <summary>
        /// Instancia un FrmAMB para medicos y cierra este form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMedicos_Click(object sender, EventArgs e)
        {
            FrmABM a = new FrmABM(true);
            a.Show();
            this.Close();
        }

        /// <summary>
        /// Instancia un FrmAMB para pacientes y cierra este form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPacientes_Click(object sender, EventArgs e)
        {
            FrmABM a = new FrmABM(false);
            a.Show();
            this.Close();
        }

        /// <summary>
        /// Modifica el lbl de ultimoPaciente.
        /// </summary>
        /// <param name="actualizacion"></param>
        public void RecibirActualizacion(string actualizacion)
        {
            this.lblUltimoPaciente.Text = $"Ultimo paciente ingresado: {actualizacion}";
        }

        /// <summary>
        /// Modifica la apariencia del form y asocia el metodo RecibirActualizacion al evento PacienteActualizado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.lblUltimoPaciente.ForeColor = Color.White;
            this.BackColor = Color.Black;
            Consultorio.PacienteActualizado += this.RecibirActualizacion;
            Consultorio.EnviarActualizacionPaciente();
        }


    }
}
