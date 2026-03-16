namespace TRABAJO_FINAL
{
    partial class FormCrearTurno
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
            this.lbl_hora = new System.Windows.Forms.Label();
            this.lbl_sala = new System.Windows.Forms.Label();
            this.lbl_Dia = new System.Windows.Forms.Label();
            this.lbl_psico = new System.Windows.Forms.Label();
            this.dgvUsuariosEspera = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCrearTurno = new System.Windows.Forms.Button();
            this.cb_turnos = new System.Windows.Forms.CheckBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosEspera)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_hora
            // 
            this.lbl_hora.AutoSize = true;
            this.lbl_hora.Location = new System.Drawing.Point(37, 69);
            this.lbl_hora.Name = "lbl_hora";
            this.lbl_hora.Size = new System.Drawing.Size(55, 16);
            this.lbl_hora.TabIndex = 0;
            this.lbl_hora.Text = "lbl_hora";
            // 
            // lbl_sala
            // 
            this.lbl_sala.AutoSize = true;
            this.lbl_sala.Location = new System.Drawing.Point(37, 106);
            this.lbl_sala.Name = "lbl_sala";
            this.lbl_sala.Size = new System.Drawing.Size(54, 16);
            this.lbl_sala.TabIndex = 1;
            this.lbl_sala.Text = "lbl_sala";
            // 
            // lbl_Dia
            // 
            this.lbl_Dia.AutoSize = true;
            this.lbl_Dia.Location = new System.Drawing.Point(37, 143);
            this.lbl_Dia.Name = "lbl_Dia";
            this.lbl_Dia.Size = new System.Drawing.Size(47, 16);
            this.lbl_Dia.TabIndex = 2;
            this.lbl_Dia.Text = "lbl_dia";
            // 
            // lbl_psico
            // 
            this.lbl_psico.AutoSize = true;
            this.lbl_psico.Location = new System.Drawing.Point(37, 177);
            this.lbl_psico.Name = "lbl_psico";
            this.lbl_psico.Size = new System.Drawing.Size(88, 16);
            this.lbl_psico.TabIndex = 3;
            this.lbl_psico.Text = "lbl_psicologo";
            // 
            // dgvUsuariosEspera
            // 
            this.dgvUsuariosEspera.AllowUserToAddRows = false;
            this.dgvUsuariosEspera.AllowUserToDeleteRows = false;
            this.dgvUsuariosEspera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuariosEspera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuariosEspera.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.dgvUsuariosEspera.Location = new System.Drawing.Point(380, 35);
            this.dgvUsuariosEspera.Name = "dgvUsuariosEspera";
            this.dgvUsuariosEspera.ReadOnly = true;
            this.dgvUsuariosEspera.RowHeadersVisible = false;
            this.dgvUsuariosEspera.RowHeadersWidth = 51;
            this.dgvUsuariosEspera.RowTemplate.Height = 24;
            this.dgvUsuariosEspera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuariosEspera.Size = new System.Drawing.Size(292, 347);
            this.dgvUsuariosEspera.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "USUARIOS A LA ESPERA DE TURNO";
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(16, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(31, 32);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "x";
            this.btnExit.UseMnemonic = false;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCrearTurno
            // 
            this.btnCrearTurno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrearTurno.Location = new System.Drawing.Point(40, 338);
            this.btnCrearTurno.Name = "btnCrearTurno";
            this.btnCrearTurno.Size = new System.Drawing.Size(147, 23);
            this.btnCrearTurno.TabIndex = 7;
            this.btnCrearTurno.Text = "Confirmar Turno";
            this.btnCrearTurno.UseVisualStyleBackColor = true;
            this.btnCrearTurno.Click += new System.EventHandler(this.btnCrearTurno_Click);
            // 
            // cb_turnos
            // 
            this.cb_turnos.AutoSize = true;
            this.cb_turnos.Location = new System.Drawing.Point(40, 288);
            this.cb_turnos.Name = "cb_turnos";
            this.cb_turnos.Size = new System.Drawing.Size(154, 20);
            this.cb_turnos.TabIndex = 8;
            this.cb_turnos.Text = "CREAR 16 TURNOS";
            this.cb_turnos.UseVisualStyleBackColor = true;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(40, 237);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(303, 28);
            this.txtObservaciones.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "OBSERVACIONES";
            // 
            // FormCrearTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(741, 398);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.cb_turnos);
            this.Controls.Add(this.btnCrearTurno);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvUsuariosEspera);
            this.Controls.Add(this.lbl_psico);
            this.Controls.Add(this.lbl_Dia);
            this.Controls.Add(this.lbl_sala);
            this.Controls.Add(this.lbl_hora);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormCrearTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crear turno:";
            this.Load += new System.EventHandler(this.FormCrearTurno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosEspera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_hora;
        private System.Windows.Forms.Label lbl_sala;
        private System.Windows.Forms.Label lbl_Dia;
        private System.Windows.Forms.Label lbl_psico;
        private System.Windows.Forms.DataGridView dgvUsuariosEspera;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCrearTurno;
        private System.Windows.Forms.CheckBox cb_turnos;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label2;
    }
}