namespace UI
{
    partial class Consulta_Bitacora
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
            this.dgBitacora = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ImprimirReporte = new System.Windows.Forms.Button();
            this.txtIdUsuario_Bitacora = new System.Windows.Forms.TextBox();
            this.btn_BuscarRango = new System.Windows.Forms.Button();
            this.btnBitacoraBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.datepi_Hasta = new System.Windows.Forms.DateTimePicker();
            this.datepi_Desde = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCriticidad_Bitacora = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // dgBitacora
            // 
            this.dgBitacora.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBitacora.Location = new System.Drawing.Point(39, 190);
            this.dgBitacora.Name = "dgBitacora";
            this.dgBitacora.Size = new System.Drawing.Size(827, 226);
            this.dgBitacora.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(63, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 36;
            this.label1.Text = "Criticidad";
            // 
            // btn_ImprimirReporte
            // 
            this.btn_ImprimirReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ImprimirReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btn_ImprimirReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ImprimirReporte.ForeColor = System.Drawing.Color.White;
            this.btn_ImprimirReporte.Location = new System.Drawing.Point(357, 439);
            this.btn_ImprimirReporte.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btn_ImprimirReporte.Name = "btn_ImprimirReporte";
            this.btn_ImprimirReporte.Size = new System.Drawing.Size(177, 42);
            this.btn_ImprimirReporte.TabIndex = 34;
            this.btn_ImprimirReporte.Text = "Imprimir Reporte";
            this.btn_ImprimirReporte.UseVisualStyleBackColor = false;
            this.btn_ImprimirReporte.Click += new System.EventHandler(this.btn_ImprimirReporte_Click);
            // 
            // txtIdUsuario_Bitacora
            // 
            this.txtIdUsuario_Bitacora.Location = new System.Drawing.Point(356, 72);
            this.txtIdUsuario_Bitacora.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtIdUsuario_Bitacora.Name = "txtIdUsuario_Bitacora";
            this.txtIdUsuario_Bitacora.Size = new System.Drawing.Size(245, 23);
            this.txtIdUsuario_Bitacora.TabIndex = 33;
            // 
            // btn_BuscarRango
            // 
            this.btn_BuscarRango.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_BuscarRango.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btn_BuscarRango.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BuscarRango.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarRango.ForeColor = System.Drawing.Color.White;
            this.btn_BuscarRango.Location = new System.Drawing.Point(641, 110);
            this.btn_BuscarRango.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btn_BuscarRango.Name = "btn_BuscarRango";
            this.btn_BuscarRango.Size = new System.Drawing.Size(177, 42);
            this.btn_BuscarRango.TabIndex = 32;
            this.btn_BuscarRango.Text = "Buscar Rango";
            this.btn_BuscarRango.UseVisualStyleBackColor = false;
            this.btn_BuscarRango.Click += new System.EventHandler(this.btn_BuscarRango_Click);
            // 
            // btnBitacoraBuscar
            // 
            this.btnBitacoraBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBitacoraBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnBitacoraBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBitacoraBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBitacoraBuscar.Location = new System.Drawing.Point(641, 54);
            this.btnBitacoraBuscar.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnBitacoraBuscar.Name = "btnBitacoraBuscar";
            this.btnBitacoraBuscar.Size = new System.Drawing.Size(177, 42);
            this.btnBitacoraBuscar.TabIndex = 30;
            this.btnBitacoraBuscar.Text = "Buscar";
            this.btnBitacoraBuscar.UseVisualStyleBackColor = false;
            this.btnBitacoraBuscar.Click += new System.EventHandler(this.btnBitacoraBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(353, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 18);
            this.label2.TabIndex = 38;
            this.label2.Text = "NombreUsuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(64, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 39;
            this.label3.Text = "Desde";
            // 
            // datepi_Hasta
            // 
            this.datepi_Hasta.Location = new System.Drawing.Point(357, 129);
            this.datepi_Hasta.Name = "datepi_Hasta";
            this.datepi_Hasta.Size = new System.Drawing.Size(200, 23);
            this.datepi_Hasta.TabIndex = 40;
            // 
            // datepi_Desde
            // 
            this.datepi_Desde.Location = new System.Drawing.Point(67, 129);
            this.datepi_Desde.Name = "datepi_Desde";
            this.datepi_Desde.Size = new System.Drawing.Size(200, 23);
            this.datepi_Desde.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(354, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 18);
            this.label4.TabIndex = 42;
            this.label4.Text = "Hasta";
            // 
            // cbCriticidad_Bitacora
            // 
            this.cbCriticidad_Bitacora.FormattingEnabled = true;
            this.cbCriticidad_Bitacora.Location = new System.Drawing.Point(66, 72);
            this.cbCriticidad_Bitacora.Name = "cbCriticidad_Bitacora";
            this.cbCriticidad_Bitacora.Size = new System.Drawing.Size(251, 24);
            this.cbCriticidad_Bitacora.TabIndex = 43;
            // 
            // Consulta_Bitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 516);
            this.Controls.Add(this.cbCriticidad_Bitacora);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.datepi_Desde);
            this.Controls.Add(this.datepi_Hasta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgBitacora);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ImprimirReporte);
            this.Controls.Add(this.txtIdUsuario_Bitacora);
            this.Controls.Add(this.btn_BuscarRango);
            this.Controls.Add(this.btnBitacoraBuscar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Consulta_Bitacora";
            this.Text = "Consulta Bitácora";
            this.Load += new System.EventHandler(this.Consulta_Bitacora_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Ayuda);
            ((System.ComponentModel.ISupportInitialize)(this.dgBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgBitacora;
        private System.Windows.Forms.Button btnBitacoraBuscar;
        private System.Windows.Forms.Button btn_BuscarRango;
        private System.Windows.Forms.TextBox txtIdUsuario_Bitacora;
        private System.Windows.Forms.Button btn_ImprimirReporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datepi_Hasta;
        private System.Windows.Forms.DateTimePicker datepi_Desde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCriticidad_Bitacora;
    }
}

