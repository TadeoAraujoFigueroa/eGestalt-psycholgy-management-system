namespace TRABAJO_FINAL
{
    partial class FormValidarInformes
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
            this.dgInformesAValidar = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnValidar = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnReconstruir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgInformesAValidar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgInformesAValidar
            // 
            this.dgInformesAValidar.AllowUserToAddRows = false;
            this.dgInformesAValidar.AllowUserToDeleteRows = false;
            this.dgInformesAValidar.AllowUserToOrderColumns = true;
            this.dgInformesAValidar.AllowUserToResizeColumns = false;
            this.dgInformesAValidar.AllowUserToResizeRows = false;
            this.dgInformesAValidar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgInformesAValidar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInformesAValidar.Location = new System.Drawing.Point(52, 76);
            this.dgInformesAValidar.MultiSelect = false;
            this.dgInformesAValidar.Name = "dgInformesAValidar";
            this.dgInformesAValidar.ReadOnly = true;
            this.dgInformesAValidar.RowHeadersVisible = false;
            this.dgInformesAValidar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgInformesAValidar.RowTemplate.Height = 24;
            this.dgInformesAValidar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgInformesAValidar.Size = new System.Drawing.Size(682, 406);
            this.dgInformesAValidar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 68);
            this.label1.TabIndex = 1;
            this.label1.Text = "INFORMES A VALIDAR:";
            // 
            // btnValidar
            // 
            this.btnValidar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnValidar.Location = new System.Drawing.Point(80, 518);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(208, 38);
            this.btnValidar.TabIndex = 2;
            this.btnValidar.Text = "VALIDAR";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRechazar.Location = new System.Drawing.Point(494, 518);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(208, 38);
            this.btnRechazar.TabIndex = 3;
            this.btnRechazar.Text = "RECHAZAR";
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(775, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(741, 406);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnReconstruir
            // 
            this.btnReconstruir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReconstruir.Location = new System.Drawing.Point(1029, 518);
            this.btnReconstruir.Name = "btnReconstruir";
            this.btnReconstruir.Size = new System.Drawing.Size(208, 38);
            this.btnReconstruir.TabIndex = 10;
            this.btnReconstruir.Text = "RECONSTRUIR";
            this.btnReconstruir.UseVisualStyleBackColor = true;
            this.btnReconstruir.Click += new System.EventHandler(this.btnReconstruir_Click);
            // 
            // FormValidarInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1567, 588);
            this.Controls.Add(this.btnReconstruir);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgInformesAValidar);
            this.Name = "FormValidarInformes";
            this.Text = "Informes a Validar:";
            this.Load += new System.EventHandler(this.FormValidarInformes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgInformesAValidar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgInformesAValidar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnReconstruir;
    }
}