namespace TRABAJO_FINAL
{
    partial class FormTablaHistoriasClinicas
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
            this.dgvHistoriasClinicas = new System.Windows.Forms.DataGridView();
            this.lblPsico = new System.Windows.Forms.Label();
            this.btnVerHistoria = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoriasClinicas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistoriasClinicas
            // 
            this.dgvHistoriasClinicas.AllowUserToAddRows = false;
            this.dgvHistoriasClinicas.AllowUserToDeleteRows = false;
            this.dgvHistoriasClinicas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistoriasClinicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoriasClinicas.Location = new System.Drawing.Point(79, 78);
            this.dgvHistoriasClinicas.MultiSelect = false;
            this.dgvHistoriasClinicas.Name = "dgvHistoriasClinicas";
            this.dgvHistoriasClinicas.ReadOnly = true;
            this.dgvHistoriasClinicas.RowHeadersWidth = 51;
            this.dgvHistoriasClinicas.RowTemplate.Height = 24;
            this.dgvHistoriasClinicas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistoriasClinicas.Size = new System.Drawing.Size(658, 469);
            this.dgvHistoriasClinicas.TabIndex = 31;
            // 
            // lblPsico
            // 
            this.lblPsico.AutoSize = true;
            this.lblPsico.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPsico.Location = new System.Drawing.Point(76, 40);
            this.lblPsico.Name = "lblPsico";
            this.lblPsico.Size = new System.Drawing.Size(70, 26);
            this.lblPsico.TabIndex = 32;
            this.lblPsico.Text = "label1";
            // 
            // btnVerHistoria
            // 
            this.btnVerHistoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerHistoria.Location = new System.Drawing.Point(174, 577);
            this.btnVerHistoria.Name = "btnVerHistoria";
            this.btnVerHistoria.Size = new System.Drawing.Size(151, 65);
            this.btnVerHistoria.TabIndex = 33;
            this.btnVerHistoria.Text = "VER H.C.";
            this.btnVerHistoria.UseVisualStyleBackColor = true;
            this.btnVerHistoria.Click += new System.EventHandler(this.btnVerHistoria_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(499, 577);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 65);
            this.button1.TabIndex = 34;
            this.button1.Text = "EDITAR H.C.";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormTablaHistoriasClinicas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(824, 671);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnVerHistoria);
            this.Controls.Add(this.lblPsico);
            this.Controls.Add(this.dgvHistoriasClinicas);
            this.Name = "FormTablaHistoriasClinicas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historias Clinicas:";
            this.Load += new System.EventHandler(this.FormTablaHistoriasClinicas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoriasClinicas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistoriasClinicas;
        private System.Windows.Forms.Label lblPsico;
        private System.Windows.Forms.Button btnVerHistoria;
        private System.Windows.Forms.Button button1;
    }
}