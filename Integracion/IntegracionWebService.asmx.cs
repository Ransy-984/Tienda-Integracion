using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Integracion.DataSet1TableAdapters;

namespace Integracion
{

    /// <summary>
    /// Descripción breve de IntegracionWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]

    public class IntegracionWebService : System.Web.Services.WebService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [WebMethod]
        public void AbrirCaja(int UsuarioID, bool OperacionCaja, int Monedas1Peso, int Monedas5Peso, int Monedas10Peso, int Monedas25Peso, int Billetes50Pesos, int Billetes100Pesos, int Billetes200Pesos, int Billetes500Pesos, int Billetes1000Pesos, int Billetes2000Pesos)
        {
            AperturaCierreCajaTableAdapter AperturaCierreCajaadapter = new AperturaCierreCajaTableAdapter();
            AperturaCierreCajaadapter.Connection.Open();
            try
            {
                AperturaCierreCajaadapter.Transaction = AperturaCierreCajaadapter.Transaction.Connection.BeginTransaction();
                AperturaCierreCajaadapter.proc_AbrirCaja(UsuarioID, OperacionCaja, Monedas1Peso, Monedas5Peso, Monedas10Peso, Monedas25Peso, Billetes50Pesos, Billetes100Pesos, Billetes200Pesos, Billetes500Pesos, Billetes1000Pesos, Billetes2000Pesos);
                AperturaCierreCajaadapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                AperturaCierreCajaadapter.Transaction.Rollback();
                log.Error(err);
            }
            AperturaCierreCajaadapter.Connection.Close();
            log.Info("Caja abierta de manera exitosa");
        }

        [WebMethod]
        public void ActualizarCierre(int IDapertura)
        {
            FacturasTableAdapter FacturasTableAdapter = new FacturasTableAdapter();
            FacturasTableAdapter.Connection.Open();
            try
            {
                FacturasTableAdapter.Transaction = FacturasTableAdapter.Transaction.Connection.BeginTransaction();
                FacturasTableAdapter.proc_ActualizarCierre(IDapertura);
                FacturasTableAdapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                FacturasTableAdapter.Transaction.Rollback();
                log.Error(err);
            }
            FacturasTableAdapter.Connection.Close();
            log.Info("Cierre Actualizados Correctamente");
        }

        [WebMethod]
        public void ActualizarBilletes(int IDApertura, int UsuarioID, bool OperacionCaja, int Monedas1Peso, int Monedas5Peso, int Monedas10Peso, int Monedas25Peso, int Billetes50Pesos, int Billetes100Pesos, int Billetes200Pesos, int Billetes500Pesos, int Billetes1000Pesos, int Billetes2000Pesos)
        {
            AperturaCierreCajaTableAdapter AperturaCierreCajaadapter = new AperturaCierreCajaTableAdapter();
            AperturaCierreCajaadapter.Connection.Open();
            try
            {
                AperturaCierreCajaadapter.Transaction = AperturaCierreCajaadapter.Transaction.Connection.BeginTransaction();
                AperturaCierreCajaadapter.proc_ActualizarBilletes(IDApertura, UsuarioID, OperacionCaja, Monedas1Peso, Monedas5Peso, Monedas10Peso, Monedas25Peso, Billetes50Pesos, Billetes100Pesos, Billetes200Pesos, Billetes500Pesos, Billetes1000Pesos, Billetes2000Pesos);
                AperturaCierreCajaadapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                AperturaCierreCajaadapter.Transaction.Rollback();
                log.Error(err);
            }
            AperturaCierreCajaadapter.Connection.Close();
            log.Info("Billetes Actualizados Correctamente");


        }

        [WebMethod]

