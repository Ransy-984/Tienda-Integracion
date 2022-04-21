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
    public partial class frm_PagoTarjeta : Form
    {
        // Objeto log4net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        FacturasTableAdapter adapterFacturas = new FacturasTableAdapter();
        AperturaCierreCaja1TableAdapter adapterAperturaCierre = new AperturaCierreCaja1TableAdapter();
        MovimientosCajaTableAdapter adapterMovimientosCaja = new MovimientosCajaTableAdapter();

        frm_Facturacion facturacion = new frm_Facturacion();
        int IdFactura;
        
        public frm_PagoTarjeta()
        {
            InitializeComponent();
        }

        // Metodo para permitir solo el ingreso de numeros en los campos
        private void SoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }


        // Funcion load
        private void frm_PagoTarjeta_Load(object sender, EventArgs e)
        {
            IdFactura = int.Parse(adapterFacturas.proc_UltimaFactura().ToString()); // Se guarda el ID creado para la factura en curso
        }

        // Cancelar pago
        private void btnCancelarPago_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cancelar el pago?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                log.Info("Pago cancelado");
                this.Hide();
            }
        }

        // Boton pagar
        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTarjeta.Text.Trim().Length == 16)
                {
                    FacturasTableAdapter adapterFacturas = new FacturasTableAdapter();
                    adapterFacturas.proc_ActualizarEstadoPagoFactura(facturacion.IdFactura);

                    // Actualizar movimientos de la caja (entrada)
                    adapterMovimientosCaja.proc_MovimientosCaja(int.Parse(adapterAperturaCierre.proc_ObtenerIDAperturaCierre().ToString()), Cache.UsuarioCache.IdUsuario, true, int.Parse(adapterFacturas.proc_UltimaFactura().ToString()), "Tarjeta", decimal.Parse(adapterFacturas.proc_MostrarTotalBruto(IdFactura).ToString()));

                    MessageBox.Show("El pago ha sido procesado satisfactoriamente.", "Acción completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    log.Info("Pago con tarjeta realizado");

                    facturacion.estadoFacturacion = false;
                    facturacion.ControlesFacturacion();
                    this.Hide();
                }
                else
                    MessageBox.Show("Ingrese un número de tarjeta con 16 números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                log.Error(ex.Message);
            }
        }

        // Evento keypress
        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }
    }
}
