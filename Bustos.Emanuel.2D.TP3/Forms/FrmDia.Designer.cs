namespace Forms
{
    partial class FrmDia
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
            this.btnAgendar = new System.Windows.Forms.Button();
            this.btnVerTurnos = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnVerMedicos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgendar
            // 
            this.btnAgendar.Location = new System.Drawing.Point(12, 12);
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Size = new System.Drawing.Size(210, 87);
            this.btnAgendar.TabIndex = 0;
            this.btnAgendar.Text = "Agendar Turno";
            this.btnAgendar.UseVisualStyleBackColor = true;
            this.btnAgendar.Click += new System.EventHandler(this.btnAgendar_Click);
            // 
            // btnVerTurnos
            // 
            this.btnVerTurnos.Location = new System.Drawing.Point(275, 12);
            this.btnVerTurnos.Name = "btnVerTurnos";
            this.btnVerTurnos.Size = new System.Drawing.Size(210, 87);
            this.btnVerTurnos.TabIndex = 1;
            this.btnVerTurnos.Text = "Ver Turnos Agendados";
            this.btnVerTurnos.UseVisualStyleBackColor = true;
            this.btnVerTurnos.Click += new System.EventHandler(this.btnVerTurnos_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(355, 159);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(130, 51);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnVerMedicos
            // 
            this.btnVerMedicos.Location = new System.Drawing.Point(12, 123);
            this.btnVerMedicos.Name = "btnVerMedicos";
            this.btnVerMedicos.Size = new System.Drawing.Size(210, 87);
            this.btnVerMedicos.TabIndex = 3;
            this.btnVerMedicos.Text = "Ver Médicos Disponibles";
            this.btnVerMedicos.UseVisualStyleBackColor = true;
            this.btnVerMedicos.Click += new System.EventHandler(this.btnVerMedicos_Click);
            // 
            // FrmDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 232);
            this.ControlBox = false;
            this.Controls.Add(this.btnVerMedicos);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnVerTurnos);
            this.Controls.Add(this.btnAgendar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDia";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dia";
            this.Load += new System.EventHandler(this.FrmDia_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgendar;
        private System.Windows.Forms.Button btnVerTurnos;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnVerMedicos;
    }
}