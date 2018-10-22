using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Configuration;
using System.Data.Entity.Migrations.Infrastructure;
using System.Diagnostics.Eventing.Reader;
using static swyraServices.General;
using System.Globalization;
using System.Threading;

namespace swyraServices
{
    public partial class Service1 : ServiceBase
    {
        private List<Inventario> listFbInventarios;
        private CultureInfo cultureInfo = new CultureInfo(ConfigurationManager.AppSettings["DefaultCulture"]);

        public Service1()
        {
            string provider = "DataProtectionConfigurationProvider";
            string strConn = "Data Source=" + ConfigurationManager.AppSettings["sqlServer1"].ToString() + ";Initial Catalog=SWYRA;Persist Security Info=True;User ID=swrya_Cliente;Password=swyra2017";
            ConnectionStringSettings setConn = new ConnectionStringSettings("DB", strConn, "System.Data.SqlClient");

            string strFbConn = @"User = SYSDBA; Password = masterkey; Database =" + ConfigurationManager.AppSettings["fbDataBase1"].ToString() +
                                "; DataSource = " + ConfigurationManager.AppSettings["fbServer1"].ToString() +
                                "; Port = 3050; Dialect = 3; Charset = NONE; Role =; Connection lifetime = 15; Pooling = true; Packet Size = 8192; ServerType = 0";
            ConnectionStringSettings setFbConn = new ConnectionStringSettings("FB", strFbConn, "FirebirdSql.Data.FirebirdClient");

            Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            appConfig.ConnectionStrings.ConnectionStrings.Add(setConn);
            appConfig.ConnectionStrings.ConnectionStrings.Add(setFbConn);
            ConfigurationSection connStrings = appConfig.ConnectionStrings;

            connStrings.SectionInformation.ProtectSection(provider);
            connStrings.SectionInformation.ForceSave = true;
            appConfig.Save(ConfigurationSaveMode.Full);

            InitializeComponent();
            if (!EventLog.SourceExists("SWYRAServiceLog"))
            {
                EventLog.CreateEventSource("SWYRAServiceLog", "SWYRA");
            }
            eventLog1.Source = "SWYRAServiceLog";
            eventLog1.Log = "SWYRA";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("In OnStart");
            timer1.Interval = 1 * 60 * 1000;
            timer1.Enabled = true;
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In onStop.");
        }

        /// <summary>
        /// 
        /// </summary>
        private void consultar()
        {
            List<Precios> listFbPrecios = CargaFbPrecios();
            List<Precios> listDbPrecios = CargaDbPrecios();
            var preciosAct = listFbPrecios.Where(o => listDbPrecios.Any(p => p.cve_art == o.cve_art && p.cve_precio == o.cve_precio)).ToList();
            var preciosNvo = listFbPrecios.Except(preciosAct).ToList();
            var preciosDif = preciosAct.Where(o => listDbPrecios.Any(p => p.cve_art == o.cve_art && p.cve_precio == o.cve_precio && Math.Abs(p.precio - o.precio) > 1)).ToList();
            foreach (var clt in preciosNvo)
            {
                GuardaPrecios(clt);
            }
            foreach (var clt in preciosDif)
            {
                ModificaPrecios(clt);
            }

            List<Cliente> listFbClientes = cargaFbClientes();
            List<Cliente> listDbClientes = cargaDbClientes();
            var clientesAct = listFbClientes.Where(o => listDbClientes.Any(p => p.clave == o.clave)).ToList();
            var clientesNvo = listFbClientes.Except(clientesAct).ToList();
            var clientesDif = clientesAct.Where(o => listDbClientes.Any(p => p.clave == o.clave && p.fch_ultcom != o.fch_ultcom)).ToList();
            foreach (var clt in clientesNvo)
            {
                GuardaCliente(clt);
            }
            foreach (var clt in clientesDif)
            {
                ModificaCliente(clt);
            }

            List<Inventario> listFbInventarios = CargaFbInventarios();
            List<Inventario> listDbInventarios = CargaDbInventarios();
            var inventarioAct = listFbInventarios.Where(o => listDbInventarios.Any(p => p.cve_art == o.cve_art)).ToList();
            var inventarioNvo = listFbInventarios.Except(inventarioAct).ToList();
            var inventarioDif = inventarioAct.Where(o => listDbInventarios.Any(p => p.cve_art == o.cve_art && (p.fch_ultvta != o.fch_ultvta || p.fch_ultcom != o.fch_ultcom || (int)p.uni_emp != (int)o.uni_emp || p.ctrl_alm != o.ctrl_alm || p.masters_ubi != o.masters_ubi))).ToList();
            foreach (var inv in inventarioNvo)
            {
                GuardaInventario(inv);
            }
            foreach (var inv in inventarioDif)
            {
                ModificaInventario(inv);
            }

            List<Pedidos> listDbPedidosFac = CargaDbPedidosFac();
            foreach (var pedFac in listDbPedidosFac)
            {
                var lsDbDetPed = CargaDbDetallePedido(pedFac.cve_doc);
                var lsFbDetPed = CargaFbDetallePedido(pedFac.cve_doc);

                foreach (var detDB in lsDbDetPed)
                {
                    var detFB = lsFbDetPed.Find(o => o.num_par == detDB.num_par);
                    ModificaFbDetallePedido(detDB, detFB);
                }

                var detalleAct = lsFbDetPed.Where(o => lsDbDetPed.Any(p => o.cve_art == p.cve_art)).ToList();
                var detalleQuitar = lsFbDetPed.Except(detalleAct).ToList();

                foreach (var detFB in detalleQuitar)
                {
                    ModificaFbDetallePedido(null, detFB);
                }

                detalleAct = lsFbDetPed.Where(o => lsDbDetPed.Any(p => o.num_par == p.num_par)).ToList();
                detalleQuitar = lsFbDetPed.Except(detalleAct).ToList();

                foreach (var detFB in detalleQuitar)
                {
                    ModificaFbDetallePedido(null, detFB);
                }

                ModificaFbPedido(pedFac);
                ModificaDbPedidos(null, pedFac);
            }

            List<Pedidos> listDbPedidosGuia = CargaDbPedidosGuia();
            foreach (var pedGuia in listDbPedidosGuia)
            {
                var fac = CargaFbFactura(pedGuia.cve_doc);
                if (fac != null)
                {
                    ModificaFbFactura(fac, pedGuia);
                    ModificaDbPedidos(null, pedGuia);
                }
            }

            List<Pedidos> listDbPedidosCan = CargaDbPedidosCan();
            foreach (var pedCan in listDbPedidosCan)
            {
                ModificaFbPedido(pedCan);
                ModificaDbPedidos(null, pedCan);
            }

            List<Pedidos> listFbPedidos = CargaFbPedidos(DateTime.Today.AddDays(-3), DateTime.Today);
            List<Pedidos> listDbPedidos = CargaDbPedidos(DateTime.Today.AddDays(-3), DateTime.Today);
            var pedidosAct = listFbPedidos.Where(o => listDbPedidos.Any(p => o.cve_doc == p.cve_doc && p.status != "C") && o.status != "C").ToList();
            var pedidosNuevos = listFbPedidos.Where(o => o.status != "C").Except(pedidosAct).ToList();
            var pedidosCan = listFbPedidos.Where(o => listDbPedidos.Any(p => o.cve_doc == p.cve_doc && p.status != "C") && o.status == "C").ToList();
            var pedidosDiferentes = pedidosAct.Except(pedidosAct.Where(o => listDbPedidos.Any(p => o.cve_doc == p.cve_doc && Math.Round(o.importe, 2) == Math.Round(p.importe, 2))).ToList()).ToList();
            foreach (var ped in pedidosNuevos)
            {
                GuardarDbPedidos(ped);
                if((validaExis(false,ped.cve_doc) == true) && (validaExis(true, ped.cve_doc) == false)) { cambiarArea(ped); }
            }
            foreach (var ped in pedidosCan)
            {
                var pedDb = listDbPedidos.FirstOrDefault(o => o.cve_doc == ped.cve_doc);
                CancelaDbPedidos(pedDb);
            }
            foreach (var pedFb in pedidosDiferentes)
            {
                var pedDb = listDbPedidos.Find(o => o.cve_doc == pedFb.cve_doc);
                ModificaDbPedidos(pedFb, pedDb);
            }
        }

        private List<Precios> CargaFbPrecios()
        {
            List<Precios> listFbPrecios = new List<Precios>();
            try
            {
                var query =
                    "select CVE_ART, CVE_PRECIO, PRECIO " +
                    "from PRECIO_X_PROD01";
                listFbPrecios = GetFbDataTable("FB", query, 25).ToList<Precios>();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("25: " + ex.Message, EventLogEntryType.Error);
            }
            return listFbPrecios;
        }

        private List<Precios> CargaDbPrecios()
        {
            List<Precios> listDbPrecios = new List<Precios>();
            try
            {
                var query =
                    "select CVE_ART, CVE_PRECIO, PRECIO " +
                    "from INVENTARIOPRECIOS";
                listDbPrecios = GetDataTable("DB", query, 26).ToList<Precios>();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("26: " + ex.Message, EventLogEntryType.Error);
            }
            return listDbPrecios;
        }

        private void GuardaPrecios(Precios clt)
        {
            try
            {
                var query =
                    "insert INVENTARIOPRECIOS (CVE_ART, CVE_PRECIO, PRECIO )" +
                    "values ('" + clt.cve_art+ "', " + clt.cve_precio.ToString() + ", " + clt.precio.ToString(CultureInfo.CurrentCulture) + " )";
                var res = GetExecute("DB", query, 27);
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("27: " + ex.Message, EventLogEntryType.Error);
            }
        }

