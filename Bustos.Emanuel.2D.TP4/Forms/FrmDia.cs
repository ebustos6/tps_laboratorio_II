using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class FrmDia : Form
    {
        private int dia;
        public FrmDia(int dia)
        {
            InitializeComponent();
            this.dia = dia;
        }

        /// <summary>
        /// Cierra el form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Cambia el color del form y su titulo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDia_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.Text = $"{this.dia}/{FrmCalendario.Mes}/{FrmCalendario.Anio}";
        }

        /// <summary>
        /// Llama a un form con una lista de medicos y cierra este form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerMedicos_Click(object sender, EventArgs e)
        {
            FrmListar m = new FrmListar(this.dia, 1);
            m.Show();
            this.Close();
        }

        /// <summary>
        /// Llama al form FrmAltaTurno y cierra este form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgendar_Click(object sender, EventArgs e)
        {
            FrmAltaTurno t = new FrmAltaTurno(this.dia);
            t.Show();
            this.Close();
        }

        /// <summary>
        /// Llama a un form con una lista de turnos del dia de hoy y cierra este form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerTurnos_Click(object sender, EventArgs e)
        {
            FrmListar t = new FrmListar(this.dia, 2);
            t.Show();
            this.Close();
        }
    }
}