        public void ActualizarEstadoFactura(int IdFactura)
        {
            FacturasTableAdapter FacturasTableAdapter = new FacturasTableAdapter();
            FacturasTableAdapter.Connection.Open();
            try
            {
                FacturasTableAdapter.Transaction = FacturasTableAdapter.Transaction.Connection.BeginTransaction();
                FacturasTableAdapter.proc_ActualizarEstadoPagoFactura(IdFactura);
                FacturasTableAdapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                FacturasTableAdapter.Transaction.Rollback();
                log.Error(err);
            }
            FacturasTableAdapter.Connection.Close();
            log.Info("Billetes Actualizados Correctamente");

        }

        [WebMethod]
        public void CajaCerrada(int IDapertura)
        {
            AperturaCierreCajaTableAdapter AperturaCierreCajaadapter = new AperturaCierreCajaTableAdapter();
            AperturaCierreCajaadapter.Connection.Open();
            try
            {
                AperturaCierreCajaadapter.Transaction = AperturaCierreCajaadapter.Transaction.Connection.BeginTransaction();
                AperturaCierreCajaadapter.proc_CajaCerrada(IDapertura);
                AperturaCierreCajaadapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                AperturaCierreCajaadapter.Transaction.Rollback();
                log.Error(err);
            }
            AperturaCierreCajaadapter.Connection.Close();
            log.Info("Caja confirmada cerrada de manera exitosa");
        }

        [WebMethod]
        public void CargarClientes(int IDclientes)
        {
            ClientesTableAdapter ClientesTableAdapter = new ClientesTableAdapter();
            ClientesTableAdapter.Connection.Open();
            try
            {
                ClientesTableAdapter.Transaction = ClientesTableAdapter.Transaction.Connection.BeginTransaction();
                ClientesTableAdapter.proc_CargarClientes(IDclientes);
                ClientesTableAdapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                ClientesTableAdapter.Transaction.Rollback();
                log.Error(err);
            }
            log.Info("Clientes Cargados exitosamente");
        }

        [WebMethod]
        public void CierreCaja(int IDUsuario)
        {
            AperturaCierreCajaTableAdapter AperturaCierreCajaadapter = new AperturaCierreCajaTableAdapter();
            AperturaCierreCajaadapter.Connection.Open();
            try
            {
                AperturaCierreCajaadapter.Transaction = AperturaCierreCajaadapter.Transaction.Connection.BeginTransaction();
                AperturaCierreCajaadapter.proc_CierreCaja(IDUsuario);
                AperturaCierreCajaadapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                AperturaCierreCajaadapter.Transaction.Rollback();
                log.Error(err);
            }
            AperturaCierreCajaadapter.Connection.Close();
            log.Info("Caja cerrada de manera exitosa");
        }

        [WebMethod]
        public void CxC()
        {
            FacturasTableAdapter FacturasTableAdapter = new FacturasTableAdapter();
            FacturasTableAdapter.Connection.Open();
            try
            {
                FacturasTableAdapter.Transaction = FacturasTableAdapter.Transaction.Connection.BeginTransaction();
                FacturasTableAdapter.proc_CxC();
                FacturasTableAdapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                FacturasTableAdapter.Transaction.Rollback();
                log.Error(err);
            }
            FacturasTableAdapter.Connection.Close();           

        }

        [WebMethod]
        public void DetalleCotizacion(int IdCotizacion, int IdProducto, int cantidad)
        {
            CotizacionesDetalleTableAdapter cotizacionesDetalleTableAdapter = new CotizacionesDetalleTableAdapter();
            cotizacionesDetalleTableAdapter.Connection.Open();
            try
            {
                cotizacionesDetalleTableAdapter.Transaction = cotizacionesDetalleTableAdapter.Transaction.Connection.BeginTransaction();
                cotizacionesDetalleTableAdapter.proc_DetalleCotizacion(IdCotizacion, IdProducto, cantidad);
                cotizacionesDetalleTableAdapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                cotizacionesDetalleTableAdapter.Transaction.Rollback();
                log.Error(err);            
            }
            cotizacionesDetalleTableAdapter.Connection.Close();
            log.Info("Detalle de cotizacion insertado exitosamente");
        }

