namespace TRABAJO_FINAL
{
    partial class FormTablaDeSalarios
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
            this.dgv_salarios = new System.Windows.Forms.DataGridView();
            this.cb_psicologo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_salarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_salarios
            // 
            this.dgv_salarios.AllowUserToAddRows = false;
            this.dgv_salarios.AllowUserToDeleteRows = false;
            this.dgv_salarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_salarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_salarios.Location = new System.Drawing.Point(181, 92);
            this.dgv_salarios.MultiSelect = false;
            this.dgv_salarios.Name = "dgv_salarios";
            this.dgv_salarios.ReadOnly = true;
            this.dgv_salarios.RowHeadersWidth = 51;
            this.dgv_salarios.RowTemplate.Height = 24;
            this.dgv_salarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_salarios.Size = new System.Drawing.Size(742, 362);
            this.dgv_salarios.TabIndex = 0;
            // 
            // cb_psicologo
            // 
            this.cb_psicologo.FormattingEnabled = true;
            this.cb_psicologo.Location = new System.Drawing.Point(453, 52);
            this.cb_psicologo.Name = "cb_psicologo";
            this.cb_psicologo.Size = new System.Drawing.Size(207, 24);
            this.cb_psicologo.TabIndex = 1;
            this.cb_psicologo.SelectedIndexChanged += new System.EventHandler(this.cb_psicologo_SelectedIndexChanged);
            // 
            // FormTablaDeSalarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1122, 538);
            this.Controls.Add(this.cb_psicologo);
            this.Controls.Add(this.dgv_salarios);
            this.Name = "FormTablaDeSalarios";
            this.Text = "Tabla de Salarios:";
            this.Load += new System.EventHandler(this.FormTablaDeSalarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_salarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_salarios;
        private System.Windows.Forms.ComboBox cb_psicologo;
    }
}