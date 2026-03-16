namespace TRABAJO_FINAL
{
    partial class FormPacientesEnEspera
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
            this.dgvUsuariosEnEspera = new System.Windows.Forms.DataGridView();
            this.btnDatos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosEnEspera)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDarAlta
            // 
            this.btnDarAlta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDarAlta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDarAlta.Location = new System.Drawing.Point(316, 454);
            this.btnDarAlta.Name = "btnDarAlta";
            this.btnDarAlta.Size = new System.Drawing.Size(159, 41);
            this.btnDarAlta.TabIndex = 25;
            this.btnDarAlta.Text = "DAR DE ALTA";
            this.btnDarAlta.UseVisualStyleBackColor = true;
            this.btnDarAlta.Click += new System.EventHandler(this.btnDarAlta_Click);
            // 
            // label6
            // 
            this.label6.AllowDrop = true;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Rockwell Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(472, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 31);
            this.label6.TabIndex = 24;
            this.label6.Text = "USUARIOS EN ESPERA";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dgvUsuariosEnEspera
            // 
            this.dgvUsuariosEnEspera.AllowUserToAddRows = false;
            this.dgvUsuariosEnEspera.AllowUserToDeleteRows = false;
            this.dgvUsuariosEnEspera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuariosEnEspera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuariosEnEspera.Location = new System.Drawing.Point(147, 68);
            this.dgvUsuariosEnEspera.MultiSelect = false;
            this.dgvUsuariosEnEspera.Name = "dgvUsuariosEnEspera";
            this.dgvUsuariosEnEspera.ReadOnly = true;
            this.dgvUsuariosEnEspera.RowHeadersWidth = 51;
            this.dgvUsuariosEnEspera.RowTemplate.Height = 24;
            this.dgvUsuariosEnEspera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuariosEnEspera.Size = new System.Drawing.Size(902, 352);
            this.dgvUsuariosEnEspera.TabIndex = 23;
            this.dgvUsuariosEnEspera.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuariosEnEspera_CellDoubleClick);
            // 
            // btnDatos
            // 
            this.btnDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDatos.Location = new System.Drawing.Point(730, 454);
            this.btnDatos.Name = "btnDatos";
            this.btnDatos.Size = new System.Drawing.Size(159, 41);
            this.btnDatos.TabIndex = 26;
            this.btnDatos.Text = "VER DATOS";
            this.btnDatos.UseVisualStyleBackColor = true;
            this.btnDatos.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormPacientesEnEspera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1196, 548);
            this.Controls.Add(this.btnDatos);
            this.Controls.Add(this.btnDarAlta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvUsuariosEnEspera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormPacientesEnEspera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pacientes en espera:";
            this.Load += new System.EventHandler(this.FormPacientesEnEspera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosEnEspera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDarAlta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvUsuariosEnEspera;
        private System.Windows.Forms.Button btnDatos;
    }
}