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
            this.CargarDataGrid(this.tipoLista);
        }

        private void CargarDataGrid(int tipoLista)
        {
            switch (tipoLista)
            {
                case 1:
                    this.Text = $"Medicos disponibles para el {this.dia}/{FrmCalendario.Mes}/{FrmCalendario.Anio}";
                    DateTime aux = new DateTime(FrmCalendario.Anio, FrmCalendario.Mes, this.dia);
                    this.dgvListado.DataSource = Consultorio.ListarMedicosPorDia((int)aux.DayOfWeek);
                    break;

                case 2:
                    this.Text = "Turnos";
                    //listar turnos
                    break;

                case 3:
                    this.Text = "Pacientes";
                    this.dgvListado.DataSource = Consultorio.Pacientes;
                    break;

                default:
                    break;
            }
            
        }
    }
}
