namespace TRABAJO_FINAL
{
    partial class FormTurneroDiarioDos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTurnero = new System.Windows.Forms.DataGridView();
            this.btn_exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnero)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTurnero
            // 
            this.dgvTurnero.AllowUserToAddRows = false;
            this.dgvTurnero.AllowUserToDeleteRows = false;
            this.dgvTurnero.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTurnero.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvTurnero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTurnero.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTurnero.Location = new System.Drawing.Point(125, 61);
            this.dgvTurnero.MultiSelect = false;
            this.dgvTurnero.Name = "dgvTurnero";
            this.dgvTurnero.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Poor Richard", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTurnero.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTurnero.RowHeadersVisible = false;
            this.dgvTurnero.RowHeadersWidth = 51;
            this.dgvTurnero.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTurnero.RowTemplate.Height = 24;
            this.dgvTurnero.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTurnero.Size = new System.Drawing.Size(955, 493);
            this.dgvTurnero.TabIndex = 1;
            this.dgvTurnero.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnero_CellContentClick);
            this.dgvTurnero.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnero_CellContentDoubleClick);
            this.dgvTurnero.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnero_CellDoubleClick);
            this.dgvTurnero.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTurnero_CellMouseMove_1);
            // 
            // btn_exit
            // 
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_exit.Location = new System.Drawing.Point(1120, 28);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(44, 37);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "X";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // FormTurneroDiarioDos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1205, 614);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.dgvTurnero);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormTurneroDiarioDos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turnero diario:";
            this.Load += new System.EventHandler(this.FormTurneroDiarioDos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTurnero;
        private System.Windows.Forms.Button btn_exit;
    }
}