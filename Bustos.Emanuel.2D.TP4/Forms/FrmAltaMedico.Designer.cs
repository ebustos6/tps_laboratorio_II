namespace Forms
{
    partial class FrmAltaMedico
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblDiasDisponibles = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.clbDiasDisponibles = new System.Windows.Forms.CheckedListBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(313, 329);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(130, 51);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(78, 25);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre";
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Location = new System.Drawing.Point(12, 69);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(84, 25);
            this.lblMatricula.TabIndex = 7;
            this.lblMatricula.Text = "Matricula";
            // 
            // lblDiasDisponibles
            // 
            this.lblDiasDisponibles.AutoSize = true;
            this.lblDiasDisponibles.Location = new System.Drawing.Point(12, 129);
            this.lblDiasDisponibles.Name = "lblDiasDisponibles";
            this.lblDiasDisponibles.Size = new System.Drawing.Size(144, 25);
            this.lblDiasDisponibles.TabIndex = 8;
            this.lblDiasDisponibles.Text = "Dias Disponibles";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(218, 6);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(150, 31);
            this.txtNombre.TabIndex = 9;
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(218, 66);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(150, 31);
            this.txtMatricula.TabIndex = 10;
            // 
            // clbDiasDisponibles
            // 
            this.clbDiasDisponibles.CheckOnClick = true;
            this.clbDiasDisponibles.FormattingEnabled = true;
            this.clbDiasDisponibles.Location = new System.Drawing.Point(218, 129);
            this.clbDiasDisponibles.Name = "clbDiasDisponibles";
            this.clbDiasDisponibles.Size = new System.Drawing.Size(180, 172);
            this.clbDiasDisponibles.TabIndex = 11;
            this.clbDiasDisponibles.ThreeDCheckBoxes = true;
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(164, 329);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(130, 51);
            this.btnCrear.TabIndex = 12;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // FrmAltaMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 388);
            this.ControlBox = false;
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.clbDiasDisponibles);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblDiasDisponibles);
            this.Controls.Add(this.lblMatricula);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnVolver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAltaMedico";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de Medico";
            this.Load += new System.EventHandler(this.FrmAltaMedico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.Label lblDiasDisponibles;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.CheckedListBox clbDiasDisponibles;
        private System.Windows.Forms.Button btnCrear;
    }
}