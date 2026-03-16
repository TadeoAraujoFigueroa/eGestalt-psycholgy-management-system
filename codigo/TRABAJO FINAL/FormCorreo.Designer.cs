namespace TRABAJO_FINAL
{
    partial class FormCorreo
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
            this.txtDestinatario = new System.Windows.Forms.TextBox();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.txtCuerpo = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_todos = new System.Windows.Forms.ComboBox();
            this.cb_pacientes = new System.Windows.Forms.ComboBox();
            this.cb_psicologos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rb_uno = new System.Windows.Forms.RadioButton();
            this.rb_dos = new System.Windows.Forms.RadioButton();
            this.rb_tres = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvPlantillas = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtNvoAsunto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNvoMensaje = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlantillas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDestinatario
            // 
            this.txtDestinatario.Location = new System.Drawing.Point(149, 16);
            this.txtDestinatario.Multiline = true;
            this.txtDestinatario.Name = "txtDestinatario";
            this.txtDestinatario.Size = new System.Drawing.Size(492, 28);
            this.txtDestinatario.TabIndex = 0;
            // 
            // txtAsunto
            // 
            this.txtAsunto.Location = new System.Drawing.Point(149, 86);
            this.txtAsunto.Multiline = true;
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(492, 28);
            this.txtAsunto.TabIndex = 1;
            // 
            // txtCuerpo
            // 
            this.txtCuerpo.Location = new System.Drawing.Point(149, 152);
            this.txtCuerpo.Multiline = true;
            this.txtCuerpo.Name = "txtCuerpo";
            this.txtCuerpo.Size = new System.Drawing.Size(492, 435);
            this.txtCuerpo.TabIndex = 2;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(160, 625);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 36);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "LIMPIAR CAMPOS";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(472, 625);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(150, 36);
            this.btnEnviar.TabIndex = 4;
            this.btnEnviar.Text = "ENVIAR";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "PARA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "ASUNTO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "MENSAJE:";
            // 
            // cb_todos
            // 
            this.cb_todos.FormattingEnabled = true;
            this.cb_todos.Location = new System.Drawing.Point(856, 35);
            this.cb_todos.Name = "cb_todos";
            this.cb_todos.Size = new System.Drawing.Size(226, 24);
            this.cb_todos.TabIndex = 8;
            this.cb_todos.SelectedIndexChanged += new System.EventHandler(this.cb_todos_SelectedIndexChanged);
            // 
            // cb_pacientes
            // 
            this.cb_pacientes.FormattingEnabled = true;
            this.cb_pacientes.Location = new System.Drawing.Point(856, 91);
            this.cb_pacientes.Name = "cb_pacientes";
            this.cb_pacientes.Size = new System.Drawing.Size(226, 24);
            this.cb_pacientes.TabIndex = 9;
            this.cb_pacientes.SelectedIndexChanged += new System.EventHandler(this.cb_pacientes_SelectedIndexChanged);
            // 
            // cb_psicologos
            // 
            this.cb_psicologos.FormattingEnabled = true;
            this.cb_psicologos.Location = new System.Drawing.Point(856, 149);
            this.cb_psicologos.Name = "cb_psicologos";
            this.cb_psicologos.Size = new System.Drawing.Size(226, 24);
            this.cb_psicologos.TabIndex = 10;
            this.cb_psicologos.SelectedIndexChanged += new System.EventHandler(this.cb_psicologos_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(893, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "TODOS LOS CORREOS:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(926, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "PACIENTES:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(926, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "PSICÓLOGOS:";
            // 
            // rb_uno
            // 
            this.rb_uno.AutoSize = true;
            this.rb_uno.Location = new System.Drawing.Point(819, 38);
            this.rb_uno.Name = "rb_uno";
            this.rb_uno.Size = new System.Drawing.Size(17, 16);
            this.rb_uno.TabIndex = 14;
            this.rb_uno.TabStop = true;
            this.rb_uno.UseVisualStyleBackColor = true;
            this.rb_uno.CheckedChanged += new System.EventHandler(this.rb_uno_CheckedChanged);
            // 
            // rb_dos
            // 
            this.rb_dos.AutoSize = true;
            this.rb_dos.Location = new System.Drawing.Point(819, 94);
            this.rb_dos.Name = "rb_dos";
            this.rb_dos.Size = new System.Drawing.Size(17, 16);
            this.rb_dos.TabIndex = 15;
            this.rb_dos.TabStop = true;
            this.rb_dos.UseVisualStyleBackColor = true;
            this.rb_dos.CheckedChanged += new System.EventHandler(this.rb_dos_CheckedChanged);
            // 
            // rb_tres
            // 
            this.rb_tres.AutoSize = true;
            this.rb_tres.Location = new System.Drawing.Point(819, 152);
            this.rb_tres.Name = "rb_tres";
            this.rb_tres.Size = new System.Drawing.Size(17, 16);
            this.rb_tres.TabIndex = 16;
            this.rb_tres.TabStop = true;
            this.rb_tres.UseVisualStyleBackColor = true;
            this.rb_tres.CheckedChanged += new System.EventHandler(this.rb_tres_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(931, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "PLANTILLAS:";
            // 
            // dgvPlantillas
            // 
            this.dgvPlantillas.AllowUserToAddRows = false;
            this.dgvPlantillas.AllowUserToDeleteRows = false;
            this.dgvPlantillas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlantillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlantillas.Location = new System.Drawing.Point(763, 232);
            this.dgvPlantillas.MultiSelect = false;
            this.dgvPlantillas.Name = "dgvPlantillas";
            this.dgvPlantillas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPlantillas.RowHeadersWidth = 51;
            this.dgvPlantillas.RowTemplate.Height = 24;
            this.dgvPlantillas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlantillas.Size = new System.Drawing.Size(419, 169);
            this.dgvPlantillas.TabIndex = 18;
            this.dgvPlantillas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlantillas_CellClick);
            this.dgvPlantillas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlantillas_CellDoubleClick);
            // 
            // btnAgregar
            // 
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregar.Location = new System.Drawing.Point(927, 638);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(99, 23);
            this.btnAgregar.TabIndex = 19;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnMod
            // 
            this.btnMod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMod.Location = new System.Drawing.Point(848, 418);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(113, 23);
            this.btnMod.TabIndex = 20;
            this.btnMod.Text = "MODIFICAR";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Location = new System.Drawing.Point(1004, 418);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(101, 23);
            this.btnEliminar.TabIndex = 21;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtNvoAsunto
            // 
            this.txtNvoAsunto.Location = new System.Drawing.Point(807, 488);
            this.txtNvoAsunto.Multiline = true;
            this.txtNvoAsunto.Name = "txtNvoAsunto";
            this.txtNvoAsunto.Size = new System.Drawing.Size(344, 28);
            this.txtNvoAsunto.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(816, 469);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "ASUNTO:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(816, 538);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "MENSAJE:";
            // 
            // txtNvoMensaje
            // 
            this.txtNvoMensaje.Location = new System.Drawing.Point(807, 557);
            this.txtNvoMensaje.Multiline = true;
            this.txtNvoMensaje.Name = "txtNvoMensaje";
            this.txtNvoMensaje.Size = new System.Drawing.Size(344, 67);
            this.txtNvoMensaje.TabIndex = 25;
            // 
            // FormCorreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(184)))), ((int)(((byte)(158)))));
            this.ClientSize = new System.Drawing.Size(1244, 707);
            this.Controls.Add(this.txtNvoMensaje);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNvoAsunto);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvPlantillas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rb_tres);
            this.Controls.Add(this.rb_dos);
            this.Controls.Add(this.rb_uno);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_psicologos);
            this.Controls.Add(this.cb_pacientes);
            this.Controls.Add(this.cb_todos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtCuerpo);
            this.Controls.Add(this.txtAsunto);
            this.Controls.Add(this.txtDestinatario);
            this.Name = "FormCorreo";
            this.Text = "Correo:";
            this.Load += new System.EventHandler(this.FormCorreo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlantillas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDestinatario;
        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.TextBox txtCuerpo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_todos;
        private System.Windows.Forms.ComboBox cb_pacientes;
        private System.Windows.Forms.ComboBox cb_psicologos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rb_uno;
        private System.Windows.Forms.RadioButton rb_dos;
        private System.Windows.Forms.RadioButton rb_tres;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvPlantillas;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtNvoAsunto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNvoMensaje;
    }
}