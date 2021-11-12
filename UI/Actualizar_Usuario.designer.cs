namespace UI
{
    partial class Actualizar_Usuario
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
            this.components = new System.ComponentModel.Container();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnCerrar = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.lbDNI = new System.Windows.Forms.Label();
            this.btn_Cancelar_Actualizar_Usuario = new System.Windows.Forms.Button();
            this.btnActualizar_Usuario_Aceptar = new System.Windows.Forms.Button();
            this.Label11 = new System.Windows.Forms.Label();
            this.linkEditProfile = new System.Windows.Forms.LinkLabel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LinkEditPass = new System.Windows.Forms.LinkLabel();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPalabraRestitucion = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.dgConsultaUsuario = new System.Windows.Forms.DataGridView();
            this.txt_ConsultaUsuario_DNI = new System.Windows.Forms.TextBox();
            this.txt_ConsultaUsuario_ID = new System.Windows.Forms.TextBox();
            this.btn_ConsultarUsuario_Consultar = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsultaUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer1
            // 
            this.Timer1.Interval = 10;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Ebrima", 12F);
            this.btnCerrar.ForeColor = System.Drawing.Color.DimGray;
            this.btnCerrar.Location = new System.Drawing.Point(0, 0);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(47, 43);
            this.btnCerrar.TabIndex = 36;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label6.Location = new System.Drawing.Point(227, 75);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(86, 18);
            this.Label6.TabIndex = 28;
            this.Label6.Text = "ID_Usuario:";
            // 
            // lbDNI
            // 
            this.lbDNI.AutoSize = true;
            this.lbDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDNI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbDNI.Location = new System.Drawing.Point(227, 129);
            this.lbDNI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDNI.Name = "lbDNI";
            this.lbDNI.Size = new System.Drawing.Size(37, 18);
            this.lbDNI.TabIndex = 29;
            this.lbDNI.Text = "DNI:";
            this.lbDNI.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_Cancelar_Actualizar_Usuario
            // 
            this.btn_Cancelar_Actualizar_Usuario.BackColor = System.Drawing.Color.DarkGray;
            this.btn_Cancelar_Actualizar_Usuario.FlatAppearance.BorderSize = 0;
            this.btn_Cancelar_Actualizar_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar_Actualizar_Usuario.ForeColor = System.Drawing.Color.White;
            this.btn_Cancelar_Actualizar_Usuario.Location = new System.Drawing.Point(226, 491);
            this.btn_Cancelar_Actualizar_Usuario.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cancelar_Actualizar_Usuario.Name = "btn_Cancelar_Actualizar_Usuario";
            this.btn_Cancelar_Actualizar_Usuario.Size = new System.Drawing.Size(163, 46);
            this.btn_Cancelar_Actualizar_Usuario.TabIndex = 24;
            this.btn_Cancelar_Actualizar_Usuario.Text = "Cancelar";
            this.btn_Cancelar_Actualizar_Usuario.UseVisualStyleBackColor = false;
            this.btn_Cancelar_Actualizar_Usuario.Click += new System.EventHandler(this.btn_Cancelar_Actualizar_Usuario_Click);
            // 
            // btnActualizar_Usuario_Aceptar
            // 
            this.btnActualizar_Usuario_Aceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnActualizar_Usuario_Aceptar.FlatAppearance.BorderSize = 0;
            this.btnActualizar_Usuario_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar_Usuario_Aceptar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar_Usuario_Aceptar.Location = new System.Drawing.Point(51, 491);
            this.btnActualizar_Usuario_Aceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizar_Usuario_Aceptar.Name = "btnActualizar_Usuario_Aceptar";
            this.btnActualizar_Usuario_Aceptar.Size = new System.Drawing.Size(164, 46);
            this.btnActualizar_Usuario_Aceptar.TabIndex = 23;
            this.btnActualizar_Usuario_Aceptar.Text = "Aceptar";
            this.btnActualizar_Usuario_Aceptar.UseVisualStyleBackColor = false;
            this.btnActualizar_Usuario_Aceptar.Click += new System.EventHandler(this.btnActualizar_Usuario_Aceptar_Click);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.ForeColor = System.Drawing.Color.White;
            this.Label11.Location = new System.Drawing.Point(46, 2);
            this.Label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(134, 31);
            this.Label11.TabIndex = 23;
            this.Label11.Text = "Actualizar";
            // 
            // linkEditProfile
            // 
            this.linkEditProfile.ActiveLinkColor = System.Drawing.Color.White;
            this.linkEditProfile.AutoSize = true;
            this.linkEditProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkEditProfile.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.linkEditProfile.Location = new System.Drawing.Point(227, 260);
            this.linkEditProfile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkEditProfile.Name = "linkEditProfile";
            this.linkEditProfile.Size = new System.Drawing.Size(123, 17);
            this.linkEditProfile.TabIndex = 37;
            this.linkEditProfile.TabStop = true;
            this.linkEditProfile.Text = "Actualizar Usuario";
            this.linkEditProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEditProfile_LinkClicked);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.Panel1.Controls.Add(this.label9);
            this.Panel1.Controls.Add(this.txtDNI);
            this.Panel1.Controls.Add(this.txtDireccion);
            this.Panel1.Controls.Add(this.label3);
            this.Panel1.Controls.Add(this.LinkEditPass);
            this.Panel1.Controls.Add(this.btn_Cancelar_Actualizar_Usuario);
            this.Panel1.Controls.Add(this.btnActualizar_Usuario_Aceptar);
            this.Panel1.Controls.Add(this.Label11);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.txtNombreUsuario);
            this.Panel1.Controls.Add(this.txtTelefono);
            this.Panel1.Controls.Add(this.label10);
            this.Panel1.Controls.Add(this.label2);
            this.Panel1.Controls.Add(this.txtEmail);
            this.Panel1.Controls.Add(this.txtPalabraRestitucion);
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Controls.Add(this.label13);
            this.Panel1.Controls.Add(this.txtApellido);
            this.Panel1.Controls.Add(this.txtNombre);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel1.Location = new System.Drawing.Point(594, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(437, 550);
            this.Panel1.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(48, 208);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 17);
            this.label9.TabIndex = 29;
            this.label9.Text = "DNI:";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(52, 233);
            this.txtDNI.Margin = new System.Windows.Forms.Padding(4);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(337, 23);
            this.txtDNI.TabIndex = 28;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(52, 338);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(337, 23);
            this.txtDireccion.TabIndex = 26;
            this.txtDireccion.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(48, 313);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Dirección:";
            // 
            // LinkEditPass
            // 
            this.LinkEditPass.ActiveLinkColor = System.Drawing.Color.White;
            this.LinkEditPass.AutoSize = true;
            this.LinkEditPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LinkEditPass.LinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.LinkEditPass.Location = new System.Drawing.Point(129, 371);
            this.LinkEditPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LinkEditPass.Name = "LinkEditPass";
            this.LinkEditPass.Size = new System.Drawing.Size(32, 17);
            this.LinkEditPass.TabIndex = 25;
            this.LinkEditPass.TabStop = true;
            this.LinkEditPass.Text = "Edit";
            this.LinkEditPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkEditPass_LinkClicked);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(48, 43);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(111, 17);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "NombreUsuario:";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(52, 68);
            this.txtNombreUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(337, 23);
            this.txtNombreUsuario.TabIndex = 0;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(52, 395);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(337, 23);
            this.txtTelefono.TabIndex = 2;
            this.txtTelefono.UseSystemPasswordChar = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(48, 260);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 17);
            this.label10.TabIndex = 11;
            this.label10.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(48, 371);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tetlefono:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(52, 285);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(337, 23);
            this.txtEmail.TabIndex = 10;
            // 
            // txtPalabraRestitucion
            // 
            this.txtPalabraRestitucion.Location = new System.Drawing.Point(52, 452);
            this.txtPalabraRestitucion.Margin = new System.Windows.Forms.Padding(4);
            this.txtPalabraRestitucion.Name = "txtPalabraRestitucion";
            this.txtPalabraRestitucion.Size = new System.Drawing.Size(337, 23);
            this.txtPalabraRestitucion.TabIndex = 4;
            this.txtPalabraRestitucion.UseSystemPasswordChar = true;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.ForeColor = System.Drawing.Color.White;
            this.Label5.Location = new System.Drawing.Point(48, 156);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(62, 17);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "Apellido:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(48, 427);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 17);
            this.label13.TabIndex = 5;
            this.label13.Text = "Palabra de restitución:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(52, 181);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(337, 23);
            this.txtApellido.TabIndex = 8;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(52, 124);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(337, 23);
            this.txtNombre.TabIndex = 6;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(48, 100);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(62, 17);
            this.Label4.TabIndex = 7;
            this.Label4.Text = "Nombre:";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::UI.Properties.Resources.Usuario;
            this.PictureBox1.Location = new System.Drawing.Point(13, 75);
            this.PictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(206, 233);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 25;
            this.PictureBox1.TabStop = false;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Label7.Location = new System.Drawing.Point(89, 12);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(108, 31);
            this.Label7.TabIndex = 26;
            this.Label7.Text = "Usuario";
            // 
            // dgConsultaUsuario
            // 
            this.dgConsultaUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConsultaUsuario.Location = new System.Drawing.Point(396, 68);
            this.dgConsultaUsuario.Name = "dgConsultaUsuario";
            this.dgConsultaUsuario.Size = new System.Drawing.Size(182, 469);
            this.dgConsultaUsuario.TabIndex = 38;
            this.dgConsultaUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgConsultaUsuario_CellContentClick);
            // 
            // txt_ConsultaUsuario_DNI
            // 
            this.txt_ConsultaUsuario_DNI.Location = new System.Drawing.Point(226, 150);
            this.txt_ConsultaUsuario_DNI.Name = "txt_ConsultaUsuario_DNI";
            this.txt_ConsultaUsuario_DNI.Size = new System.Drawing.Size(154, 23);
            this.txt_ConsultaUsuario_DNI.TabIndex = 39;
            // 
            // txt_ConsultaUsuario_ID
            // 
            this.txt_ConsultaUsuario_ID.Location = new System.Drawing.Point(230, 97);
            this.txt_ConsultaUsuario_ID.Name = "txt_ConsultaUsuario_ID";
            this.txt_ConsultaUsuario_ID.Size = new System.Drawing.Size(150, 23);
            this.txt_ConsultaUsuario_ID.TabIndex = 40;
            // 
            // btn_ConsultarUsuario_Consultar
            // 
            this.btn_ConsultarUsuario_Consultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btn_ConsultarUsuario_Consultar.FlatAppearance.BorderSize = 0;
            this.btn_ConsultarUsuario_Consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ConsultarUsuario_Consultar.ForeColor = System.Drawing.Color.White;
            this.btn_ConsultarUsuario_Consultar.Location = new System.Drawing.Point(226, 193);
            this.btn_ConsultarUsuario_Consultar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ConsultarUsuario_Consultar.Name = "btn_ConsultarUsuario_Consultar";
            this.btn_ConsultarUsuario_Consultar.Size = new System.Drawing.Size(154, 46);
            this.btn_ConsultarUsuario_Consultar.TabIndex = 30;
            this.btn_ConsultarUsuario_Consultar.Text = "Consultar";
            this.btn_ConsultarUsuario_Consultar.UseVisualStyleBackColor = false;
            this.btn_ConsultarUsuario_Consultar.Click += new System.EventHandler(this.btn_ConsultarUsuario_Consultar_Click);
            // 
            // Actualizar_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 550);
            this.Controls.Add(this.btn_ConsultarUsuario_Consultar);
            this.Controls.Add(this.txt_ConsultaUsuario_ID);
            this.Controls.Add(this.txt_ConsultaUsuario_DNI);
            this.Controls.Add(this.dgConsultaUsuario);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.lbDNI);
            this.Controls.Add(this.linkEditProfile);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Label7);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Actualizar_Usuario";
            this.Text = "Actualizar Usuario";
            this.Load += new System.EventHandler(this.Actualizar_Usuario_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsultaUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Timer Timer1;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label lbDNI;
        internal System.Windows.Forms.Button btn_Cancelar_Actualizar_Usuario;
        internal System.Windows.Forms.Button btnActualizar_Usuario_Aceptar;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.LinkLabel linkEditProfile;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtNombreUsuario;
        internal System.Windows.Forms.TextBox txtTelefono;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtEmail;
        internal System.Windows.Forms.TextBox txtPalabraRestitucion;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox txtApellido;
        internal System.Windows.Forms.TextBox txtNombre;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtDireccion;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.LinkLabel LinkEditPass;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.DataGridView dgConsultaUsuario;
        private System.Windows.Forms.TextBox txt_ConsultaUsuario_DNI;
        private System.Windows.Forms.TextBox txt_ConsultaUsuario_ID;
        internal System.Windows.Forms.Button btn_ConsultarUsuario_Consultar;
    }
}