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
    public partial class UscDia : UserControl
    {
        public UscDia()
        {
            InitializeComponent();
        }

        private void UscDia_Load(object sender, EventArgs e)
        {

        }

        public void AsignarDia(int dia)
        {
            lblDias.Text = dia.ToString();
        }
    }
}
