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
    public partial class frm_Facturacion : Form
    {
        // Objeto log4net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        DataTable tabla = new DataTable();
        public int IdFactura;
        public double TotalBruto, TotalITBIS, TotalNeto;
        string MetodoPago;
        public bool estadoFacturacion = false;

        // Adapters
        ClientesTableAdapter adapterClientes = new ClientesTableAdapter();
        FacturasTableAdapter adapterFacturas = new FacturasTableAdapter();
        FacturaDetalleTableAdapter adapterDetalleFactura = new FacturaDetalleTableAdapter();
        ProductosTableAdapter adapterProductos = new ProductosTableAdapter();

        public frm_Facturacion()
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

        #region Eventos KeyPress
        private void txtIDCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtCantidadProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }
        #endregion
        
        // Controles de facturacion
        public void ControlesFacturacion()
        {
            /* Si hay una factura creada, se deshabilita el panel para crear una factura y se habilita el panel
            para el detalle de factura, de lo contrario, se hace la operación inversa y se limpian los campos.*/
            switch (estadoFacturacion)
            {
                case true:
                    panelNuevaFactura.Enabled = false;
                    panelDetalleFactura.Enabled = true;
                    break;
                case false:
                    panelNuevaFactura.Enabled = true;
                    panelDetalleFactura.Enabled = false;
                    LimpiarCampos();
                    break;
                default:
                    break;
            }
        }

        // Funcion Load
        private void frm_Facturacion_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS_Login.FacturaDetalle' table. You can move, or remove it, as needed.
            this.facturaDetalleTableAdapter.Fill(this.dS_Login.FacturaDetalle);
            // TODO: This line of code loads data into the 'dS_Login.Usuarios' table. You can move, or remove it, as needed.
            this.usuariosTableAdapter.Fill(this.dS_Login.Usuarios);
        }

        // Boton nueva factura
        private void btnNuevaFactura_Click(object sender, EventArgs e)
        {
            if (txtIDCliente.Text.Trim() != "" && cmbMetodoPago.Text.Trim() != "" && cmbTipoFactura.Text.Trim() != "")
            {
                try
                {
                    // Se llena el datatable con la información del cliente
                    tabla = adapterClientes.GetDataByClientes(int.Parse(txtIDCliente.Text));

                    // Si retorna filas, entonces el cliente existe y se puede facturar
                    if (tabla.Rows.Count > 0)
                    {
                        #region Crear nueva factura
                        estadoFacturacion = true;
                        string RNC = tabla.Rows[0][5].ToString();
                        MetodoPago = cmbMetodoPago.Text.Trim();

                        adapterFacturas.proc_InsertarFactura(int.Parse(txtIDCliente.Text), Cache.UsuarioCache.IdUsuario, cmbTipoFactura.Text.Trim(), "Principal", RNC, cmbMetodoPago.Text.Trim());
                        MessageBox.Show("Factura iniciada satisfactoriamente.", "Acción completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ControlesFacturacion();
                        
                        log.Info("Nueva factura creada");
                        tabla.Rows.Clear(); // Insertada la informacion, se elimina la data del datatable
                        IdFactura = int.Parse(adapterFacturas.proc_UltimaFactura().ToString()); // Se guarda el ID creado para la factura en curso
                        #endregion

                        // Si el método de pago es distinto de 'Diferido', se actualiza el estado de pago de la factura
                        if (cmbMetodoPago.Text.Trim() != "Diferido")
                            adapterFacturas.proc_ActualizarEstadoPagoFactura(IdFactura);
                    }
                    else
                    {
                        MessageBox.Show("El ID ingresado no pertenece a ningún cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        log.Error("ID erróneo ingresado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    log.Error(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos para iniciar una nueva factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.Error("Campos incompletos para iniciar una nueva factura.");
            }
        }

        // Limpiar campos
        private void LimpiarCampos()
        {
            txtIDCliente.Clear();
            cmbMetodoPago.SelectedIndex = 0;
            cmbTipoFactura.SelectedIndex = 0;
            txtIDCliente.Focus();
            lblSubtotal.Text = "";
            lblITBIS.Text = "";
            lblTotalPagar.Text = "";
            dgvDetalleFactura.DataSource = null;
        }

        // Boton agregar producto
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCantidadProducto.Text.Trim() != "" && txtCodigoProducto.Text.Trim() != "" && txtCodigoServicio.Text.Trim() != "" && txtCantidadProducto.Text.Trim() != "0" && txtCodigoProducto.Text.Trim() != "0" && txtCodigoServicio.Text.Trim() != "0")
                {
                    // Inserción del producto en la tabla detalle factura
                    adapterDetalleFactura.proc_DetalleFactura(IdFactura, int.Parse(txtCodigoProducto.Text.Trim()), int.Parse(txtCodigoServicio.Text.Trim()), int.Parse(txtCantidadProducto.Text.Trim()));
                    log.Info("Detalle de factura creado");

                    // Insertado el producto, se reestablecen los valores por defecto de los campos
                    txtCantidadProducto.Text = "0";
                    txtCodigoProducto.Text = "0";

                    // Actualización del datagridview para ver el detalle de la factura
                    dgvDetalleFactura.DataSource = adapterDetalleFactura.GetDataByDetalleFactura(IdFactura);

                    #region Generar y mostrar totales
                    TotalBruto = double.Parse(adapterFacturas.proc_MostrarTotalBruto(IdFactura).ToString());
                    TotalITBIS = double.Parse(adapterFacturas.proc_MostrarTotalITBIS(IdFactura).ToString());
                    TotalNeto = double.Parse(adapterFacturas.proc_MostrarTotalPagar(IdFactura).ToString());

                    lblSubtotal.Text = TotalBruto.ToString();
                    lblITBIS.Text = TotalITBIS.ToString();
                    lblTotalPagar.Text = TotalNeto.ToString();
                    #endregion
                    
                    log.Info("Producto agregado");
                }
                else
                    MessageBox.Show("Complete todos los campos para agregar productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                log.Error(ex.Message);
            }
        }

        // Finalizar facturacion
        private void btnFinalizarFactura_Click(object sender, EventArgs e)
        {
            // Si hay productos agregados en el DGV, se procede a facturar
            if (dgvDetalleFactura.Rows.Count > 0)
            {
                estadoFacturacion = false;

                // Abrir from en dependencia del método de pago
                switch (MetodoPago)
                {
                    // Pago en efectivo
                    case "Efectivo":
                        ControlesFacturacion();
                        frm_PagoEfectivo frm_PagoEfectivo = new frm_PagoEfectivo();
                        frm_PagoEfectivo.ShowDialog();
                        break;
                    // Pago con tarjeta
                    case "Tarjeta":
                        ControlesFacturacion();
                        frm_PagoTarjeta frm_PagoTarjeta = new frm_PagoTarjeta();
                        frm_PagoTarjeta.ShowDialog();
                        break;
                    // Pago diferido
                    case "Diferido":
                        // Mostrar reporte factura
                        MessageBox.Show("Factura completada con éxito.", "Transacción completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;
                    default:
                        MessageBox.Show("Seleccione un metodo de pago valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            else
                MessageBox.Show("Agregue al menos un producto para facturar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #region Eventos textbox
        // Evento enter txtCodigoProducto
        private void txtCodigoProducto_Enter(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text == "0")
                txtCodigoProducto.Text = "";
        }

        // Evento leave del txtCodigoProducto para validar si existe el producto
        private void txtCodigoProducto_Leave(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text.Trim() == "")
                txtCodigoProducto.Text = "0";
            else
            {
                // Si el adapter no retorna filas, entonces el producto no existe; se muestra una alerta
                if (adapterProductos.GetDataByProductos(int.Parse(txtCodigoProducto.Text)).Rows.Count == 0)
                    lblAlertaCodigoProducto.Text = "El código ingresado no existe. Intente con uno válido";
                else
                    lblAlertaCodigoProducto.Text = "";
            }
        }

        // Evento enter txtCantidad
        private void txtCantidadProducto_Enter(object sender, EventArgs e)
        {
            if (txtCantidadProducto.Text == "0")
                txtCantidadProducto.Text = "";
        }

        // Evento cantidad producto
        private void txtCantidadProducto_Leave(object sender, EventArgs e)
        {
            if (txtCantidadProducto.Text.Trim() == "")
                txtCantidadProducto.Text = "0";
        }
        #endregion

    }
}
