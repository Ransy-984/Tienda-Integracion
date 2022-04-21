using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Caja.DS_LoginTableAdapters;

namespace Caja
{
    public partial class frm_Login : Form
    {
        // Librerías para mover el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        // Objeto log4net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frm_Login()
        {
            InitializeComponent();
        }
        
        // Evento load del Login
        private void frm_Login_Load(object sender, EventArgs e)
        {
            log.Info("Login iniciado");
        }

        // Boton cerrar ventana
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            log.Info("Cierre de la pantalla de Login");
            Application.Exit();
        }

        // Minimizar ventana
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Boton ver contraseña
        private void btnVerPassword_Click(object sender, EventArgs e)
        {
            PasswordChar();
        }

        // Funcion para ver la contraseña
        private void PasswordChar()
        {
            if (txtPassword.UseSystemPasswordChar == true)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }

        // Funcion para limpiar campos
        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtPassword.Clear();

            txtUsuario.Text = "Usuario";
            txtUsuario.ForeColor = Color.Gray;
            PasswordChar();
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Text = "Contraseña";
            
            txtUsuario.Focus();
        }

        // Boton inicar sesion
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() == "" || txtUsuario.Text.Trim() == "Usuario")
            {
                lblAlertaUsuario.Text = "Ingrese su nombre de usuario";
                txtUsuario.Focus();
            }
            else
            {
                if (txtPassword.Text.Trim() == "" || txtPassword.Text.Trim() == "Contraseña")
                {
                    lblAlertaPassword.Text = "Ingrese su contraseña";
                    txtPassword.Focus();
                }
                else // Inicio de sesión
                {
                    try
                    {
                        UsuariosTableAdapter adapter = new UsuariosTableAdapter();
                        DataTable tabla = adapter.GetDataByLogin(txtUsuario.Text, txtPassword.Text);

                        if (tabla.Rows.Count > 0)
                        {
                            #region Asignacion de propiedades segun el usuario
                            Cache.UsuarioCache.IdUsuario = int.Parse(tabla.Rows[0][0].ToString());
                            Cache.UsuarioCache.IdPerfil = int.Parse(tabla.Rows[0][1].ToString());
                            Cache.UsuarioCache.Nombres = tabla.Rows[0][2].ToString();
                            Cache.UsuarioCache.Apellidos = tabla.Rows[0][3].ToString();
                            Cache.UsuarioCache.Email = tabla.Rows[0][4].ToString();
                            Cache.UsuarioCache.NombreUsuario = tabla.Rows[0][5].ToString();
                            Cache.UsuarioCache.Telefono = tabla.Rows[0][7].ToString();
                            #endregion

                            log.Info("Sesión iniciada");
                            frm_Principal FormPrincipal = new frm_Principal();
                            this.Hide();
                            FormPrincipal.Show();
                        }
                        else
                        {
                            MessageBox.Show("El usuario o contraseña ingresados son inválidos. Intente nuevamente.", "Acceso inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LimpiarCampos();
                            log.Error("Intento de acceso son credenciales inválidas");
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex.Message);
                        MessageBox.Show("ERROR: " + ex);
                    }
                }
            }
        }

        #region Eventos usabilidad txtUsuario
        // Evento enter txtUsuario
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() == "Usuario")
            {
                txtUsuario.Clear();
                txtUsuario.ForeColor = Color.Black;
            }
        }

        // Evento leave txtUsuario
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.Gray;
            }
        }
        #endregion

        #region Eventos usabilidad txtPassword
        // Evento enter txtPassword
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "Contraseña")
            {
                PasswordChar();
                txtPassword.Clear();
                txtPassword.ForeColor = Color.Black;
            }
        }

        // Evento leave txtPassword
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "")
            {
                PasswordChar();
                txtPassword.ForeColor = Color.Gray;
                txtPassword.Text = "Contraseña";
            }
        }
        #endregion

        // Evento mousedown del formulario
        private void frm_Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

    }
}
