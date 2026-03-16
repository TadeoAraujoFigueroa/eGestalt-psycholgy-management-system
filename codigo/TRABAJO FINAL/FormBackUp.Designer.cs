namespace TRABAJO_FINAL
{
    partial class FormBackUp
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
            this.dgvBackUp = new System.Windows.Forms.DataGridView();
            this.btnBackUp = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtIdU = new System.Windows.Forms.TextBox();
            this.txtNombreU = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackUp)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBackUp
            // 
            this.dgvBackUp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBackUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBackUp.Location = new System.Drawing.Point(48, 42);
            this.dgvBackUp.Name = "dgvBackUp";
            this.dgvBackUp.RowHeadersWidth = 51;
            this.dgvBackUp.RowTemplate.Height = 24;
            this.dgvBackUp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBackUp.Size = new System.Drawing.Size(374, 276);
            this.dgvBackUp.TabIndex = 0;
            this.dgvBackUp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBackUp_CellClick);
            // 
            // btnBackUp
            // 
            this.btnBackUp.Location = new System.Drawing.Point(86, 427);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(116, 61);
            this.btnBackUp.TabIndex = 1;
            this.btnBackUp.Text = "REALIZAR BACKUP";
            this.btnBackUp.UseVisualStyleBackColor = true;
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(269, 427);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(116, 61);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // txtIdU
            // 
            this.txtIdU.Location = new System.Drawing.Point(139, 348);
            this.txtIdU.Name = "txtIdU";
            this.txtIdU.ReadOnly = true;
            this.txtIdU.Size = new System.Drawing.Size(193, 22);
            this.txtIdU.TabIndex = 3;
            // 
            // txtNombreU
            // 
            this.txtNombreU.Location = new System.Drawing.Point(139, 386);
            this.txtNombreU.Name = "txtNombreU";
            this.txtNombreU.ReadOnly = true;
            this.txtNombreU.Size = new System.Drawing.Size(193, 22);
            this.txtNombreU.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "NOMBRE:";
            // 
            // FormBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(471, 511);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombreU);
            this.Controls.Add(this.txtIdU);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBackUp);
            this.Controls.Add(this.dgvBackUp);
            this.Name = "FormBackUp";
            this.Text = "BackUp:";
            this.Load += new System.EventHandler(this.FormBackUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBackUp;
        private System.Windows.Forms.Button btnBackUp;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtIdU;
        private System.Windows.Forms.TextBox txtNombreU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}