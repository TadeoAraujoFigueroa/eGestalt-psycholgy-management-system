namespace TRABAJO_FINAL
{
    partial class FormEstadoTurno
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
            this.lbl_psico = new System.Windows.Forms.Label();
            this.lbl_paciente = new System.Windows.Forms.Label();
            this.lbl_fecha = new System.Windows.Forms.Label();
            this.lbl_sala = new System.Windows.Forms.Label();
            this.lbl_hora = new System.Windows.Forms.Label();
            this.rb_programado = new System.Windows.Forms.RadioButton();
            this.rb_realizado = new System.Windows.Forms.RadioButton();
            this.rb_cancelado = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbAusente = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lbl_psico
            // 
            this.lbl_psico.AutoSize = true;
            this.lbl_psico.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_psico.Location = new System.Drawing.Point(81, 106);
            this.lbl_psico.Name = "lbl_psico";
            this.lbl_psico.Size = new System.Drawing.Size(45, 20);
            this.lbl_psico.TabIndex = 0;
            this.lbl_psico.Text = "label1";
            // 
            // lbl_paciente
            // 
            this.lbl_paciente.AutoSize = true;
            this.lbl_paciente.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_paciente.Location = new System.Drawing.Point(241, 106);
            this.lbl_paciente.Name = "lbl_paciente";
            this.lbl_paciente.Size = new System.Drawing.Size(47, 20);
            this.lbl_paciente.TabIndex = 1;
            this.lbl_paciente.Text = "label2";
            // 
            // lbl_fecha
            // 
            this.lbl_fecha.AutoSize = true;
            this.lbl_fecha.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fecha.Location = new System.Drawing.Point(38, 33);
            this.lbl_fecha.Name = "lbl_fecha";
            this.lbl_fecha.Size = new System.Drawing.Size(47, 20);
            this.lbl_fecha.TabIndex = 2;
            this.lbl_fecha.Text = "label3";
            // 
            // lbl_sala
            // 
            this.lbl_sala.AutoSize = true;
            this.lbl_sala.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sala.Location = new System.Drawing.Point(408, 106);
            this.lbl_sala.Name = "lbl_sala";
            this.lbl_sala.Size = new System.Drawing.Size(49, 20);
            this.lbl_sala.TabIndex = 3;
            this.lbl_sala.Text = "label4";
            // 
            // lbl_hora
            // 
            this.lbl_hora.AutoSize = true;
            this.lbl_hora.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hora.Location = new System.Drawing.Point(557, 106);
            this.lbl_hora.Name = "lbl_hora";
            this.lbl_hora.Size = new System.Drawing.Size(47, 20);
            this.lbl_hora.TabIndex = 4;
            this.lbl_hora.Text = "label5";
            this.lbl_hora.Click += new System.EventHandler(this.lbl_hora_Click);
            // 
            // rb_programado
            // 
            this.rb_programado.AutoSize = true;
            this.rb_programado.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_programado.Location = new System.Drawing.Point(107, 337);
            this.rb_programado.Name = "rb_programado";
            this.rb_programado.Size = new System.Drawing.Size(112, 24);
            this.rb_programado.TabIndex = 5;
            this.rb_programado.TabStop = true;
            this.rb_programado.Text = "Programado";
            this.rb_programado.UseVisualStyleBackColor = true;
            // 
            // rb_realizado
            // 
            this.rb_realizado.AutoSize = true;
            this.rb_realizado.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_realizado.Location = new System.Drawing.Point(240, 337);
            this.rb_realizado.Name = "rb_realizado";
            this.rb_realizado.Size = new System.Drawing.Size(93, 24);
            this.rb_realizado.TabIndex = 6;
            this.rb_realizado.TabStop = true;
            this.rb_realizado.Text = "Realizado";
            this.rb_realizado.UseVisualStyleBackColor = true;
            this.rb_realizado.CheckedChanged += new System.EventHandler(this.rb_realizado_CheckedChanged);
            // 
            // rb_cancelado
            // 
            this.rb_cancelado.AutoSize = true;
            this.rb_cancelado.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_cancelado.Location = new System.Drawing.Point(367, 337);
            this.rb_cancelado.Name = "rb_cancelado";
            this.rb_cancelado.Size = new System.Drawing.Size(99, 24);
            this.rb_cancelado.TabIndex = 7;
            this.rb_cancelado.TabStop = true;
            this.rb_cancelado.Text = "Cancelado";
            this.rb_cancelado.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(242, 196);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 106);
            this.textBox1.TabIndex = 8;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirmar.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Location = new System.Drawing.Point(273, 395);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(151, 40);
            this.btnConfirmar.TabIndex = 9;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(72, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "PSICÓLOGO:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(238, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "PACIENTE:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(405, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "SALA:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(32, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "FECHA:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(551, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "HORA:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(283, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "OBSERVACIONES:";
            // 
            // rbAusente
            // 
            this.rbAusente.AutoSize = true;
            this.rbAusente.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAusente.Location = new System.Drawing.Point(492, 337);
            this.rbAusente.Name = "rbAusente";
            this.rbAusente.Size = new System.Drawing.Size(84, 24);
            this.rbAusente.TabIndex = 21;
            this.rbAusente.TabStop = true;
            this.rbAusente.Text = "Ausente";
            this.rbAusente.UseVisualStyleBackColor = true;
            this.rbAusente.CheckedChanged += new System.EventHandler(this.rbAusente_CheckedChanged);
            // 
            // FormEstadoTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(700, 492);
            this.Controls.Add(this.rbAusente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rb_cancelado);
            this.Controls.Add(this.rb_realizado);
            this.Controls.Add(this.rb_programado);
            this.Controls.Add(this.lbl_hora);
            this.Controls.Add(this.lbl_sala);
            this.Controls.Add(this.lbl_fecha);
            this.Controls.Add(this.lbl_paciente);
            this.Controls.Add(this.lbl_psico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormEstadoTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estado del turno:";
            this.Load += new System.EventHandler(this.FormEstadoTurno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_psico;
        private System.Windows.Forms.Label lbl_paciente;
        private System.Windows.Forms.Label lbl_fecha;
        private System.Windows.Forms.Label lbl_sala;
        private System.Windows.Forms.Label lbl_hora;
        private System.Windows.Forms.RadioButton rb_programado;
        private System.Windows.Forms.RadioButton rb_realizado;
        private System.Windows.Forms.RadioButton rb_cancelado;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbAusente;
    }
}