        [WebMethod]
        public void DetalleFactura(int IdCotizacion, int IdProducto, int cantidad)
        {
            CotizacionesDetalleTableAdapter cotizacionesDetalleTableAdapter = new CotizacionesDetalleTableAdapter();
            cotizacionesDetalleTableAdapter.Connection.Open();
            try
            {
                cotizacionesDetalleTableAdapter.Transaction = cotizacionesDetalleTableAdapter.Transaction.Connection.BeginTransaction();
                cotizacionesDetalleTableAdapter.proc_DetalleCotizacion(IdCotizacion, IdProducto, cantidad);
                cotizacionesDetalleTableAdapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                cotizacionesDetalleTableAdapter.Transaction.Rollback();
                log.Error(err);
            }
            cotizacionesDetalleTableAdapter.Connection.Close();
            log.Info("Detalle de factura insertado exitosamente");
        }

        [WebMethod]
        public void ExistenciaProducto(int IdProducto)
        {
            ProductosTableAdapter productosTableAdapter = new ProductosTableAdapter();
            productosTableAdapter.Connection.Open();
            try
            {
                productosTableAdapter.proc_ExistenciaProducto(IdProducto);
            }
            catch (Exception err)
            {
                log.Error(err);
            }
            productosTableAdapter.Connection.Close();
        }

        [WebMethod]
        public void HistorialFactura()
        {
            FacturasTableAdapter FacturasTableAdapter = new FacturasTableAdapter();
            FacturasTableAdapter.Connection.Open();
            try
            {
                FacturasTableAdapter.proc_HistorialFacturas(); ;
            }
            catch (Exception err)
            {
                log.Error(err);
            }
            FacturasTableAdapter.Connection.Close();
        }

        [WebMethod]
        public void InsertarCotizacion(int IdCliente, string RNC)
        {
            CotizacionesTableAdapter cotizacionesTableAdapter = new CotizacionesTableAdapter();
            cotizacionesTableAdapter.Connection.Open();
            try
            {
                cotizacionesTableAdapter.Transaction = cotizacionesTableAdapter.Transaction.Connection.BeginTransaction();
                cotizacionesTableAdapter.proc_InsertarCotizacion(IdCliente, RNC);
                cotizacionesTableAdapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                cotizacionesTableAdapter.Transaction.Rollback();
                log.Error(err);
            }
            cotizacionesTableAdapter.Connection.Close();
            log.Info("Cotizacion insertada exitosamente");
        }

        [WebMethod]
        public void InsertarFactura(int IdCliente, int IdUsuario, string TipoFactura, string sucursal, string RNC, string MetodoPago)
        {
            FacturasTableAdapter FacturasTableAdapter = new FacturasTableAdapter();
            FacturasTableAdapter.Connection.Open();
            try
            {
                FacturasTableAdapter.Transaction = FacturasTableAdapter.Transaction.Connection.BeginTransaction();
                FacturasTableAdapter.proc_InsertarFactura(IdCliente, IdUsuario, TipoFactura, sucursal, RNC, MetodoPago);
                FacturasTableAdapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                FacturasTableAdapter.Transaction.Rollback();
                log.Error(err);
            }
            FacturasTableAdapter.Connection.Close();
            log.Info("Factura insertada exitosamente");

        }

        [WebMethod]
        public void Login(string user, string password)
        {
            UsuariosTableAdapter usuariosTableAdapter = new UsuariosTableAdapter();
            usuariosTableAdapter.Connection.Open();
            try
            {
                usuariosTableAdapter.proc_Login(user, password);
            }
            catch (Exception err)
            {
                log.Error(err);                
            }
            usuariosTableAdapter.Connection.Close();
        }

