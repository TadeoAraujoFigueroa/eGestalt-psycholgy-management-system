namespace TRABAJO_FINAL
{
    partial class FormDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea51 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend51 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series51 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea52 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend52 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series52 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea53 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend53 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series53 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea54 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend54 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series54 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea55 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend55 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series55 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.dateFin = new System.Windows.Forms.DateTimePicker();
            this.dateInicio = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_ultimomes = new System.Windows.Forms.Button();
            this.btn_meses = new System.Windows.Forms.Button();
            this.btn_semestre = new System.Windows.Forms.Button();
            this.chart_cant_usuarios = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_cant_psico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chart_sesiones = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.chart_turnos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.chart_finanzas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_ingreso = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_egreso = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_cant_usuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_cant_psico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_sesiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_turnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_finanzas)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnFiltro);
            this.panel1.Controls.Add(this.dateFin);
            this.panel1.Controls.Add(this.dateInicio);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_ultimomes);
            this.panel1.Controls.Add(this.btn_meses);
            this.panel1.Controls.Add(this.btn_semestre);
            this.panel1.Location = new System.Drawing.Point(22, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1626, 89);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Corbel", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(210, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "HASTA:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Corbel", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(210, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "DESDE:";
            // 
            // btnFiltro
            // 
            this.btnFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(139)))));
            this.btnFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltro.Font = new System.Drawing.Font("Corbel", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnFiltro.Location = new System.Drawing.Point(31, 22);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(109, 44);
            this.btnFiltro.TabIndex = 16;
            this.btnFiltro.Text = "APLICAR FILTRO";
            this.btnFiltro.UseVisualStyleBackColor = false;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // dateFin
            // 
            this.dateFin.CalendarFont = new System.Drawing.Font("Montserrat SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFin.Location = new System.Drawing.Point(278, 48);
            this.dateFin.Name = "dateFin";
            this.dateFin.Size = new System.Drawing.Size(200, 22);
            this.dateFin.TabIndex = 15;
            // 
            // dateInicio
            // 
            this.dateInicio.CalendarFont = new System.Drawing.Font("Montserrat SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateInicio.Location = new System.Drawing.Point(278, 14);
            this.dateInicio.Name = "dateInicio";
            this.dateInicio.Size = new System.Drawing.Size(200, 22);
            this.dateInicio.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(139)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Corbel", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.button2.Location = new System.Drawing.Point(1424, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 44);
            this.button2.TabIndex = 3;
            this.button2.Text = "TURNOS EN EL PRÓXIMO MES";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(139)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Corbel", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.button1.Location = new System.Drawing.Point(685, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "ULTIMOS SEIS MESES";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btn_ultimomes
            // 
            this.btn_ultimomes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(139)))));
            this.btn_ultimomes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ultimomes.Font = new System.Drawing.Font("Corbel", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ultimomes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btn_ultimomes.Location = new System.Drawing.Point(971, 22);
            this.btn_ultimomes.Name = "btn_ultimomes";
            this.btn_ultimomes.Size = new System.Drawing.Size(109, 44);
            this.btn_ultimomes.TabIndex = 2;
            this.btn_ultimomes.Text = "ULTIMO MES";
            this.btn_ultimomes.UseVisualStyleBackColor = false;
            this.btn_ultimomes.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_meses
            // 
            this.btn_meses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(139)))));
            this.btn_meses.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_meses.Font = new System.Drawing.Font("Corbel", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_meses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btn_meses.Location = new System.Drawing.Point(828, 22);
            this.btn_meses.Name = "btn_meses";
            this.btn_meses.Size = new System.Drawing.Size(109, 44);
            this.btn_meses.TabIndex = 1;
            this.btn_meses.Text = "ULTIMOS TRES MESES";
            this.btn_meses.UseVisualStyleBackColor = false;
            this.btn_meses.Click += new System.EventHandler(this.btn_meses_Click);
            // 
            // btn_semestre
            // 
            this.btn_semestre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(139)))));
            this.btn_semestre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_semestre.Font = new System.Drawing.Font("Corbel", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_semestre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btn_semestre.Location = new System.Drawing.Point(543, 22);
            this.btn_semestre.Name = "btn_semestre";
            this.btn_semestre.Size = new System.Drawing.Size(109, 44);
            this.btn_semestre.TabIndex = 0;
            this.btn_semestre.Text = "SEMESTRE ANTERIOR";
            this.btn_semestre.UseVisualStyleBackColor = false;
            this.btn_semestre.Click += new System.EventHandler(this.btn_semestre_Click);
            // 
            // chart_cant_usuarios
            // 
            this.chart_cant_usuarios.BackColor = System.Drawing.Color.Transparent;
            this.chart_cant_usuarios.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            chartArea51.Name = "ChartArea1";
            this.chart_cant_usuarios.ChartAreas.Add(chartArea51);
            legend51.Name = "Legend1";
            this.chart_cant_usuarios.Legends.Add(legend51);
            this.chart_cant_usuarios.Location = new System.Drawing.Point(133, 130);
            this.chart_cant_usuarios.Name = "chart_cant_usuarios";
            this.chart_cant_usuarios.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series51.ChartArea = "ChartArea1";
            series51.Legend = "Legend1";
            series51.Name = "Series1";
            this.chart_cant_usuarios.Series.Add(series51);
            this.chart_cant_usuarios.Size = new System.Drawing.Size(697, 300);
            this.chart_cant_usuarios.TabIndex = 1;
            this.chart_cant_usuarios.Click += new System.EventHandler(this.chart_cant_usuarios_Click);
            // 
            // chart_cant_psico
            // 
            this.chart_cant_psico.BackColor = System.Drawing.Color.Transparent;
            this.chart_cant_psico.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            chartArea52.Name = "ChartArea1";
            this.chart_cant_psico.ChartAreas.Add(chartArea52);
            legend52.Name = "Legend1";
            this.chart_cant_psico.Legends.Add(legend52);
            this.chart_cant_psico.Location = new System.Drawing.Point(977, 130);
            this.chart_cant_psico.Name = "chart_cant_psico";
            this.chart_cant_psico.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series52.ChartArea = "ChartArea1";
            series52.Legend = "Legend1";
            series52.Name = "Series1";
            this.chart_cant_psico.Series.Add(series52);
            this.chart_cant_psico.Size = new System.Drawing.Size(512, 300);
            this.chart_cant_psico.TabIndex = 2;
            this.chart_cant_psico.Text = "47, 47, 47";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(377, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "CANTIDAD DE PACIENTES:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1185, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "CANTIDAD DE PSICÓLOGOS:";
            // 
            // chart_sesiones
            // 
            this.chart_sesiones.BackColor = System.Drawing.Color.Transparent;
            this.chart_sesiones.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            chartArea53.Name = "ChartArea1";
            this.chart_sesiones.ChartAreas.Add(chartArea53);
            legend53.Name = "Legend1";
            this.chart_sesiones.Legends.Add(legend53);
            this.chart_sesiones.Location = new System.Drawing.Point(22, 511);
            this.chart_sesiones.Name = "chart_sesiones";
            this.chart_sesiones.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series53.ChartArea = "ChartArea1";
            series53.Legend = "Legend1";
            series53.Name = "Series1";
            this.chart_sesiones.Series.Add(series53);
            this.chart_sesiones.Size = new System.Drawing.Size(300, 300);
            this.chart_sesiones.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Corbel", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(99, 493);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "CANTIDAD DE SESIONES:";
            // 
            // chart_turnos
            // 
            this.chart_turnos.BackColor = System.Drawing.Color.Transparent;
            this.chart_turnos.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            chartArea54.Name = "ChartArea1";
            this.chart_turnos.ChartAreas.Add(chartArea54);
            legend54.Name = "Legend1";
            this.chart_turnos.Legends.Add(legend54);
            this.chart_turnos.Location = new System.Drawing.Point(386, 511);
            this.chart_turnos.Name = "chart_turnos";
            this.chart_turnos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series54.ChartArea = "ChartArea1";
            series54.Legend = "Legend1";
            series54.Name = "Series1";
            this.chart_turnos.Series.Add(series54);
            this.chart_turnos.Size = new System.Drawing.Size(300, 300);
            this.chart_turnos.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Corbel", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(518, 493);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "TURNOS:";
            // 
            // chart_finanzas
            // 
            this.chart_finanzas.BackColor = System.Drawing.Color.Transparent;
            this.chart_finanzas.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            chartArea55.Name = "ChartArea1";
            this.chart_finanzas.ChartAreas.Add(chartArea55);
            legend55.Name = "Legend1";
            this.chart_finanzas.Legends.Add(legend55);
            this.chart_finanzas.Location = new System.Drawing.Point(781, 511);
            this.chart_finanzas.Name = "chart_finanzas";
            this.chart_finanzas.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series55.ChartArea = "ChartArea1";
            series55.Legend = "Legend1";
            series55.Name = "Series1";
            this.chart_finanzas.Series.Add(series55);
            this.chart_finanzas.Size = new System.Drawing.Size(639, 300);
            this.chart_finanzas.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Corbel", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1027, 493);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "ENTRADAS Y SALIDAS:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lb_ingreso);
            this.panel2.Controls.Add(this.lb_egreso);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(1436, 511);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 300);
            this.panel2.TabIndex = 13;
            // 
            // lb_ingreso
            // 
            this.lb_ingreso.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ingreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.lb_ingreso.Location = new System.Drawing.Point(26, 68);
            this.lb_ingreso.Margin = new System.Windows.Forms.Padding(3);
            this.lb_ingreso.Name = "lb_ingreso";
            this.lb_ingreso.Size = new System.Drawing.Size(145, 35);
            this.lb_ingreso.TabIndex = 2;
            this.lb_ingreso.Text = "lb_ingreso";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Corbel", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "TOTAL EGRESOS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "TOTAL INGRESOS:";
            // 
            // lb_egreso
            // 
            this.lb_egreso.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_egreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.lb_egreso.Location = new System.Drawing.Point(31, 204);
            this.lb_egreso.Margin = new System.Windows.Forms.Padding(3);
            this.lb_egreso.Name = "lb_egreso";
            this.lb_egreso.Size = new System.Drawing.Size(134, 35);
            this.lb_egreso.TabIndex = 3;
            this.lb_egreso.Text = "lb_egreso";
            this.lb_egreso.Click += new System.EventHandler(this.lb_egreso_Click);
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1670, 844);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chart_finanzas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chart_turnos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chart_sesiones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart_cant_psico);
            this.Controls.Add(this.chart_cant_usuarios);
            this.Controls.Add(this.panel1);
            this.Name = "FormDashboard";
            this.Text = "DashBoard:";
            this.Load += new System.EventHandler(this.FormDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_cant_usuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_cant_psico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_sesiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_turnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_finanzas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_meses;
        private System.Windows.Forms.Button btn_semestre;
        private System.Windows.Forms.Button btn_ultimomes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_cant_usuarios;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_cant_psico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_sesiones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_turnos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_finanzas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_ingreso;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.DateTimePicker dateFin;
        private System.Windows.Forms.DateTimePicker dateInicio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_egreso;
    }
}