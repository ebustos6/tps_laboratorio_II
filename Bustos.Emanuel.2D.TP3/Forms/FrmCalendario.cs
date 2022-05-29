using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class FrmCalendario : Form
    {
        private static int mes;
        private static int anio;

        public FrmCalendario()
        {
            InitializeComponent();
            mes = DateTime.Now.Month;
            anio = DateTime.Now.Year;
        }

        public static int Mes
        {
            get { return mes; }
        }

        public static int Anio
        {
            get { return anio; }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipal menu = new FrmMenuPrincipal();
            menu.Show();
            this.Close();
        }

        private void FrmCalendario_Load(object sender, EventArgs e)
        {
            this.MostrarDias();
        }

        private void MostrarDias()
        {
            this.lblMes.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(mes) + $" {anio}";
            int dia = Convert.ToInt32(new DateTime(anio,mes,1).DayOfWeek.ToString("d")) + 1;
            for(int i = 1; i < dia; i++)
            {
                UscBlanco ub = new UscBlanco();
                flpDias.Controls.Add(ub);

            }
            for(int i = 1; i <= DateTime.DaysInMonth(anio,mes); i++)
            {
                UscDia uc = new UscDia();
                uc.AsignarDia(i);
                flpDias.Controls.Add(uc);
            }    

        }

        private void MesSiguiente()
        {
            if (mes == 12)
            {
                mes = 1;
                anio++;
            }
            else
            {
                mes++;
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            flpDias.Controls.Clear();
            this.MesSiguiente();
            this.MostrarDias();
        }

        private void MesAnterior()
        {
            if (mes == 1)
            {
                mes = 12;
                anio--;
            }
            else
            {
                mes--;
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            flpDias.Controls.Clear();
            this.MesAnterior(); 
            this.MostrarDias();
        }
    }
}
