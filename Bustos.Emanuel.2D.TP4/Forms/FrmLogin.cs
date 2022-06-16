﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Entidades;

namespace Forms
{
    public partial class FrmLogin : Form,ILimpiar
    {
        private SoundPlayer ok;
        private SoundPlayer no;
        public FrmLogin()
        {
            InitializeComponent();
            this.ok = new SoundPlayer(Properties.Resources.audioZugZug);
            this.no = new SoundPlayer(Properties.Resources.audioError);
        }

        /// <summary>
        /// vacia txtUsuario y txtPass.
        /// </summary>
        public void Limpiar()
        {
            this.txtUsuario.Text = string.Empty;
            this.txtPass.Text = string.Empty;
        }

        /// <summary>
        /// cierra la aplicacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// levanta los datos de los TextBoxs, si son validos loggea al usuario y llama a un nuevo FrmMainMenu, lo muestra y oculta este form,
        /// caso contrario informa al usuario y limpia el form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Consultorio.LoggearUsuario(this.txtUsuario.Text.Trim(), this.txtPass.Text.Trim()))
                {

                    this.ok.Play();
                    FrmMenuPrincipal menu = new FrmMenuPrincipal();
                    menu.Show();
                    this.Hide();

                }
                else
                {
                    this.no.Play();
                    MessageBox.Show("El usuario con el que intenta ingresar no existe.", "Ingresar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Limpiar();
                }
            }
            catch (Exception ex)
            {
                this.no.Play();
                this.Limpiar();
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            this.txtUsuario.Text = "Ema";
            this.txtPass.Text = "123";
        }
    }
}
