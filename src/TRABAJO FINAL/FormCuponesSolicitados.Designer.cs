namespace TRABAJO_FINAL
{
    partial class FormCuponesSolicitados
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
            this.dgv_cupones = new System.Windows.Forms.DataGridView();
            this.btnEmitir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cupones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_cupones
            // 
            this.dgv_cupones.AllowUserToAddRows = false;
            this.dgv_cupones.AllowUserToDeleteRows = false;
            this.dgv_cupones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_cupones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cupones.Location = new System.Drawing.Point(154, 59);
            this.dgv_cupones.MultiSelect = false;
            this.dgv_cupones.Name = "dgv_cupones";
            this.dgv_cupones.ReadOnly = true;
            this.dgv_cupones.RowHeadersWidth = 51;
            this.dgv_cupones.RowTemplate.Height = 24;
            this.dgv_cupones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_cupones.Size = new System.Drawing.Size(742, 362);
            this.dgv_cupones.TabIndex = 1;
            // 
            // btnEmitir
            // 
            this.btnEmitir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmitir.Location = new System.Drawing.Point(433, 457);
            this.btnEmitir.Name = "btnEmitir";
            this.btnEmitir.Size = new System.Drawing.Size(197, 38);
            this.btnEmitir.TabIndex = 2;
            this.btnEmitir.Text = "EMITIR CUPÓN DE PAGO";
            this.btnEmitir.UseVisualStyleBackColor = true;
            this.btnEmitir.Click += new System.EventHandler(this.btnEmitir_Click);
            // 
            // FormCuponesSolicitados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1051, 555);
            this.Controls.Add(this.btnEmitir);
            this.Controls.Add(this.dgv_cupones);
            this.Name = "FormCuponesSolicitados";
            this.Text = "Tabla de Cupones Solicitados:";
            this.Load += new System.EventHandler(this.FormCuponesSolicitados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cupones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_cupones;
        private System.Windows.Forms.Button btnEmitir;
    }
}