        [WebMethod]
        public void DeleteClientes(int IDclientes)
        {
            ClientesTableAdapter ClientesTableAdapter = new ClientesTableAdapter();
            ClientesTableAdapter.Connection.Open();
            try
            {
                ClientesTableAdapter.Transaction = ClientesTableAdapter.Transaction.Connection.BeginTransaction();
                ClientesTableAdapter.ppDeleteCliente(IDclientes);
                ClientesTableAdapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                ClientesTableAdapter.Transaction.Rollback();
                log.Error(err);
            }
            log.Info("Clientes Borrados exitosamente");
        }

        [WebMethod]
        public void DeleteCotizacion(int IdCliente)
        {
            CotizacionesTableAdapter cotizacionesTableAdapter = new CotizacionesTableAdapter();
            cotizacionesTableAdapter.Connection.Open();
            try
            {
                cotizacionesTableAdapter.Transaction = cotizacionesTableAdapter.Transaction.Connection.BeginTransaction();
                cotizacionesTableAdapter.ppDeleteCotizacion(IdCliente);
                cotizacionesTableAdapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                cotizacionesTableAdapter.Transaction.Rollback();
                log.Error(err);
            }
            cotizacionesTableAdapter.Connection.Close();
            log.Info("Cotizacion insertada exitosamente");
        }

        [WebMethod]
        public void DeleteFactura(int IdCliente)
        {
            FacturasTableAdapter FacturasTableAdapter = new FacturasTableAdapter();
            FacturasTableAdapter.Connection.Open();
            try
            {
                FacturasTableAdapter.Transaction = FacturasTableAdapter.Transaction.Connection.BeginTransaction();
                FacturasTableAdapter.ppDeleteFactura(IdCliente);
                FacturasTableAdapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                FacturasTableAdapter.Transaction.Rollback();
                log.Error(err);
            }
            FacturasTableAdapter.Connection.Close();
            log.Info("Factura borrada exitosamente");

        }

        [WebMethod]
        public void DeletePerfil(int IdPerfil)
        {
            PerfilesTableAdapter perfilesTableAdapter = new PerfilesTableAdapter();
            perfilesTableAdapter.Connection.Open();
            try
            {
                perfilesTableAdapter.Transaction = perfilesTableAdapter.Transaction.Connection.BeginTransaction();
                perfilesTableAdapter.ppDeletePerfil(IdPerfil);
                perfilesTableAdapter.Transaction.Commit();  
            }
            catch (Exception err)
            {
                perfilesTableAdapter.Transaction.Rollback();
                log.Error(err);
            }
            perfilesTableAdapter.Connection.Close();
            log.Info("Perfil eliminado exitosamente");
        }

        [WebMethod]
        public void DeleteProducto(int IdProducto)
        {
            ProductosTableAdapter productosTableAdapter = new ProductosTableAdapter();
            productosTableAdapter.Connection.Open();
            try
            {
                productosTableAdapter.Transaction = productosTableAdapter.Transaction.Connection.BeginTransaction();
                productosTableAdapter.ppDeleteProducto(IdProducto);
                productosTableAdapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                productosTableAdapter.Transaction.Rollback();
                log.Error(err);
            }
            productosTableAdapter.Connection.Close ();
            log.Info("Producto eliminado exitosamente");            
        }

        [WebMethod]
        public void DeleteUsuario(int IdUsuario)
        {
            UsuariosTableAdapter usuariosTableAdapter = new UsuariosTableAdapter();
            usuariosTableAdapter.Connection.Open();
            try
            {
                usuariosTableAdapter.Transaction = usuariosTableAdapter.Transaction.Connection.BeginTransaction();  
                usuariosTableAdapter.ppDeleteUsuario(IdUsuario);
                usuariosTableAdapter.Transaction.Commit();
            }
            catch (Exception err)
            {
                usuariosTableAdapter.Transaction.Rollback();
                log.Error(err);
            }
            usuariosTableAdapter.Connection.Close();
            log.Info("Usuario Eliminado Exitosamente");
        }

    }
}
