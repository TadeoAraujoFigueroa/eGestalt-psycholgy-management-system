namespace TRABAJO_FINAL
{
    partial class FormVerificarCodigoDeAcceso
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
            this.txtCod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCod
            // 
            this.txtCod.Location = new System.Drawing.Point(78, 138);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(231, 22);
            this.txtCod.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "INGRESAR CREDENCIAL:";
            // 
            // btnIngresar
            // 
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIngresar.Location = new System.Drawing.Point(117, 231);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(152, 39);
            this.btnIngresar.TabIndex = 2;
            this.btnIngresar.Text = "INGRESAR";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // FormVerificarCodigoDeAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(386, 299);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCod);
            this.Name = "FormVerificarCodigoDeAcceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verificar Codigo de Acceso:";
            this.Load += new System.EventHandler(this.FormVerificarCodigoDeAcceso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIngresar;
    }
}