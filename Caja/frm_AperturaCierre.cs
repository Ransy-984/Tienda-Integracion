using Caja.DS_LoginTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caja
{
    public partial class frm_AperturaCierre : Form
    {
        // Objeto log4net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        AperturaCierreCaja1TableAdapter adapterApertura = new AperturaCierreCaja1TableAdapter();
        FacturasTableAdapter adapterFacturas = new FacturasTableAdapter();

        private double totalApertura = 0;
        public bool estadoCaja = false;


        public frm_AperturaCierre()
        {
            InitializeComponent();
        }

        #region Metodos para colocar valores por defecto en los campos
        private void eventoEnter(TextBox txt)
        {
            if (txt.Text.Trim() == "0")
                txt.Text = "";
        }

        private void eventoLeave(TextBox txt)
        {
            if (txt.Text.Trim() == "")
                txt.Text = 0.ToString();
        }
        #endregion

        #region Eventos enter campos
        private void txt1Peso_Enter(object sender, EventArgs e)
        {
            eventoEnter(txt1Peso);            
        }

        private void txt5Pesos_Enter(object sender, EventArgs e)
        {
            eventoEnter(txt5Pesos);            
        }

        private void txt10Pesos_Enter(object sender, EventArgs e)
        {
            eventoEnter(txt10Pesos);            
        }

        private void txt25Pesos_Enter(object sender, EventArgs e)
        {
            eventoEnter(txt25Pesos);            
        }

        private void txt50Pesos_Enter(object sender, EventArgs e)
        {
            eventoEnter(txt50Pesos);            
        }

        private void txt100Pesos_Enter(object sender, EventArgs e)
        {
            eventoEnter(txt100Pesos);            
        }

        private void txt200Pesos_Enter(object sender, EventArgs e)
        {
            eventoEnter(txt200Pesos);            
        }

        private void txt500Pesos_Enter(object sender, EventArgs e)
        {
            eventoEnter(txt500Pesos);            
        }

        private void txt1000Pesos_Enter(object sender, EventArgs e)
        {
            eventoEnter(txt1000Pesos);            
        }

        private void txt2000Pesos_Enter(object sender, EventArgs e)
        {
            eventoEnter(txt2000Pesos);
        }
        #endregion

        #region Eventos leave campos
        private void txt1Peso_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt1Peso);
            generarTotalApertura();
        }

        private void txt5Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt5Pesos);
            generarTotalApertura();
        }

        private void txt10Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt10Pesos);
            generarTotalApertura();
        }

        private void txt25Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt25Pesos);
            generarTotalApertura();
        }

        private void txt50Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt50Pesos);
            generarTotalApertura();
        }

        private void txt100Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt100Pesos);
            generarTotalApertura();
        }

        private void txt200Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt200Pesos);
            generarTotalApertura();
        }

        private void txt500Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt500Pesos);
            generarTotalApertura();
        }

        private void txt1000Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt1000Pesos);
            generarTotalApertura();
        }

        private void txt2000Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt2000Pesos);
            generarTotalApertura();
        }
        #endregion

        #region Eventos KeyPress
        private void txt1Peso_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txt5Pesos_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txt10Pesos_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txt25Pesos_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txt50Pesos_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txt100Pesos_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txt200Pesos_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txt500Pesos_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txt1000Pesos_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txt2000Pesos_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }
        #endregion

        // Generar total de apertura
        private void generarTotalApertura()
        {
            totalApertura = int.Parse(txt1Peso.Text) + 5*int.Parse(txt5Pesos.Text) + 10*int.Parse(txt10Pesos.Text) + 25*int.Parse(txt25Pesos.Text) + 50*int.Parse(txt50Pesos.Text) + 100*int.Parse(txt100Pesos.Text) + 200*int.Parse(txt200Pesos.Text) + 500*int.Parse(txt500Pesos.Text) + 1000*int.Parse(txt1000Pesos.Text) + 2000*int.Parse(txt2000Pesos.Text);

            txtTotalApertura.Text = totalApertura.ToString();
        }

        // Metodo para permitir solo el ingreso de numeros en los campos
        private void SoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        // Abrir caja
        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            try
            {
                #region Creacion de apertura
                adapterApertura.proc_AbrirCaja(Cache.UsuarioCache.IdUsuario, true, int.Parse(txt1Peso.Text), int.Parse(txt5Pesos.Text), int.Parse(txt10Pesos.Text), int.Parse(txt25Pesos.Text), int.Parse(txt50Pesos.Text), int.Parse(txt100Pesos.Text), int.Parse(txt200Pesos.Text), int.Parse(txt500Pesos.Text), int.Parse(txt1000Pesos.Text), int.Parse(txt2000Pesos.Text));
                estadoCaja = true; // La caja se abre
                LimpiarCampos();
                MessageBox.Show("Caja aperturada satisfactoriamente.", "Acción completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                log.Info("Caja aperturada.");
                #endregion

                #region Creacion Cierre de factura
                int IdFactura = int.Parse(adapterFacturas.proc_UltimaFactura().ToString()); // Se guarda el ID creado para la factura en curso
                adapterApertura.proc_CierreCaja(Cache.UsuarioCache.IdUsuario);
                #endregion
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show($"Error intentando aperturar la caja. Póngase en contacto con el administrador.\n\nDetalles del error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Limpiar campos
        private void LimpiarCampos()
        {
            txt1Peso.Text = "0";
            txt5Pesos.Text = "0";
            txt10Pesos.Text = "0";
            txt25Pesos.Text = "0";
            txt50Pesos.Text = "0";
            txt100Pesos.Text = "0";
            txt200Pesos.Text = "0";
            txt500Pesos.Text = "0";
            txt1000Pesos.Text = "0";
            txt2000Pesos.Text = "0";
            txtTotalApertura.Text = "0";
        }
    }
}
