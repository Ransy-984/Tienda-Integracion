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

namespace Caja
{
    public partial class frm_Principal : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg,int wparam, int lparam);

        // Objeto log4net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //public bool estadoCaja = false;
        frm_AperturaCierre frm_AperturaCierre = new frm_AperturaCierre();

        public frm_Principal()
        {
            InitializeComponent();
        }

        // Boton cerrar ventana
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea cerrar la aplicación?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                log.Info("Aplicación cerrada");
                Application.Exit();
            }
        }

        // Boton minimizar ventana
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Boton maximizar
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        // Boton restaurar
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        // Funcion para mover el formulario
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Boton cerrar sesion
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que desea cerrar sesión?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                log.Info("Sesión del usuario cerrada");
                this.Hide();
                frm_Login login = new frm_Login();
                login.Show();
            }
        }

        // Funcion load
        private void frm_Principal_Load(object sender, EventArgs e)
        {
            #region Privilegios
            switch(Cache.UsuarioCache.IdPerfil)
            {
                // Segmentacion de privilegios para cajero
                case 2:
                    btnCuadreTransacciones.Enabled = false;
                    btnReportes.Enabled = false;
                    break;
                default:
                    break;
            }
            #endregion

            #region Propiedades de usuario
            lblUsuario.Text = Cache.UsuarioCache.NombreUsuario;
            lblNombreApellido.Text = $"{Cache.UsuarioCache.Apellidos}, {Cache.UsuarioCache.Nombres}";
            
            switch(Cache.UsuarioCache.IdPerfil)
            {
                case 1:
                    lblRol.Text = "Administrador";
                    break;
                case 2:
                    lblRol.Text = "Cajero";
                    break;
                default:
                    break;
            }
            #endregion
        }

        // Funcion abrir form hijo
        private void AbrirFormHijo(object formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);

            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        // Boton abrir caja
        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new frm_AperturaCierre());
        }

        // Boton facturacion
        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            //if (frm_AperturaCierre.estadoCaja == true)
                AbrirFormHijo(new frm_Facturacion());
            //else
            //    MessageBox.Show("La caja está cerrada; para facturar, debe abrirla primero.", "Caja cerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
