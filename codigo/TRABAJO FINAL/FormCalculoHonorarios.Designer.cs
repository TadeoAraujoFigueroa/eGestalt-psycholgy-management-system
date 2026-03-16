namespace TRABAJO_FINAL
{
    partial class FormCalculoHonorarios
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
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSesionesRealizadas = new System.Windows.Forms.TextBox();
            this.txtHonorario = new System.Windows.Forms.TextBox();
            this.txtRetencionDos = new System.Windows.Forms.TextBox();
            this.txtRetencionUno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txt_por_uno = new System.Windows.Forms.TextBox();
            this.txt_por_dos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirmar.Location = new System.Drawing.Point(282, 359);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(263, 53);
            this.btnConfirmar.TabIndex = 17;
            this.btnConfirmar.Text = "ASIGNAR SALARIO:";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(672, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(616, 292);
            this.dataGridView1.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(73, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "CANTIDAD DE SESIONES:";
            // 
            // txtSesionesRealizadas
            // 
            this.txtSesionesRealizadas.Location = new System.Drawing.Point(67, 51);
            this.txtSesionesRealizadas.Name = "txtSesionesRealizadas";
            this.txtSesionesRealizadas.Size = new System.Drawing.Size(235, 22);
            this.txtSesionesRealizadas.TabIndex = 27;
            this.txtSesionesRealizadas.TextChanged += new System.EventHandler(this.txtSesionesRealizadas_TextChanged);
            // 
            // txtHonorario
            // 
            this.txtHonorario.Location = new System.Drawing.Point(67, 302);
            this.txtHonorario.Name = "txtHonorario";
            this.txtHonorario.ReadOnly = true;
            this.txtHonorario.Size = new System.Drawing.Size(235, 22);
            this.txtHonorario.TabIndex = 26;
            // 
            // txtRetencionDos
            // 
            this.txtRetencionDos.Location = new System.Drawing.Point(67, 235);
            this.txtRetencionDos.Name = "txtRetencionDos";
            this.txtRetencionDos.ReadOnly = true;
            this.txtRetencionDos.Size = new System.Drawing.Size(235, 22);
            this.txtRetencionDos.TabIndex = 25;
            // 
            // txtRetencionUno
            // 
            this.txtRetencionUno.Location = new System.Drawing.Point(67, 166);
            this.txtRetencionUno.Name = "txtRetencionUno";
            this.txtRetencionUno.ReadOnly = true;
            this.txtRetencionUno.Size = new System.Drawing.Size(235, 22);
            this.txtRetencionUno.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(313, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "HONORARIO A PERCIBIR POR PSICÓLOGO/A:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "RETENCIÓN DOS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "RETENCIÓN UNO:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "TARIFA ACTUAL:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(67, 106);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(235, 22);
            this.txtMonto.TabIndex = 19;
            // 
            // txt_por_uno
            // 
            this.txt_por_uno.Location = new System.Drawing.Point(379, 166);
            this.txt_por_uno.Name = "txt_por_uno";
            this.txt_por_uno.Size = new System.Drawing.Size(100, 22);
            this.txt_por_uno.TabIndex = 29;
            this.txt_por_uno.TextChanged += new System.EventHandler(this.txt_por_uno_TextChanged);
            // 
            // txt_por_dos
            // 
            this.txt_por_dos.Location = new System.Drawing.Point(379, 235);
            this.txt_por_dos.Name = "txt_por_dos";
            this.txt_por_dos.Size = new System.Drawing.Size(100, 22);
            this.txt_por_dos.TabIndex = 30;
            this.txt_por_dos.TextChanged += new System.EventHandler(this.txt_por_dos_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(359, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "RETENCIÓN UNO (%):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(359, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 16);
            this.label7.TabIndex = 32;
            this.label7.Text = "RETENCIÓN DOS (%):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(922, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 16);
            this.label8.TabIndex = 33;
            this.label8.Text = "PSICÓLOGOS:";
            // 
            // FormCalculoHonorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1340, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_por_dos);
            this.Controls.Add(this.txt_por_uno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSesionesRealizadas);
            this.Controls.Add(this.txtHonorario);
            this.Controls.Add(this.txtRetencionDos);
            this.Controls.Add(this.txtRetencionUno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnConfirmar);
            this.Name = "FormCalculoHonorarios";
            this.Text = "Calcular Honorarios:";
            this.Load += new System.EventHandler(this.FormCalculoHonorarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSesionesRealizadas;
        private System.Windows.Forms.TextBox txtHonorario;
        private System.Windows.Forms.TextBox txtRetencionDos;
        private System.Windows.Forms.TextBox txtRetencionUno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txt_por_uno;
        private System.Windows.Forms.TextBox txt_por_dos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}