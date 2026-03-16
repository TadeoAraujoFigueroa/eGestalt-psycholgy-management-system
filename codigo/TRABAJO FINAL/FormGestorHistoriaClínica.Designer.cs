namespace TRABAJO_FINAL
{
    partial class FormGestorHistoriaClínica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGestorHistoriaClínica));
            this.lblNom = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.rtbHistoriaClinica = new System.Windows.Forms.RichTextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnMas = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tNegrita = new System.Windows.Forms.ToolStripButton();
            this.tItalic = new System.Windows.Forms.ToolStripButton();
            this.tSub = new System.Windows.Forms.ToolStripButton();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(32, 9);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(44, 16);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "label1";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(172, 9);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(44, 16);
            this.lblDni.TabIndex = 1;
            this.lblDni.Text = "label2";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(972, 9);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(44, 16);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "label2";
            // 
            // rtbHistoriaClinica
            // 
            this.rtbHistoriaClinica.Location = new System.Drawing.Point(0, 34);
            this.rtbHistoriaClinica.Name = "rtbHistoriaClinica";
            this.rtbHistoriaClinica.Size = new System.Drawing.Size(1087, 615);
            this.rtbHistoriaClinica.TabIndex = 3;
            this.rtbHistoriaClinica.Text = "";
            this.rtbHistoriaClinica.TextChanged += new System.EventHandler(this.rtbHistoriaClinica_TextChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(35, 655);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(187, 68);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnMas
            // 
            this.btnMas.Location = new System.Drawing.Point(276, 655);
            this.btnMas.Name = "btnMas";
            this.btnMas.Size = new System.Drawing.Size(187, 68);
            this.btnMas.TabIndex = 5;
            this.btnMas.Text = "NUEVA SESION";
            this.btnMas.UseVisualStyleBackColor = true;
            this.btnMas.Click += new System.EventHandler(this.btnMas_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(78)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tNegrita,
            this.tItalic,
            this.tSub});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1087, 31);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tNegrita
            // 
            this.tNegrita.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tNegrita.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tNegrita.Image = ((System.Drawing.Image)(resources.GetObject("tNegrita.Image")));
            this.tNegrita.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tNegrita.Name = "tNegrita";
            this.tNegrita.Size = new System.Drawing.Size(29, 28);
            this.tNegrita.Text = "toolStripButton1";
            this.tNegrita.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tItalic
            // 
            this.tItalic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tItalic.Image = ((System.Drawing.Image)(resources.GetObject("tItalic.Image")));
            this.tItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tItalic.Name = "tItalic";
            this.tItalic.Size = new System.Drawing.Size(29, 28);
            this.tItalic.Text = "toolStripButton2";
            this.tItalic.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tSub
            // 
            this.tSub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tSub.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSub.Image = ((System.Drawing.Image)(resources.GetObject("tSub.Image")));
            this.tSub.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSub.Name = "tSub";
            this.tSub.Size = new System.Drawing.Size(29, 28);
            this.tSub.Text = "toolStripButton3";
            this.tSub.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(859, 655);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(187, 68);
            this.btnFinalizar.TabIndex = 7;
            this.btnFinalizar.Text = "FINALIZAR H.C";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnCambiarEstado
            // 
            this.btnCambiarEstado.Location = new System.Drawing.Point(618, 655);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(187, 68);
            this.btnCambiarEstado.TabIndex = 8;
            this.btnCambiarEstado.Text = "CAMBIAR ESTADO H.C";
            this.btnCambiarEstado.UseVisualStyleBackColor = true;
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);
            // 
            // FormGestorHistoriaClínica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 747);
            this.Controls.Add(this.btnCambiarEstado);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnMas);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.rtbHistoriaClinica);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.lblNom);
            this.Name = "FormGestorHistoriaClínica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor Historia Clinica:";
            this.Load += new System.EventHandler(this.FormGestorHistoriaClínica_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.RichTextBox rtbHistoriaClinica;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnMas;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tItalic;
        private System.Windows.Forms.ToolStripButton tSub;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnCambiarEstado;
        internal System.Windows.Forms.ToolStripButton tNegrita;
    }
}