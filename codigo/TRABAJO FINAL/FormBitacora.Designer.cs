namespace TRABAJO_FINAL
{
    partial class FormBitacora
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
            this.dgvBitacoras = new System.Windows.Forms.DataGridView();
            this.rb_backup = new System.Windows.Forms.RadioButton();
            this.rb_restore = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreU = new System.Windows.Forms.TextBox();
            this.txtIdU = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacoras)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBitacoras
            // 
            this.dgvBitacoras.AllowUserToAddRows = false;
            this.dgvBitacoras.AllowUserToDeleteRows = false;
            this.dgvBitacoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacoras.Location = new System.Drawing.Point(67, 36);
            this.dgvBitacoras.Name = "dgvBitacoras";
            this.dgvBitacoras.ReadOnly = true;
            this.dgvBitacoras.RowHeadersWidth = 51;
            this.dgvBitacoras.RowTemplate.Height = 24;
            this.dgvBitacoras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBitacoras.Size = new System.Drawing.Size(339, 235);
            this.dgvBitacoras.TabIndex = 0;
            this.dgvBitacoras.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBitacoras_CellClick);
            // 
            // rb_backup
            // 
            this.rb_backup.AutoSize = true;
            this.rb_backup.Location = new System.Drawing.Point(95, 435);
            this.rb_backup.Name = "rb_backup";
            this.rb_backup.Size = new System.Drawing.Size(129, 20);
            this.rb_backup.TabIndex = 1;
            this.rb_backup.TabStop = true;
            this.rb_backup.Text = "Mostrar Backups";
            this.rb_backup.UseVisualStyleBackColor = true;
            this.rb_backup.CheckedChanged += new System.EventHandler(this.rb_backup_CheckedChanged);
            // 
            // rb_restore
            // 
            this.rb_restore.AutoSize = true;
            this.rb_restore.Location = new System.Drawing.Point(244, 435);
            this.rb_restore.Name = "rb_restore";
            this.rb_restore.Size = new System.Drawing.Size(131, 20);
            this.rb_restore.TabIndex = 2;
            this.rb_restore.TabStop = true;
            this.rb_restore.Text = "Mostrar Restores";
            this.rb_restore.UseVisualStyleBackColor = true;
            this.rb_restore.CheckedChanged += new System.EventHandler(this.rb_restore_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNombreU);
            this.panel1.Controls.Add(this.txtIdU);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(67, 304);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 100);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "NOMBRE:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "ID:";
            // 
            // txtNombreU
            // 
            this.txtNombreU.Location = new System.Drawing.Point(85, 64);
            this.txtNombreU.Name = "txtNombreU";
            this.txtNombreU.ReadOnly = true;
            this.txtNombreU.Size = new System.Drawing.Size(193, 22);
            this.txtNombreU.TabIndex = 8;
            // 
            // txtIdU
            // 
            this.txtIdU.Location = new System.Drawing.Point(85, 26);
            this.txtIdU.Name = "txtIdU";
            this.txtIdU.ReadOnly = true;
            this.txtIdU.Size = new System.Drawing.Size(193, 22);
            this.txtIdU.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "DATOS DEL USUARIO ";
            // 
            // FormBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(471, 511);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rb_restore);
            this.Controls.Add(this.rb_backup);
            this.Controls.Add(this.dgvBitacoras);
            this.Name = "FormBitacora";
            this.Text = "Bitácoras:";
            this.Load += new System.EventHandler(this.FormBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacoras)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBitacoras;
        private System.Windows.Forms.RadioButton rb_backup;
        private System.Windows.Forms.RadioButton rb_restore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreU;
        private System.Windows.Forms.TextBox txtIdU;
    }
}