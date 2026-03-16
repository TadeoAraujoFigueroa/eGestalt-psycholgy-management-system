namespace TRABAJO_FINAL
{
    partial class FormInformesRealizados
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
            this.btnReconstruir = new System.Windows.Forms.Button();
            this.btnValidar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgInformes = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvRechazados = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgInformes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRechazados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReconstruir
            // 
            this.btnReconstruir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReconstruir.Location = new System.Drawing.Point(842, 445);
            this.btnReconstruir.Name = "btnReconstruir";
            this.btnReconstruir.Size = new System.Drawing.Size(208, 23);
            this.btnReconstruir.TabIndex = 7;
            this.btnReconstruir.Text = "RECONSTRUIR";
            this.btnReconstruir.UseVisualStyleBackColor = true;
            this.btnReconstruir.Click += new System.EventHandler(this.btnReconstruir_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnValidar.Location = new System.Drawing.Point(274, 445);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(208, 23);
            this.btnValidar.TabIndex = 6;
            this.btnValidar.Text = "LIBERAR ESPACIO";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 68);
            this.label1.TabIndex = 5;
            this.label1.Text = "INFORMES VALIDADOS:";
            // 
            // dgInformes
            // 
            this.dgInformes.AllowUserToAddRows = false;
            this.dgInformes.AllowUserToDeleteRows = false;
            this.dgInformes.AllowUserToOrderColumns = true;
            this.dgInformes.AllowUserToResizeColumns = false;
            this.dgInformes.AllowUserToResizeRows = false;
            this.dgInformes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgInformes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInformes.Location = new System.Drawing.Point(44, 70);
            this.dgInformes.Name = "dgInformes";
            this.dgInformes.ReadOnly = true;
            this.dgInformes.RowHeadersVisible = false;
            this.dgInformes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgInformes.RowTemplate.Height = 24;
            this.dgInformes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgInformes.Size = new System.Drawing.Size(682, 356);
            this.dgInformes.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(761, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(709, 356);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Location = new System.Drawing.Point(1176, 445);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(208, 23);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvRechazados
            // 
            this.dgvRechazados.AllowUserToAddRows = false;
            this.dgvRechazados.AllowUserToDeleteRows = false;
            this.dgvRechazados.AllowUserToOrderColumns = true;
            this.dgvRechazados.AllowUserToResizeColumns = false;
            this.dgvRechazados.AllowUserToResizeRows = false;
            this.dgvRechazados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRechazados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRechazados.Location = new System.Drawing.Point(428, 602);
            this.dgvRechazados.Name = "dgvRechazados";
            this.dgvRechazados.ReadOnly = true;
            this.dgvRechazados.RowHeadersVisible = false;
            this.dgvRechazados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvRechazados.RowTemplate.Height = 24;
            this.dgvRechazados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRechazados.Size = new System.Drawing.Size(682, 239);
            this.dgvRechazados.TabIndex = 10;
            this.dgvRechazados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRechazados_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Sans Serif Collection", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(626, 531);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 68);
            this.label2.TabIndex = 11;
            this.label2.Text = "INFORMES RECHAZADOS:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // FormInformesRealizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1538, 853);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvRechazados);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnReconstruir);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgInformes);
            this.Name = "FormInformesRealizados";
            this.Text = "Informes realizados:";
            this.Load += new System.EventHandler(this.FormInformesRealizados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgInformes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRechazados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReconstruir;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgInformes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvRechazados;
        private System.Windows.Forms.Label label2;
    }
}