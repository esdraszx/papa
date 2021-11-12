namespace UI
{
    partial class Idioma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Idioma));
            this.lidioma = new System.Windows.Forms.Label();
            this.btnAceptarIdioma = new System.Windows.Forms.Button();
            this.titleBar = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.cbIdioma = new System.Windows.Forms.ComboBox();
            this.btn_Cancelar_Idioma = new System.Windows.Forms.Button();
            this.titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lidioma
            // 
            this.lidioma.AutoSize = true;
            this.lidioma.Location = new System.Drawing.Point(43, 52);
            this.lidioma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lidioma.Name = "lidioma";
            this.lidioma.Size = new System.Drawing.Size(60, 17);
            this.lidioma.TabIndex = 0;
            this.lidioma.Text = "Idiomas:";
            // 
            // btnAceptarIdioma
            // 
            this.btnAceptarIdioma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnAceptarIdioma.FlatAppearance.BorderSize = 0;
            this.btnAceptarIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptarIdioma.ForeColor = System.Drawing.Color.White;
            this.btnAceptarIdioma.Location = new System.Drawing.Point(38, 121);
            this.btnAceptarIdioma.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptarIdioma.Name = "btnAceptarIdioma";
            this.btnAceptarIdioma.Size = new System.Drawing.Size(203, 44);
            this.btnAceptarIdioma.TabIndex = 2;
            this.btnAceptarIdioma.Text = "Aceptar";
            this.btnAceptarIdioma.UseVisualStyleBackColor = false;
            this.btnAceptarIdioma.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.titleBar.Controls.Add(this.Label2);
            this.titleBar.Controls.Add(this.btnClose);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(279, 40);
            this.titleBar.TabIndex = 9;
            this.titleBar.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Ayuda);
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.Label2.Location = new System.Drawing.Point(13, 9);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(49, 17);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Idioma";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(253, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(16, 16);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnClose.TabIndex = 11;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbIdioma
            // 
            this.cbIdioma.FormattingEnabled = true;
            this.cbIdioma.Location = new System.Drawing.Point(38, 75);
            this.cbIdioma.Name = "cbIdioma";
            this.cbIdioma.Size = new System.Drawing.Size(203, 24);
            this.cbIdioma.TabIndex = 10;
            // 
            // btn_Cancelar_Idioma
            // 
            this.btn_Cancelar_Idioma.BackColor = System.Drawing.Color.Tomato;
            this.btn_Cancelar_Idioma.FlatAppearance.BorderSize = 0;
            this.btn_Cancelar_Idioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar_Idioma.ForeColor = System.Drawing.Color.White;
            this.btn_Cancelar_Idioma.Location = new System.Drawing.Point(38, 186);
            this.btn_Cancelar_Idioma.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cancelar_Idioma.Name = "btn_Cancelar_Idioma";
            this.btn_Cancelar_Idioma.Size = new System.Drawing.Size(203, 44);
            this.btn_Cancelar_Idioma.TabIndex = 11;
            this.btn_Cancelar_Idioma.Text = "Cancelar";
            this.btn_Cancelar_Idioma.UseVisualStyleBackColor = false;
            // 
            // Idioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 265);
            this.Controls.Add(this.btn_Cancelar_Idioma);
            this.Controls.Add(this.cbIdioma);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.btnAceptarIdioma);
            this.Controls.Add(this.lidioma);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Idioma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Idioma";
            this.Load += new System.EventHandler(this.FormIdioma_Load);
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lidioma;
        private System.Windows.Forms.Button btnAceptarIdioma;
        internal System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.ComboBox cbIdioma;
        private System.Windows.Forms.Button btn_Cancelar_Idioma;
    }
}