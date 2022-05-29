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
    public partial class FrmListarMedicos : Form
    {
        private int dia;
        public FrmListarMedicos(int dia)
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

        private void FrmListarMedicos_Load(object sender, EventArgs e)
        {
            this.CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            DateTime aux = new DateTime(FrmCalendario.Anio, FrmCalendario.Mes,this.dia);
            this.dgvMedicos.DataSource = Consultorio.ListarMedicosPorDia((int)aux.DayOfWeek);
        }
    }
}
