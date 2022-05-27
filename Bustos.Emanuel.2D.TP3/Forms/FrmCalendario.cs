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
        private int mes;
        private int anio;
        public FrmCalendario()
        {
            InitializeComponent();
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
            this.mes = DateTime.Now.Month;
            this.anio = DateTime.Now.Year;
            this.lblMes.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(this.mes) + $" {this.anio}";
            int dia = Convert.ToInt32(new DateTime(this.anio,this.mes,1).DayOfWeek.ToString("d")) + 1;
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

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

            flpDias.Controls.Clear();   
            if (this.mes == 12)
            {
                this.mes = 1;
                this.anio++;
            }
            else
            {
                this.mes++;
            }
            this.lblMes.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(this.mes) + $" {this.anio}";
            int dia = Convert.ToInt32(new DateTime(this.anio, this.mes, 1).DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < dia; i++)
            {
                UscBlanco ub = new UscBlanco();
                flpDias.Controls.Add(ub);

            }
            for (int i = 1; i <= DateTime.DaysInMonth(anio, mes); i++)
            {
                UscDia uc = new UscDia();
                uc.AsignarDia(i);
                flpDias.Controls.Add(uc);
            }
        }
    }
}