        private void ModificaPrecios(Precios clt)
        {
            try
            {
                var query =
                    "update INVENTARIOPRECIOS set PRECIO = " + clt.precio.ToString(CultureInfo.CurrentCulture) +
                    " where CVE_ART = '" + clt.cve_art + "' AND CVE_PRECIO = " + clt.cve_precio.ToString();
                var res = GetExecute("DB", query, 28);
                eventLog1.WriteEntry("q: " + query, EventLogEntryType.Warning);
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("28: " + ex.Message, EventLogEntryType.Error);
            }
        }

        private List<Cliente> cargaFbClientes()
        {
            List<Cliente> listFbClientes = new List<Cliente>();
            try
            {
                var query =
                    "select CLAVE, STATUS, replace(NOMBRE,'''','') NOMBRE, CALLE, NUMINT, NUMEXT, CRUZAMIENTOS, CRUZAMIENTOS2, COLONIA, " +
                    "CODIGO, MUNICIPIO, ESTADO, PAIS, TELEFONO, CVE_VEND, CVE_OBS, TIPO_EMPRESA, CALLE_ENVIO, " +
                    "NUMINT_ENVIO, NUMEXT_ENVIO, CRUZAMIENTOS_ENVIO, CRUZAMIENTOS_ENVIO2, COLONIA_ENVIO, CAMPLIB2 FLETE, CAMPLIB8 FLETE2, " +
                    "LOCALIDAD_ENVIO, MUNICIPIO_ENVIO, ESTADO_ENVIO, PAIS_ENVIO, CODIGO_ENVIO, ULT_COMPM, FCH_ULTCOM, CLASIFIC " +
                    "from CLIE01 c LEFT JOIN CLIE_CLIB01 b ON b.CVE_CLIE = c.CLAVE";
                listFbClientes = GetFbDataTable("FB", query, 21).ToList<Cliente>();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("21: " + ex.Message, EventLogEntryType.Error);
            }
            return listFbClientes;
        }

        private List<Cliente> cargaDbClientes()
        {
            List<Cliente> listFbClientes = new List<Cliente>();
            try
            {
                var query =
                    "select CLAVE, STATUS, NOMBRE, CALLE, NUMINT, NUMEXT, CRUZAMIENTOS, CRUZAMIENTOS2, COLONIA, " +
                    "CODIGO, MUNICIPIO, ESTADO, PAIS, TELEFONO, CVE_VEND, CVE_OBS, TIPO_EMPRESA, CALLE_ENVIO, " +
                    "NUMINT_ENVIO, NUMEXT_ENVIO, CRUZAMIENTOS_ENVIO, CRUZAMIENTOS_ENVIO2, COLONIA_ENVIO, " +
                    "LOCALIDAD_ENVIO, MUNICIPIO_ENVIO, ESTADO_ENVIO, PAIS_ENVIO, CODIGO_ENVIO, ULT_COMPM, FCH_ULTCOM, CLASIFIC " +
                    "from CLIENTE";
                listFbClientes = GetDataTable("DB", query, 22).ToList<Cliente>();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("22: " + ex.Message, EventLogEntryType.Error);
            }
            return listFbClientes;
        }

        private void GuardaCliente(Cliente clt)
        {
            try
            {
                var query =
                    "insert CLIENTE (CLAVE, STATUS, NOMBRE, CALLE, NUMINT, NUMEXT, CRUZAMIENTOS, CRUZAMIENTOS2, COLONIA, " +
                    "CODIGO, MUNICIPIO, ESTADO, PAIS, TELEFONO, CVE_VEND, CVE_OBS, TIPO_EMPRESA, CALLE_ENVIO, " +
                    "NUMINT_ENVIO, NUMEXT_ENVIO, CRUZAMIENTOS_ENVIO, CRUZAMIENTOS_ENVIO2, COLONIA_ENVIO, " +
                    "LOCALIDAD_ENVIO, MUNICIPIO_ENVIO, ESTADO_ENVIO, PAIS_ENVIO, CODIGO_ENVIO, ULT_COMPM, FCH_ULTCOM, CLASIFIC, FLETE, FLETE2) " +
                    "values ('" + clt.clave + "', '" + clt.status + "', '" + clt.nombre + "', '" + clt.calle + "', '" +
                    clt.numint + "', '" + clt.numext + "', '" + clt.cruzamientos + "', '" + clt.cruzamientos2 + "', '" +
                    clt.colonia + "', '" + clt.codigo + "', '" + clt.municipio + "', '" + clt.estado + "', '" + clt.pais + "', '" +
                    clt.telefono + "', '" + clt.cve_vend + "', " + clt.cve_obs + ", '" + clt.tipo_empresa + "', '" +
                    clt.calle_envio + "', '" + clt.numint_envio + "', '" + clt.numext_envio + "', '" + clt.cruzamientos_envio + "', '" +
                    clt.cruzamientos_envio2 + "', '" + clt.colonia_envio + "', '" + clt.localidad_envio + "', '" +
                    clt.municipio_envio + "', '" + clt.estado_envio + "', '" + clt.pais_envio + "', '" + clt.codigo_envio + "', " +
                    clt.ult_compm.ToString(cultureInfo) + ", " + ((clt.ult_compm == 0.00) ? "NULL" : "'" + clt.fch_ultcom.ToString("yyyy-MM-dd") + "'") + ", '" +
                    clt.clasific + "', '" + clt.flete + "', '" + clt.flete2 + "' )";
                var res = GetExecute("DB", query, 23);
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("23: " + ex.Message, EventLogEntryType.Error);
            }
        }

        private void ModificaCliente(Cliente clt)
        {
            try
            {
                var query =
                    "update CLIENTE set STATUS = '" + clt.status + "', NOMBRE = '" + clt.nombre + "', CALLE = '" +
                    clt.calle + "', NUMINT = '" + clt.numint + "', NUMEXT = '" + clt.numext + "', CRUZAMIENTOS = '" +
                    clt.cruzamientos + "', CRUZAMIENTOS2 = '" + clt.cruzamientos2 + "', COLONIA  = '" +
                    clt.colonia + "', CODIGO = '" + clt.codigo + "', MUNICIPIO = '" + clt.municipio + "', ESTADO ='" +
                    clt.estado + "', PAIS = '" + clt.pais + "', TELEFONO = '" + clt.telefono + "', CVE_VEND ='" +
                    clt.cve_vend + "', CVE_OBS = " + clt.cve_obs + ", TIPO_EMPRESA = '" + clt.tipo_empresa + "', CALLE_ENVIO = '" +
                    clt.calle_envio + "', NUMINT_ENVIO = '" + clt.numint_envio + "', NUMEXT_ENVIO = '" +
                    clt.numext_envio + "', CRUZAMIENTOS_ENVIO = '" + clt.cruzamientos_envio + "', CRUZAMIENTOS_ENVIO2 = '" +
                    clt.cruzamientos_envio2 + "', COLONIA_ENVIO = '" + clt.colonia_envio + "', LOCALIDAD_ENVIO = '" +
                    clt.localidad_envio + "', MUNICIPIO_ENVIO = '" + clt.municipio_envio + "', ESTADO_ENVIO = '" +
                    clt.estado_envio + "', PAIS_ENVIO = '" + clt.pais_envio + "', CODIGO_ENVIO = '" +
                    clt.codigo_envio + "', ULT_COMPM = " + clt.ult_compm.ToString(cultureInfo) + ", " + 
                    "FCH_ULTCOM = " + ((clt.ult_compm == 0.00) ? "NULL" : "'" + clt.fch_ultcom.ToString("yyyy-MM-dd") + "'") + ", " +
                    "CLASIFIC = '" + clt.clasific + "', FLETE = '" + clt.flete + "' where CLAVE = '" + clt.clave + "'";
                var res = GetExecute("DB", query, 24);
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("24: " + ex.Message, EventLogEntryType.Error);
            }
        }

        private List<Pedidos> CargaFbPedidos(DateTime fini, DateTime ffin)
        {
            List<Pedidos> listFbPedidos = new List<Pedidos>();
            try
            {
                var query =
                    "select TIP_DOC, p.CVE_DOC, CVE_CLPV, p.STATUS, DAT_MOSTR, p.CVE_VEND, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, " +
                    "FECHA_CANCELA, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, CONDICION, p.CVE_OBS, " +
                    "NUM_ALMA, ACT_CXC, ACT_COI, ENLAZADO, TIP_DOC_E, NUM_MONED, TIPCAMB, NUM_PAGOS, FECHAELAB, PRIMERPAGO, RFC, " +
                    "CTLPOL, ESCFD, AUTORIZA, SERIE, FOLIO, AUTOANIO, DAT_ENVIO, CONTADO, CVE_BITA, BLOQ, FORMAENVIO, DES_FIN_PORC, " +
                    "DES_TOT_PORC, IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, TIP_DOC_SIG, DOC_SIG, i.NOMBRE ENVIAR, " +
                    "STR_OBS OBSERVACIONES, v.NOMBRE NOMBRE_VENDEDOR, (i.CALLE || ' # ' || i.NUMEXT || ' COL. ' || i.COLONIA || '; ' || i.MUNICIPIO || ', ' || i.ESTADO) consignacion " +
                    "from FACTP01 p LEFT JOIN OBS_DOCF01 o ON p.CVE_OBS = o.CVE_OBS LEFT JOIN VEND01 v ON p.CVE_VEND = v.CVE_VEND " +
                    "LEFT JOIN INFENVIO01 i ON i.CVE_INFO = p.DAT_ENVIO " +
                    "where FECHA_DOC between '" + fini.ToString("yyyy-MM-dd") + "' and '" +
                    ffin.ToString("yyyy-MM-dd") + "'";
                listFbPedidos = GetFbDataTable("FB", query, 6).ToList<Pedidos>();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("25: " + ex.Message, EventLogEntryType.Error);
            }
            return listFbPedidos;
        }

