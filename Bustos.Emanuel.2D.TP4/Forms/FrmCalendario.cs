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

        /// <summary>
        /// Devuelve el mes guardado en este form.
        /// </summary>
        public static int Mes
        {
            get { return mes; }
        }

        /// <summary>
        /// Devuelve el año guardado en este form.
        /// </summary>
        public static int Anio
        {
            get { return anio; }
        }

        /// <summary>
        /// Llama al FrmMenuPrincipal y cierra este.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipal menu = new FrmMenuPrincipal();
            menu.Show();
            this.Close();
        }

        /// <summary>
        /// Cambia aspectos esteticos de este form y llama al metodo MostrarDias.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCalendario_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.lblMes.ForeColor = Color.White;
            this.lblDomingo.ForeColor = Color.White;
            this.lblLunes.ForeColor = Color.White;
            this.lblMartes.ForeColor = Color.White;
            this.lblMiercoles.ForeColor = Color.White;
            this.lblJueves.ForeColor = Color.White;
            this.lblViernes.ForeColor = Color.White;
            this.lblSabado.ForeColor = Color.White;
            this.MostrarDias();
        }

        /// <summary>
        /// Crea el calendario del form.
        /// </summary>
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

        /// <summary>
        /// Modifica el mes guardado en este form.
        /// </summary>
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

        /// <summary>
        /// Modifica el form para que muestre el mes siguiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            flpDias.Controls.Clear();
            this.MesSiguiente();
            this.MostrarDias();
        }

        /// <summary>
        /// Modifica el mes guardado en este form.
        /// </summary>
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

        /// <summary>
        /// Modifica el form para que muestre el mes anterior.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            flpDias.Controls.Clear();
            this.MesAnterior(); 
            this.MostrarDias();
        }
    }
}
