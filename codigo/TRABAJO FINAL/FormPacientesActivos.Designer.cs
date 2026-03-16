namespace TRABAJO_FINAL
{
    partial class FormPacientesActivos
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
            this.btnDarBaja = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvUsuariosActivos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosActivos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDarBaja
            // 
            this.btnDarBaja.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDarBaja.Location = new System.Drawing.Point(759, 451);
            this.btnDarBaja.Name = "btnDarBaja";
            this.btnDarBaja.Size = new System.Drawing.Size(159, 41);
            this.btnDarBaja.TabIndex = 18;
            this.btnDarBaja.Text = "DAR DE BAJA";
            this.btnDarBaja.UseVisualStyleBackColor = true;
            this.btnDarBaja.Click += new System.EventHandler(this.btnDarBaja_Click);
            // 
            // btnMod
            // 
            this.btnMod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMod.Location = new System.Drawing.Point(278, 451);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(159, 41);
            this.btnMod.TabIndex = 17;
            this.btnMod.Text = "VER DATOS";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // label6
            // 
            this.label6.AllowDrop = true;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Rockwell Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(492, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 31);
            this.label6.TabIndex = 16;
            this.label6.Text = "USUARIOS ACTIVOS";
            // 
            // dgvUsuariosActivos
            // 
            this.dgvUsuariosActivos.AllowUserToAddRows = false;
            this.dgvUsuariosActivos.AllowUserToDeleteRows = false;
            this.dgvUsuariosActivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuariosActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuariosActivos.Location = new System.Drawing.Point(147, 59);
            this.dgvUsuariosActivos.MultiSelect = false;
            this.dgvUsuariosActivos.Name = "dgvUsuariosActivos";
            this.dgvUsuariosActivos.ReadOnly = true;
            this.dgvUsuariosActivos.RowHeadersWidth = 51;
            this.dgvUsuariosActivos.RowTemplate.Height = 24;
            this.dgvUsuariosActivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuariosActivos.Size = new System.Drawing.Size(902, 369);
            this.dgvUsuariosActivos.TabIndex = 15;
            this.dgvUsuariosActivos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuariosActivos_CellDoubleClick);
            // 
            // FormPacientesActivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1196, 548);
            this.Controls.Add(this.btnDarBaja);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvUsuariosActivos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormPacientesActivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Usuarios activos:";
            this.Load += new System.EventHandler(this.FormPacientesActivos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosActivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDarBaja;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvUsuariosActivos;
    }
}