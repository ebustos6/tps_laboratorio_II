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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            FrmCalendario c = new FrmCalendario();
            c.Show();
            this.Close();
        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            FrmABM a = new FrmABM(true);
            a.Show();
            this.Close();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            FrmABM a = new FrmABM(false);
            a.Show();
            this.Close();
        }

        public void RecibirActualizacion(string actualizacion)
        {
            this.lblUltimoPaciente.Text =$"Ultimo paciente ingresado: {actualizacion}";
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.lblUltimoPaciente.ForeColor = Color.White;
            this.BackColor = Color.Black;
            Consultorio.PacienteActualizado += this.RecibirActualizacion;
            Consultorio.EnviarActualizacionPaciente();
        }


    }
}
