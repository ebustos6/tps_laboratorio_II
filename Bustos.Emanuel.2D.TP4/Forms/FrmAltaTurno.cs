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
    public partial class FrmAltaTurno : Form,ICargarDataGrid
    {
        private int dia;
        public FrmAltaTurno(int dia)
        {
            InitializeComponent();
            this.dia = dia; 
        }

        /// <summary>
        /// Invoca un FrmDia y cierra el form activo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmDia dia = new FrmDia(this.dia);
            dia.Show();
            this.Close();
        }

        /// <summary>
        /// Modifica aspectos esteticos del form y llama al metodo CargarDatos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTurno_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.lblHorario.ForeColor = Color.White;
            this.lblMedicos.ForeColor = Color.White;
            this.lblPacientes.ForeColor = Color.White;
            this.CargarDatos();
            this.lbxHorarios.Enabled = false;
            this.dgvListadoMedicos.Enabled = true;
        }

        /// <summary>
        /// Ingresa los datos en los datagrids y en el listbox.
        /// </summary>
        public void CargarDatos()
        {
            try
            {
                DateTime aux = new DateTime(FrmCalendario.Anio, FrmCalendario.Mes, this.dia);
                this.Text = $"Crear Turno para el dia {aux.Day}/{aux.Month}/{aux.Year}";
                this.dgvListaPacientes.DataSource = Consultorio.Pacientes;
                this.dgvListadoMedicos.DataSource = Consultorio.ListarMedicosPorDia((int)aux.DayOfWeek);
                this.lbxHorarios.DataSource = Consultorio.Horarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.btnVolver_Click(this, new EventArgs());
            }
            
        }

        /// <summary>
        /// Fija a un medico del datagrid y trae los horarios disponibles de este.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeleccionarMedico_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime aux = new DateTime(FrmCalendario.Anio, FrmCalendario.Mes, this.dia);
                this.lbxHorarios.DataSource = Consultorio.HorariosDisponibles(aux, (int)this.dgvListadoMedicos.SelectedRows[0].Cells[2].Value);
                this.lbxHorarios.Enabled = true;
                this.dgvListadoMedicos.Enabled = false;
                this.btnSeleccionarMedico.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.btnVolver_Click(sender, e);
            }          
        }

        /// <summary>
        /// Valida los datos ingresados y crea un turno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrearTurno_Click(object sender, EventArgs e)
        {
            if (dgvListadoMedicos.Enabled)
            {
                MessageBox.Show("Debe seleccionar un medico antes de crear un turno", "Crear Turno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    DateTime auxFecha = new DateTime(FrmCalendario.Anio, FrmCalendario.Mes, this.dia);
                    int auxMedico = (int)this.dgvListadoMedicos.SelectedRows[0].Cells[2].Value;
                    int auxPaciente = (int)this.dgvListaPacientes.SelectedRows[0].Cells[2].Value;

                    if (Consultorio.CrearTurno(auxMedico, auxPaciente, auxFecha, this.lbxHorarios.SelectedItem.ToString()))
                    {
                        MessageBox.Show($"Se creo un turno para el dia {auxFecha.Day}/{auxFecha.Month}/{auxFecha.Year}, con el Dr. {this.dgvListadoMedicos.SelectedRows[0].Cells[1].Value}, para el Paciente {this.dgvListaPacientes.SelectedRows[0].Cells[0].Value} {this.dgvListaPacientes.SelectedRows[0].Cells[1].Value} a las {this.lbxHorarios.SelectedItem}hs.", "Crear Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.btnVolver_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    this.btnVolver_Click(sender, e);
                }
            }
        }

        /// <summary>
        /// Deselecciona al medico fijado por el boton seleccionar y devuelve el form a su estado anterior.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCambiarMedico_Click(object sender, EventArgs e)
        {
            try
            {
                this.lbxHorarios.DataSource = Consultorio.Horarios;
                this.lbxHorarios.Enabled = false;
                this.dgvListadoMedicos.Enabled = true;
                this.btnSeleccionarMedico.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.btnVolver_Click(sender, e);
            }
            
        }
    }
}
