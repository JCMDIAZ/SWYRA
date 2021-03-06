﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using LinqToDB;
using static SWYRA.General;
using System.Net.Sockets;

namespace SWYRA
{
    public partial class Test : Form
    {          
        public Test()
        {
            InitializeComponent();
        }

        private List<Inventario> CargaFbInventarios()
        {
            List<Inventario> listFbInventarios = new List<Inventario>();
            try
            {
                var query = "select CVE_ART, DESCR, LIN_PROD, CON_SERIE, UNI_MED, UNI_EMP, CTRL_ALM, STOCK_MIN, " + 
                            "STOCK_MAX, FCH_ULTVTA, EXIST, STATUS, CAMPLIB5 MASTERS, CAMPLIB6 MASTERS_UBI " +
                            "from INVE01 i join inve_clib01 c on i.cve_art = c.cve_prod";
                listFbInventarios = GetFbDataTable("FB", query, 5).ToList<Inventario>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                            "from INVENTARIO";listDbInventarios = GetDataTable("DB", query, 5).ToList<Inventario>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listDbInventarios;
        }

        private List<Pedidos> CargaFbPedidos(DateTime fini, DateTime ffin)
        {
            List<Pedidos> listFbPedidos = new List<Pedidos>();
            try
            {
                var query =
                    "select TIP_DOC, CVE_DOC, CVE_CLPV, STATUS, DAT_MOSTR, CVE_VEND, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, " +
                    "FECHA_CANCELA, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, CONDICION, CVE_OBS, " +
                    "NUM_ALMA, ACT_CXC, ACT_COI, ENLAZADO, TIP_DOC_E, NUM_MONED, TIPCAMB, NUM_PAGOS, FECHAELAB, PRIMERPAGO, RFC, " +
                    "CTLPOL, ESCFD, AUTORIZA, SERIE, FOLIO, AUTOANIO, DAT_ENVIO, CONTADO, CVE_BITA, BLOQ, FORMAENVIO, DES_FIN_PORC, " +
                    "DES_TOT_PORC, IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, TIP_DOC_SIG, DOC_SIG " +
                    "from FACTP01 where FECHA_ENT between '" + fini.ToString("yyyy-MM-dd") + "' and '" +
                    ffin.ToString("yyyy-MM-dd") + "'";
                listFbPedidos = GetFbDataTable("FB", query, 6).ToList<Pedidos>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                listDbPedidos = GetDataTable("DB", query, 6).ToList<Pedidos>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listDbPedidos;
        }

        private void GuardarDbPedidos(Pedidos p)
        {
            try
            {
                string[] dats = p.condicion.Split(';');
                if (dats.Length > 0)
                {
                    string[] catTipoServ = {"LOCAL", "FORANEO", "LOCAL URGENTE", "FORANEO URGENTE"};
                    p.tiposervicio = (catTipoServ.Contains(dats[0])) ? dats[0] : "LOCAL";
                }
                p.ocurredomicilio = (p.condicion.ToUpper().Contains("OCURRRE")) ? "OCURRE" : "DOMICILIO";
                p.estatuspedido = "AUTORIZACION";
                var query =
                    "insert into PEDIDO (TIP_DOC, CVE_DOC, CVE_CLPV, STATUS, DAT_MOSTR, CVE_VEND, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, " +
                    "FECHA_CANCELA, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, CONDICION, CVE_OBS, " +
                    "NUM_ALMA, ACT_CXC, ACT_COI, ENLAZADO, TIP_DOC_E, NUM_MONED, TIPCAMB, NUM_PAGOS, FECHAELAB, PRIMERPAGO, RFC, " +
                    "CTLPOL, ESCFD, AUTORIZA, SERIE, FOLIO, AUTOANIO, DAT_ENVIO, CONTADO, CVE_BITA, BLOQ, FORMAENVIO, DES_FIN_PORC, " +
                    "DES_TOT_PORC, IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, TIP_DOC_SIG, DOC_SIG, " + 
                    "TIPOSERVICIO, ESTATUSPEDIDO, OCURREDOMICILIO) values ('" +
                    p.tip_doc + "', '" + p.cve_doc + "', '" + p.cve_clpv + "', '" + p.status + "', " + p.dat_mostr.ToString() +", '" + p.cve_vend + "', '" +
                    p.cve_pedi + "', " + p.fecha_doc.ToStrSql() + ", " + p.fecha_ent.ToStrSql() + ", " +
                    p.fecha_ven.ToStrSql() + ", " + p.fecha_cancela.ToStrSql() + ", " + p.can_tot + ", " +
                    p.imp_tot1 + ", " + p.imp_tot2 + ", " + p.imp_tot3 + ", " + p.imp_tot4 + ", " + p.des_tot + ", " + p.des_fin + ", " +
                    p.com_tot + ", '" + p.condicion + "', " + p.cve_obs + ", " + p.num_alma + ", '" + p.act_cxc + "', '" + p.act_coi + "', '" +
                    p.enlazado + "', '" + p.tip_doc_e + "', " + p.num_moned + ", " + p.tipcamb + ", " + p.num_pagos + ", " +
                    p.fechaelab.ToStrSql() + ", " + p.primerpago + ", '" + p.rfc + "', " + p.ctlpol + ", '" + p.escfd + "', " +
                    p.autoriza + ", '" + p.serie + "', " + p.folio + ", '" + p.autoanio + "', " + p.dat_envio + ", '" + p.contado + "', " +
                    p.cve_bita + ", '" + p.bloq + "', '" + p.formaenvio + "', " + p.des_fin_porc + ", " + p.des_tot_porc + ", " +
                    p.importe + ", " + p.com_tot_porc + ", '" + p.metododepago + "', '" + p.numctapago + "', '" + p.tip_doc_ant + "', '" +
                    p.doc_ant + "', '" + p.tip_doc_sig + "', '" + p.doc_sig + "', '" + p.tiposervicio + "', '" +  p.estatuspedido + "', '" +
                    p.ocurredomicilio + "')";
                var res = GetExecute("DB", query, 7);
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
                MessageBox.Show(ex.Message);
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
                listFbDetalle = GetFbDataTable("FB", query, 8).ToList<DetallePedidos>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    "TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, CANTSURTIDO, SURTIDO " +
                    "from DETALLEPEDIDO where CVE_DOC = '" + cvedoc + "'";
                listDbDetalle = GetDataTable("DB", query, 8).ToList<DetallePedidos>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                            ped.cve_doc + "', " + ped.num_par + ", '" + ped.cve_art + "', " + ped.cant + ", " + ped.pxs + ", " + ped.prec + ", " + ped.cost + ", " +
                            ped.impu1 + ", " + ped.impu2 + ", " + ped.impu3 + ", " + ped.impu4 + ", " + ped.imp1apla + ", " + ped.imp2apla + ", " +
                            ped.imp3apla + ", " + ped.imp4apla + ", " + ped.totimp1 + ", " + ped.totimp2 + ", " + ped.totimp3 + ", " + ped.totimp4 + ", " +
                            ped.desc1 + ", " + ped.desc2 + ", " + ped.desc3 + ", " + ped.comi + ", '" + ped.apar + "', '" + ped.act_inv + "', " + ped.num_alm + ", '" +
                            ped.polit_apli + "', " + ped.tip_cam + ", '" + ped.uni_venta + "', '" + ped.tipo_prod + "', " + ped.cve_obs + ", " + ped.reg_serie + ", " +
                            ped.e_ltpd + ", '" + ped.tipo_elem + "', " + ped.num_mov + ", " + ped.tot_partida + ", '" + ped.imprimir + "')";
                var res = GetExecute("DB", query, 9);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelaDbPedidos(Pedidos pedDb)
        {
            try
            {
                pedDb.status = "C";
                pedDb.estatuspedido = (pedDb.estatuspedido == "AUTORIZACION") ? "CANCELACION" : "MODIFICACION";
                var query = "update PEDIDO set STATUS = '" + pedDb.status + "', " +
                            "ESTATUSPEDIDO = '" + pedDb.estatuspedido + "' " +
                            "where CVE_DOC = '" + pedDb.cve_doc + "'";
                if (GetExecute("DB", query, 10))
                {
                    if (pedDb.estatuspedido == "MODIFICACION")
                    {
                        var query2 = "insert DETALLEPEDIDODEV (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, " +
                                     "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " +
                                     "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                                     "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR) select CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, " +
                                     "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " +
                                     "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " +
                                     "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR from DETALLEPEDIDO where CVE_DOC = '" + pedDb.cve_doc + "' " +
                                     "and isnull(SURTIDO,0) = 1 delete DETALLEPEDIDO where CVE_DOC = '" + pedDb.cve_doc + "'";
                        var res = GetExecute("DB", query2, 11);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ModificaDbPedidos(Pedidos pedFb, Pedidos pedDb)
        {
            try
            {
                string[] dats = {"AUTORIZACION", "SURTIR", "MODIFICACION"};
                pedFb.estatuspedido = (pedDb.estatuspedido.In(dats)) ? pedDb.estatuspedido : "MODIFICACION";
                
                var query = "update PEDIDO set " +
                            "CAN_TOT = " + pedFb.can_tot + ", IMP_TOT1 = " + pedFb.imp_tot1 + ", IMP_TOT2 = " + pedFb.imp_tot2 + ", " +
                            "IMP_TOT3 = " + pedFb.imp_tot3 + ", IMP_TOT4 = " + pedFb.imp_tot4 + ", DES_TOT = " + pedFb.des_tot + ", " +
                            "DES_FIN = " + pedFb.des_fin + ", COM_TOT = " + pedFb.com_tot + ", DES_FIN_PORC = " + pedFb.des_fin_porc + ", " +
                            "DES_TOT_PORC = " + pedFb.des_tot_porc + ", IMPORTE = " + pedFb.importe + ", COM_TOT_PORC = " + pedFb.com_tot_porc + ", " +
                            "ESTATUSPEDIDO = '" + pedFb.estatuspedido + "' " +
                            "where CVE_DOC = '" + pedFb.cve_doc + "'";
                if (GetExecute("DB", query, 10))
                {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                            "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR from DETALLEPEDIDO where CVE_ART = '" + detDB.cve_art + "' " +
                            "CVE_DOC = '" + detDB.cve_doc + "'";
                        GetExecute("DB", query2, 12);
                        detDB.cantsurtido = detFB.cant;
                    }
                    else
                    {
                        detFB.cant = detDB.cantsurtido;
                    }
                }
                var query3 = "update DETALLEPEDIDO SET CANT = " + detFB.cant + ", PXS = " + detFB.pxs + ", PREC = " + detFB.prec + ", COST = " + detFB.cost + ", " +
                             "IMPU1 = " + detFB.impu1 + ", IMPU2 = " + detFB.impu2 + ", IMPU3 = " + detFB.impu3 + ", IMPU4 = " + detFB.impu4 + ", " +
                             "IMP1APLA = " + detFB.imp1apla + ", IMP2APLA = " + detFB.imp2apla + ", IMP3APLA = " + detFB.imp3apla + ", IMP4APLA = " + detFB.imp4apla + ", " +
                             "TOTIMP1 = " + detFB.totimp1 + ", TOTIMP2 = " + detFB.totimp2 + ", TOTIMP3 = " + detFB.totimp3 + ", TOTIMP4 = " + detFB.totimp4 + ", " +
                             "DESC1 = " + detFB.desc1 + ", DESC2 = " + detFB.desc2 + ", DESC3 = " + detFB.desc3 + ", COMI = " + detFB.comi + ", APAR = " + detFB.apar + ", " +
                             "NUM_ALM = " + detFB.num_alm + ", TIP_CAM = " + detFB.tip_cam + ", TOT_PARTIDA = " + detFB.tot_partida + ", " +
                             "CANTSURTIDO = " + detDB.cantsurtido + ", SURTIDO = 0 where CVE_ART = '" + detFB.cve_art + "' " +
                             "CVE_DOC = '" + detFB.cve_doc + "'";
                GetExecute("DB", query3, 13);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                var res = GetExecute("DB", query, 14);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Pedidos> listFbPedidos = CargaFbPedidos(new DateTime(2012,11,1), new DateTime(2012,11,30));
            List<Pedidos> listDbPedidos = CargaDbPedidos(new DateTime(2012,11,1), new DateTime(2012,11,30));
            var pedidosAct = listFbPedidos.Where(o => listDbPedidos.Any(p => o.cve_doc == p.cve_doc && p.status != "C") && o.status != "C").ToList();
            var pedidosNuevos = listFbPedidos.Where(o => o.status != "C").Except(pedidosAct).ToList();
            var pedidosCan = listFbPedidos.Where(o => listDbPedidos.Any(p => o.cve_doc == p.cve_doc && p.status != "C") && o.status == "C").ToList();
            var pedidosDiferentes = pedidosAct.Except(pedidosAct.Where(o => listDbPedidos.Any(p => o.cve_doc == p.cve_doc && Math.Round(o.importe,2) == Math.Round(p.importe,2))).ToList()).ToList();
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
        }

        private List<Cliente> cargaFbClientes()
        {
            List<Cliente> listFbClientes = new List<Cliente>();
            try
            {
                var query =
                    "select CLAVE, STATUS, NOMBRE, CALLE, NUMINT, NUMEXT, CRUZAMIENTOS, CRUZAMIENTOS2, COLONIA, " +
                    "CODIGO, MUNICIPIO, ESTADO, PAIS, TELEFONO, CVE_VEND, CVE_OBS, TIPO_EMPRESA, CALLE_ENVIO, " +
                    "NUMINT_ENVIO, NUMEXT_ENVIO, CRUZAMIENTOS_ENVIO, CRUZAMIENTOS_ENVIO2, COLONIA_ENVIO, CAMPLIB2 FLETE, " +
                    "LOCALIDAD_ENVIO, MUNICIPIO_ENVIO, ESTADO_ENVIO, PAIS_ENVIO, CODIGO_ENVIO, ULT_COMPM, FCH_ULTCOM " +
                    "from CLIE01 c JOIN CLIE_CLIB01 b ON b.CVE_CLIE = c.CLAVE";
                listFbClientes = GetFbDataTable("FB", query, 15).ToList<Cliente>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    "LOCALIDAD_ENVIO, MUNICIPIO_ENVIO, ESTADO_ENVIO, PAIS_ENVIO, CODIGO_ENVIO, ULT_COMPM, FCH_ULTCOM " +
                    "from CLIENTE";
                listFbClientes = GetDataTable("DB", query, 16).ToList<Cliente>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    "LOCALIDAD_ENVIO, MUNICIPIO_ENVIO, ESTADO_ENVIO, PAIS_ENVIO, CODIGO_ENVIO, ULT_COMPM, FCH_ULTCOM) " +
                    "values ('" + clt.clave + "', '" + clt.status + "', '" + clt.nombre + "', '" + clt.calle + "', '" +
                    clt.numint + "', '" + clt.numext + "', '" + clt.cruzamientos + "', '" + clt.cruzamientos2 + "', '" +
                    clt.colonia + "', '" + clt.codigo + "', '" + clt.municipio + "', '" + clt.estado + "', '" + clt.pais + "', '" +
                    clt.telefono + "', '" + clt.cve_vend + "', " + clt.cve_obs + ", '" + clt.tipo_empresa + "', '" +
                    clt.calle_envio + "', '" + clt.numint_envio + "', '" + clt.numext_envio + "', '" + clt.cruzamientos_envio + "', '" +
                    clt.cruzamientos_envio2 + "', '" + clt.colonia_envio + "', '" + clt.localidad_envio + "', '" +
                    clt.municipio_envio + "', '" + clt.estado_envio + "', '" + clt.pais_envio + "', '" + clt.codigo_envio + "', " +
                    clt.ult_compm + ", " + ((clt.ult_compm == 0.00) ? "NULL" : "'" + clt.fch_ultcom.ToString("yyyy-MM-dd") + "'") + " )";
                var res = GetExecute("DB", query, 17);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ModificaCliente(Cliente clt){
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
                    clt.codigo_envio + "', ULT_COMPM = " + clt.ult_compm + ", FCH_ULTCOM = " + ((clt.ult_compm == 0.00) ? "NULL" : "'" + clt.fch_ultcom.ToString("yyyy-MM-dd") + "'") +
                    " where CLAVE = '" + clt.clave + "'";
                var res = GetExecute("DB", query, 18);
            }catch (Exception ex){
                MessageBox.Show(ex.Message);}
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
        }

        private void GuardaInventario(Inventario inv)
        {
            try
            {
                var query =
                    "insert INVENTARIO (CVE_ART, DESCR, LIN_PROD, CON_SERIE, UNI_MED, UNI_EMP, CTRL_ALM, STOCK_MIN, " + 
                    "STOCK_MAX, FCH_ULTVTA, EXIST, STATUS, MASTERS, MASTERS_UBI) " +
                    "values ('" + inv.cve_art + "', '" + inv.descr + "', '" + inv.lin_prod + "', '" + inv.con_serie + "', '" +
                    inv.uni_med + "', " + inv.uni_emp + ", '" + inv.ctrl_alm + "', " + inv.stock_min + ", " +
                    inv.stock_max + ", " + ((inv.fch_ultvta.Year == 1) ? "Null" : "'" + inv.fch_ultvta.ToString("yyyy-MM-dd") + "'") + ", " +
                    inv.exist + ", '" + inv.status + "', " + inv.masters + ", '" + inv.masters_ubi + "' )";
                var res = GetExecute("DB", query, 19);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);}
        }
        private void ModificaInventario(Inventario inv)
        {
            try{
                var query =
                    "update INVENTARIO set DESCR = '" + inv.descr + "', LIN_PROD = '" + inv.lin_prod + "', CON_SERIE = '" +
                    inv.con_serie + "', UNI_MED = '" + inv.con_serie + "', UNI_EMP = " + inv.uni_emp + ", CTRL_ALM = '" +
                    inv.ctrl_alm + "', STOCK_MIN = " + inv.stock_min + ", STOCK_MAX = " + inv.stock_max + ", FCH_ULTVTA = " +
                    ((inv.fch_ultvta.Year == 1) ? "Null" : "'" + inv.fch_ultvta.ToString("yyyy-MM-dd") + "'") + ", EXIST = " +
                    inv.exist + ", STATUS = '" + inv.status + "', MASTERS = " + inv.masters + ", MASTERS_UBI = '" + inv.masters_ubi + "' " +
                    "where CVE_ART = '" + inv.cve_art + "'";
                var res = GetExecute("DB", query, 17);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            barCodeControl1.Text = memoEdit1.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cargaFbClientes();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<Pedidos> ped = CargaPedido("          0000197852");
            List<DetallePedidoMerc> det = CargaDetalle("          0000197852");
            XtraReport1 rpt1 = new XtraReport1();
            rpt1.DataSource = ped;
            XtraReport1_Detalle det1 = new XtraReport1_Detalle();
            det1.DataSource = det;
            rpt1.xrSubreport1.ReportSource = det1;
            rpt1.ShowPreview();
        }

        private List<Pedidos> CargaPedido(string cvedoc)
        {
            List<Pedidos> peds = new List<Pedidos>();
            try
            {
                var query =
                    "SELECT  CVE_DOC, CVE_CLPV, FECHA_DOC, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, p.CVE_VEND, OBSERVACIONES, " +
                    "CONDICION, RFC, AUTORIZA, FOLIO, CONTADO, DES_FIN_PORC, DES_TOT_PORC, IMPORTE, TIPOSERVICIO, ESTATUSPEDIDO, COBRADOR_ASIGNADO, " +
                    "COBRADOR_AUTORIZO, uCobAsig.Nombre cobrador_asignado_n, uCobAut.Nombre cobrador_autorizo_n, uSurAsig.Nombre surtidor_asignado_n, cliente.NOMBRE CLIENTE, FECHAAUT, " +
                    "TotCajaCarton, TotCajaMadera, TotBultos, TotRollos, TotCubetas, TotAtados, TotTarimas, TotCostoGuias, OCURREDOMICILIO, p.NOMBRE_VENDEDOR, " +
                    "STUFF((select ',' + UbicacionEmpaque from PEDIDO_Ubicacion u where u.CVE_DOC = p.CVE_DOC FOR XML PATH('')), 1, 1, '') UbicacionEmpaque " +
                    "FROM PEDIDO p left join USUARIOS uCobAsig on uCobAsig.Usuario = p.COBRADOR_ASIGNADO " +
                    "left join USUARIOS uCobAut on uCobAut.Usuario = p.COBRADOR_AUTORIZO " +
                    "left join USUARIOS uSurAsig on uSurAsig.Usuario = p.SURTIDOR_ASIGNADO " +
                    "left join CLIENTE cliente on cliente.CLAVE = p.CVE_CLPV " +
                    "WHERE CVE_DOC = '" + cvedoc + "'";
                peds = GetDataTable("DB", query, 1).ToList<Pedidos>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return peds;
        }
        private List<DetallePedidoMerc> CargaDetalle(string cvedoc)
        {
            List<DetallePedidoMerc> dets = new List<DetallePedidoMerc>();
            try
            {
                var query =
                    "SELECT CVE_DOC, CONSEC, NUM_PAR, d.CVE_ART, CODIGO_BARRA, CANT, TIPOPAQUETE, CONSEC_PADRE, " +
                    "ULTIMO, CANCELADO, TotArt, CONSEC_EMPAQUE, CONSEC_PADRE_GUIA, CVE_ART_GUIA, PRECIO_GUIA, " +
                    "ASIG_PEDIDO_GUIA, NUM_GUIA,i.DESCR FROM DETALLEPEDIDOMERC d LEFT JOIN INVENTARIO i ON d.CVE_ART = i.CVE_ART " +
                    "WHERE ISNULL(TIPOPAQUETE,'') = ''AND ISNULL(CANCELADO,0) = 0 AND CVE_DOC = '" + cvedoc + "' " +
                    "ORDER BY CONSEC";
                dets = GetDataTable("DB", query, 1).ToList<DetallePedidoMerc>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dets;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Printer IP Address and communication port
            string ipAddress = "192.168.1.207";
            int port = 9100;

            // ZPL Command(s)
            string ZPLString =
                "^XA" +
                "^FO10,10^GFA,870,870,15,,::I02,0066,00FF,00FF8,:00FFC,00FDC,01F9CI03FFC01FF80C7E03FF," +
                "03FFEI03IF07FFC1IF0IFC,03IFI03F3F8FCFE3IF0IFE,03FFB8003F0F8F83E3EI0F83E,03FFB8003F0F8F83E3EI0F03E," +
                "03IF8003F0F8F83E3EI0F83E,07FFD8003F0F8F83E3EI0F03E,07FCF8003F0F8F83E3E7F8F83E,07FF8I03F0F8F83E3E7F8F03E," +
                "0IF8I03F0F8F83E3E4F8F83E,0IF8I03F0F8F83E3E0F8F83E,0IFCI03F0F8F83E3E0F8F83E,1IFEI03F0F8F83E3E0F8F83E," +
                "1JFC003F0F8F83E3E1F8F87E,1KF003IF8IFE3IF8IFC,1KF003IF07FFC1FF787FFC,3KF8,1KFC,::0KFE03FFE0F8060F8003FF8," +
                "0KFE07IF1F8060FC007FFC,0KFE077E30F8060F800FDEC,0KFE003E00F8060F800F8,0F1IFE003E00F8060F800F8," + 
                "0701FCF003E00F8060F800FC,0700FC7003E00F8060F800IFC,07007C3003E00F8060F800IFC,0700741003E00F8060F800IFC," + 
                "0700741803E00F8060F800IFC,0701F01803E00F8060F8007FFC,0703F00C03E00F8060FCJ07C,0703F00C03E00F8060F8J07C," +
                "0701700603E00F80E0F8J07C,0700700703E00IFC0IF8IFD,0700700303E007FFC0IF07FF84,0F007W04,0F007,1F00F,0C00F8,J09,0804," +
                "08C6036CDBJ63923030361E188,19EOFCE7FE7IFEJFBC,1BEDFC9FEIFDE7FEJFEJF3C,1DC8649D08CA4E73466F679959B8,Y08,,^FS" +
                "^FO130,40^A0,42,50^FDHERIMSA SA DE CV^FS" +
                "^FO10,78^GB760,110,1,,2^FS" +
                "^FO20,85^A0,30,25^FDNum.Pedido :^FS" +
                "^FO160,85^A0,30,30^FD0000197852^FS" +
                "^FO405,85^A0,30,25^FDFecha :^FS" +
                "^FO555,85^A0,30,30^FD04 / 06 / 2018^FS" +
                "^FO20,110^A0,30,25^FDCliente :^FS" +
                "^FO160,110^A0,30,30^FD(4327) DANIEL OLIVERA GONZALEZ^FS" +
                "^FO20,135^A0,30,25^FDTipo Servicio:^FS" +
                "^FO160,135^A0,30,30^FDFORANEO^FS" +
                "^FO405,135^A0,30,25^FDOcu./ Dom. :^FS" +
                "^FO555,135^A0,30,30^FDDOMICILIO^FS" +
                "^FO20,160^A0,30,25^FDPrioridad :^FS" +
                "^FO160,160^A0,30,30^FDNORMAL^FS" +
                "^FO405,160^A0,30,25^FDOrden Comp. :^FS" +
                "^FO555,160^A0,30,30^FD74019^FS" +
                "^FO10,200^A0,30,75^FB760,1,0,C,0^FR^FDCAJA CARTON^FS" +
                "^BY4,2,80^FO50,230^BC^FD0000197852-1^FS" +
                "^FO10,360^A0,50,100^FB760,1,0,C,0^FR^FDCONTADO^FS" +
                "^FO10,450^A0,25,35^FR^FDContenido :^FS" +
                "^FO10,470^GB760,530,1,,0^FS" +
                "^FO20,480^A0,25,20^FD10^FS" +
                "^FO50,480^A0,25,20^FD(NH2006) TEE DE REPARACION PARA VALVULA Y  PIVOTE^FS" +
                "^FO610,480^A0,25,20^FD17502215659955^FS" +
                "^FO20,501^A0,25,20^FD3^FS" +
                "^FO50,501^A0,25,20^FD(SH9007) CANDADO DE HIERRO 25MM GANCHO CORTO^FS" +
                "^FO610,501^A0,25,20^FD7502248042369^FS" +
                "^FO20,522^A0,25,20^FD2^FS" +
                "^FO50,522^A0,25,20^FD(SH9007) CANDADO DE HIERRO 25MM GANCHO CORTO^FS" +
                "^FO610,522^A0,25,20^FD7502248042369-2^FS" +
                "^FO20,543^A0,25,20^FD6^FS" +
                "^FO50,543^A0,25,20^FD(SH9015) CANDADO DE HIERRO 50MM GANCHO LARGO^FS" +
                "^FO610,543^A0,25,20^FD17502248040522^FS" +
                "^FO20,564^A0,25,20^FD6^FS" +
                "^FO50,564^A0,25,20^FD(SH9013) CANDADO DE HIERRO 38MM GANCHO LARGO^FS" +
                "^FO610,564^A0,25,20^FD17502248040515^FS" +
                "^XZ";

            try
            {
                // Open connection
                TcpClient client = new TcpClient();
                client.Connect(ipAddress, port);

                // Write ZPL String to connection
                System.IO.StreamWriter writer =
                    new System.IO.StreamWriter(client.GetStream());
                writer.Write(ZPLString);
                writer.Flush();

                // Close Connection
                writer.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                // Catch Exception
            }
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }
    }
}