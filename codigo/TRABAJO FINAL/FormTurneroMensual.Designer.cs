namespace TRABAJO_FINAL
{
    partial class FormTurneroMensual
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
            this.calendario_turno = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // calendario_turno
            // 
            this.calendario_turno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(78)))));
            this.calendario_turno.CalendarDimensions = new System.Drawing.Size(2, 2);
            this.calendario_turno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calendario_turno.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendario_turno.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.calendario_turno.Location = new System.Drawing.Point(237, 92);
            this.calendario_turno.MaxSelectionCount = 1;
            this.calendario_turno.Name = "calendario_turno";
            this.calendario_turno.TabIndex = 0;
            this.calendario_turno.TitleBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.calendario_turno.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendario_turno_DateChanged);
            this.calendario_turno.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendario_turno_DateSelected);
            // 
            // FormTurneroMensual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1003, 582);
            this.Controls.Add(this.calendario_turno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormTurneroMensual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Turnero Mensual:";
            this.Load += new System.EventHandler(this.FormTurneroMensual_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendario_turno;
    }
}