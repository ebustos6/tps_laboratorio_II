namespace Forms
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCalendario = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnMedicos = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.lblUltimoPaciente = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCalendario
            // 
            this.btnCalendario.Location = new System.Drawing.Point(38, 74);
            this.btnCalendario.Name = "btnCalendario";
            this.btnCalendario.Size = new System.Drawing.Size(394, 92);
            this.btnCalendario.TabIndex = 0;
            this.btnCalendario.Text = "Agenda";
            this.btnCalendario.UseVisualStyleBackColor = true;
            this.btnCalendario.Click += new System.EventHandler(this.btnCalendario_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(38, 464);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(394, 92);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnMedicos
            // 
            this.btnMedicos.Location = new System.Drawing.Point(38, 204);
            this.btnMedicos.Name = "btnMedicos";
            this.btnMedicos.Size = new System.Drawing.Size(394, 92);
            this.btnMedicos.TabIndex = 2;
            this.btnMedicos.Text = "Medicos";
            this.btnMedicos.UseVisualStyleBackColor = true;
            this.btnMedicos.Click += new System.EventHandler(this.btnMedicos_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.Location = new System.Drawing.Point(38, 334);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(394, 92);
            this.btnPacientes.TabIndex = 3;
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // lblUltimoPaciente
            // 
            this.lblUltimoPaciente.AutoSize = true;
            this.lblUltimoPaciente.Location = new System.Drawing.Point(38, 19);
            this.lblUltimoPaciente.Name = "lblUltimoPaciente";
            this.lblUltimoPaciente.Size = new System.Drawing.Size(134, 25);
            this.lblUltimoPaciente.TabIndex = 4;
            this.lblUltimoPaciente.Text = "Ultimo Paciente";
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 568);
            this.ControlBox = false;
            this.Controls.Add(this.lblUltimoPaciente);
            this.Controls.Add(this.btnPacientes);
            this.Controls.Add(this.btnMedicos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCalendario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenuPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalendario;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnMedicos;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Label lblUltimoPaciente;
    }
}