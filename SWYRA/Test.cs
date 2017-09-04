using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToDB;
using static SWYRA.General;

namespace SWYRA
{
    public partial class Test : Form
    {
        private List<Inventario> listFbInventarios;
          
        public Test()
        {
            InitializeComponent();
        }

        private void CargaFbInventarios()
        {
            try
            {
                var query = "select cve_art, descr, lin_prod, con_serie, uni_med, uni_emp, ctrl_alm, tiem_surt, " +
                            "stock_min, stock_max, tip_costeo, num_mon, fch_ultcom, comp_x_rec, fch_ultvta, pend_surt, " +
                            "exist, costo_prom, ult_costo, cve_obs, tipo_ele, uni_alt, fac_conv, apart, con_lote, " +
                            "con_pedimento, peso, volumen, cve_esqimpu, cve_bita, vtas_anl_c, vtas_anl_m, comp_anl_c, " +
                            "comp_anl_m, prefijo, talla, color, cuent_cont, cve_imagen, blk_cst_ext, status from inve01";
                listFbInventarios = GetFbDataTable("FB", query, 5).ToList<Inventario>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                var res = GetExecute("DB", query, 12);
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
    }
}
