namespace TRABAJO_FINAL
{
    partial class FormActualizarTarifa
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
            this.btnTarifaActual = new System.Windows.Forms.Button();
            this.btnNvaTarifa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTarifaActual
            // 
            this.btnTarifaActual.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTarifaActual.Location = new System.Drawing.Point(464, 160);
            this.btnTarifaActual.Name = "btnTarifaActual";
            this.btnTarifaActual.Size = new System.Drawing.Size(228, 75);
            this.btnTarifaActual.TabIndex = 0;
            this.btnTarifaActual.Text = "VER TARIFA ACTUAL";
            this.btnTarifaActual.UseVisualStyleBackColor = true;
            this.btnTarifaActual.Click += new System.EventHandler(this.btnTarifaActual_Click);
            // 
            // btnNvaTarifa
            // 
            this.btnNvaTarifa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNvaTarifa.Location = new System.Drawing.Point(86, 160);
            this.btnNvaTarifa.Name = "btnNvaTarifa";
            this.btnNvaTarifa.Size = new System.Drawing.Size(228, 75);
            this.btnNvaTarifa.TabIndex = 1;
            this.btnNvaTarifa.Text = "CALCULAR NUEVA TARIFA";
            this.btnNvaTarifa.UseVisualStyleBackColor = true;
            this.btnNvaTarifa.Click += new System.EventHandler(this.btnNvaTarifa_Click);
            // 
            // FormActualizarTarifa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNvaTarifa);
            this.Controls.Add(this.btnTarifaActual);
            this.Name = "FormActualizarTarifa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Actualizar tarifa:";
            this.Load += new System.EventHandler(this.FormActualizarTarifa_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTarifaActual;
        private System.Windows.Forms.Button btnNvaTarifa;
    }
}