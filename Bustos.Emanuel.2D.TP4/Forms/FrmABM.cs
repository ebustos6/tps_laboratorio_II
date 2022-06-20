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
    public partial class FrmABM : Form
    {
        private bool esMedico;
        public FrmABM(bool esMedico)
        {
            InitializeComponent();
            this.esMedico = esMedico;
        }

        /// <summary>
        /// Invoca a un menu principal y cierra este form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipal m = new FrmMenuPrincipal();
            m.Show();
            this.Close();
        }

        /// <summary>
        /// Instancia un formulario listar dependiendo bool ingresado al crear este form, luego cierre el form activo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListar_Click(object sender, EventArgs e)
        {
            if (esMedico)
            {
                FrmListar l = new FrmListar(6, 4);
                l.Show();
                this.Close();
            }
            else
            {
                FrmListar l = new FrmListar(6, 3);
                l.Show();
                this.Close();
            }
        }

        /// <summary>
        /// Modifica el aspecto de este form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmABM_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            if (esMedico)
            {
                this.Text = "Medicos";
            }
            else
            {
                this.Text = "Pacientes";
            }
        }

        /// <summary>
        /// Dependiendo el bool ingresado al crear este form, llama a un formulario crear y cierra este.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (esMedico)
            {
                FrmAltaMedico m = new FrmAltaMedico();
                m.Show();
                this.Close();
            }
            else
            {
                FrmAltaPaciente p = new FrmAltaPaciente();
                p.Show();
                this.Close();
            }
        }
    }
}
