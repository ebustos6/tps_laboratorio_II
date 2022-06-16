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
    public partial class FrmListar : Form,ICargarDataGrid
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
            if (this.tipoLista == 3 || this.tipoLista == 5)
            {
                FrmABM p = new FrmABM(false);
                p.Show();
                this.Close();
            }
            else if (this.tipoLista == 4)
            {
                FrmABM m = new FrmABM(true);
                m.Show();
                this.Close();
            }
            else
            {
                FrmDia dia = new FrmDia(this.dia);
                dia.Show();
                this.Close();
            }
            
        }

        private void FrmListar_Load(object sender, EventArgs e)
        {
            this.btnAdicional.Enabled = false;
            this.btnAdicional.Hide();
            this.CargarDatos();
        }

        public void CargarDatos()
        {
            
            switch (this.tipoLista)
            {
                case 1:
                    DateTime aux = new DateTime(FrmCalendario.Anio, FrmCalendario.Mes, this.dia);
                    this.Text = $"Medicos disponibles para el {aux.Day}/{aux.Month}/{aux.Year}";
                    this.dgvListado.DataSource = Consultorio.ListarMedicosPorDia((int)aux.DayOfWeek);
                    break;

                case 2:
                    DateTime aux2 = new DateTime(FrmCalendario.Anio, FrmCalendario.Mes, this.dia);
                    this.btnAdicional.Text = "Descargar Certificado";
                    this.btnAdicional.Enabled = true;
                    this.btnAdicional.Show();
                    this.Text = $"Turnos {aux2.Day}/{aux2.Month}/{aux2.Year}";
                    this.dgvListado.DataSource = Consultorio.ListarTurnosPorFecha(aux2);
                    this.ModificarDataGrid(1);
                    break;

                case 3:
                    this.btnAdicional.Text = "Ver Historial de Turnos";
                    this.btnAdicional.Enabled = true;
                    this.btnAdicional.Show();
                    this.Text = "Pacientes";
                    this.dgvListado.DataSource = Consultorio.Pacientes;
                    break;

                case 4:
                    this.Text = "Medicos";
                    this.dgvListado.DataSource = Consultorio.Medicos;
                    break;

                default:
                    break;
            }
            
        }

        private void btnAdicional_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tipoLista == 2)
                {
                    if (this.dgvListado.SelectedRows.Count > 0)
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
                    else
                    {
                        MessageBox.Show("No hay ningun certificado seleccionado.");
                    }

                }
                else if (this.tipoLista == 3)
                {
                    int os = (int)this.dgvListado.SelectedRows[0].Cells[2].Value;
                    Paciente paciente = Consultorio.BuscarPacientePorOS(os);
                    this.Text = $"Turnos del Paciente {paciente.Nombre} {paciente.Apellido}";
                    this.dgvListado.DataSource = Consultorio.ListarTurnosPorPaciente(os);
                    this.dgvListado.Refresh();
                    this.ModificarDataGrid(2);
                    this.btnAdicional.Text = "Descargar Certificado";
                    this.tipoLista = 5;

                }
                else if (this.tipoLista == 5)
                {
                    if (this.dgvListado.SelectedRows.Count > 0)
                    {
                        int paciente = (int)this.dgvListado.SelectedRows[0].Cells[2].Value;
                        int medico = (int)this.dgvListado.SelectedRows[0].Cells[1].Value;
                        DateTime fecha = (DateTime)this.dgvListado.SelectedRows[0].Cells[3].Value;
                        string horario = (string)this.dgvListado.SelectedRows[0].Cells[4].Value;

                        if (Consultorio.BuscarPacientePorOS(paciente) is not null && Consultorio.BuscarMedicoPorMatricula(medico) is not null)
                        {
                            Certificado.Escribir(Consultorio.BuscarPacientePorOS(paciente), Consultorio.BuscarMedicoPorMatricula(medico), fecha, horario);
                            MessageBox.Show("El certificado ha sido emitido con exito.");
                        }
                        else
                        {
                            MessageBox.Show("Error.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay ningun certificado seleccionado.");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void ModificarDataGrid(int opcion)
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[1].Visible = false;
            this.dgvListado.Columns[2].Visible = false;

            dgvListado.Columns.Add("Nombre_Medico", "Nombre Medico");
            dgvListado.Columns.Add("Nombre_Paciente", "Nombre Paciente");

            for (int i = 0; i < dgvListado.RowCount; i++)
            {
                Medico medico = Consultorio.BuscarMedicoPorMatricula((int)dgvListado.Rows[i].Cells[1].Value);
                Paciente paciente = Consultorio.BuscarPacientePorOS((int)dgvListado.Rows[i].Cells[2].Value);
                dgvListado.Rows[i].Cells["Nombre_Medico"].Value = medico.ToString();
                dgvListado.Rows[i].Cells["Nombre_Paciente"].Value = $"{paciente.Apellido} {paciente.Nombre}";

            }

            if (opcion == 1)
            {
                this.dgvListado.Columns[3].Visible = false;
            }
            else
            {
                this.dgvListado.Columns["Nombre_Paciente"].Visible = false;
            }

            this.dgvListado.Refresh();
        }
    }
}
