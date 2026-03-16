namespace TRABAJO_FINAL
{
    partial class FormGeneracionCuponDePago
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNro = new System.Windows.Forms.TextBox();
            this.txtFechaEmision = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnGenerarCupon = new System.Windows.Forms.Button();
            this.btnDescargarCupon = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtEstado);
            this.panel1.Controls.Add(this.txtDni);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(60, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 265);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Estado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dni:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(30, 184);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(205, 22);
            this.txtEstado.TabIndex = 4;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(30, 123);
            this.txtDni.Name = "txtDni";
            this.txtDni.ReadOnly = true;
            this.txtDni.Size = new System.Drawing.Size(205, 22);
            this.txtDni.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(30, 60);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(205, 22);
            this.txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "DATOS DEL PACIENTE:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(30, 195);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtNro);
            this.panel2.Controls.Add(this.txtFechaEmision);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(413, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(263, 265);
            this.panel2.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Fecha de vencimiento:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "Número de cupón:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Fecha de emisión:";
            // 
            // txtNro
            // 
            this.txtNro.Location = new System.Drawing.Point(30, 123);
            this.txtNro.Name = "txtNro";
            this.txtNro.ReadOnly = true;
            this.txtNro.Size = new System.Drawing.Size(205, 22);
            this.txtNro.TabIndex = 3;
            // 
            // txtFechaEmision
            // 
            this.txtFechaEmision.Location = new System.Drawing.Point(30, 60);
            this.txtFechaEmision.Name = "txtFechaEmision";
            this.txtFechaEmision.ReadOnly = true;
            this.txtFechaEmision.Size = new System.Drawing.Size(205, 22);
            this.txtFechaEmision.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "DATOS DEL CUPÓN:";
            // 
            // btnGenerarCupon
            // 
            this.btnGenerarCupon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerarCupon.Location = new System.Drawing.Point(126, 425);
            this.btnGenerarCupon.Name = "btnGenerarCupon";
            this.btnGenerarCupon.Size = new System.Drawing.Size(197, 51);
            this.btnGenerarCupon.TabIndex = 9;
            this.btnGenerarCupon.Text = "GENERAR CUPÓN DE PAGO";
            this.btnGenerarCupon.UseVisualStyleBackColor = true;
            this.btnGenerarCupon.Click += new System.EventHandler(this.btnGenerarCupon_Click);
            // 
            // btnDescargarCupon
            // 
            this.btnDescargarCupon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDescargarCupon.Location = new System.Drawing.Point(413, 425);
            this.btnDescargarCupon.Name = "btnDescargarCupon";
            this.btnDescargarCupon.Size = new System.Drawing.Size(197, 51);
            this.btnDescargarCupon.TabIndex = 10;
            this.btnDescargarCupon.Text = "DESCARGAR CUPÓN DE PAGO:";
            this.btnDescargarCupon.UseVisualStyleBackColor = true;
            this.btnDescargarCupon.Click += new System.EventHandler(this.btnDescargarCupon_Click);
            // 
            // FormGeneracionCuponDePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(737, 573);
            this.Controls.Add(this.btnDescargarCupon);
            this.Controls.Add(this.btnGenerarCupon);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormGeneracionCuponDePago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generacion de Cupon de Pago:";
            this.Load += new System.EventHandler(this.FormGeneracionCuponDePago_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNro;
        private System.Windows.Forms.TextBox txtFechaEmision;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnGenerarCupon;
        private System.Windows.Forms.Button btnDescargarCupon;
    }
}