namespace TRABAJO_FINAL
{
    partial class FormABMUsuarios
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
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_encriptar = new System.Windows.Forms.CheckBox();
            this.checkbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(259, 32);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.RowTemplate.Height = 24;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(506, 297);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(42, 94);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(148, 22);
            this.txtNombre.TabIndex = 1;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(42, 147);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(148, 22);
            this.txtClave.TabIndex = 2;
            // 
            // btnCrear
            // 
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrear.Location = new System.Drawing.Point(62, 219);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(114, 48);
            this.btnCrear.TabIndex = 3;
            this.btnCrear.Text = "CREAR";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnMod
            // 
            this.btnMod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMod.Location = new System.Drawing.Point(364, 367);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(114, 48);
            this.btnMod.TabIndex = 4;
            this.btnMod.Text = "MODIFICAR";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Location = new System.Drawing.Point(542, 367);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(114, 48);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "NOMBRE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "CLAVE:";
            // 
            // cb_encriptar
            // 
            this.cb_encriptar.AutoSize = true;
            this.cb_encriptar.Location = new System.Drawing.Point(36, 177);
            this.cb_encriptar.Name = "cb_encriptar";
            this.cb_encriptar.Size = new System.Drawing.Size(106, 20);
            this.cb_encriptar.TabIndex = 8;
            this.cb_encriptar.Text = "Desencriptar";
            this.cb_encriptar.UseVisualStyleBackColor = true;
            this.cb_encriptar.CheckedChanged += new System.EventHandler(this.cb_encriptar_CheckedChanged);
            // 
            // checkbox
            // 
            this.checkbox.AutoSize = true;
            this.checkbox.Location = new System.Drawing.Point(13, 382);
            this.checkbox.Name = "checkbox";
            this.checkbox.Size = new System.Drawing.Size(348, 25);
            this.checkbox.TabIndex = 9;
            this.checkbox.Text = "MOSTRAR USUARIOS DESACTIVADOS";
            this.checkbox.UseVisualStyleBackColor = true;
            this.checkbox.CheckedChanged += new System.EventHandler(this.checkbox_CheckedChanged);
            // 
            // FormABMUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(232)))), ((int)(((byte)(207)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkbox);
            this.Controls.Add(this.cb_encriptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.dgvUsuarios);
            this.Name = "FormABMUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ABM Usuarios:";
            this.Load += new System.EventHandler(this.FormABMUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_encriptar;
        private System.Windows.Forms.CheckBox checkbox;
    }
}