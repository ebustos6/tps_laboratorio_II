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
            //DateTime aux = new DateTime(FrmCalendario.Anio, FrmCalendario.Mes,this.dia);
            //MessageBox.Show($"{((int)aux.DayOfWeek)} = {(int)Entidades.IDias.Martes}");
            FrmListarMedicos m = new FrmListarMedicos(this.dia);
            m.Show();
            this.Close();
        }
    }
}
