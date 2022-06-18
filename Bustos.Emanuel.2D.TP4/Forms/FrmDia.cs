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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDia_Load(object sender, EventArgs e)
        {
            this.Text = $"{this.dia}/{FrmCalendario.Mes}/{FrmCalendario.Anio}";
        }

        private void btnVerMedicos_Click(object sender, EventArgs e)
        {
            FrmListar m = new FrmListar(this.dia, 1);
            m.Show();
            this.Close();
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            FrmAltaTurno t = new FrmAltaTurno(this.dia);
            t.Show();
            this.Close();
        }

        private void btnVerTurnos_Click(object sender, EventArgs e)
        {
            FrmListar t = new FrmListar(this.dia, 2);
            t.Show();
            this.Close();
        }
    }
}