        private List<Pedidos> CargaDbPedidos(DateTime fini, DateTime ffin)
        {
            List<Pedidos> listDbPedidos = new List<Pedidos>();
            try
            {
                var query =
                    "select TIP_DOC, CVE_DOC, CVE_CLPV, STATUS, DAT_MOSTR, CVE_VEND, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, " +
                    "FECHA_CANCELA, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, CONDICION, CVE_OBS, " +
                    "NUM_ALMA, ACT_CXC, ACT_COI, ENLAZADO, TIP_DOC_E, NUM_MONED, TIPCAMB, NUM_PAGOS, FECHAELAB, PRIMERPAGO, RFC, " +
                    "CTLPOL, ESCFD, AUTORIZA, SERIE, FOLIO, AUTOANIO, DAT_ENVIO, CONTADO, CVE_BITA, BLOQ, FORMAENVIO, DES_FIN_PORC, " +
                    "DES_TOT_PORC, IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, TIP_DOC_SIG, DOC_SIG, " +
                    "ENVIAR, TIPOSERVICIO, ESTATUSPEDIDO, OCURREDOMICILIO " +
                    "from PEDIDO where FECHA_DOC between '" + fini.ToString("yyyy-MM-dd") + "' and '" +
                    ffin.ToString("yyyy-MM-dd") + "'";
                listDbPedidos = GetDataTable("DB", query, 7).ToList<Pedidos>();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("7: " + ex.Message, EventLogEntryType.Error);
            }
            return listDbPedidos;
        }

        private class Results
        {
             public string usuario { get; set; }
        }

        private string GetUsuarioIdByERP(string cve_clpv)
        {
            Results result = new Results();
            try
            {
                var query = "select u.Usuario from CLIENTE c join  USUARIOS u on u.LetraERP = SUBSTRING(c.CLASIFIC, 1, 1) " +
                            "where c.CLAVE = '" + cve_clpv + "'";
                result = GetDataTable("DB", query, 26).ToList<Results>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("26: " + ex.Message, EventLogEntryType.Error);
            }
            return ((result == null) ? "" : result.usuario);
        }

        private string GetUsuarioIdByLastERP(string cve_clpv)
        {
            Results result = new Results();
            try
            {
                var query = "select u.Usuario from CLIENTE c join USUARIOS u on u.LetraERP = RIGHT(RTRIM(CLASIFIC),1) " +
                            "where c.CLAVE = '" + cve_clpv + "'";
                result = GetDataTable("DB", query, 26).ToList<Results>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("26: " + ex.Message, EventLogEntryType.Error);
            }
            return ((result == null) ? "" : result.usuario);
        }

        private void GuardarDbPedidos(Pedidos p)
        {
            var query = "";
            var seguimiento = "";
            int index = -1;
            try
            {
                p.condicion = p.condicion ?? "";
                string[] dats = p.condicion.Split(';');
                if (dats.Length == 2)
                {
                    string[] clvTipoServ = {"L", "F", "LU", "FU"};
                    string[] catTipoServ = {"LOCAL", "FORANEO", "LOCAL URGENTE", "FORANEO URGENTE"};
                    index = Array.IndexOf(clvTipoServ, dats[0]);
                    p.tiposervicio = (index > 0) ? catTipoServ[index] : "LOCAL";
                }
                else if (dats.Length > 2)
                {
                    string[] clvTipoServ = { "L", "F", "LU", "FU" };
                    string[] catTipoServ = { "LOCAL", "FORANEO", "LOCAL URGENTE", "FORANEO URGENTE" };
                    index = Array.IndexOf(clvTipoServ, dats[0]);
                    p.tiposervicio = (index > 0) ? catTipoServ[index] : "LOCAL";

                    string[] clvTipoDom = { "OCU", "PAS", "DOM" };
                    string[] catTipoDom = { "OCURRE", "PASAN", "DOMICILIO" };
                    int index2 = Array.IndexOf(clvTipoDom, dats[1]);
                    p.ocurredomicilio = (index2 > 0) ? catTipoDom[index2] : "OCURRE";
                }
                p.estatuspedido = "AUTORIZACION";
                var cobrador = GetUsuarioIdByERP(p.cve_clpv);
                var capturo = GetUsuarioIdByLastERP(p.cve_clpv);
                query =
                    "insert into PEDIDO (TIP_DOC, CVE_DOC, CVE_CLPV, STATUS, DAT_MOSTR, CVE_VEND, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, " +
                    "FECHA_CANCELA, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, CONDICION, CVE_OBS, " +
                    "NUM_ALMA, ACT_CXC, ACT_COI, ENLAZADO, TIP_DOC_E, NUM_MONED, TIPCAMB, NUM_PAGOS, FECHAELAB, PRIMERPAGO, RFC, " +
                    "CTLPOL, ESCFD, AUTORIZA, SERIE, FOLIO, AUTOANIO, DAT_ENVIO, CONTADO, CVE_BITA, BLOQ, FORMAENVIO, DES_FIN_PORC, " +
                    "DES_TOT_PORC, IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, TIP_DOC_SIG, DOC_SIG, " +
                    "TIPOSERVICIO, ESTATUSPEDIDO, OCURREDOMICILIO, COBRADOR_ASIGNADO, PRIORIDAD, OBSERVACIONES, NOMBRE_VENDEDOR, CONSIGNACION, ENVIAR, CAPTURO) values ('" +
                    p.tip_doc + "', '" + p.cve_doc + "', '" + p.cve_clpv + "', '" + p.status + "', " + p.dat_mostr.ToString() + ", '" + p.cve_vend + "', '" +
                    p.cve_pedi + "', " + p.fecha_doc.ToStrSql() + ", " + p.fecha_ent.ToStrSql() + ", " +
                    p.fecha_ven.ToStrSql() + ", " + p.fecha_cancela.ToStrSql() + ", " + p.can_tot.ToString(cultureInfo) + ", " +
                    p.imp_tot1.ToString(cultureInfo) + ", " + p.imp_tot2.ToString(cultureInfo) + ", " + p.imp_tot3.ToString(cultureInfo) + ", " + 
                    p.imp_tot4.ToString(cultureInfo) + ", " + p.des_tot.ToString(cultureInfo) + ", " + p.des_fin.ToString(cultureInfo) + ", " +
                    p.com_tot.ToString(cultureInfo) + ", '" + p.condicion + "', " + p.cve_obs + ", " + p.num_alma + ", '" + p.act_cxc + "', '" + p.act_coi + "', '" +
                    p.enlazado + "', '" + p.tip_doc_e + "', " + p.num_moned + ", " + p.tipcamb.ToString(cultureInfo) + ", " + p.num_pagos + ", " +
                    p.fechaelab.ToStrSql() + ", " + p.primerpago.ToString(cultureInfo) + ", '" + p.rfc + "', " + p.ctlpol + ", '" + p.escfd + "', " +
                    p.autoriza + ", '" + p.serie + "', " + p.folio + ", '" + p.autoanio + "', " + p.dat_envio + ", '" + p.contado + "', " +
                    p.cve_bita + ", '" + p.bloq + "', '" + p.formaenvio + "', " + p.des_fin_porc.ToString(cultureInfo) + ", " + p.des_tot_porc.ToString(cultureInfo) + ", " +
                    p.importe.ToString(cultureInfo) + ", " + p.com_tot_porc.ToString(cultureInfo) + ", '" + p.metododepago + "', '" + p.numctapago + "', '" + p.tip_doc_ant + "', '" +
                    p.doc_ant + "', '" + p.tip_doc_sig + "', '" + p.doc_sig + "', '" + p.tiposervicio + "', '" + p.estatuspedido + "', '" +
                    p.ocurredomicilio + "', '" + cobrador + "', '" + ((index > 1) ? "URGENTE" : "NORMAL") + "', '" + p.observaciones + "', '" + p.nombre_vendedor + "', '" + 
                    p.consignacion + "', '" + p.enviar + "', '" + capturo + "' )";
                var res = GetExecute("DB", query, 8);

                query = "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values ('" +
                        p.cve_doc + "', '" + p.estatuspedido + "', getdate(), null)";
                res = GetExecute("DB", query, 8);
                if (res)
                {
                    List<DetallePedidos> listFbDetalle = CargaFbDetallePedido(p.cve_doc);
                    foreach (DetallePedidos det in listFbDetalle)
                    {
                        GuardaDbDetallePedido(det);
                    }
                }
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("8" + seguimiento + ": " + ex.Message, EventLogEntryType.Error);
            }
        }

        private List<DetallePedidos> CargaFbDetallePedido(string cvedoc)
        {
            List<DetallePedidos> listFbDetalle = new List<DetallePedidos>();
            try
            {
                var query =
                    "select CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, " +
                    "IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, " +
                    "TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR " +
                    "from PAR_FACTP01 where CVE_DOC = '" + cvedoc + "'";
                listFbDetalle = GetFbDataTable("FB", query, 9).ToList<DetallePedidos>();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("9: " + ex.Message, EventLogEntryType.Error);
            }
            return listFbDetalle;
        }

