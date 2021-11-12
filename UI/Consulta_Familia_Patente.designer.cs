namespace UI
{
    partial class Consulta_Familia_Patente
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
            this.dgConsultaFamilia_Familias = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminarFamilia = new System.Windows.Forms.Button();
            this.txtFamiliaID = new System.Windows.Forms.TextBox();
            this.btbBuscarFamilia = new System.Windows.Forms.Button();
            this.dgConsultaFamilia_PatenteFamilias = new System.Windows.Forms.DataGridView();
            this.dgConsultaFamilias_Patentes = new System.Windows.Forms.DataGridView();
            this.btnQuitarPatenteFamilia = new System.Windows.Forms.Button();
            this.btnAgregarPatenteFamilia = new System.Windows.Forms.Button();
            this.btnCrearFamilia = new System.Windows.Forms.Button();
            this.btnAceptarConsultaFam = new System.Windows.Forms.Button();
            this.btn_Cancelar_Consulta_Familia_Patente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPatente = new System.Windows.Forms.Button();
            this.txtPat = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsultaFamilia_Familias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsultaFamilia_PatenteFamilias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsultaFamilias_Patentes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgConsultaFamilia_Familias
            // 
            this.dgConsultaFamilia_Familias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgConsultaFamilia_Familias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConsultaFamilia_Familias.Location = new System.Drawing.Point(47, 104);
            this.dgConsultaFamilia_Familias.Name = "dgConsultaFamilia_Familias";
            this.dgConsultaFamilia_Familias.Size = new System.Drawing.Size(187, 159);
            this.dgConsultaFamilia_Familias.TabIndex = 37;
            this.dgConsultaFamilia_Familias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgConsultaFamilia_Familias_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(97, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 24);
            this.label1.TabIndex = 36;
            this.label1.Text = "ID_Familia";
            // 
            // btnEliminarFamilia
            // 
            this.btnEliminarFamilia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarFamilia.BackColor = System.Drawing.Color.Tomato;
            this.btnEliminarFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFamilia.ForeColor = System.Drawing.Color.White;
            this.btnEliminarFamilia.Location = new System.Drawing.Point(47, 325);
            this.btnEliminarFamilia.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnEliminarFamilia.Name = "btnEliminarFamilia";
            this.btnEliminarFamilia.Size = new System.Drawing.Size(98, 56);
            this.btnEliminarFamilia.TabIndex = 34;
            this.btnEliminarFamilia.Text = "Eliminar Familia";
            this.btnEliminarFamilia.UseVisualStyleBackColor = false;
            this.btnEliminarFamilia.Click += new System.EventHandler(this.btnEliminarFamilia_Click);
            // 
            // txtFamiliaID
            // 
            this.txtFamiliaID.Location = new System.Drawing.Point(205, 25);
            this.txtFamiliaID.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtFamiliaID.Name = "txtFamiliaID";
            this.txtFamiliaID.Size = new System.Drawing.Size(187, 23);
            this.txtFamiliaID.TabIndex = 31;
            // 
            // btbBuscarFamilia
            // 
            this.btbBuscarFamilia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btbBuscarFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btbBuscarFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btbBuscarFamilia.ForeColor = System.Drawing.Color.White;
            this.btbBuscarFamilia.Location = new System.Drawing.Point(406, 21);
            this.btbBuscarFamilia.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btbBuscarFamilia.Name = "btbBuscarFamilia";
            this.btbBuscarFamilia.Size = new System.Drawing.Size(123, 31);
            this.btbBuscarFamilia.TabIndex = 30;
            this.btbBuscarFamilia.Text = "Buscar";
            this.btbBuscarFamilia.UseVisualStyleBackColor = false;
            this.btbBuscarFamilia.Click += new System.EventHandler(this.btbBuscarFamilia_Click);
            // 
            // dgConsultaFamilia_PatenteFamilias
            // 
            this.dgConsultaFamilia_PatenteFamilias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgConsultaFamilia_PatenteFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConsultaFamilia_PatenteFamilias.Location = new System.Drawing.Point(306, 104);
            this.dgConsultaFamilia_PatenteFamilias.Name = "dgConsultaFamilia_PatenteFamilias";
            this.dgConsultaFamilia_PatenteFamilias.Size = new System.Drawing.Size(184, 159);
            this.dgConsultaFamilia_PatenteFamilias.TabIndex = 38;
            this.dgConsultaFamilia_PatenteFamilias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgConsultaFamilia_PatenteFamilias_CellContentClick);
            // 
            // dgConsultaFamilias_Patentes
            // 
            this.dgConsultaFamilias_Patentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgConsultaFamilias_Patentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConsultaFamilias_Patentes.Location = new System.Drawing.Point(648, 104);
            this.dgConsultaFamilias_Patentes.Name = "dgConsultaFamilias_Patentes";
            this.dgConsultaFamilias_Patentes.Size = new System.Drawing.Size(201, 159);
            this.dgConsultaFamilias_Patentes.TabIndex = 39;
            this.dgConsultaFamilias_Patentes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgConsultaFamilias_Patentes_CellContentClick);
            // 
            // btnQuitarPatenteFamilia
            // 
            this.btnQuitarPatenteFamilia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitarPatenteFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnQuitarPatenteFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarPatenteFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarPatenteFamilia.ForeColor = System.Drawing.Color.White;
            this.btnQuitarPatenteFamilia.Location = new System.Drawing.Point(525, 134);
            this.btnQuitarPatenteFamilia.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnQuitarPatenteFamilia.Name = "btnQuitarPatenteFamilia";
            this.btnQuitarPatenteFamilia.Size = new System.Drawing.Size(64, 35);
            this.btnQuitarPatenteFamilia.TabIndex = 40;
            this.btnQuitarPatenteFamilia.Text = ">";
            this.btnQuitarPatenteFamilia.UseVisualStyleBackColor = false;
            this.btnQuitarPatenteFamilia.Click += new System.EventHandler(this.btnQuitarPatenteFamilia_Click);
            // 
            // btnAgregarPatenteFamilia
            // 
            this.btnAgregarPatenteFamilia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarPatenteFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnAgregarPatenteFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPatenteFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPatenteFamilia.ForeColor = System.Drawing.Color.White;
            this.btnAgregarPatenteFamilia.Location = new System.Drawing.Point(525, 195);
            this.btnAgregarPatenteFamilia.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnAgregarPatenteFamilia.Name = "btnAgregarPatenteFamilia";
            this.btnAgregarPatenteFamilia.Size = new System.Drawing.Size(64, 35);
            this.btnAgregarPatenteFamilia.TabIndex = 41;
            this.btnAgregarPatenteFamilia.Text = "<";
            this.btnAgregarPatenteFamilia.UseVisualStyleBackColor = false;
            this.btnAgregarPatenteFamilia.Click += new System.EventHandler(this.btnAgregarPatenteFamilia_Click);
            // 
            // btnCrearFamilia
            // 
            this.btnCrearFamilia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrearFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnCrearFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearFamilia.ForeColor = System.Drawing.Color.White;
            this.btnCrearFamilia.Location = new System.Drawing.Point(170, 325);
            this.btnCrearFamilia.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnCrearFamilia.Name = "btnCrearFamilia";
            this.btnCrearFamilia.Size = new System.Drawing.Size(95, 56);
            this.btnCrearFamilia.TabIndex = 42;
            this.btnCrearFamilia.Text = "Crear Familia";
            this.btnCrearFamilia.UseVisualStyleBackColor = false;
            this.btnCrearFamilia.Click += new System.EventHandler(this.btnCrearFamilia_Click);
            // 
            // btnAceptarConsultaFam
            // 
            this.btnAceptarConsultaFam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptarConsultaFam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnAceptarConsultaFam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptarConsultaFam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptarConsultaFam.ForeColor = System.Drawing.Color.White;
            this.btnAceptarConsultaFam.Location = new System.Drawing.Point(306, 325);
            this.btnAceptarConsultaFam.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnAceptarConsultaFam.Name = "btnAceptarConsultaFam";
            this.btnAceptarConsultaFam.Size = new System.Drawing.Size(95, 56);
            this.btnAceptarConsultaFam.TabIndex = 43;
            this.btnAceptarConsultaFam.Text = "Aceptar";
            this.btnAceptarConsultaFam.UseVisualStyleBackColor = false;
            this.btnAceptarConsultaFam.Click += new System.EventHandler(this.btnAceptarConsultaFam_Click);
            // 
            // btn_Cancelar_Consulta_Familia_Patente
            // 
            this.btn_Cancelar_Consulta_Familia_Patente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancelar_Consulta_Familia_Patente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btn_Cancelar_Consulta_Familia_Patente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar_Consulta_Familia_Patente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar_Consulta_Familia_Patente.ForeColor = System.Drawing.Color.White;
            this.btn_Cancelar_Consulta_Familia_Patente.Location = new System.Drawing.Point(424, 325);
            this.btn_Cancelar_Consulta_Familia_Patente.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btn_Cancelar_Consulta_Familia_Patente.Name = "btn_Cancelar_Consulta_Familia_Patente";
            this.btn_Cancelar_Consulta_Familia_Patente.Size = new System.Drawing.Size(95, 56);
            this.btn_Cancelar_Consulta_Familia_Patente.TabIndex = 44;
            this.btn_Cancelar_Consulta_Familia_Patente.Text = "Cancelar";
            this.btn_Cancelar_Consulta_Familia_Patente.UseVisualStyleBackColor = false;
            this.btn_Cancelar_Consulta_Familia_Patente.Click += new System.EventHandler(this.btn_Cancelar_Consulta_Familia_Patente_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(43, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 24);
            this.label2.TabIndex = 45;
            this.label2.Text = "Familias";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(302, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 24);
            this.label3.TabIndex = 46;
            this.label3.Text = "Patentes de Familia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(644, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 24);
            this.label4.TabIndex = 47;
            this.label4.Text = "Todas las Patentes";
            // 
            // btnPatente
            // 
            this.btnPatente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPatente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnPatente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatente.ForeColor = System.Drawing.Color.White;
            this.btnPatente.Location = new System.Drawing.Point(711, 40);
            this.btnPatente.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnPatente.Name = "btnPatente";
            this.btnPatente.Size = new System.Drawing.Size(174, 31);
            this.btnPatente.TabIndex = 48;
            this.btnPatente.Text = "Seleccionar Patente";
            this.btnPatente.UseVisualStyleBackColor = false;
            this.btnPatente.Click += new System.EventHandler(this.Patente_Click);
            // 
            // txtPat
            // 
            this.txtPat.Location = new System.Drawing.Point(648, 44);
            this.txtPat.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtPat.Name = "txtPat";
            this.txtPat.Size = new System.Drawing.Size(49, 23);
            this.txtPat.TabIndex = 49;
            // 
            // Consulta_Familia_Patente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 516);
            this.Controls.Add(this.txtPat);
            this.Controls.Add(this.btnPatente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Cancelar_Consulta_Familia_Patente);
            this.Controls.Add(this.btnAceptarConsultaFam);
            this.Controls.Add(this.btnCrearFamilia);
            this.Controls.Add(this.btnAgregarPatenteFamilia);
            this.Controls.Add(this.btnQuitarPatenteFamilia);
            this.Controls.Add(this.dgConsultaFamilias_Patentes);
            this.Controls.Add(this.dgConsultaFamilia_PatenteFamilias);
            this.Controls.Add(this.dgConsultaFamilia_Familias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminarFamilia);
            this.Controls.Add(this.txtFamiliaID);
            this.Controls.Add(this.btbBuscarFamilia);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Consulta_Familia_Patente";
            this.Text = "Consultar Familia Patente ";
            this.Load += new System.EventHandler(this.Consulta_Familia_Patente_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Ayuda);
            ((System.ComponentModel.ISupportInitialize)(this.dgConsultaFamilia_Familias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsultaFamilia_PatenteFamilias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsultaFamilias_Patentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgConsultaFamilia_Familias;
        private System.Windows.Forms.Button btbBuscarFamilia;
        private System.Windows.Forms.TextBox txtFamiliaID;
        private System.Windows.Forms.Button btnEliminarFamilia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgConsultaFamilia_PatenteFamilias;
        private System.Windows.Forms.DataGridView dgConsultaFamilias_Patentes;
        private System.Windows.Forms.Button btnQuitarPatenteFamilia;
        private System.Windows.Forms.Button btnAgregarPatenteFamilia;
        private System.Windows.Forms.Button btnCrearFamilia;
        private System.Windows.Forms.Button btnAceptarConsultaFam;
        private System.Windows.Forms.Button btn_Cancelar_Consulta_Familia_Patente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPatente;
        private System.Windows.Forms.TextBox txtPat;
    }
}

