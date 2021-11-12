namespace UI
{
    partial class Alta_Familia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alta_Familia));
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancelar_CrearFam = new System.Windows.Forms.Button();
            this.btnAceptar_CrearFam = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtCrearFam_NombreFamilia = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.titleBar = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.titleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(17, 58);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(237, 189);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 60;
            this.PictureBox1.TabStop = false;
            // 
            // btnCancelar_CrearFam
            // 
            this.btnCancelar_CrearFam.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar_CrearFam.FlatAppearance.BorderSize = 0;
            this.btnCancelar_CrearFam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar_CrearFam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar_CrearFam.ForeColor = System.Drawing.Color.White;
            this.btnCancelar_CrearFam.Location = new System.Drawing.Point(432, 170);
            this.btnCancelar_CrearFam.Name = "btnCancelar_CrearFam";
            this.btnCancelar_CrearFam.Size = new System.Drawing.Size(153, 49);
            this.btnCancelar_CrearFam.TabIndex = 59;
            this.btnCancelar_CrearFam.Text = "Cancelar";
            this.btnCancelar_CrearFam.UseVisualStyleBackColor = false;
            this.btnCancelar_CrearFam.Click += new System.EventHandler(this.btnCancelar_CrearFam_Click);
            // 
            // btnAceptar_CrearFam
            // 
            this.btnAceptar_CrearFam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnAceptar_CrearFam.FlatAppearance.BorderSize = 0;
            this.btnAceptar_CrearFam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar_CrearFam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar_CrearFam.ForeColor = System.Drawing.Color.White;
            this.btnAceptar_CrearFam.Location = new System.Drawing.Point(263, 170);
            this.btnAceptar_CrearFam.Name = "btnAceptar_CrearFam";
            this.btnAceptar_CrearFam.Size = new System.Drawing.Size(153, 49);
            this.btnAceptar_CrearFam.TabIndex = 58;
            this.btnAceptar_CrearFam.Text = "Aceptar";
            this.btnAceptar_CrearFam.UseVisualStyleBackColor = false;
            this.btnAceptar_CrearFam.Click += new System.EventHandler(this.btnAceptar_CrearFam_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label1.Location = new System.Drawing.Point(260, 108);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(95, 17);
            this.Label1.TabIndex = 47;
            this.Label1.Text = "Crear Familia:";
            // 
            // txtCrearFam_NombreFamilia
            // 
            this.txtCrearFam_NombreFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrearFam_NombreFamilia.Location = new System.Drawing.Point(260, 128);
            this.txtCrearFam_NombreFamilia.Name = "txtCrearFam_NombreFamilia";
            this.txtCrearFam_NombreFamilia.Size = new System.Drawing.Size(325, 23);
            this.txtCrearFam_NombreFamilia.TabIndex = 46;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(13, 9);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(112, 20);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Nueva  Familia";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(584, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(16, 16);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnClose.TabIndex = 11;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.titleBar.Controls.Add(this.Label2);
            this.titleBar.Controls.Add(this.btnClose);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(610, 40);
            this.titleBar.TabIndex = 45;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            // 
            // Alta_Familia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 276);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.btnCancelar_CrearFam);
            this.Controls.Add(this.btnAceptar_CrearFam);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtCrearFam_NombreFamilia);
            this.Controls.Add(this.titleBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Alta_Familia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alta Familia";
            this.Load += new System.EventHandler(this.Alta_Familia_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Ayuda);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Button btnCancelar_CrearFam;
        internal System.Windows.Forms.Button btnAceptar_CrearFam;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtCrearFam_NombreFamilia;
        private System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.PictureBox btnClose;
        internal System.Windows.Forms.Panel titleBar;
    }
}