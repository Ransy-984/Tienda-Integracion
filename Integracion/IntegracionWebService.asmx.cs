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

    }
}