        private List<DetallePedidos> CargaDbDetallePedido(string cvedoc)
        {
            List<DetallePedidos> listDbDetalle = new List<DetallePedidos>();
            try
            {
                var query =
                    "select CVE_DOC, NUM_PAR, CVE_ART, CANTSURTIDO CANT, PXS, PREC, COST, IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, " +
                    "IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, " +
                    "TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, CANTSURTIDO, SURTIDO, TDESC, SUBTO, TCOMI, SERVI " +
                    "from DETALLEPEDIDO where CVE_DOC = '" + cvedoc + "'";
                listDbDetalle = GetDataTable("DB", query, 10).ToList<DetallePedidos>();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("10: " + ex.Message, EventLogEntryType.Error);
            }
            return listDbDetalle;
        }

        private List<DetallePedidos> CargaDbDetallePedidoDev(string cvedoc)
        {
            List<DetallePedidos> listDbDetalle = new List<DetallePedidos>();
            try
            {
                var query =
                    "select CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, " +
                    "IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, " +
                    "TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, CANTDEVUELTO, DEVUELTO " +
                    "from DETALLEPEDIDODEV where CVE_DOC = '" + cvedoc + "'";
                listDbDetalle = GetDataTable("DB", query, 10).ToList<DetallePedidos>();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("50: " + ex.Message, EventLogEntryType.Error);
            }
            return listDbDetalle;
        }

        private void GuardaDbDetallePedido(DetallePedidos ped)
        {
            try
            {
                var query = "if EXISTS(select * from DETALLEPEDIDO where CVE_DOC = '" + ped.cve_doc + "' and NUM_PAR = " + ped.num_par + " and isnull(CANTSURTIDO,0) > 0) " +
                            "insert DETALLEPEDIDODEV (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, " +
                            "IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, " +
                            "POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR) " +
                            "select CVE_DOC, NUM_PAR, CVE_ART, CANTSURTIDO, PXS, PREC, COST, IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, " +
                            "IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, " +
                            "POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR " +
                            "from DETALLEPEDIDO where CVE_DOC = '" + ped.cve_doc + "' and NUM_PAR = " + ped.num_par + " " +
                            "DELETE DETALLEPEDIDO where CVE_DOC = '" + ped.cve_doc + "' and NUM_PAR = " + ped.num_par + " " +
                            "insert DETALLEPEDIDO (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, " +
                            "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, " +
                            "IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " +
                            "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, " +
                            "POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                            "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR) VALUES ( '" +
                            ped.cve_doc + "', " + ped.num_par + ", '" + ped.cve_art + "', " + ped.cant.ToString(cultureInfo) + ", " + ped.pxs.ToString(cultureInfo) + ", " + 
                            ped.prec.ToString(cultureInfo) + ", " + ped.cost.ToString(cultureInfo) + ", " +
                            ped.impu1.ToString(cultureInfo) + ", " + ped.impu2.ToString(cultureInfo) + ", " + ped.impu3.ToString(cultureInfo) + ", " + ped.impu4.ToString(cultureInfo) + ", " + 
                            ped.imp1apla + ", " + ped.imp2apla + ", " + ped.imp3apla + ", " + ped.imp4apla + ", " + 
                            ped.totimp1.ToString(cultureInfo) + ", " + ped.totimp2.ToString(cultureInfo) + ", " + ped.totimp3.ToString(cultureInfo) + ", " + ped.totimp4.ToString(cultureInfo) + ", " +
                            ped.desc1.ToString(cultureInfo) + ", " + ped.desc2.ToString(cultureInfo) + ", " + ped.desc3.ToString(cultureInfo) + ", " + 
                            ped.comi.ToString(cultureInfo) + ", '" + ped.apar.ToString(cultureInfo) + "', '" + ped.act_inv + "', " + ped.num_alm + ", '" +
                            ped.polit_apli + "', " + ped.tip_cam.ToString(cultureInfo) + ", '" + ped.uni_venta + "', '" + ped.tipo_prod + "', " + ped.cve_obs + ", " + ped.reg_serie + ", " +
                            ped.e_ltpd + ", '" + ped.tipo_elem + "', " + ped.num_mov + ", " + ped.tot_partida.ToString(cultureInfo) + ", '" + ped.imprimir + "')";
                var res = GetExecute("DB", query, 11);
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("11: " + ex.Message, EventLogEntryType.Error);
            }
        }

        private void CancelaDbPedidos(Pedidos pedDb)
        {
            try
            {
                pedDb.status = "C";
                string[] dats = { "AUTORIZACION", "SURTIR", "DETENIDO", "EMPAQUE", "MODIFICACION", "DETENIDO EMP" };
                if (pedDb.estatuspedido.In(dats))
                {
                    pedDb.estatuspedido = (pedDb.estatuspedido == "AUTORIZACION") ? "CANCELACION" : "DEVOLUCION";
                    var query = "update PEDIDO set STATUS = '" + pedDb.status + "', " +
                                "ESTATUSPEDIDO = '" + pedDb.estatuspedido + "' " +
                                "where CVE_DOC = '" + pedDb.cve_doc + "'";
                    GetExecute("DB", query, 12);
                    var query3 = "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values ('" +
                                    pedDb.cve_doc + "', '" + pedDb.estatuspedido + "', getdate(), null)";
                    var res2 = GetExecute("DB", query3, 12);
                    if (pedDb.estatuspedido == "DEVOLUCION")
                    {
                        var query2 = "if EXISTS(select * from DETALLEPEDIDODEV where CVE_DOC = '" + pedDb.cve_doc + "' ) " +
                                     "UPDATE DETALLEPEDIDODEV SET NUM_PAR = NUM_PAR + 1000 where CVE_DOC = '" + pedDb.cve_doc + "' " +
                                     "insert DETALLEPEDIDODEV (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, " +
                                        "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " +
                                        "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                                        "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR) select CVE_DOC, NUM_PAR, CVE_ART, CANTSURTIDO CANT, PXS, PREC, COST, " +
                                        "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " +
                                        "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                                        "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR from DETALLEPEDIDO where CVE_DOC = '" +
                                        pedDb.cve_doc + "' and isnull(CANTSURTIDO,0) > 0 delete DETALLEPEDIDO where CVE_DOC = '" +
                                        pedDb.cve_doc + "'";
                        var res = GetExecute("DB", query2, 13);
                        query2 = "update DETALLEPEDIDODEV set CANT = d2.CANT " +
                                 "from DETALLEPEDIDODEV d1 join ( select cve_doc, CVE_ART, sum(CANT) CANT from DETALLEPEDIDODEV " +
                                 "where (CVE_DOC = '" + pedDb.cve_doc + "') and isnull(DEVUELTO,0) = 0 " +
                                 "group by CVE_DOC, CVE_ART) as d2 on d1.CVE_DOC = d2.CVE_DOC and d1.CVE_ART = d2.CVE_ART " +
                                 "update DETALLEPEDIDODEV set DEVUELTO = 1, CANTDEVUELTO = CANT " +
                                 "where(LTRIM(CVE_DOC) = '" + pedDb.cve_doc + "') and NUM_PAR > 999";
                        res = GetExecute("DB", query2, 201);
                    }
                }
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("13: " + ex.Message, EventLogEntryType.Error);
            }
        }

        private bool validaExis(bool Area, string cve_doc)
        {
            bool res = false;
            try
            {
                if (Area)
                {
                    var detA = GetDataTable("DB", createQR(Area, false, cve_doc), 2).ToList<DetallePedidos>();
                    var devA = GetDataTable("DB", createQR(Area, true, cve_doc), 3).ToList<DetallePedidos>();
                    var cdetA = detA.Where(o => o.surtido == false).ToList().Count;
                    var cdevA = devA.Where(o => o.devuelto == false).ToList().Count;
                    res = (cdetA == 0 && cdevA == 0);
                }
                else
                {
                    var det = GetDataTable("DB", createQR(Area, false, cve_doc), 4).ToList<DetallePedidos>();
                    var dev = GetDataTable("DB", createQR(Area, true, cve_doc), 5).ToList<DetallePedidos>();
                    var cdet = det.Where(o => o.surtido == false).ToList().Count;
                    var cdev = dev.Where(o => o.devuelto == false).ToList().Count;
                    res = (cdet == 0 && cdev == 0);
                }
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("11: " + ex.Message, EventLogEntryType.Error);
            }
            return res;
        }

