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
    public partial class FrmListar : Form
    {
        private int dia;
        private int tipoLista;
        public FrmListar(int dia, int tipoLista)
        {
            InitializeComponent();
            this.dia = dia;
            this.tipoLista = tipoLista;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmDia dia = new FrmDia(this.dia);
            dia.Show();
            this.Close();
        }

        private void FrmListar_Load(object sender, EventArgs e)
        {
            this.btnCertificado.Enabled = false;
            this.btnCertificado.Hide();
            this.CargarDataGrid(this.tipoLista);
        }

        private void CargarDataGrid(int tipoLista)
        {
            DateTime aux = new DateTime(FrmCalendario.Anio, FrmCalendario.Mes, this.dia);
            switch (tipoLista)
            {
                case 1:
                    this.Text = $"Medicos disponibles para el {aux.Day}/{aux.Month}/{aux.Year}";
                    this.dgvListado.DataSource = Consultorio.ListarMedicosPorDia((int)aux.DayOfWeek);
                    break;

                case 2:
                    //ver la forma de mostrar los nombres del medico y del paciente
                    this.btnCertificado.Enabled = true;
                    this.btnCertificado.Show();
                    this.Text = $"Turnos {aux.Day}/{aux.Month}/{aux.Year}";
                    this.dgvListado.DataSource = Consultorio.ListarTurnosPorFecha(aux);
                    this.dgvListado.Columns[0].Visible = false;
                    this.dgvListado.Columns[3].Visible = false;
                    break;

                case 3:
                    this.Text = "Pacientes";
                    this.dgvListado.DataSource = Consultorio.Pacientes;
                    break;

                default:
                    break;
            }
            
        }

        private void btnCertificado_Click(object sender, EventArgs e)
        {
            int paciente = (int)this.dgvListado.SelectedRows[0].Cells[2].Value;
            int medico = (int)this.dgvListado.SelectedRows[0].Cells[1].Value;
            DateTime aux = new DateTime(FrmCalendario.Anio, FrmCalendario.Mes, this.dia);
            string horario = (string)this.dgvListado.SelectedRows[0].Cells[4].Value;

            if (Consultorio.BuscarPacientePorOS(paciente) is not null && Consultorio.BuscarMedicoPorMatricula(medico) is not null)
            {
                Certificado.Escribir(Consultorio.BuscarPacientePorOS(paciente), Consultorio.BuscarMedicoPorMatricula(medico), aux, horario);
                MessageBox.Show("El certificado ha sido emitido con exito.");
            }
            else
            {
                MessageBox.Show("Error.");
            }
        }
    }
}
