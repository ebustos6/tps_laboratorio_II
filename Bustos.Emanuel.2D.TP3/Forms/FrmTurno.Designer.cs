namespace Forms
{
    partial class FrmTurno
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
            this.dgvListaPacientes = new System.Windows.Forms.DataGridView();
            this.dgvListadoMedicos = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblPacientes = new System.Windows.Forms.Label();
            this.lblMedicos = new System.Windows.Forms.Label();
            this.lblHorario = new System.Windows.Forms.Label();
            this.lbxHorarios = new System.Windows.Forms.ListBox();
            this.btnSeleccionarMedico = new System.Windows.Forms.Button();
            this.btnCrearTurno = new System.Windows.Forms.Button();
            this.btnCambiarMedico = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoMedicos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaPacientes
            // 
            this.dgvListaPacientes.AllowUserToAddRows = false;
            this.dgvListaPacientes.AllowUserToDeleteRows = false;
            this.dgvListaPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaPacientes.Location = new System.Drawing.Point(12, 40);
            this.dgvListaPacientes.MultiSelect = false;
            this.dgvListaPacientes.Name = "dgvListaPacientes";
            this.dgvListaPacientes.ReadOnly = true;
            this.dgvListaPacientes.RowHeadersWidth = 62;
            this.dgvListaPacientes.RowTemplate.Height = 33;
            this.dgvListaPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaPacientes.Size = new System.Drawing.Size(580, 204);
            this.dgvListaPacientes.TabIndex = 1;
            // 
            // dgvListadoMedicos
            // 
            this.dgvListadoMedicos.AllowUserToAddRows = false;
            this.dgvListadoMedicos.AllowUserToDeleteRows = false;
            this.dgvListadoMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoMedicos.Location = new System.Drawing.Point(12, 301);
            this.dgvListadoMedicos.MultiSelect = false;
            this.dgvListadoMedicos.Name = "dgvListadoMedicos";
            this.dgvListadoMedicos.ReadOnly = true;
            this.dgvListadoMedicos.RowHeadersWidth = 62;
            this.dgvListadoMedicos.RowTemplate.Height = 33;
            this.dgvListadoMedicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoMedicos.Size = new System.Drawing.Size(580, 204);
            this.dgvListadoMedicos.TabIndex = 2;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(637, 540);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(203, 64);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblPacientes
            // 
            this.lblPacientes.AutoSize = true;
            this.lblPacientes.Location = new System.Drawing.Point(12, 9);
            this.lblPacientes.Name = "lblPacientes";
            this.lblPacientes.Size = new System.Drawing.Size(84, 25);
            this.lblPacientes.TabIndex = 4;
            this.lblPacientes.Text = "Pacientes";
            // 
            // lblMedicos
            // 
            this.lblMedicos.AutoSize = true;
            this.lblMedicos.Location = new System.Drawing.Point(12, 273);
            this.lblMedicos.Name = "lblMedicos";
            this.lblMedicos.Size = new System.Drawing.Size(177, 25);
            this.lblMedicos.TabIndex = 5;
            this.lblMedicos.Text = "Medicos Disponibles";
            // 
            // lblHorario
            // 
            this.lblHorario.AutoSize = true;
            this.lblHorario.Location = new System.Drawing.Point(637, 9);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(178, 25);
            this.lblHorario.TabIndex = 6;
            this.lblHorario.Text = "Horarios Disponibles";
            // 
            // lbxHorarios
            // 
            this.lbxHorarios.FormattingEnabled = true;
            this.lbxHorarios.ItemHeight = 25;
            this.lbxHorarios.Location = new System.Drawing.Point(641, 40);
            this.lbxHorarios.Name = "lbxHorarios";
            this.lbxHorarios.Size = new System.Drawing.Size(85, 204);
            this.lbxHorarios.TabIndex = 7;
            // 
            // btnSeleccionarMedico
            // 
            this.btnSeleccionarMedico.Location = new System.Drawing.Point(637, 301);
            this.btnSeleccionarMedico.Name = "btnSeleccionarMedico";
            this.btnSeleccionarMedico.Size = new System.Drawing.Size(203, 64);
            this.btnSeleccionarMedico.TabIndex = 8;
            this.btnSeleccionarMedico.Text = "Seleccionar Medico";
            this.btnSeleccionarMedico.UseVisualStyleBackColor = true;
            this.btnSeleccionarMedico.Click += new System.EventHandler(this.btnSeleccionarMedico_Click);
            // 
            // btnCrearTurno
            // 
            this.btnCrearTurno.Location = new System.Drawing.Point(389, 539);
            this.btnCrearTurno.Name = "btnCrearTurno";
            this.btnCrearTurno.Size = new System.Drawing.Size(203, 64);
            this.btnCrearTurno.TabIndex = 9;
            this.btnCrearTurno.Text = "Crear Turno";
            this.btnCrearTurno.UseVisualStyleBackColor = true;
            this.btnCrearTurno.Click += new System.EventHandler(this.btnCrearTurno_Click);
            // 
            // btnCambiarMedico
            // 
            this.btnCambiarMedico.Location = new System.Drawing.Point(637, 392);
            this.btnCambiarMedico.Name = "btnCambiarMedico";
            this.btnCambiarMedico.Size = new System.Drawing.Size(203, 64);
            this.btnCambiarMedico.TabIndex = 10;
            this.btnCambiarMedico.Text = "Cambiar Medico";
            this.btnCambiarMedico.UseVisualStyleBackColor = true;
            this.btnCambiarMedico.Click += new System.EventHandler(this.btnCambiarMedico_Click);
            // 
            // FrmTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 611);
            this.ControlBox = false;
            this.Controls.Add(this.btnCambiarMedico);
            this.Controls.Add(this.btnCrearTurno);
            this.Controls.Add(this.btnSeleccionarMedico);
            this.Controls.Add(this.lbxHorarios);
            this.Controls.Add(this.lblHorario);
            this.Controls.Add(this.lblMedicos);
            this.Controls.Add(this.lblPacientes);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvListadoMedicos);
            this.Controls.Add(this.dgvListaPacientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTurno";
            this.ShowIcon = false;
            this.Text = "Crear Turno";
            this.Load += new System.EventHandler(this.FrmTurno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoMedicos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListaPacientes;
        private System.Windows.Forms.DataGridView dgvListadoMedicos;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblPacientes;
        private System.Windows.Forms.Label lblMedicos;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.ListBox lbxHorarios;
        private System.Windows.Forms.Button btnSeleccionarMedico;
        private System.Windows.Forms.Button btnCrearTurno;
        private System.Windows.Forms.Button btnCambiarMedico;
    }
}