        private string createQR(bool Area, bool Devuelto, string cve_doc)
        {
            var query = "select a.*, isnull(o.ORDEN,0) ORDEN FROM( select *, " +
                    "case when sel > 0 then cast(((CANT - (ISNULL(" + (Devuelto ? "CANTDEVUELTO" : "CANTSURTIDO") + ",0) + CANTPENDIENTE) - 1) / sel) as int) else 0 end con, " +
                    "case when (case when sel > 0 then cast(((CANT - (ISNULL(" + (Devuelto ? "CANTDEVUELTO" : "CANTSURTIDO") + ",0) + CANTPENDIENTE) - 1) / sel) as int) else 1 end) > 0 then CTRL_ALM " +
                    "else case when MASTERS_UBI = '' then CTRL_ALM else MASTERS_UBI end end ubicacion, " +
                    "(CANT - (sel * (case when sel > 0 then cast(((CANT - (ISNULL(" + (Devuelto ? "CANTDEVUELTO" : "CANTSURTIDO") + ",0) + CANTPENDIENTE) - 1) / sel) as int) " +
                    "else 0 end)) - (ISNULL(" + (Devuelto ? "CANTDEVUELTO" : "CANTSURTIDO") + ",0) + CANTPENDIENTE)) CANTDIFERENCIA " +
                    "from ( SELECT  CVE_DOC, NUM_PAR, dp.CVE_ART, CANT, ISNULL(" + (Devuelto ? "CANTDEVUELTO" : "CANTSURTIDO") + ",0) " + (Devuelto ? "CANTDEVUELTO" : "CANTSURTIDO") + ", " +
                    "ISNULL(" + (Devuelto ? "DEVUELTO" : "SURTIDO") + ",0) " + (Devuelto ? "DEVUELTO" : "SURTIDO") + ", i.DESCR, i.EXIST, i.LIN_PROD, " +
                    "ISNULL(ic.COMENTARIO,'') COMENTARIO, ISNULL(ic.APLICAEXIST,0) APLICAEXIST, " +
                    "ISNULL(ic.EXISTENCIA,0) MINEXIST, ISNULL(IC.APLICALOTE,0) APLICALOTE, " +
                    "i.CTRL_ALM, i.MASTERS_UBI, i.UNI_EMP MIN, i.MASTERS MAS, " +
                    "cast(cast(case when i.MASTERS > 0 then (CANT / i.MASTERS) else 0 end as int) * i.MASTERS as int) sel, " +
                    (Devuelto ? "0" : "ISNULL(CANTPENDIENTE,0)") + " CANTPENDIENTE " +
                    "FROM " + (Devuelto ? "DETALLEPEDIDODEV" : "DETALLEPEDIDO") + " dp JOIN INVENTARIO i ON dp.CVE_ART = i.CVE_ART " +
                    "LEFT JOIN INVENTARIOCOND ic ON ic.CVE_ART = dp.CVE_ART AND ic.ACTIVO = 1 " +
                    "WHERE (LTRIM(CVE_DOC) = '" + cve_doc + "') AND dp.NUM_PAR < 1000 ) as c) as a LEFT JOIN ORDEN_RUTA o ON RTRIM(LTRIM(a.ubicacion)) = o.CVE_UBI " +
                    "JOIN AREAS r ON ISNULL(o.AREA,'') " + (Area ? "" : "NOT") + " like '%' + r.NOMBRE + '%' ORDER BY o.ORDEN";
            return query;
        }

