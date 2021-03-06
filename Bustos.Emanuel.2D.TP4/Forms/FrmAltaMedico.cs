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
    public partial class FrmAltaMedico : Form,ILimpiar
    {
        public FrmAltaMedico()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Vacia los campos del form.
        /// </summary>
        public void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtMatricula.Text = string.Empty;
            for (int i = 0; i < clbDiasDisponibles.Items.Count; i++)
            {
                clbDiasDisponibles.SetItemChecked(i, false);
            }
        }

        /// <summary>
        /// Invoca al formulario anterior y cierra este.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmABM c = new FrmABM(true);
            c.Show();
            this.Close();
        }

        /// <summary>
        /// Modifica aspectos esteticos del form y carga el checkedlistbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAltaMedico_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.lblDiasDisponibles.ForeColor = Color.White;
            this.lblMatricula.ForeColor = Color.White;
            this.lblNombre.ForeColor = Color.White;
            this.clbDiasDisponibles.BackColor = this.BackColor;
            this.clbDiasDisponibles.ForeColor = Color.White;
            this.clbDiasDisponibles.Items.AddRange(new[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado" });
        }

        /// <summary>
        /// Valida los datos ingresados, crea una medico y limpia el form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(this.txtMatricula.Text, out int matricula))
                {
                    if (Consultorio.CrearMedico(this.txtNombre.Text, matricula, ListarDiasDisponibles()))
                    {
                        MessageBox.Show("Medico ingresado exitosamente.", "Alta Medico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("El nombre ingresado es invalido o la matricula ingresada ya existe.", "Alta Medico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Limpiar();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un numero de matricula valido.", "Alta Medico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        /// Devuelve una lista con los dias seleccionados en el checkedlistbox.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private List<Dias> ListarDiasDisponibles()
        {
            List<Dias> diasDisponibles = new List<Dias>();
            for (int i = 0; i < clbDiasDisponibles.Items.Count; i++)
            {
                if (clbDiasDisponibles.GetItemChecked(i))
                {
                    diasDisponibles.Add((Dias)i + 1);
                }
            }
            if (diasDisponibles is null || diasDisponibles.Count <= 0)
            {
                throw new Exception("Ingrese por lo menos un dia disponible.");
            }
            return diasDisponibles;
        }
    }
}
