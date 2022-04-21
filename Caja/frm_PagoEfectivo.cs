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
    public partial class frm_PagoEfectivo : Form
    {
        // Objeto log4net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        double totalSuministrado = 0;
        

        //Adapters
        FacturasTableAdapter adapterFacturas = new FacturasTableAdapter();
        AperturaCierreCaja1TableAdapter adapterAperturaCierre = new AperturaCierreCaja1TableAdapter();
        MovimientosCajaTableAdapter adapterMovimientosCaja = new MovimientosCajaTableAdapter();

        public frm_PagoEfectivo()
        {
            InitializeComponent();
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
        }

        // Metodo para permitir solo el ingreso de numeros en los campos
        private void SoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
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

        #region Eventos enter
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

        #region Eventos leave
        private void txt1Peso_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt1Peso);
            generarTotalSuministrado();
        }

        private void txt5Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt5Pesos);
            generarTotalSuministrado();
        }

        private void txt10Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt10Pesos);
            generarTotalSuministrado();
        }

        private void txt25Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt25Pesos);
            generarTotalSuministrado();
        }

        private void txt50Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt50Pesos);
            generarTotalSuministrado();
        }

        private void txt100Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt100Pesos);
            generarTotalSuministrado();
        }

        private void txt200Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt200Pesos);
            generarTotalSuministrado();
        }

        private void txt500Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt500Pesos);
            generarTotalSuministrado();
        }

        private void txt1000Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt1000Pesos);
            generarTotalSuministrado();
        }

        private void txt2000Pesos_Leave(object sender, EventArgs e)
        {
            eventoLeave(txt2000Pesos);
            generarTotalSuministrado();
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

        // Generar total efectivo suministrado
        private void generarTotalSuministrado()
        {
            totalSuministrado = int.Parse(txt1Peso.Text) + 5 * int.Parse(txt5Pesos.Text) + 10 * int.Parse(txt10Pesos.Text) + 25 * int.Parse(txt25Pesos.Text) + 50 * int.Parse(txt50Pesos.Text) + 100 * int.Parse(txt100Pesos.Text) + 200 * int.Parse(txt200Pesos.Text) + 500 * int.Parse(txt500Pesos.Text) + 1000 * int.Parse(txt1000Pesos.Text) + 2000 * int.Parse(txt2000Pesos.Text);

            lblTotalSuministrado.Text = totalSuministrado.ToString();
        }

        // Funcion load
        private void frm_PagoEfectivo_Load(object sender, EventArgs e)
        {
            int IdFactura = int.Parse(adapterFacturas.proc_UltimaFactura().ToString()); // Se guarda el ID creado para la factura en curso

            double TotalBruto = double.Parse(adapterFacturas.proc_MostrarTotalBruto(IdFactura).ToString());
            double TotalITBIS = double.Parse(adapterFacturas.proc_MostrarTotalITBIS(IdFactura).ToString());
            double TotalNeto = double.Parse(adapterFacturas.proc_MostrarTotalPagar(IdFactura).ToString());

            lblSubtotal.Text = TotalBruto.ToString();
            lblITBIS.Text = TotalITBIS.ToString();
            lblTotalPagar.Text = TotalNeto.ToString();
            log.Info("Formulario de pago en efectivo abierto");
        }

        // Boton pagar
        private void btnPagar_Click(object sender, EventArgs e)
        {
            // Si lo provisto por el cliente es suficiente para saldar la cuenta, se hace,
            // de lo contrario, no procesa el pago.
            if (double.Parse(lblTotalSuministrado.Text) >= double.Parse(lblTotalPagar.Text))
            {
                gbInsertarEfectivo.Visible = false;
                gbDevuelta.Visible = true;

                // Se insertan los billetes recibidos por el cliente
                adapterAperturaCierre.proc_ActualizarBilletes(int.Parse(adapterAperturaCierre.proc_ObtenerIDAperturaCierre().ToString()), Cache.UsuarioCache.IdUsuario, true, int.Parse(txt1Peso.Text), int.Parse(txt5Pesos.Text), int.Parse(txt10Pesos.Text), int.Parse(txt25Pesos.Text), int.Parse(txt50Pesos.Text), int.Parse(txt100Pesos.Text), int.Parse(txt200Pesos.Text), int.Parse(txt500Pesos.Text), int.Parse(txt1000Pesos.Text), int.Parse(txt2000Pesos.Text));

                // Actualizar movimientos de la caja (entrada)
                adapterMovimientosCaja.proc_MovimientosCaja(int.Parse(adapterAperturaCierre.proc_ObtenerIDAperturaCierre().ToString()), Cache.UsuarioCache.IdUsuario, true, int.Parse(adapterFacturas.proc_UltimaFactura().ToString()), "Efectivo", 0);

                #region Devolucion de billtes y/o monedas
                double devuelta = int.Parse(lblTotalSuministrado.Text) - int.Parse(lblTotalPagar.Text);

                short[] arMonedas = { 2000, 1000, 500, 200, 100, 50, 25, 10, 5, 1 };
                short[] armonedaDevolucion = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                for (int i = 0; i < 10; i++)
                {
                    while (devuelta - arMonedas[i] >= 0)
                    {
                        armonedaDevolucion[i]++;
                        devuelta -= arMonedas[i];

                        if (devuelta == 0)
                            break;
                    }
                }

                DOP1.Text = armonedaDevolucion[9].ToString();
                DOP5.Text = armonedaDevolucion[8].ToString();
                DOP10.Text = armonedaDevolucion[7].ToString();
                DOP25.Text = armonedaDevolucion[6].ToString();
                DOP50.Text = armonedaDevolucion[5].ToString();
                DOP100.Text = armonedaDevolucion[4].ToString();
                DOP200.Text = armonedaDevolucion[3].ToString();
                DOP500.Text = armonedaDevolucion[2].ToString();
                DOP1000.Text = armonedaDevolucion[1].ToString();
                DOP2000.Text = armonedaDevolucion[0].ToString();
                #endregion

                // Actualizar billetes en la caja
                adapterAperturaCierre.proc_ActualizarBilletes(int.Parse(adapterAperturaCierre.proc_ObtenerIDAperturaCierre().ToString()), Cache.UsuarioCache.IdUsuario, false, int.Parse(DOP1.Text), int.Parse(DOP5.Text), int.Parse(DOP10.Text), int.Parse(DOP25.Text), int.Parse(DOP50.Text), int.Parse(DOP100.Text), int.Parse(DOP200.Text), int.Parse(DOP500.Text), int.Parse(DOP1000.Text), int.Parse(DOP2000.Text));

                // Actualizar movimientos de la caja (salida)
                adapterMovimientosCaja.proc_MovimientosCaja(int.Parse(adapterAperturaCierre.proc_ObtenerIDAperturaCierre().ToString()), Cache.UsuarioCache.IdUsuario, false, int.Parse(adapterFacturas.proc_UltimaFactura().ToString()), "Efectivo", 0);

                MessageBox.Show("El pago ha sido procesado satisfactoriamente.", "Acción completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                log.Info("Pago en efectivo realizado");
            }
            else
            {
                MessageBox.Show("El efectivo recibido es insuficiente para saldar la cuenta.", "Efectivo insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Info("Monto insuficiente para pagar");
            }
        }

    }
}
