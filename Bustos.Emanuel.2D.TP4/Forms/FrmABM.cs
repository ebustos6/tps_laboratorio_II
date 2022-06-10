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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipal m = new FrmMenuPrincipal();
            m.Show();
            this.Close();
        }

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

        private void FrmABM_Load(object sender, EventArgs e)
        {
            if (esMedico)
            {
                this.Text = "Medicos";
            }
            else
            {
                this.Text = "Pacientes";
            }
        }
    }
}
