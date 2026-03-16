namespace TRABAJO_FINAL
{
    partial class FormPacientesDiscontinuados
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
            this.dgvUsuariosInactivos = new System.Windows.Forms.DataGridView();
            this.btnDatos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosInactivos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDarAlta
            // 
            this.btnDarAlta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDarAlta.Location = new System.Drawing.Point(323, 433);
            this.btnDarAlta.Name = "btnDarAlta";
            this.btnDarAlta.Size = new System.Drawing.Size(159, 41);
            this.btnDarAlta.TabIndex = 22;
            this.btnDarAlta.Text = "DAR DE ALTA";
            this.btnDarAlta.UseVisualStyleBackColor = true;
            this.btnDarAlta.Click += new System.EventHandler(this.btnDarAlta_Click);
            // 
            // label6
            // 
            this.label6.AllowDrop = true;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Rockwell Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(435, 19);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(320, 31);
            this.label6.TabIndex = 20;
            this.label6.Text = "USUARIOS DISCONTINUADOS";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dgvUsuariosInactivos
            // 
            this.dgvUsuariosInactivos.AllowUserToAddRows = false;
            this.dgvUsuariosInactivos.AllowUserToDeleteRows = false;
            this.dgvUsuariosInactivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuariosInactivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuariosInactivos.Location = new System.Drawing.Point(147, 76);
            this.dgvUsuariosInactivos.MultiSelect = false;
            this.dgvUsuariosInactivos.Name = "dgvUsuariosInactivos";
            this.dgvUsuariosInactivos.ReadOnly = true;
            this.dgvUsuariosInactivos.RowHeadersWidth = 51;
            this.dgvUsuariosInactivos.RowTemplate.Height = 24;
            this.dgvUsuariosInactivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuariosInactivos.Size = new System.Drawing.Size(902, 316);
            this.dgvUsuariosInactivos.TabIndex = 19;
            this.dgvUsuariosInactivos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuariosInactivos_CellContentClick);
            this.dgvUsuariosInactivos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuariosInactivos_CellDoubleClick);
            // 
            // btnDatos
            // 
            this.btnDatos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDatos.Location = new System.Drawing.Point(715, 433);
            this.btnDatos.Name = "btnDatos";
            this.btnDatos.Size = new System.Drawing.Size(159, 41);
            this.btnDatos.TabIndex = 27;
            this.btnDatos.Text = "VER DATOS";
            this.btnDatos.UseVisualStyleBackColor = true;
            this.btnDatos.Click += new System.EventHandler(this.btnDatos_Click);
            // 
            // FormPacientesDiscontinuados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1196, 548);
            this.Controls.Add(this.btnDatos);
            this.Controls.Add(this.btnDarAlta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvUsuariosInactivos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormPacientesDiscontinuados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Usuarios discontinuados:";
            this.Load += new System.EventHandler(this.FormPacientesDiscontinuados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosInactivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDarAlta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvUsuariosInactivos;
        private System.Windows.Forms.Button btnDatos;
    }
}