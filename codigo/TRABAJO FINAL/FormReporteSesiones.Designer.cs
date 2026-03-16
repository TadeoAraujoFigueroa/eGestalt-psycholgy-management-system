namespace TRABAJO_FINAL
{
    partial class FormReporteSesiones
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.datePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_psicologo = new System.Windows.Forms.ComboBox();
            this.cb_paciente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.check_gral = new System.Windows.Forms.CheckBox();
            this.btn_confirmar = new System.Windows.Forms.Button();
            this.chart_uno = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_validacion = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.rb_cupones = new System.Windows.Forms.RadioButton();
            this.rb_no_abonadas = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.instrucciones = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_uno)).BeginInit();
            this.SuspendLayout();
            // 
            // datePicker2
            // 
            this.datePicker2.Location = new System.Drawing.Point(154, 95);
            this.datePicker2.Name = "datePicker2";
            this.datePicker2.Size = new System.Drawing.Size(200, 22);
            this.datePicker2.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "FECHA FINAL:";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(154, 39);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 22);
            this.datePicker.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "FECHA INICIAL:";
            // 
            // cb_psicologo
            // 
            this.cb_psicologo.FormattingEnabled = true;
            this.cb_psicologo.Location = new System.Drawing.Point(154, 155);
            this.cb_psicologo.Name = "cb_psicologo";
            this.cb_psicologo.Size = new System.Drawing.Size(200, 24);
            this.cb_psicologo.TabIndex = 34;
            // 
            // cb_paciente
            // 
            this.cb_paciente.FormattingEnabled = true;
            this.cb_paciente.Location = new System.Drawing.Point(154, 218);
            this.cb_paciente.Name = "cb_paciente";
            this.cb_paciente.Size = new System.Drawing.Size(200, 24);
            this.cb_paciente.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 36;
            this.label2.Text = "PSICÓLOGO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 37;
            this.label4.Text = "PACIENTE:";
            // 
            // check_gral
            // 
            this.check_gral.AutoSize = true;
            this.check_gral.Location = new System.Drawing.Point(154, 383);
            this.check_gral.Name = "check_gral";
            this.check_gral.Size = new System.Drawing.Size(124, 20);
            this.check_gral.TabIndex = 38;
            this.check_gral.Text = "Informe General";
            this.check_gral.UseVisualStyleBackColor = true;
            // 
            // btn_confirmar
            // 
            this.btn_confirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_confirmar.Location = new System.Drawing.Point(138, 433);
            this.btn_confirmar.Name = "btn_confirmar";
            this.btn_confirmar.Size = new System.Drawing.Size(133, 44);
            this.btn_confirmar.TabIndex = 39;
            this.btn_confirmar.Text = "GENERAR INFORME";
            this.btn_confirmar.UseVisualStyleBackColor = true;
            this.btn_confirmar.Click += new System.EventHandler(this.btn_confirmar_Click);
            // 
            // chart_uno
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_uno.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_uno.Legends.Add(legend1);
            this.chart_uno.Location = new System.Drawing.Point(479, 16);
            this.chart_uno.Name = "chart_uno";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_uno.Series.Add(series1);
            this.chart_uno.Size = new System.Drawing.Size(720, 379);
            this.chart_uno.TabIndex = 40;
            this.chart_uno.Text = "chart_uno";
            this.chart_uno.Click += new System.EventHandler(this.chart_uno_Click);
            // 
            // btn_validacion
            // 
            this.btn_validacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_validacion.Location = new System.Drawing.Point(646, 433);
            this.btn_validacion.Name = "btn_validacion";
            this.btn_validacion.Size = new System.Drawing.Size(133, 44);
            this.btn_validacion.TabIndex = 41;
            this.btn_validacion.Text = "PEDIR VALIDACIÓN";
            this.btn_validacion.UseVisualStyleBackColor = true;
            this.btn_validacion.Click += new System.EventHandler(this.btn_validacion_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_guardar.Location = new System.Drawing.Point(891, 433);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(133, 44);
            this.btn_guardar.TabIndex = 42;
            this.btn_guardar.Text = "GUARDAR INFORME";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // rb_cupones
            // 
            this.rb_cupones.AutoSize = true;
            this.rb_cupones.Location = new System.Drawing.Point(154, 269);
            this.rb_cupones.Name = "rb_cupones";
            this.rb_cupones.Size = new System.Drawing.Size(137, 20);
            this.rb_cupones.TabIndex = 43;
            this.rb_cupones.TabStop = true;
            this.rb_cupones.Text = "Cupones Emitidos";
            this.rb_cupones.UseVisualStyleBackColor = true;
            // 
            // rb_no_abonadas
            // 
            this.rb_no_abonadas.AutoSize = true;
            this.rb_no_abonadas.Location = new System.Drawing.Point(154, 310);
            this.rb_no_abonadas.Name = "rb_no_abonadas";
            this.rb_no_abonadas.Size = new System.Drawing.Size(172, 20);
            this.rb_no_abonadas.TabIndex = 44;
            this.rb_no_abonadas.TabStop = true;
            this.rb_no_abonadas.Text = "Sesiones No Abonadas";
            this.rb_no_abonadas.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(154, 348);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(91, 20);
            this.radioButton1.TabIndex = 45;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Abonadas";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // instrucciones
            // 
            this.instrucciones.Location = new System.Drawing.Point(1285, 16);
            this.instrucciones.Name = "instrucciones";
            this.instrucciones.Size = new System.Drawing.Size(412, 379);
            this.instrucciones.TabIndex = 46;
            this.instrucciones.Text = "";
            // 
            // FormReporteSesiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(216)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1748, 509);
            this.Controls.Add(this.instrucciones);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.rb_no_abonadas);
            this.Controls.Add(this.rb_cupones);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.btn_validacion);
            this.Controls.Add(this.chart_uno);
            this.Controls.Add(this.btn_confirmar);
            this.Controls.Add(this.check_gral);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_paciente);
            this.Controls.Add(this.cb_psicologo);
            this.Controls.Add(this.datePicker2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.label1);
            this.Name = "FormReporteSesiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte sesiones realizadas:";
            this.Load += new System.EventHandler(this.FormReporteSesiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_uno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_psicologo;
        private System.Windows.Forms.ComboBox cb_paciente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox check_gral;
        private System.Windows.Forms.Button btn_confirmar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_uno;
        private System.Windows.Forms.Button btn_validacion;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.RadioButton rb_cupones;
        private System.Windows.Forms.RadioButton rb_no_abonadas;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RichTextBox instrucciones;
    }
}