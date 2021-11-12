using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Alta_Empleado : System.Windows.Forms.Form
    {
        public Alta_Empleado()
        {
            InitializeComponent();
        }
        #region Drag Form/ Mover-Arrastrar Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void FormCreateUser_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            cmbPosition.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //    if (txtPassword.Text == txtConfirmPass.Text && txtPassword.Text != "")
            //    {
            //        var userModel = new UserModel(
            //               idUser: 0, //user id is inserted automatically. We do not need to send a value.//id usuario se inserta automáticamente. No necesitamos enviar un valor
            //               loginName: txtUsername.Text,
            //               password: txtPassword.Text,
            //               firstName: txtFirstName.Text,
            //               lastName: txtLastName.Text,
            //               position: cmbPosition.Text,
            //               email: txtEmail.Text
            //            );
            //        string result = userModel.registerUser();
            //        MessageBox.Show(result);
            //        if (userModel.validUser == true)
            //            this.Close();
            //        else {
            //            txtUsername.Focus();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("the passwords do not match, do you want to try again?\n"+
            //            "las contraseñas no coinciden, ¿quieres intentarlo de nuevo?", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        txtPassword.Focus();
            //    }
        }
    }
}