        private void cambiarArea(Pedidos ped)
        {
            try
            {
                var query = "UPDATE PEDIDO SET SOLAREA = 1 WHERE CVE_DOC = '" + ped.cve_doc + "'";
                var res = GetExecute("DB", query, 100);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void ModificaDbPedidos(Pedidos pedFb, Pedidos pedDb)
        {
            string linea = "";
            try
            {
                linea = "1";
                string[] dats = { "AUTORIZACION", "SURTIR", "DETENIDO", "EMPAQUE", "MODIFICACION", "DETENIDO EMP" };
                linea = "2";
                if (pedDb.estatuspedido.In(dats))
                {
                    linea = "3";
                    pedFb.estatuspedido = (pedDb.estatuspedido != "EMPAQUE" && pedDb.estatuspedido != "DETENIDO EMP") ? pedDb.estatuspedido : "MODIFICACION";

                    linea = "4";
                    var query = "update PEDIDO set " +
                                "CAN_TOT = " + pedFb.can_tot.ToString(cultureInfo) + 
                                ", IMP_TOT1 = " + pedFb.imp_tot1.ToString(cultureInfo) + 
                                ", IMP_TOT2 = " + pedFb.imp_tot2.ToString(cultureInfo) + 
                                ", IMP_TOT3 = " + pedFb.imp_tot3.ToString(cultureInfo) + 
                                ", IMP_TOT4 = " + pedFb.imp_tot4.ToString(cultureInfo) + 
                                ", DES_TOT = " + pedFb.des_tot.ToString(cultureInfo) +
                                ", DES_FIN = " + pedFb.des_fin.ToString(cultureInfo) + 
                                ", COM_TOT = " + pedFb.com_tot +
                                ", DES_FIN_PORC = " + pedFb.des_fin_porc + 
                                ", DES_TOT_PORC = " + pedFb.des_tot_porc.ToString(cultureInfo) + 
                                ", IMPORTE = " + pedFb.importe.ToString(cultureInfo) + 
                                ", COM_TOT_PORC = " + pedFb.com_tot_porc.ToString(cultureInfo) +
                                ", ESTATUSPEDIDO = '" + pedFb.estatuspedido + "' " +
                                ", SOLAREA = NULL " +
                                ", OBSERVACIONES = '" + pedFb.observaciones + "' " +
                                ", CONSIGNACION = '" + pedFb.consignacion + "' " +
                                ", ENVIAR = '" + pedFb.enviar + "' " +
                                "where CVE_DOC = '" + pedFb.cve_doc + "'";
                    linea = "5";
                    if (GetExecute("DB", query, 14))
                    {
                        linea = "6";
                        query = "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values ('" +
                                pedFb.cve_doc + "', '" + pedFb.estatuspedido + "', getdate(), null)";
                        linea = "7";
                        var res = GetExecute("DB", query, 50);

                        linea = "8";
                        List<DetallePedidos> listFbDetalle = CargaFbDetallePedido(pedFb.cve_doc);
                        linea = "9";
                        List<DetallePedidos> listDbDetalle = CargaDbDetallePedido(pedFb.cve_doc);
                        linea = "10";
                        List<DetallePedidos> listDbDetalleEx = CargaDbDetallePedidoDev(pedFb.cve_doc);
                        linea = "11";
                        var detalleAct = listFbDetalle.Where(o => listDbDetalle.Any(p => o.cve_art == p.cve_art && o.num_par == p.num_par)).ToList();
                        linea = "12";
                        var detalleNuevos = listFbDetalle.Except(detalleAct).ToList();
                        linea = "13";
                        foreach (var det in detalleNuevos)
                        {
                            linea = "14-" + det.cve_doc.Trim();
                            GuardaDbDetallePedido(det);
                            linea = "15-" + det.cve_doc.Trim();
                            if (listDbDetalleEx.Count > 0)
                            {
                                linea = "16-" + det.cve_doc.Trim();
                                var detEx = listDbDetalleEx.Find(o => o.cve_art == det.cve_art);
                                linea = "17-" + det.cve_doc.Trim();
                                if (detEx != null)
                                {
                                    linea = "18-" + det.cve_doc.Trim();
                                    if (detEx.devuelto == false && detEx.cant > det.cant)
                                    {
                                        linea = "19-" + det.cve_doc.Trim();
                                        detEx.cant = detEx.cant - det.cant;
                                        linea = "20-" + det.cve_doc.Trim();
                                        var query2 = "update DETALLEPEDIDODEV set " +
                                                     "CANT = " + detEx.cant + " " +
                                                     "where CVE_DOC = '" + detEx.cve_doc + "' " +
                                                     "and NUM_PAR = " + detEx.num_par;
                                        linea = "21-" + det.cve_doc.Trim();
                                        GetExecute("DB", query, 51);
                                    }
                                    else if (detEx.devuelto == false && detEx.cant <= det.cant)
                                    {
                                        linea = "22-" + det.cve_doc.Trim();
                                        var query2 = "delete DETALLEPEDIDODEV " +
                                                     "where CVE_DOC = '" + detEx.cve_doc + "' " +
                                                     "and NUM_PAR = " + detEx.num_par;
                                        linea = "23-" + det.cve_doc.Trim();
                                        GetExecute("DB", query, 52);
                                    }
                                }
                            }
                        }

                        linea = "23";
                        listFbDetalle = CargaFbDetallePedido(pedFb.cve_doc);
                        linea = "24";
                        listDbDetalle = CargaDbDetallePedido(pedFb.cve_doc);
                        linea = "25";
                        var detalleAnt = listDbDetalle.Where(o => listFbDetalle.Any(p => o.cve_art == p.cve_art && o.num_par == p.num_par)).ToList();
                        linea = "26";
                        var detalleExcluidos = listDbDetalle.Except(detalleAnt).ToList();
                        linea = "27";
                        foreach (var det in detalleExcluidos) 
                        {
                            linea = "28-" + det.cve_doc.Trim();
                            CancelaDbDetallePedido(det);
                        }

                        linea = "29";
                        listFbDetalle = CargaFbDetallePedido(pedFb.cve_doc);
                        linea = "30";
                        listDbDetalle = CargaDbDetallePedido(pedFb.cve_doc);
                        linea = "31";
                        detalleAct = listFbDetalle.Where(o => listDbDetalle.Any(p => o.cve_art == p.cve_art)).ToList();
                        linea = "32";
                        var detalleIden = detalleAct.Where(o => listDbDetalle.Any(p => p.cve_art == o.cve_art && p.num_par == o.num_par && p.cant == o.cant)).ToList();
                        linea = "33";
                        var detalleDiferentes = detalleAct.Except(detalleIden).ToList();
                        linea = "34";
                        foreach (var detFB in detalleDiferentes)
                        {
                            linea = "35-" + detFB.cve_doc;
                            DetallePedidos detDB = listDbDetalle.FirstOrDefault(o => o.cve_art == detFB.cve_art);
                            linea = "36-" + detFB.cve_doc;
                            ModificaDbDetallePedido(detDB, detFB);
                            query = "update DETALLEPEDIDO set SURTIDO = 1 where CVE_DOC = '" + pedDb.cve_doc + "' and CANTSURTIDO = CANT and SURTIDO = 0"; //Valido que este surtido
                            GetExecute("DB", query, 14);
                        }
                        if (!validaExis(false, pedFb.cve_doc))
                        {
                            if (validaExis(true, pedFb.cve_doc))
                            {
                                query = "update PEDIDO set SOLAREA = 1 where CVE_DOC = '" + pedFb.cve_doc + "'";
                                GetExecute("DB", query, 14);
                            }
                        }
                    }
                }
                else if(pedDb.estatuspedido == "FACTURACION")
                {
                    linea = "37";
                    var est = (pedDb.tiposervicio == "LOCAL" || pedDb.tiposervicio == "LOCAL URGENTE" || pedDb.tiposervicio == "LOCAL INMEDIATO") ? "TERMINADO" : "GUIA";
                    linea = "38";
                    var query = "update PEDIDO set " +
                                "ESTATUSPEDIDO = '" + est + "' " +
                                "where CVE_DOC = '" + pedDb.cve_doc + "'";
                    linea = "39";
                    var res = GetExecute("DB", query, 35);
                    linea = "40";
                    query = "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values ('" +
                            pedDb.cve_doc + "', '" + est + "', getdate(), null)";
                    linea = "41";
                    res = GetExecute("DB", query, 36);
                }
                else if (pedDb.estatuspedido == "INGRESARGUIA")
                {
                    linea = "42";
                    var query = "update PEDIDO set ESTATUSPEDIDO = 'TERMINADO' " +
                                "where CVE_DOC = '" + pedDb.cve_doc + "'";
                    linea = "43";
                    var res = GetExecute("DB", query, 35);
                    linea = "44";
                    query = "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values ('" +
                            pedDb.cve_doc + "', 'TERMINADO', getdate(), null)";
                    linea = "45";
                    res = GetExecute("DB", query, 36);
                }
                else if (pedDb.estatuspedido == "PORCANCELAR")
                {
                    linea = "46";
                    var query = "update PEDIDO set ESTATUSPEDIDO = 'CANCELACION' " +
                                "where CVE_DOC = '" + pedDb.cve_doc + "'";
                    linea = "47";
                    var res = GetExecute("DB", query, 35);
                    linea = "48";
                    query = "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values ('" +
                            pedDb.cve_doc + "', 'CANCELACION', getdate(), null)";
                    linea = "49";
                    res = GetExecute("DB", query, 36);
                }

            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("14: " + ex.Message + " Linea : " + linea, EventLogEntryType.Error);
            }
        }

        private void ModificaDbDetallePedido(DetallePedidos detDB, DetallePedidos detFB)
        {
            try
            {
                double cantpendant = 0;
                if (detDB.cantsurtido > 0)
                {
                    if (detDB.cantsurtido >= detFB.cant)
                    {
                        var dif = detDB.cantsurtido - detFB.cant;
                        var query2 = "IF NOT EXISTS (SELECT * FROM DETALLEPEDIDODEV WHERE CVE_DOC = '" + detDB.cve_doc +
                                     "' AND NUM_PAR = " + detDB.num_par + ") " +
                                     "insert DETALLEPEDIDODEV (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, " +
                                     "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " +
                                     "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                                     "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR) select CVE_DOC, NUM_PAR, CVE_ART, " +
                                     dif + ", PXS, PREC, COST, " +
                                     "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3 , TOTIMP4, " +
                                     "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                                     "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR from DETALLEPEDIDO where CVE_ART = '" +
                                     detDB.cve_art + "' AND " +
                                     "CVE_DOC = '" + detDB.cve_doc +
                                     "' ELSE UPDATE DETALLEPEDIDODEV SET CANT = (CASE WHEN ISNULL(DEVUELTO,0) = 0 THEN CANT + " +
                                     dif + " ELSE " + dif + " END), " +
                                     "CANTDEVUELTO = (CASE WHEN ISNULL(DEVUELTO,0) = 0 THEN CANTDEVUELTO ELSE 0 END), DEVUELTO = 0 WHERE CVE_DOC = '" +
                                     detDB.cve_doc + "' AND NUM_PAR = " + detDB.num_par +
                                     " UPDATE DETALLEPEDIDODEV SET DEVUELTO = 1 WHERE CVE_DOC = '" + detDB.cve_doc +
                                     "' AND NUM_PAR = " + detDB.num_par + " AND CANT = 0";
                        GetExecute("DB", query2, 25);
                        detDB.cant = detFB.cant; //detDB.cantsurtido = detFB.cant;
                        detDB.cantpendiente = 0;
                        //detDB.surtido = false;
                    }
                    else if (detDB.cantsurtido < detFB.cant)
                    {
                        detDB.cant = detFB.cant;
                        if (detDB.cantpendiente > 0)
                        {
                            cantpendant = detDB.cantpendiente;
                            detDB.cantpendiente = detDB.cant - detDB.cantsurtido;
                        }
                        //detDB.surtido = ((detDB.cantsurtido + detDB.cantpendiente) == detDB.cant);
                    }
                }
                else
                {
                    if (detDB.cantpendiente > 0)
                    {
                        cantpendant = detDB.cantpendiente;
                        detDB.cantpendiente = 0;
                    }
                }
                if (detDB.cant > 0)
                {
                    detDB.surtido = ((int)(detDB.cantsurtido + detDB.cantpendiente) == (int)detDB.cant);
                }
                var query3 = "update DETALLEPEDIDO SET CANT = " + detFB.cant.ToString(cultureInfo) + 
                             ", PXS = " + detFB.pxs.ToString(cultureInfo) + 
                             ", PREC = " + detFB.prec.ToString(cultureInfo) +
                             ", COST = " + detFB.cost.ToString(cultureInfo) + 
                             ", IMPU1 = " + detFB.impu1.ToString(cultureInfo) + 
                             ", IMPU2 = " + detFB.impu2.ToString(cultureInfo) + 
                             ", IMPU3 = " + detFB.impu3.ToString(cultureInfo) +
                             ", IMPU4 = " + detFB.impu4.ToString(cultureInfo) +
                             ", IMP1APLA = " + detFB.imp1apla + 
                             ", IMP2APLA = " + detFB.imp2apla + 
                             ", IMP3APLA = " + detFB.imp3apla + 
                             ", IMP4APLA = " + detFB.imp4apla + 
                             ", TOTIMP1 = " + detFB.totimp1.ToString(cultureInfo) + 
                             ", TOTIMP2 = " + detFB.totimp2.ToString(cultureInfo) + 
                             ", TOTIMP3 = " + detFB.totimp3 + 
                             ", TOTIMP4 = " + detFB.totimp4.ToString(cultureInfo) + 
                             ", DESC1 = " + detFB.desc1.ToString(cultureInfo) + 
                             ", DESC2 = " + detFB.desc2.ToString(cultureInfo) + 
                             ", DESC3 = " + detFB.desc3.ToString(cultureInfo) +
                             ", COMI = " + detFB.comi.ToString(cultureInfo) + 
                             ", APAR = " + detFB.apar.ToString(cultureInfo) +
                             ", NUM_ALM = " + detFB.num_alm + 
                             ", TIP_CAM = " + detFB.tip_cam + 
                             ", TOT_PARTIDA = " + detFB.tot_partida +
                             ", CANTSURTIDO = " + detDB.cantsurtido + 
                             ", SURTIDO = " + ((detDB.surtido) ? "1" : "0") +
                             ", CANTPENDIENTE = " + detDB.cantpendiente +
                             " where NUM_PAR = " + detFB.num_par + " AND CVE_DOC = '" + detFB.cve_doc + "' " +
                             ((cantpendant > 0)
                                 ? "update DETALLEPEDIDOMERC set PEND = " + detDB.cantpendiente + 
                                   " where CVE_DOC = '" + detFB.cve_doc + "' and  CVE_ART = '" + detFB.cve_art + "' and ISNULL(PEND,0) = " + cantpendant + " and ISNULL(CANCELADO,0) = 0"
                                 : "");
                GetExecute("DB", query3, 15);
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("15: " + ex.Message, EventLogEntryType.Error);
            }
        }

        private void CancelaDbDetallePedido(DetallePedidos det)
        {
            try
            {
                var query =
                        "IF EXISTS (select * from DETALLEPEDIDODEV where CVE_DOC = '" + det.cve_doc + "' and CVE_ART = '" + det.cve_art + "' ) " +
                        "DELETE DETALLEPEDIDODEV where CVE_DOC = '" + det.cve_doc + "' and CVE_ART = '" + det.cve_art + "' " +
                        "insert DETALLEPEDIDODEV (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, " +
                        "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " +
                        "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                        "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR) select CVE_DOC, NUM_PAR, CVE_ART, isnull(CANTSURTIDO,0), PXS, PREC, COST, " +
                        "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " +
                        "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                        "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR from DETALLEPEDIDO where CVE_DOC = '" + det.cve_doc + "' " +
                        "and CVE_ART = '" + det.cve_art + "' and isnull(CANTSURTIDO,0) > 0 and NUM_PAR = " + det.num_par + " " +
                        "delete DETALLEPEDIDO where CVE_DOC = '" + det.cve_doc + "' and CVE_ART = '" + det.cve_art + "' and NUM_PAR = " + det.num_par;
                var res = GetExecute("DB", query, 16);
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("16: " + ex.Message, EventLogEntryType.Error);
            }
        }

        private List<Inventario> CargaFbInventarios()
        {
            List<Inventario> listFbInventarios = new List<Inventario>();
            try
            {
                var query = "select CVE_ART, replace(DESCR,'''','') DESCR, LIN_PROD, CON_SERIE, UNI_MED, UNI_EMP, CTRL_ALM, STOCK_MIN, " +
                            "STOCK_MAX, FCH_ULTVTA, EXIST, STATUS, CAMPLIB6 MASTERS, CAMPLIB10 MASTERS_UBI, VERSION_SINC FCH_ULTCOM " +
                            "from INVE01 i join inve_clib01 c on i.cve_art = c.cve_prod";
                listFbInventarios = GetFbDataTable("FB", query, 17).ToList<Inventario>();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("17: " + ex.Message, EventLogEntryType.Error);
            }
            return listFbInventarios;
        }

