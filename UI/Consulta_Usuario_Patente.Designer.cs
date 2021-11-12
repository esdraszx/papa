namespace UI
{
    partial class Consulta_Usuario_Patente
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
            this.dgFamiliasdeUsuario = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancelar_Consulta_Usuario_Patente = new System.Windows.Forms.Button();
            this.btnSacar_Patente_Usuario = new System.Windows.Forms.Button();
            this.TxtNombreUsuario = new System.Windows.Forms.TextBox();
            this.btnBuscarUsuario = new System.Windows.Forms.Button();
            this.btnAgregar_Patente_Usuario = new System.Windows.Forms.Button();
            this.btnSacar_Familia_Usuario = new System.Windows.Forms.Button();
            this.btnAgregar_Familia_Usuario = new System.Windows.Forms.Button();
            this.btn_Aceptar_Consulta_Usuario_Patente = new System.Windows.Forms.Button();
            this.dgFamilias = new System.Windows.Forms.DataGridView();
            this.dgPatentes = new System.Windows.Forms.DataGridView();
            this.dgPatentesdeUsuario = new System.Windows.Forms.DataGridView();
            this.dgUsuarios = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPatente = new System.Windows.Forms.Button();
            this.btnFamilia = new System.Windows.Forms.Button();
            this.txtId_Pat = new System.Windows.Forms.TextBox();
            this.txtId_Fam = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgFamiliasdeUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFamilias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatentesdeUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgFamiliasdeUsuario
            // 
            this.dgFamiliasdeUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFamiliasdeUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFamiliasdeUsuario.Location = new System.Drawing.Point(285, 289);
            this.dgFamiliasdeUsuario.Name = "dgFamiliasdeUsuario";
            this.dgFamiliasdeUsuario.Size = new System.Drawing.Size(126, 127);
            this.dgFamiliasdeUsuario.TabIndex = 38;
            this.dgFamiliasdeUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFamiliasdeUsuario_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(116, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 24);
            this.label1.TabIndex = 36;
            this.label1.Text = "ID_Usuario";
            // 
            // btn_Cancelar_Consulta_Usuario_Patente
            // 
            this.btn_Cancelar_Consulta_Usuario_Patente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancelar_Consulta_Usuario_Patente.BackColor = System.Drawing.Color.Tomato;
            this.btn_Cancelar_Consulta_Usuario_Patente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar_Consulta_Usuario_Patente.ForeColor = System.Drawing.Color.White;
            this.btn_Cancelar_Consulta_Usuario_Patente.Location = new System.Drawing.Point(612, 458);
            this.btn_Cancelar_Consulta_Usuario_Patente.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btn_Cancelar_Consulta_Usuario_Patente.Name = "btn_Cancelar_Consulta_Usuario_Patente";
            this.btn_Cancelar_Consulta_Usuario_Patente.Size = new System.Drawing.Size(134, 54);
            this.btn_Cancelar_Consulta_Usuario_Patente.TabIndex = 34;
            this.btn_Cancelar_Consulta_Usuario_Patente.Text = "Cancelar";
            this.btn_Cancelar_Consulta_Usuario_Patente.UseVisualStyleBackColor = false;
            this.btn_Cancelar_Consulta_Usuario_Patente.Click += new System.EventHandler(this.btn_Cancelar_Consulta_Usuario_Patente_Click);
            // 
            // btnSacar_Patente_Usuario
            // 
            this.btnSacar_Patente_Usuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSacar_Patente_Usuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnSacar_Patente_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSacar_Patente_Usuario.ForeColor = System.Drawing.Color.White;
            this.btnSacar_Patente_Usuario.Location = new System.Drawing.Point(441, 70);
            this.btnSacar_Patente_Usuario.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnSacar_Patente_Usuario.Name = "btnSacar_Patente_Usuario";
            this.btnSacar_Patente_Usuario.Size = new System.Drawing.Size(82, 39);
            this.btnSacar_Patente_Usuario.TabIndex = 32;
            this.btnSacar_Patente_Usuario.Text = ">";
            this.btnSacar_Patente_Usuario.UseVisualStyleBackColor = false;
            this.btnSacar_Patente_Usuario.Click += new System.EventHandler(this.btnSacar_Patente_Usuario_Click);
            // 
            // TxtNombreUsuario
            // 
            this.TxtNombreUsuario.Location = new System.Drawing.Point(305, 13);
            this.TxtNombreUsuario.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.TxtNombreUsuario.Name = "TxtNombreUsuario";
            this.TxtNombreUsuario.Size = new System.Drawing.Size(60, 20);
            this.TxtNombreUsuario.TabIndex = 31;
            this.TxtNombreUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnBuscarUsuario
            // 
            this.btnBuscarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnBuscarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnBuscarUsuario.Location = new System.Drawing.Point(345, 8);
            this.btnBuscarUsuario.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnBuscarUsuario.Name = "btnBuscarUsuario";
            this.btnBuscarUsuario.Size = new System.Drawing.Size(150, 29);
            this.btnBuscarUsuario.TabIndex = 30;
            this.btnBuscarUsuario.Text = "Seleccionar Usuario";
            this.btnBuscarUsuario.UseVisualStyleBackColor = false;
            this.btnBuscarUsuario.Click += new System.EventHandler(this.btnBuscarUsuario_Click);
            // 
            // btnAgregar_Patente_Usuario
            // 
            this.btnAgregar_Patente_Usuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar_Patente_Usuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnAgregar_Patente_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar_Patente_Usuario.ForeColor = System.Drawing.Color.White;
            this.btnAgregar_Patente_Usuario.Location = new System.Drawing.Point(441, 145);
            this.btnAgregar_Patente_Usuario.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnAgregar_Patente_Usuario.Name = "btnAgregar_Patente_Usuario";
            this.btnAgregar_Patente_Usuario.Size = new System.Drawing.Size(82, 42);
            this.btnAgregar_Patente_Usuario.TabIndex = 39;
            this.btnAgregar_Patente_Usuario.Text = "<";
            this.btnAgregar_Patente_Usuario.UseVisualStyleBackColor = false;
            this.btnAgregar_Patente_Usuario.Click += new System.EventHandler(this.btnAgregar_Patente_Usuario_Click);
            // 
            // btnSacar_Familia_Usuario
            // 
            this.btnSacar_Familia_Usuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSacar_Familia_Usuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnSacar_Familia_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSacar_Familia_Usuario.ForeColor = System.Drawing.Color.White;
            this.btnSacar_Familia_Usuario.Location = new System.Drawing.Point(441, 292);
            this.btnSacar_Familia_Usuario.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnSacar_Familia_Usuario.Name = "btnSacar_Familia_Usuario";
            this.btnSacar_Familia_Usuario.Size = new System.Drawing.Size(82, 40);
            this.btnSacar_Familia_Usuario.TabIndex = 40;
            this.btnSacar_Familia_Usuario.Text = ">";
            this.btnSacar_Familia_Usuario.UseVisualStyleBackColor = false;
            this.btnSacar_Familia_Usuario.Click += new System.EventHandler(this.btnSacar_Familia_Usuario_Click);
            // 
            // btnAgregar_Familia_Usuario
            // 
            this.btnAgregar_Familia_Usuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar_Familia_Usuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnAgregar_Familia_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar_Familia_Usuario.ForeColor = System.Drawing.Color.White;
            this.btnAgregar_Familia_Usuario.Location = new System.Drawing.Point(441, 362);
            this.btnAgregar_Familia_Usuario.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnAgregar_Familia_Usuario.Name = "btnAgregar_Familia_Usuario";
            this.btnAgregar_Familia_Usuario.Size = new System.Drawing.Size(82, 44);
            this.btnAgregar_Familia_Usuario.TabIndex = 41;
            this.btnAgregar_Familia_Usuario.Text = "<";
            this.btnAgregar_Familia_Usuario.UseVisualStyleBackColor = false;
            this.btnAgregar_Familia_Usuario.Click += new System.EventHandler(this.btnAgregar_Familia_Usuario_Click);
            // 
            // btn_Aceptar_Consulta_Usuario_Patente
            // 
            this.btn_Aceptar_Consulta_Usuario_Patente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Aceptar_Consulta_Usuario_Patente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btn_Aceptar_Consulta_Usuario_Patente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Aceptar_Consulta_Usuario_Patente.ForeColor = System.Drawing.Color.White;
            this.btn_Aceptar_Consulta_Usuario_Patente.Location = new System.Drawing.Point(285, 460);
            this.btn_Aceptar_Consulta_Usuario_Patente.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btn_Aceptar_Consulta_Usuario_Patente.Name = "btn_Aceptar_Consulta_Usuario_Patente";
            this.btn_Aceptar_Consulta_Usuario_Patente.Size = new System.Drawing.Size(126, 52);
            this.btn_Aceptar_Consulta_Usuario_Patente.TabIndex = 42;
            this.btn_Aceptar_Consulta_Usuario_Patente.Text = "Aceptar";
            this.btn_Aceptar_Consulta_Usuario_Patente.UseVisualStyleBackColor = false;
            this.btn_Aceptar_Consulta_Usuario_Patente.Click += new System.EventHandler(this.btn_Aceptar_Consulta_Usuario_Patente_Click);
            // 
            // dgFamilias
            // 
            this.dgFamilias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFamilias.Location = new System.Drawing.Point(658, 289);
            this.dgFamilias.Name = "dgFamilias";
            this.dgFamilias.Size = new System.Drawing.Size(134, 127);
            this.dgFamilias.TabIndex = 43;
            this.dgFamilias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFamilias_CellContentClick);
            // 
            // dgPatentes
            // 
            this.dgPatentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPatentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatentes.Location = new System.Drawing.Point(658, 72);
            this.dgPatentes.Name = "dgPatentes";
            this.dgPatentes.Size = new System.Drawing.Size(145, 134);
            this.dgPatentes.TabIndex = 44;
            this.dgPatentes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPatentes_CellContentClick);
            // 
            // dgPatentesdeUsuario
            // 
            this.dgPatentesdeUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPatentesdeUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatentesdeUsuario.Location = new System.Drawing.Point(285, 70);
            this.dgPatentesdeUsuario.Name = "dgPatentesdeUsuario";
            this.dgPatentesdeUsuario.Size = new System.Drawing.Size(126, 134);
            this.dgPatentesdeUsuario.TabIndex = 45;
            this.dgPatentesdeUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPatentesdeUsuario_CellContentClick);
            // 
            // dgUsuarios
            // 
            this.dgUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUsuarios.Location = new System.Drawing.Point(23, 81);
            this.dgUsuarios.Name = "dgUsuarios";
            this.dgUsuarios.Size = new System.Drawing.Size(176, 335);
            this.dgUsuarios.TabIndex = 46;
            this.dgUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUsuarios_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(284, 257);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 24);
            this.label2.TabIndex = 47;
            this.label2.Text = "Familias del Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(281, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 24);
            this.label3.TabIndex = 48;
            this.label3.Text = "Patentes del Usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(608, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 24);
            this.label4.TabIndex = 49;
            this.label4.Text = "Todas las Patentes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkGreen;
            this.label5.Location = new System.Drawing.Point(627, 227);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 24);
            this.label5.TabIndex = 50;
            this.label5.Text = "Todas las Familias";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkGreen;
            this.label6.Location = new System.Drawing.Point(19, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 24);
            this.label6.TabIndex = 51;
            this.label6.Text = "Lista Usuarios";
            // 
            // btnPatente
            // 
            this.btnPatente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPatente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnPatente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatente.ForeColor = System.Drawing.Color.White;
            this.btnPatente.Location = new System.Drawing.Point(589, 34);
            this.btnPatente.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnPatente.Name = "btnPatente";
            this.btnPatente.Size = new System.Drawing.Size(214, 29);
            this.btnPatente.TabIndex = 52;
            this.btnPatente.Text = "Seleccionar  ID_Patente";
            this.btnPatente.UseVisualStyleBackColor = false;
            this.btnPatente.Click += new System.EventHandler(this.btnPatente_Click);
            // 
            // btnFamilia
            // 
            this.btnFamilia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFamilia.ForeColor = System.Drawing.Color.White;
            this.btnFamilia.Location = new System.Drawing.Point(589, 252);
            this.btnFamilia.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnFamilia.Name = "btnFamilia";
            this.btnFamilia.Size = new System.Drawing.Size(203, 29);
            this.btnFamilia.TabIndex = 53;
            this.btnFamilia.Text = "Seleccionar ID_Familia";
            this.btnFamilia.UseVisualStyleBackColor = false;
            this.btnFamilia.Click += new System.EventHandler(this.btnFamilia_Click);
            // 
            // txtId_Pat
            // 
            this.txtId_Pat.Location = new System.Drawing.Point(612, 72);
            this.txtId_Pat.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtId_Pat.Name = "txtId_Pat";
            this.txtId_Pat.Size = new System.Drawing.Size(40, 20);
            this.txtId_Pat.TabIndex = 54;
            this.txtId_Pat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtId_Fam
            // 
            this.txtId_Fam.Location = new System.Drawing.Point(612, 289);
            this.txtId_Fam.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtId_Fam.Name = "txtId_Fam";
            this.txtId_Fam.Size = new System.Drawing.Size(40, 20);
            this.txtId_Fam.TabIndex = 55;
            this.txtId_Fam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Consulta_Usuario_Patente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 517);
            this.Controls.Add(this.txtId_Fam);
            this.Controls.Add(this.txtId_Pat);
            this.Controls.Add(this.btnFamilia);
            this.Controls.Add(this.btnPatente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgUsuarios);
            this.Controls.Add(this.dgPatentesdeUsuario);
            this.Controls.Add(this.dgPatentes);
            this.Controls.Add(this.dgFamilias);
            this.Controls.Add(this.btn_Aceptar_Consulta_Usuario_Patente);
            this.Controls.Add(this.btnAgregar_Familia_Usuario);
            this.Controls.Add(this.btnSacar_Familia_Usuario);
            this.Controls.Add(this.btnAgregar_Patente_Usuario);
            this.Controls.Add(this.dgFamiliasdeUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancelar_Consulta_Usuario_Patente);
            this.Controls.Add(this.btnSacar_Patente_Usuario);
            this.Controls.Add(this.TxtNombreUsuario);
            this.Controls.Add(this.btnBuscarUsuario);
            this.Name = "Consulta_Usuario_Patente";
            this.Text = "Consulta Usuarios y Patentes";
            this.Load += new System.EventHandler(this.Consulta_Usuario_Patente_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Ayuda);
            ((System.ComponentModel.ISupportInitialize)(this.dgFamiliasdeUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFamilias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatentesdeUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgFamiliasdeUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancelar_Consulta_Usuario_Patente;
        private System.Windows.Forms.Button btnSacar_Patente_Usuario;
        private System.Windows.Forms.TextBox TxtNombreUsuario;
        private System.Windows.Forms.Button btnBuscarUsuario;
        private System.Windows.Forms.Button btnAgregar_Patente_Usuario;
        private System.Windows.Forms.Button btnSacar_Familia_Usuario;
        private System.Windows.Forms.Button btnAgregar_Familia_Usuario;
        private System.Windows.Forms.Button btn_Aceptar_Consulta_Usuario_Patente;
        private System.Windows.Forms.DataGridView dgFamilias;
        private System.Windows.Forms.DataGridView dgPatentes;
        private System.Windows.Forms.DataGridView dgPatentesdeUsuario;
        private System.Windows.Forms.DataGridView dgUsuarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPatente;
        private System.Windows.Forms.Button btnFamilia;
        private System.Windows.Forms.TextBox txtId_Pat;
        private System.Windows.Forms.TextBox txtId_Fam;
    }
}