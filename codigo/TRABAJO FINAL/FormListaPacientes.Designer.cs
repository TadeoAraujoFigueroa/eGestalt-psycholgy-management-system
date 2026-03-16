namespace TRABAJO_FINAL
{
    partial class FormListaPacientes
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
            this.btnDarAlta = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvPsicologos = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cb_jornada = new System.Windows.Forms.ComboBox();
            this.cb_dia = new System.Windows.Forms.ComboBox();
            this.cb_sala = new System.Windows.Forms.ComboBox();
            this.cb_estado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.check_box = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPsicologos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDarAlta
            // 
            this.btnDarAlta.Location = new System.Drawing.Point(240, 430);
            this.btnDarAlta.Name = "btnDarAlta";
            this.btnDarAlta.Size = new System.Drawing.Size(159, 41);
            this.btnDarAlta.TabIndex = 25;
            this.btnDarAlta.Text = "MODIFICAR";
            this.btnDarAlta.UseVisualStyleBackColor = true;
            this.btnDarAlta.Click += new System.EventHandler(this.btnDarAlta_Click);
            // 
            // label6
            // 
            this.label6.AllowDrop = true;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Rockwell Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 37);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 31);
            this.label6.TabIndex = 24;
            this.label6.Text = "PSICÓLOGOS";
            // 
            // dgvPsicologos
            // 
            this.dgvPsicologos.AllowUserToAddRows = false;
            this.dgvPsicologos.AllowUserToDeleteRows = false;
            this.dgvPsicologos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPsicologos.Location = new System.Drawing.Point(138, 85);
            this.dgvPsicologos.MultiSelect = false;
            this.dgvPsicologos.Name = "dgvPsicologos";
            this.dgvPsicologos.RowHeadersWidth = 51;
            this.dgvPsicologos.RowTemplate.Height = 24;
            this.dgvPsicologos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPsicologos.Size = new System.Drawing.Size(902, 316);
            this.dgvPsicologos.TabIndex = 23;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(801, 430);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(159, 41);
            this.btnEliminar.TabIndex = 26;
            this.btnEliminar.Text = "DAR DE BAJA";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cb_jornada
            // 
            this.cb_jornada.FormattingEnabled = true;
            this.cb_jornada.Location = new System.Drawing.Point(566, 36);
            this.cb_jornada.Name = "cb_jornada";
            this.cb_jornada.Size = new System.Drawing.Size(121, 24);
            this.cb_jornada.TabIndex = 28;
            this.cb_jornada.SelectedIndexChanged += new System.EventHandler(this.cb_jornada_SelectedIndexChanged);
            // 
            // cb_dia
            // 
            this.cb_dia.FormattingEnabled = true;
            this.cb_dia.Location = new System.Drawing.Point(403, 36);
            this.cb_dia.Name = "cb_dia";
            this.cb_dia.Size = new System.Drawing.Size(121, 24);
            this.cb_dia.TabIndex = 27;
            this.cb_dia.SelectedIndexChanged += new System.EventHandler(this.cb_dia_SelectedIndexChanged);
            // 
            // cb_sala
            // 
            this.cb_sala.FormattingEnabled = true;
            this.cb_sala.Location = new System.Drawing.Point(240, 37);
            this.cb_sala.Name = "cb_sala";
            this.cb_sala.Size = new System.Drawing.Size(121, 24);
            this.cb_sala.TabIndex = 29;
            this.cb_sala.SelectedIndexChanged += new System.EventHandler(this.cb_sala_SelectedIndexChanged);
            // 
            // cb_estado
            // 
            this.cb_estado.FormattingEnabled = true;
            this.cb_estado.Location = new System.Drawing.Point(831, 37);
            this.cb_estado.Name = "cb_estado";
            this.cb_estado.Size = new System.Drawing.Size(121, 24);
            this.cb_estado.TabIndex = 30;
            this.cb_estado.SelectedIndexChanged += new System.EventHandler(this.cb_estado_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(831, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "ACTIVO:";
            // 
            // check_box
            // 
            this.check_box.AutoSize = true;
            this.check_box.Location = new System.Drawing.Point(1018, 40);
            this.check_box.Name = "check_box";
            this.check_box.Size = new System.Drawing.Size(148, 20);
            this.check_box.TabIndex = 33;
            this.check_box.Text = "MOSTRAR TODOS";
            this.check_box.UseVisualStyleBackColor = true;
            this.check_box.CheckedChanged += new System.EventHandler(this.check_box_CheckedChanged);
            // 
            // FormListaPacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1178, 501);
            this.Controls.Add(this.check_box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_estado);
            this.Controls.Add(this.cb_sala);
            this.Controls.Add(this.cb_jornada);
            this.Controls.Add(this.cb_dia);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnDarAlta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvPsicologos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormListaPacientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Psicólogos:";
            this.Load += new System.EventHandler(this.FormListaPacientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPsicologos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDarAlta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvPsicologos;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox cb_jornada;
        private System.Windows.Forms.ComboBox cb_dia;
        private System.Windows.Forms.ComboBox cb_sala;
        private System.Windows.Forms.ComboBox cb_estado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox check_box;
    }
}