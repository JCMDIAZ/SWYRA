﻿using System;
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
            timer1.Interval = 2 * 60 * 1000;
            timer1.Enabled = true;
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In onStop.");
        }

        private void consultar()
        {
            List<Precios> listFbPrecios = CargaFbPrecios();
            List<Precios> listDbPrecios = CargaDbPrecios();
            var preciosAct = listFbPrecios.Where(o => listDbPrecios.Any(p => p.cve_art == o.cve_art && p.cve_precio == o.cve_precio)).ToList();
            var preciosNvo = listFbPrecios.Except(preciosAct).ToList();
            var preciosDif = preciosAct.Except(preciosAct.Where(o => listDbPrecios.Any(p => p.precio == o.precio)).ToList()).ToList();
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
            var clientesDif = clientesAct.Except(clientesAct.Where(o => listDbClientes.Any(p => p.fch_ultcom == o.fch_ultcom)).ToList()).ToList();
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
            var inventarioDif = inventarioAct.Except(inventarioAct.Where(o => listFbInventarios.Any(p => p.fch_ultvta == o.fch_ultvta || p.uni_emp == o.uni_emp)).ToList()).ToList();
            foreach (var inv in inventarioNvo)
            {
                GuardaInventario(inv);
            }
            foreach (var inv in inventarioDif)
            {
                ModificaInventario(inv);
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
            }
            foreach (var ped in pedidosCan)
            {
                var pedDb = listDbPedidos.FirstOrDefault(o => o.cve_doc == ped.cve_doc);
                CancelaDbPedidos(pedDb);
            }
            foreach (var pedFb in pedidosDiferentes)
            {
                var pedDb = listDbPedidos.FirstOrDefault(o => o.cve_doc == pedFb.cve_doc);
                ModificaDbPedidos(pedFb, pedDb);
            }

            List<Pedidos> listDbPedidosFac = CargaDbPedidosFac();
            foreach (var pedFac in listDbPedidosFac)
            {
                var lsDbDetPed = CargaDbDetallePedido(pedFac.cve_doc);
                var lsFbDetPed = CargaFbDetallePedido(pedFac.cve_doc);

                foreach (var detDB in lsDbDetPed)
                {
                    var detFB = lsFbDetPed.First(o => o.num_par == detDB.num_par);
                    ModificaFbDetallePedido(detDB, detFB);
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
                    "DES_TOT_PORC, IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, TIP_DOC_SIG, DOC_SIG, " +
                    "STR_OBS OBSERVACIONES, v.NOMBRE NOMBRE_VENDEDOR, (i.CALLE || ' # ' || i.NUMEXT || ' COL. ' || i.COLONIA || '; ' || i.MUNICIPIO || ', ' || i.ESTADO) consignacion " +
                    "from FACTP01 p LEFT JOIN OBS_DOCF01 o ON p.CVE_OBS = o.CVE_OBS LEFT JOIN VEND01 v ON p.CVE_VEND = v.CVE_VEND " +
                    "LEFT JOIN INFENVIO01 i ON i.CVE_INFO = p.DAT_ENVIO " +
                    "where FECHA_ENT between '" + fini.ToString("yyyy-MM-dd") + "' and '" +
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
                    "TIPOSERVICIO, ESTATUSPEDIDO, OCURREDOMICILIO " +
                    "from PEDIDO where FECHA_ENT between '" + fini.ToString("yyyy-MM-dd") + "' and '" +
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

        private void GuardarDbPedidos(Pedidos p)
        {
            var query = "";
            var seguimiento = "";
            try
            {
                p.condicion = p.condicion ?? "";
                string[] dats = p.condicion.Split(';');
                if (dats.Length == 1)
                {
                    string[] clvTipoServ = {"L", "F", "LU", "FU"};
                    string[] catTipoServ = {"LOCAL", "FORANEO", "LOCAL URGENTE", "FORANEO URGENTE"};
                    int index = Array.IndexOf(clvTipoServ, dats[0]);
                    p.tiposervicio = (index > 0) ? catTipoServ[index] : "LOCAL";
                }
                else if (dats.Length > 1)
                {
                    string[] clvTipoServ = { "L", "F", "LU", "FU" };
                    string[] catTipoServ = { "LOCAL", "FORANEO", "LOCAL URGENTE", "FORANEO URGENTE" };
                    int index = Array.IndexOf(clvTipoServ, dats[0]);
                    p.tiposervicio = (index > 0) ? catTipoServ[index] : "LOCAL";

                    string[] clvTipoDom = { "OCU", "PAS", "DOM" };
                    string[] catTipoDom = { "OCURRE", "PASAN", "DOMICILIO" };
                    index = Array.IndexOf(clvTipoDom, dats[1]);
                    p.ocurredomicilio = (index > 0) ? catTipoDom[index] : "OCURRE";
                }
                p.estatuspedido = "AUTORIZACION";
                var cobrador = GetUsuarioIdByERP(p.cve_clpv);
                query =
                    "insert into PEDIDO (TIP_DOC, CVE_DOC, CVE_CLPV, STATUS, DAT_MOSTR, CVE_VEND, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, " +
                    "FECHA_CANCELA, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, CONDICION, CVE_OBS, " +
                    "NUM_ALMA, ACT_CXC, ACT_COI, ENLAZADO, TIP_DOC_E, NUM_MONED, TIPCAMB, NUM_PAGOS, FECHAELAB, PRIMERPAGO, RFC, " +
                    "CTLPOL, ESCFD, AUTORIZA, SERIE, FOLIO, AUTOANIO, DAT_ENVIO, CONTADO, CVE_BITA, BLOQ, FORMAENVIO, DES_FIN_PORC, " +
                    "DES_TOT_PORC, IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, TIP_DOC_SIG, DOC_SIG, " +
                    "TIPOSERVICIO, ESTATUSPEDIDO, OCURREDOMICILIO, COBRADOR_ASIGNADO, PRIORIDAD, OBSERVACIONES, NOMBRE_VENDEDOR, CONSIGNACION) values ('" +
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
                    p.ocurredomicilio + "', '" + cobrador + "', 'NORMAL', '" + p.observaciones + "', '" + p.nombre_vendedor + "', '" + p.consignacion + "' )";
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
                    "select CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, " +
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

        private void GuardaDbDetallePedido(DetallePedidos ped)
        {
            try
            {
                var query = "insert DETALLEPEDIDO (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, " +
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
                string[] dats = { "AUTORIZACION", "SURTIR", "DETENIDO", "EMPAQUE", "MODIFICACION" };
                if (pedDb.estatuspedido.In(dats))
                {
                    pedDb.estatuspedido = (pedDb.estatuspedido == "AUTORIZACION") ? "CANCELACION" : "DEVOLUCION";
                    var query = "update PEDIDO set STATUS = '" + pedDb.status + "', " +
                                "ESTATUSPEDIDO = '" + pedDb.estatuspedido + "' " +
                                "where CVE_DOC = '" + pedDb.cve_doc + "'";
                    if (GetExecute("DB", query, 12))
                    {
                        var query3 = "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values ('" +
                                     pedDb.cve_doc + "', '" + pedDb.estatuspedido + "', getdate(), null)";
                        var res2 = GetExecute("DB", query, 12);
                        if (pedDb.estatuspedido == "MODIFICACION")
                        {
                            var query2 = "insert DETALLEPEDIDODEV (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, " +
                                         "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " +
                                         "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                                         "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR) select CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, " +
                                         "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " +
                                         "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                                         "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR from DETALLEPEDIDO where CVE_DOC = '" +
                                         pedDb.cve_doc + "' " +
                                         "and isnull(SURTIDO,0) = 1 delete DETALLEPEDIDO where CVE_DOC = '" +
                                         pedDb.cve_doc + "'";
                            var res = GetExecute("DB", query2, 13);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("13: " + ex.Message, EventLogEntryType.Error);
            }
        }

        private void ModificaDbPedidos(Pedidos pedFb, Pedidos pedDb)
        {
            try
            {
                string[] dats = { "AUTORIZACION", "SURTIR", "DETENIDO", "EMPAQUE", "MODIFICACION" };
                if (pedDb.estatuspedido.In(dats))
                {
                    pedFb.estatuspedido = (pedDb.estatuspedido != "EMPAQUE") ? pedDb.estatuspedido : "MODIFICACION";

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
                                "where CVE_DOC = '" + pedFb.cve_doc + "'";
                    if (GetExecute("DB", query, 14))
                    {
                        query = "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values ('" +
                                pedFb.cve_doc + "', '" + pedFb.estatuspedido + "', getdate(), null)";
                        var res = GetExecute("DB", query, 14);
                        List<DetallePedidos> listFbDetalle = CargaFbDetallePedido(pedFb.cve_doc);
                        List<DetallePedidos> listDbDetalle = CargaDbDetallePedido(pedFb.cve_doc);
                        var detalleAct = listFbDetalle.Where(o => listDbDetalle.Any(p => o.cve_art == p.cve_art)).ToList();
                        var detalleNuevos = listFbDetalle.Except(detalleAct).ToList();
                        var detalleExcluidos = listDbDetalle.Except(listDbDetalle.Where(o => listFbDetalle.Any(p => o.cve_art == p.cve_art))).ToList();
                        var detalleDiferentes = detalleAct.Except(detalleAct.Where(o => listDbDetalle.Any(p => p.cve_art == o.cve_art && p.cant == o.cant))).ToList();
                        foreach (var det in detalleNuevos)
                        {
                            GuardaDbDetallePedido(det);
                        }
                        foreach (var det in detalleExcluidos)
                        {
                            CancelaDbDetallePedido(det);
                        }
                        foreach (var detFB in detalleDiferentes)
                        {
                            DetallePedidos detDB = listDbDetalle.FirstOrDefault(o => o.cve_art == detFB.cve_art);
                            ModificaDbDetallePedido(detDB, detFB);
                        }
                    }
                }
                else if(pedDb.estatuspedido == "FACTURACION")
                {
                    var est = (pedDb.ocurredomicilio == "PASAN" || ((pedDb.tiposervicio == "LOCAL" || pedDb.tiposervicio == "LOCAL URGENTE") &&
                               pedDb.ocurredomicilio == "DOMICILIO")) ? "TERMINADO" : "GUIA";
                    var query = "update PEDIDO set " +
                                "ESTATUSPEDIDO = '" + est + "' " +
                                "where CVE_DOC = '" + pedDb.cve_doc + "'";
                    var res = GetExecute("DB", query, 35);
                    query = "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values ('" +
                            pedFb.cve_doc + "', 'LEVANTAMIENTO', getdate(), null)";
                    res = GetExecute("DB", query, 36);
                }
                else if (pedDb.estatuspedido == "INGRESARGUIA")
                {
                    var query = "update PEDIDO set ESTATUSPEDIDO = 'TERMINADO' " +
                                "where CVE_DOC = '" + pedDb.cve_doc + "'";
                    var res = GetExecute("DB", query, 35);
                    query = "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values ('" +
                            pedFb.cve_doc + "', 'TERMINADO', getdate(), null)";
                    res = GetExecute("DB", query, 36);
                }
                else if (pedDb.estatuspedido == "PORCANCELAR")
                {
                    var query = "update PEDIDO set ESTATUSPEDIDO = 'CANCELACION' " +
                                "where CVE_DOC = '" + pedDb.cve_doc + "'";
                    var res = GetExecute("DB", query, 35);
                    query = "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values ('" +
                            pedFb.cve_doc + "', 'CANCELACION', getdate(), null)";
                    res = GetExecute("DB", query, 36);
                }

            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("14: " + ex.Message, EventLogEntryType.Error);
            }
        }

        private void ModificaDbDetallePedido(DetallePedidos detDB, DetallePedidos detFB)
        {
            try
            {
                if (detDB.cantsurtido > 0)
                {
                    if (detDB.cantsurtido > detFB.cant)
                    {
                        var dif = detDB.cantsurtido - detFB.cant;
                        var query2 =
                            "insert DETALLEPEDIDODEV (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, " +
                            "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " +
                            "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                            "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR) select CVE_DOC, NUM_PAR, CVE_ART, " + dif + ", PXS, PREC, COST, " +
                            "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3 , TOTIMP4, " +
                            "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                            "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR from DETALLEPEDIDO where CVE_ART = '" + detDB.cve_art + "' AND " +
                            "CVE_DOC = '" + detDB.cve_doc + "'";
                        GetExecute("DB", query2, 25);
                        detDB.cantsurtido = detFB.cant;
                    }
                    else
                    {
                        detFB.cant = detDB.cantsurtido;
                    }
                }
                var query3 = "update DETALLEPEDIDO SET CANT = " + detFB.cant.ToString(cultureInfo) + ", PXS = " + detFB.pxs.ToString(cultureInfo) + ", PREC = " + detFB.prec.ToString(cultureInfo) + ", COST = " + detFB.cost.ToString(cultureInfo) + ", " +
                             "IMPU1 = " + detFB.impu1.ToString(cultureInfo) + ", IMPU2 = " + detFB.impu2.ToString(cultureInfo) + ", IMPU3 = " + detFB.impu3.ToString(cultureInfo) + ", IMPU4 = " + detFB.impu4.ToString(cultureInfo) + ", " +
                             "IMP1APLA = " + detFB.imp1apla + ", IMP2APLA = " + detFB.imp2apla + ", IMP3APLA = " + detFB.imp3apla + ", IMP4APLA = " + detFB.imp4apla + ", " +
                             "TOTIMP1 = " + detFB.totimp1.ToString(cultureInfo) + ", TOTIMP2 = " + detFB.totimp2.ToString(cultureInfo) + ", TOTIMP3 = " + detFB.totimp3 + ", TOTIMP4 = " + detFB.totimp4.ToString(cultureInfo) + ", " +
                             "DESC1 = " + detFB.desc1.ToString(cultureInfo) + ", DESC2 = " + detFB.desc2.ToString(cultureInfo) + ", DESC3 = " + detFB.desc3.ToString(cultureInfo) + ", COMI = " + detFB.comi.ToString(cultureInfo) + ", APAR = " + detFB.apar.ToString(cultureInfo) + ", " +
                             "NUM_ALM = " + detFB.num_alm + ", TIP_CAM = " + detFB.tip_cam + ", TOT_PARTIDA = " + detFB.tot_partida + ", " +
                             "CANTSURTIDO = " + detDB.cantsurtido + ", SURTIDO = 0 where CVE_ART = '" + detFB.cve_art + "' AND " +
                             "CVE_DOC = '" + detFB.cve_doc + "'";
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
                var query = "insert DETALLEPEDIDODEV (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, " +
                             "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " +
                             "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                             "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR) select CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, " +
                             "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " +
                             "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                             "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR from DETALLEPEDIDO where CVE_DOC = '" + det.cve_doc + "' " +
                             "and CVE_ART = '" + det.cve_art + "' and isnull(SURTIDO,0) = 1 " +
                             "delete DETALLEPEDIDO where CVE_DOC = '" + det.cve_doc + "' and CVE_ART = '" + det.cve_art + "'";
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
                            "STOCK_MAX, FCH_ULTVTA, EXIST, STATUS, CAMPLIB6 MASTERS, CAMPLIB10 MASTERS_UBI " +
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
                            "STOCK_MAX, FCH_ULTVTA, EXIST, STATUS, MASTERS, MASTERS_UBI " +
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
                    "STOCK_MAX, FCH_ULTVTA, EXIST, STATUS, MASTERS, MASTERS_UBI, PESO, VOLUMEN) " +
                    "values ('" + inv.cve_art + "', '" + inv.descr + "', '" + inv.lin_prod + "', '" + inv.con_serie + "', '" +
                    inv.uni_med + "', " + inv.uni_emp.ToString(cultureInfo) + ", '" + inv.ctrl_alm + "', " + inv.stock_min + ", " +
                    inv.stock_max.ToString(cultureInfo) + ", " + ((inv.fch_ultvta.Year == 1) ? "Null" : "'" + inv.fch_ultvta.ToString("yyyy-MM-dd") + "'") + ", " +
                    inv.exist.ToString(cultureInfo) + ", '" + inv.status + "', " + inv.masters.ToString(cultureInfo) + ", '" + inv.masters_ubi + "', " +
                    inv.peso + ", " + inv.volumen + ")";
                var res = GetExecute("DB", query, 19);
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("19: " + ex.Message + "|" + query , EventLogEntryType.Error);
            }
        }

        private void ModificaInventario(Inventario inv)
        {
            try
            {
                var query =
                    "update INVENTARIO set DESCR = '" + inv.descr + "', LIN_PROD = '" + inv.lin_prod + "', CON_SERIE = '" +
                    inv.con_serie + "', UNI_MED = '" + inv.con_serie + "', UNI_EMP = " + inv.uni_emp.ToString(cultureInfo) + ", CTRL_ALM = '" +
                    inv.ctrl_alm + "', STOCK_MIN = " + inv.stock_min.ToString(cultureInfo) + ", STOCK_MAX = " + inv.stock_max.ToString(cultureInfo) + ", FCH_ULTVTA = " +
                    ((inv.fch_ultvta.Year == 1) ? "Null" : "'" + inv.fch_ultvta.ToString("yyyy-MM-dd") + "'") + ", EXIST = " +
                    inv.exist.ToString(cultureInfo) + ", STATUS = '" + inv.status + "', MASTERS = " + inv.masters.ToString(cultureInfo) + ", MASTERS_UBI = '" + inv.masters_ubi + "' " +
                    "where CVE_ART = '" + inv.cve_art + "'";
                var res = GetExecute("DB", query, 20);
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("20: " + ex.Message, EventLogEntryType.Error);
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
                    "TIPOSERVICIO, ESTATUSPEDIDO, OCURREDOMICILIO " +
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
                    "SELECT p.CVE_DOC, ('A ' + p.OCURREDOMICILIO + ' ' + o.Guias) observaciones FROM PEDIDO p JOIN ( " +
                    "SELECT d1.CVE_DOC, 'TOTAL DE GUIAS : ' + CAST(COUNT(DISTINCT d1.NUM_GUIA) AS VARCHAR(MAX)) + '; ' + STUFF((select '; ' + " +
                    "CASE WHEN TIPOPAQUETE IN('ATADOS', 'TARIMA') THEN TIPOPAQUETE + ' C/' + CAST(TOTART AS VARCHAR(2)) ELSE TIPOPAQUETE END + ' NUM. GUIA ' + d2.NUM_GUIA " +
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
                    "SELECT CVE_DOC, ESTATUSPEDIDO FROM PEDIDO " +
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
                        "INSERT PAR_FACTP01 (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, " +
                        "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " +
                        "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                        "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, MAN_IEPS, APL_MAN_IMP, COUTA_IEPS, APL_MAN_IEPS, MTO_CUOTA, " +
                        "CVE_ESQ) VALUES ('" + detDB.cve_doc + "', " + detDB.num_par.ToString() + ", '" + detDB.cve_art + 
                        "', " + detDB.cantsurtido + ", " + detDB.pxs + ", " + detDB.prec + ", " + detDB.cost + ", " + detDB.impu1 + 
                        ", " + detDB.impu2 + ", " + detDB.impu3 + ", " + detDB.impu4 + ", " + detDB.imp1apla + ", " + detDB.imp2apla +
                        ", " + detDB.imp3apla + ", " + detDB.imp4apla + ", " + detDB.totimp1 + ", " + detDB.totimp2 + ", " + detDB.totimp3 +
                        ", " + detDB.totimp4 + ", " + detDB.desc1 + ", " + detDB.desc2 + ", " + detDB.desc3 + ", " + detDB.comi +
                        ", " + detDB.apar + ", '" + detDB.act_inv + "', " + detDB.num_alm + ", '" + detDB.polit_apli + "', " + detDB.tip_cam + 
                        ", '" + detDB.uni_venta + "', '" + detDB.tipo_prod + "', " + detDB.cve_obs + ", " + detDB.reg_serie + ", " + detDB.e_ltpd +
                        ", '" + detDB.tipo_elem + "', " + detDB.num_mov + ", " + detDB.tot_partida + ", '" + detDB.imprimir + 
                        ", 'N', 1, 0.000, 'C', 0.000, 0.000 ) ";
                    GetFbExecute("FB", query2, 32);
                }
                else
                {
                    var query3 = "update PAR_FACTP01 SET CANT = " + detDB.cantsurtido.ToString(cultureInfo) + 
                                 ", TOTIMP4 = " + detDB.totimp4.ToString(cultureInfo) + ", " +
                                 ", TOT_PARTIDA = " + detDB.tot_partida.ToString() + " where NUM_PAR = " +
                                 detDB.num_par + "' AND CVE_DOC = '" + detDB.cve_doc + "'";
                    GetFbExecute("FB", query3, 31);
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
                var query3 = "";
                if (pedFac.estatuspedido == "PORCANCELAR")
                {
                    query3 = "update PAR_FACTP01 SET STATUS = 'C'" + 
                             ", FECHA_CANCELA = GETDATE()" +
                             ", CONDICION = CONDICION + '" + pedFac.indicacion + "' " +
                             "where CVE_DOC = '" + pedFac.cve_doc + "'";
                }
                else
                {
                    query3 = "update PAR_FACTP01 SET CAN_TOT = " + pedFac.can_tot +
                             ", IMP_TOT4 = " + pedFac.imp_tot4 +
                             ", DES_TOT = " + pedFac.des_tot +
                             ", COM_TOT = " + pedFac.com_tot +
                             ", IMPORTE = " + pedFac.importe +
                             ", CONTADO = '" + pedFac.contado + "' " +
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
            Factura fac = new Factura();
            try
            {
                var query = "SELECT f.CVE_DOC, f.DOC_ANT, f.DAT_ENVIO, i.CVE_OBS, o.STR_OBS " +
                            "FROM FACTF01 f LEFT JOIN INFENVIO01 i ON i.CVE_INFO = f.DAT_ENVIO " +
                            "LEFT JOIN OBS_DOCF01 o ON o.CVE_OBS = i.CVE_OBS " +
                            "WHERE f.DOC_ANT = '" + cvedoc + "'";
                fac = GetFbDataTable("FB", query, 40).ToData<Factura>();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("40: " + ex.Message, EventLogEntryType.Error);
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
                    query = "declare maxdat int" +
                            "select max(CVE_INFO) + 1 FROM INFENVIO01 INTO maxdat " +
                            "insert into INFENVIO01 (CVE_INFO) values (maxdat) " +
                            "update FACTF01 set DAT_ENVIO = maxdat where CVE_DOC = '" + fac.cve_doc + "'";
                    var res = GetFbExecute("FB", query, 41);
                    fac = CargaFbFactura(fac.doc_ant);
                }
                if (fac.dat_envio == 0)
                {
                    query = "declare maxdat int" +
                            "select max(CVE_OBS) + 1 FROM OBS_DOCF01 INTO maxdat " +
                            "insert into OBS_DOCF01 (CVE_INFO) values (maxdat) " +
                            "update INFENVIO01 set CVE_OBS = maxdat where CVE_INFO = '" + fac.dat_envio + "'";
                    var res = GetFbExecute("FB", query, 42);
                    fac = CargaFbFactura(fac.doc_ant);
                }
                query = "update OBS_DOCF01 set STR_OBS = '" + ped.observaciones +
                        "' where CVE_OBS = '" + fac.cve_obs + "' ";
                fac = GetFbDataTable("FB", query, 43).ToData<Factura>();
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