        private List<Inventario> CargaDbInventarios()
        {
            List<Inventario> listDbInventarios = new List<Inventario>();
            try
            {
                var query = "select CVE_ART, DESCR, LIN_PROD, CON_SERIE, UNI_MED, UNI_EMP, CTRL_ALM, STOCK_MIN, " +
                            "STOCK_MAX, FCH_ULTVTA, EXIST, STATUS, MASTERS, MASTERS_UBI, FCH_ULTCOM " +
                            "from INVENTARIO";
                listDbInventarios = GetDataTable("DB", query, 18).ToList<Inventario>();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("18: " + ex.Message, EventLogEntryType.Error);
            }
            return listDbInventarios;
        }

        private void GuardaInventario(Inventario inv)
        {
            var query = "";
            try
            {
                if(inv.cve_art.In("he2025", "tn3014")) { return; }
                query =
                    "insert INVENTARIO (CVE_ART, DESCR, LIN_PROD, CON_SERIE, UNI_MED, UNI_EMP, CTRL_ALM, STOCK_MIN, " +
                    "STOCK_MAX, FCH_ULTVTA, EXIST, STATUS, MASTERS, MASTERS_UBI, PESO, VOLUMEN, FCH_ULTCOM) " +
                    "values ('" + inv.cve_art + "', '" + inv.descr + "', '" + inv.lin_prod + "', '" + inv.con_serie + "', '" +
                    inv.uni_med + "', " + inv.uni_emp.ToString(cultureInfo) + ", '" + inv.ctrl_alm + "', " + inv.stock_min + ", " +
                    inv.stock_max.ToString(cultureInfo) + ", " + ((inv.fch_ultvta.Year == 1) ? "Null" : "'" + inv.fch_ultvta.ToString("yyyy-MM-dd") + "'") + ", " +
                    inv.exist.ToString(cultureInfo) + ", '" + inv.status + "', " + inv.masters.ToString(cultureInfo) + ", '" + inv.masters_ubi + "', " +
                    inv.peso + ", " + inv.volumen + ", " + ((inv.fch_ultcom.Year == 1) ? "Null" : "'" + inv.fch_ultcom.ToString("yyyy-MM-dd") + "'") + " )";
                var res = GetExecute("DB", query, 19);
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("19: " + ex.Message + "|" + query , EventLogEntryType.Error);
            }
        }

        private void ModificaInventario(Inventario inv)
        {
            var query = "";
            try
            {
                query =
                    "update INVENTARIO set DESCR = '" + inv.descr + "', LIN_PROD = '" + inv.lin_prod + "', CON_SERIE = '" +
                    inv.con_serie + "', UNI_MED = '" + inv.con_serie + "', UNI_EMP = " + inv.uni_emp.ToString(cultureInfo) + ", CTRL_ALM = '" +
                    inv.ctrl_alm + "', STOCK_MIN = " + inv.stock_min.ToString(cultureInfo) + ", STOCK_MAX = " + inv.stock_max.ToString(cultureInfo) + ", FCH_ULTVTA = " +
                    ((inv.fch_ultvta.Year == 1) ? "Null" : "'" + inv.fch_ultvta.ToString("yyyy-MM-dd") + "'") + ", EXIST = " +
                    inv.exist.ToString(cultureInfo) + ", STATUS = '" + inv.status + "', MASTERS = " + inv.masters.ToString(cultureInfo) + ", MASTERS_UBI = '" + 
                    inv.masters_ubi + "', FCH_ULTCOM = " + ((inv.fch_ultcom.Year == 1) ? "Null" : "'" + inv.fch_ultcom.ToString("yyyy-MM-dd") + "'") +
                    " where CVE_ART = '" + inv.cve_art + "'";
                var res = GetExecute("DB", query, 20);
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("20: " + ex.Message + query, EventLogEntryType.Error);
            }
        }

        private List<Pedidos> CargaDbPedidosFac()
        {
            List<Pedidos> listDbPedidos = new List<Pedidos>();
            try
            {
                var query =
                    "select TIP_DOC, CVE_DOC, CVE_CLPV, STATUS, DAT_MOSTR, CVE_VEND, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, " +
                    "FECHA_CANCELA, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, CONDICION, CVE_OBS, " +
                    "NUM_ALMA, ACT_CXC, ACT_COI, ENLAZADO, TIP_DOC_E, NUM_MONED, TIPCAMB, NUM_PAGOS, FECHAELAB, PRIMERPAGO, RFC, " +
                    "CTLPOL, ESCFD, AUTORIZA, SERIE, FOLIO, AUTOANIO, DAT_ENVIO, CONTADO, CVE_BITA, BLOQ, FORMAENVIO, DES_FIN_PORC, " +
                    "DES_TOT_PORC, IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, TIP_DOC_SIG, DOC_SIG, " +
                    "TIPOSERVICIO, ESTATUSPEDIDO, OCURREDOMICILIO, OBSERVACIONES, INDICACIONES INDICACION " +
                    "from PEDIDO where ESTATUSPEDIDO = 'FACTURACION'";
                listDbPedidos = GetDataTable("DB", query, 30).ToList<Pedidos>();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("30: " + ex.Message, EventLogEntryType.Error);
            }
            return listDbPedidos;
        }

        private List<Pedidos> CargaDbPedidosGuia()
        {
            List<Pedidos> listDbPedidos = new List<Pedidos>();
            try
            {
                var query =
                    "SELECT p.CVE_DOC, ('A ' + p.OCURREDOMICILIO + ' ' + o.Guias) observaciones, p.ESTATUSPEDIDO, " +
                    "CONDICION, TIPOSERVICIO, OCURREDOMICILIO FROM PEDIDO p JOIN ( " +
                    "SELECT d1.CVE_DOC, 'TOTAL DE GUIAS : ' + CAST(COUNT(d1.NUM_GUIA) AS VARCHAR(MAX)) + '; ' + STUFF((select '; ' + " +
                    "CASE WHEN TIPOPAQUETE IN('ATADOS', 'TARIMA') THEN TIPOPAQUETE + ' C/' + CAST(TOTART AS VARCHAR(2)) ELSE TIPOPAQUETE END + ' # ' + cast(d2.CONSEC_EMPAQUE as varchar(3)) + ' GUIA: ' + d2.NUM_GUIA " +
                    "from DETALLEPEDIDOMERC d2 where d2.NUM_GUIA IS NOT NULL and d2.CVE_DOC = d1.CVE_DOC FOR XML PATH('')), 1, 1, '') Guias " +
                    "FROM DETALLEPEDIDOMERC d1 WHERE NUM_GUIA IS NOT NULL GROUP BY CVE_DOC) o ON p.CVE_DOC = o.CVE_DOC " +
                    "WHERE p.ESTATUSPEDIDO = 'INGRESARGUIA' ";
                listDbPedidos = GetDataTable("DB", query, 30).ToList<Pedidos>();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("30: " + ex.Message, EventLogEntryType.Error);
            }
            return listDbPedidos;
        }

        private List<Pedidos> CargaDbPedidosCan()
        {
            List<Pedidos> listDbPedidos = new List<Pedidos>();
            try
            {
                var query =
                    "SELECT CVE_DOC, ESTATUSPEDIDO, CVE_OBS, OBSERVACIONES, INDICACIONES INDICACION FROM PEDIDO " +
                    "WHERE ESTATUSPEDIDO = 'PORCANCELAR' ";
                listDbPedidos = GetDataTable("DB", query, 30).ToList<Pedidos>();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("50: " + ex.Message, EventLogEntryType.Error);
            }
            return listDbPedidos;
        }

        private void ModificaFbDetallePedido(DetallePedidos detDB, DetallePedidos detFB)
        {
            try
            {
                if (detFB == null)
                {
                    var query2 =
                        "INSERT INTO PAR_FACTP01 (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, " +
                        "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " +
                        "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                        "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, MAN_IEPS, APL_MAN_IMP, COUTA_IEPS, APL_MAN_IEPS, MTO_CUOTA, " +
                        "CVE_ESQ) VALUES ('" + detDB.cve_doc + "', " + detDB.num_par.ToString(cultureInfo) + ", '" + detDB.cve_art + 
                        "', " + detDB.cantsurtido + ", " + detDB.cantsurtido + ", " + detDB.prec + ", " + detDB.cost + ", " + detDB.impu1 + 
                        ", " + detDB.impu2 + ", " + detDB.impu3 + ", " + detDB.impu4 + ", " + detDB.imp1apla + ", " + detDB.imp2apla +
                        ", " + detDB.imp3apla + ", " + detDB.imp4apla + ", " + detDB.totimp1 + ", " + detDB.totimp2 + ", " + detDB.totimp3 +
                        ", " + detDB.totimp4 + ", " + detDB.desc1 + ", " + detDB.desc2 + ", " + detDB.desc3 + ", " + detDB.comi +
                        ", " + detDB.apar + ", '" + detDB.act_inv + "', " + detDB.num_alm + ", '" + detDB.polit_apli + "', " + detDB.tip_cam + 
                        ", '" + detDB.uni_venta + "', '" + detDB.tipo_prod + "', " + detDB.cve_obs + ", " + detDB.reg_serie + ", " + detDB.e_ltpd +
                        ", '" + detDB.tipo_elem + "', " + detDB.num_mov + ", " + detDB.tot_partida + ", '" + detDB.imprimir + 
                        ", 'N', 1, 0.000, 'C', 0.000, 0.000 ) ";
                    GetFbExecute("FB", query2, 32);
                }
                if (detDB == null)
                {
                    var query3 = "delete from par_factp01 where (cve_doc = '" + detFB.cve_doc + "') and (num_par = " + detFB.num_par + ")";
                    GetFbExecute("FB", query3, 61);
                }
                else
                {
                    if (Math.Abs(detDB.cantsurtido) < 0.05)
                    {
                        var query3 = "delete from par_factp01 where (cve_doc = '" + detDB.cve_doc + "') and (num_par = " + detDB.num_par + ")";
                        GetFbExecute("FB", query3, 62);
                    }
                    else
                    {
                        var query3 = "update par_factp01 SET CANT = " + detDB.cantsurtido.ToString(cultureInfo) +
                                     ", PXS = " + detDB.cantsurtido.ToString(cultureInfo)+
                                     ", TOTIMP4 = " + detDB.totimp4.ToString(cultureInfo) +
                                     ", TOT_PARTIDA = " + detDB.tot_partida.ToString(cultureInfo) + " where NUM_PAR = " +
                                     detDB.num_par + " AND CVE_DOC = '" + detDB.cve_doc + "'";
                        GetFbExecute("FB", query3, 31);
                    }
                }
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("31: " + ex.Message, EventLogEntryType.Error);
            }
        }

