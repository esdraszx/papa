namespace UI.User
{
    partial class RecalcularDV
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecalcularDV));
            this.label1 = new System.Windows.Forms.Label();
            this.btnRecalcularDV = new System.Windows.Forms.Button();
            this.btncerrar = new System.Windows.Forms.PictureBox();
            this.btnminimizar = new System.Windows.Forms.PictureBox();
            this.registros = new System.Windows.Forms.Label();
            this.Panelgeneral = new System.Windows.Forms.Panel();
            this.btnVerificarDV = new System.Windows.Forms.Button();
            this.richDetalle = new System.Windows.Forms.RichTextBox();
            this.btnRecalcularDVxT = new System.Windows.Forms.Button();
            this.txtTablas = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.btncerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnminimizar)).BeginInit();
            this.Panelgeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(244, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "RecalcularDV";
            // 
            // btnRecalcularDV
            // 
            this.btnRecalcularDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnRecalcularDV.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnRecalcularDV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnRecalcularDV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnRecalcularDV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecalcularDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecalcularDV.ForeColor = System.Drawing.Color.LightGray;
            this.btnRecalcularDV.Location = new System.Drawing.Point(16, 235);
            this.btnRecalcularDV.Name = "btnRecalcularDV";
            this.btnRecalcularDV.Size = new System.Drawing.Size(185, 40);
            this.btnRecalcularDV.TabIndex = 3;
            this.btnRecalcularDV.Text = "RecalcularDV";
            this.btnRecalcularDV.UseVisualStyleBackColor = false;
            this.btnRecalcularDV.Click += new System.EventHandler(this.btnRecalcularDV_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncerrar.Image = ((System.Drawing.Image)(resources.GetObject("btncerrar.Image")));
            this.btncerrar.Location = new System.Drawing.Point(696, 12);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(15, 15);
            this.btncerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btncerrar.TabIndex = 7;
            this.btncerrar.TabStop = false;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // btnminimizar
            // 
            this.btnminimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnminimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnminimizar.Image")));
            this.btnminimizar.Location = new System.Drawing.Point(675, 12);
            this.btnminimizar.Name = "btnminimizar";
            this.btnminimizar.Size = new System.Drawing.Size(15, 15);
            this.btnminimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnminimizar.TabIndex = 8;
            this.btnminimizar.TabStop = false;
            this.btnminimizar.Click += new System.EventHandler(this.btnminimizar_Click);
            // 
            // registros
            // 
            this.registros.AutoSize = true;
            this.registros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registros.ForeColor = System.Drawing.Color.DarkGray;
            this.registros.Image = ((System.Drawing.Image)(resources.GetObject("registros.Image")));
            this.registros.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.registros.Location = new System.Drawing.Point(13, 9);
            this.registros.Name = "registros";
            this.registros.Size = new System.Drawing.Size(61, 17);
            this.registros.TabIndex = 10;
            this.registros.Text = "Mensaje";
            this.registros.Visible = false;
            // 
            // Panelgeneral
            // 
            this.Panelgeneral.Controls.Add(this.txtTablas);
            this.Panelgeneral.Controls.Add(this.btnRecalcularDVxT);
            this.Panelgeneral.Controls.Add(this.richDetalle);
            this.Panelgeneral.Controls.Add(this.btnVerificarDV);
            this.Panelgeneral.Controls.Add(this.registros);
            this.Panelgeneral.Controls.Add(this.btnRecalcularDV);
            this.Panelgeneral.Location = new System.Drawing.Point(164, 46);
            this.Panelgeneral.Name = "Panelgeneral";
            this.Panelgeneral.Size = new System.Drawing.Size(366, 354);
            this.Panelgeneral.TabIndex = 11;
            // 
            // btnVerificarDV
            // 
            this.btnVerificarDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnVerificarDV.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnVerificarDV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnVerificarDV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnVerificarDV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificarDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificarDV.ForeColor = System.Drawing.Color.LightGray;
            this.btnVerificarDV.Location = new System.Drawing.Point(16, 189);
            this.btnVerificarDV.Name = "btnVerificarDV";
            this.btnVerificarDV.Size = new System.Drawing.Size(185, 40);
            this.btnVerificarDV.TabIndex = 11;
            this.btnVerificarDV.Text = "VerificarDV";
            this.btnVerificarDV.UseVisualStyleBackColor = false;
            this.btnVerificarDV.Click += new System.EventHandler(this.btnVerificarDV_Click);
            // 
            // richDetalle
            // 
            this.richDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(47)))), ((int)(((byte)(66)))));
            this.richDetalle.ForeColor = System.Drawing.Color.DarkGray;
            this.richDetalle.Location = new System.Drawing.Point(16, 42);
            this.richDetalle.Name = "richDetalle";
            this.richDetalle.Size = new System.Drawing.Size(333, 130);
            this.richDetalle.TabIndex = 12;
            this.richDetalle.Text = "";
            this.richDetalle.Visible = false;
            // 
            // btnRecalcularDVxT
            // 
            this.btnRecalcularDVxT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnRecalcularDVxT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnRecalcularDVxT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnRecalcularDVxT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnRecalcularDVxT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecalcularDVxT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecalcularDVxT.ForeColor = System.Drawing.Color.LightGray;
            this.btnRecalcularDVxT.Location = new System.Drawing.Point(16, 281);
            this.btnRecalcularDVxT.Name = "btnRecalcularDVxT";
            this.btnRecalcularDVxT.Size = new System.Drawing.Size(185, 40);
            this.btnRecalcularDVxT.TabIndex = 13;
            this.btnRecalcularDVxT.Text = "RecalcularDVxTabla";
            this.btnRecalcularDVxT.UseVisualStyleBackColor = false;
            this.btnRecalcularDVxT.Click += new System.EventHandler(this.RecalcularDVxT_Click);
            // 
            // txtTablas
            // 
            this.txtTablas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(47)))), ((int)(((byte)(66)))));
            this.txtTablas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTablas.ForeColor = System.Drawing.Color.DimGray;
            this.txtTablas.FormattingEnabled = true;
            this.txtTablas.Items.AddRange(new object[] {
            "UsuarioPatente",
            "Bitacora",
            "Usuarios",
            "Familia",
            "FamiliaPatente",
            "Patente",
            "DVV",
            "UsuarioFamilia"});
            this.txtTablas.Location = new System.Drawing.Point(216, 281);
            this.txtTablas.Name = "txtTablas";
            this.txtTablas.Size = new System.Drawing.Size(120, 39);
            this.txtTablas.TabIndex = 14;
            this.txtTablas.SelectedValueChanged += new System.EventHandler(this.txtTablas_SelectedValueChanged);
            // 
            // RecalcularDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(47)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(726, 412);
            this.Controls.Add(this.Panelgeneral);
            this.Controls.Add(this.btnminimizar);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecalcularDV";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DV";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RecalcularDV_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.btncerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnminimizar)).EndInit();
            this.Panelgeneral.ResumeLayout(false);
            this.Panelgeneral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRecalcularDV;
        private System.Windows.Forms.PictureBox btncerrar;
        private System.Windows.Forms.PictureBox btnminimizar;
        private System.Windows.Forms.Label registros;
        private System.Windows.Forms.Panel Panelgeneral;
        private System.Windows.Forms.Button btnVerificarDV;
        private System.Windows.Forms.RichTextBox richDetalle;
        private System.Windows.Forms.ListBox txtTablas;
        private System.Windows.Forms.Button btnRecalcularDVxT;
    }
}

