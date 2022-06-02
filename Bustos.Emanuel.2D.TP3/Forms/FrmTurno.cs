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
    public partial class FrmTurno : Form
    {
        private int dia;
        public FrmTurno(int dia)
        {
            InitializeComponent();
            this.dia = dia; 
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmDia dia = new FrmDia(this.dia);
            dia.Show();
            this.Close();
        }

        private void FrmTurno_Load(object sender, EventArgs e)
        {
            this.CargarDatos();
            this.lbxHorarios.Enabled = false;
        }

        private void CargarDatos()
        {
            DateTime aux = new DateTime(FrmCalendario.Anio, FrmCalendario.Mes, this.dia);
            this.Text = $"Crear Turno para el dia {aux.Day}/{aux.Month}/{aux.Year}";
            this.dgvListaPacientes.DataSource = Consultorio.Pacientes;
            this.dgvListadoMedicos.DataSource = Consultorio.ListarMedicosPorDia((int)aux.DayOfWeek);
            this.lbxHorarios.DataSource = Consultorio.Horarios;
        }
    }
}
