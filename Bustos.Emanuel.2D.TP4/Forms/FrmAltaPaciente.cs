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
    public partial class FrmAltaPaciente : Form
    {
        public FrmAltaPaciente()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtObraSocial.Text = string.Empty;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmABM c = new FrmABM(false);
            c.Show();
            this.Close();

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtObraSocial.Text, out int aux))
            {
                if (Consultorio.CrearPaciente(txtNombre.Text, txtApellido.Text, aux))
                {
                    MessageBox.Show("Paciente creado exitosamente.", "Alta Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Limpiar();
                }
                else
                {
                    MessageBox.Show("Los datos ingresados son invalidos o el numero de obra social que intenta ingresar ya existe.", "Alta Paciente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un numero valido.","Alta Paciente",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }
    }
}