        private void ModificaFbPedido(Pedidos pedFac)
        {
            try
            {
                var query = "";
                if (pedFac.cve_obs == 0)
                {
                    query = "select (ULT_CVE + 1) CVE_OBS FROM TBLCONTROL01 WHERE ID_TABLA = 56";
                    var f2 = GetFbDataTable("FB", query, 41).ToData<Guias>();
                    query = "UPDATE TBLCONTROL01 SET ULT_CVE = " + f2.cve_obs.ToString(cultureInfo) + " WHERE ID_TABLA = 56";
                    var res = GetFbExecute("FB", query, 48);
                    query = "insert into OBS_DOCF01 (CVE_OBS) values (" + f2.cve_obs + ") ";
                    res = GetFbExecute("FB", query, 45);
                    query = "update FACTP01 set CVE_OBS = " + f2.cve_obs + " where CVE_DOC = '" + pedFac.cve_doc + "'";
                    res = GetFbExecute("FB", query, 46);
                }

                var sf = pedFac.observaciones + "/" + pedFac.indicacion;
                var mf = (sf.Length > 255) ? 255 : sf.Length;
                query = "update OBS_DOCF01 set STR_OBS = '" + sf.Substring(0, mf) +
                        "' where CVE_OBS = '" + pedFac.cve_obs + "' ";
                var res2 = GetFbExecute("FB", query, 47);

                var query3 = "";
                if (pedFac.estatuspedido == "PORCANCELAR")
                {
                    query3 = "update FACTP01 SET STATUS = 'C'" + 
                             ", FECHA_CANCELA = GETDATE()" +
                             ", CONDICION = CONDICION + '/" + pedFac.indicacion + "' " +
                             "where CVE_DOC = '" + pedFac.cve_doc + "'";
                }
                else
                {
                    string[] dats = pedFac.condicion.Split(';');
                    string resp = "";
                    if (dats.Length == 2)
                    {
                        string[] clvTipoServ = { "L", "F", "LU", "FU" };
                        string[] catTipoServ = { "LOCAL", "FORANEO", "LOCAL URGENTE", "FORANEO URGENTE" };
                        int index = Array.IndexOf(catTipoServ, pedFac.tiposervicio);
                        resp = ((index > 0) ? clvTipoServ[index] : "L") + ";" + dats[1];
                    }
                    else if (dats.Length > 2)
                    {
                        string[] clvTipoServ = { "L", "F", "LU", "FU" };
                        string[] catTipoServ = { "LOCAL", "FORANEO", "LOCAL URGENTE", "FORANEO URGENTE" };
                        int index = Array.IndexOf(catTipoServ, pedFac.tiposervicio);

                        string[] clvTipoDom = { "OCU", "PAS", "DOM" };
                        string[] catTipoDom = { "OCURRE", "PASAN", "DOMICILIO" };
                        int index2 = Array.IndexOf(catTipoDom, pedFac.ocurredomicilio);
                        resp = ((index > 0) ? clvTipoServ[index] : "L") + ";" + ((index2 > 0) ? clvTipoDom[index2] : "OCU") + dats[2];
                    }

                    query3 = "update FACTP01 SET CAN_TOT = " + pedFac.can_tot +
                             ", IMP_TOT4 = " + pedFac.imp_tot4 +
                             ", DES_TOT = " + pedFac.des_tot +
                             ", COM_TOT = " + pedFac.com_tot +
                             ", IMPORTE = " + pedFac.importe +
                             ", CONTADO = '" + pedFac.contado + "' " +
                             ", CONDICION = '" + resp + "' " +
                             "where CVE_DOC = '" + pedFac.cve_doc + "'";
                }
                GetFbExecute("FB", query3, 33);
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("33: " + ex.Message, EventLogEntryType.Error);
            }
        }

        private Factura CargaFbFactura(string cvedoc)
        {
            var linea = "1";
            Factura fac = new Factura();
            linea = "2";
            try
            {
                linea = "3";
                var query = "SELECT f.CVE_DOC, f.DOC_ANT, f.DAT_ENVIO, i.CVE_OBS, o.STR_OBS " +
                            "FROM FACTF01 f LEFT JOIN INFENVIO01 i ON i.CVE_INFO = f.DAT_ENVIO " +
                            "LEFT JOIN OBS_DOCF01 o ON o.CVE_OBS = i.CVE_OBS " +
                            "WHERE f.DOC_ANT = '" + cvedoc + "'";
                linea = "4";
                fac = GetFbDataTable("FB", query, 40).ToData<Factura>();

                if (fac != null)
                {
                    linea = "5";
                    query = "select f.cve_doc, i.descr from par_factf01 f " +
                            "join INVE01 i on f.cve_art = i.cve_art and i.uni_med = 'flete' " +
                            "where cve_doc = '" + fac.cve_doc + "'";
                    linea = "6";
                    List<FacturaDet> detfac = new List<FacturaDet>();
                    linea = "7";
                    detfac = GetFbDataTable("FB", query, 40).ToList<FacturaDet>();
                    linea = "8";
                    var strpaq = "";
                    linea = "9";
                    foreach (var det in detfac)
                    {
                        linea = "10";
                        strpaq += det.descr + "; ";
                    }
                    linea = "11";
                    fac.str_paq = strpaq;
                }
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("40: " + ex.Message + " Linea :" + linea + " cvedoc " + cvedoc, EventLogEntryType.Error);
            }
            return fac;
        }

        private void ModificaFbFactura(Factura fac, Pedidos ped)
        {
            try
            {
                var query = "";
                if (fac.dat_envio == 0)
                {
                    query = "select (ULT_CVE + 1) CVE_INFO FROM TBLCONTROL01 WHERE ID_TABLA = 70";
                    var f1 = GetFbDataTable("FB", query, 41).ToData<Guias>();
                    query = "UPDATE TBLCONTROL01 SET ULT_CVE = " + f1.cve_info.ToString(cultureInfo) + " WHERE ID_TABLA = 70";
                    var res = GetFbExecute("FB", query, 48);
                    query = "insert into INFENVIO01 (CVE_INFO) values (" + f1.cve_info.ToString(cultureInfo) + ") ";
                    res = GetFbExecute("FB", query, 42);
                    query = "update FACTF01 set DAT_ENVIO = " + f1.cve_info.ToString(cultureInfo) + " where CVE_DOC = '" + fac.cve_doc + "'";
                    res = GetFbExecute("FB", query, 43);
                    fac = CargaFbFactura(fac.doc_ant);
                }
                if (fac.cve_obs == 0)
                {
                    query = "select (ULT_CVE + 1) CVE_OBS FROM TBLCONTROL01 WHERE ID_TABLA = 56";
                    var f2 = GetFbDataTable("FB", query, 41).ToData<Guias>();
                    query = "UPDATE TBLCONTROL01 SET ULT_CVE = " + f2.cve_obs.ToString(cultureInfo) + " WHERE ID_TABLA = 56";
                    var res = GetFbExecute("FB", query, 48);
                    query = "insert into OBS_DOCF01 (CVE_OBS) values (" + f2.cve_obs + ") ";
                    res = GetFbExecute("FB", query, 45);
                    query = "update INFENVIO01 set CVE_OBS = " + f2.cve_obs + " where CVE_INFO = '" + fac.dat_envio + "'";
                    res = GetFbExecute("FB", query, 46);
                    fac = CargaFbFactura(fac.doc_ant);
                }
                var sf = "Paquetería : " + fac.str_paq + " " + ped.observaciones;
                var mf = (sf.Length > 255) ? 255 : sf.Length;
                query = "update OBS_DOCF01 set STR_OBS = '" + sf.Substring(0,mf) +
                        "' where CVE_OBS = '" + fac.cve_obs + "' ";
                var res2 = GetFbExecute("FB", query, 47);
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("41: " + ex.Message, EventLogEntryType.Error);
            }
        }

        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer1.Stop();
            eventLog1.WriteEntry("Inicio Consulta");
            consultar();
            eventLog1.WriteEntry("Finalizo Consulta");
            timer1.Start();
        }
    }
}
