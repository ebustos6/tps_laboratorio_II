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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// deshabilita los botones convertir a binario y convertir a decimal cuando carga el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.cmbOperador.DataSource = new char[] { ' ', '+','-','*','/'};
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// vacia los campos de las operaciones y devuelve los botones a sus estados cuando inicio la calculadora.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.cmbOperador.Text = string.Empty;
            this.txtNumero2.Clear();
            this.lblResultado.Text = string.Empty;
            this.btnOperar.Enabled = true;
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// invoca a la funcion limpiar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// cierra la calculadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// realiza la operacion aritmetica solicitada con los parametros requeridos.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando auxNumero1 = new Operando(numero1);
            Operando auxNumero2 = new Operando(numero2);
            return Calculadora.Operar(auxNumero1, auxNumero2, operador);
        }

        /// <summary>
        /// llama a la funcion operar, le envia los datos de los textboxes, coloca el resultado en label de resultado
        /// y habilita la opcion de convertir a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
            this.btnConvertirABinario.Enabled = true;
            this.btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// convierte el resultado a binario, habilita el boton de convertir a decimal y se dehabilita a si mismo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.btnConvertirADecimal.Enabled = true;
            if (!string.IsNullOrWhiteSpace(this.lblResultado.Text))
            {
                Operando resultado = new Operando();
                this.lblResultado.Text = resultado.DecimalBinario(this.lblResultado.Text);
                this.btnConvertirADecimal.Enabled = true;
                this.btnConvertirABinario.Enabled = false;
                this.btnOperar.Enabled = false;
            }
        }

        /// <summary>
        /// convierte un binario a decimal, habilita el boton de convertir a binario y se deshabilita a si mismo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.lblResultado.Text))
            {
                Operando resultado = new Operando();
                this.lblResultado.Text = resultado.BinarioDecimal(this.lblResultado.Text);
                this.btnConvertirABinario.Enabled = true;
                this.btnConvertirADecimal.Enabled = false;
                this.btnOperar.Enabled = true;
            }
        }
    }
}
