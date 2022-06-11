﻿using System;
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
    public partial class FrmAltaMedico : Form
    {
        public FrmAltaMedico()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtMatricula.Text = string.Empty;
            for (int i = 0; i < clbDiasDisponibles.Items.Count; i++)
            {
                clbDiasDisponibles.SetItemChecked(i, false);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmABM c = new FrmABM(true);
            c.Show();
            this.Close();
        }

        private void FrmAltaMedico_Load(object sender, EventArgs e)
        {
            this.clbDiasDisponibles.Items.AddRange(new[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado" });
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtMatricula.Text, out int matricula))
            {
                if (ListarDiasDisponibles() is not null)
                {
                    if (Consultorio.CrearMedico(this.txtNombre.Text, matricula, ListarDiasDisponibles()))
                    {
                        MessageBox.Show("Medico ingresado exitosamente.", "Alta Medico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("El nombre ingresado es invalido o la matricula ingresada ya existe.", "Alta Medico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese por lo menos un dia disponible.", "Alta Medico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un numero de matricula valido.", "Alta Medico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private List<IDias> ListarDiasDisponibles()
        {
            List<IDias> diasDisponibles = new List<IDias>();
            for (int i = 0; i < clbDiasDisponibles.Items.Count; i++)
            {
                if (clbDiasDisponibles.GetItemChecked(i))
                {
                    diasDisponibles.Add((IDias)i + 1);
                }
            }
            return diasDisponibles;
        }
    }
}
