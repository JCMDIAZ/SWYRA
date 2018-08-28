using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SWYRA_Movil
{
    public class CatRegMachCE
    {
        public int Id { get; set; }
        public string Macmach { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
    }

    public class CatRegMach
    {
        public int IdRegMach { get; set; }
        public string MacmachRegMach { get; set; }
        public DateTime FechaRegMach { get; set; }
        public bool ActivoRegMach { get; set; }
    }

    public class Register
    {
        public string register { get; set; }
    }

    public class Usuarios
    {
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public int IdStatusPermisosUser { get; set; }
        public string LetraERP { get; set; }
        public string AreaAsignada { get; set; }
    }

    public class Inventario
    {
        public string cve_art { get; set; }
        public string descr { get; set; }
        public string lin_prod { get; set; }
        public string con_serie { get; set; }
        public string uni_med { get; set; }
        public double uni_emp { get; set; }
        public string ctrl_alm { get; set; }
        public double stock_min { get; set; }
        public double stock_max { get; set; }
        public DateTime fch_ultvta { get; set; }
        public double exist { get; set; }
        public string status { get; set; }
        public double masters { get; set; }
        public string masters_ubi { get; set; }
    }

    public class InventarioPresentacion
    {
        public string cve_art { get; set; }
        public string descr { get; set; }
        public double cant_piezas_1 { get; set; }
        public string codigo_barra_1 { get; set; }
        public double cant_piezas_2 { get; set; }
        public string codigo_barra_2 { get; set; }
        public double cant_piezas_3 { get; set; }
        public string codigo_barra_3 { get; set; }
        public double cant_piezas_4 { get; set; }
        public string codigo_barra_4 { get; set; }
        public double cant_piezas_5 { get; set; }
        public string codigo_barra_5 { get; set; }
        public double cant_piezas_6 { get; set; }
        public string codigo_barra_6 { get; set; }
        public double cant_piezas_7 { get; set; }
        public string codigo_barra_7 { get; set; }
        public double cant_piezas_8 { get; set; }
        public string codigo_barra_8 { get; set; }
        public double cant_piezas_9 { get; set; }
        public string codigo_barra_9 { get; set; }
        public bool activo { get; set; }
    }

    public class CodigosBarra
    {
        public string cve_art { get; set; }
        public int cant_piezas { get; set; }
        public string codigo_barra { get; set; }
    }

    public class Pedidos
    {
        public string tip_doc { get; set; }
        public string cve_doc { get; set; }
        public string cve_clpv { get; set; }
        public string status { get; set; }
        public int dat_mostr { get; set; }
        public string cve_vend { get; set; }
        public string cve_pedi { get; set; }
        public DateTime fecha_doc { get; set; }
        public DateTime fecha_ent { get; set; }
        public DateTime fecha_ven { get; set; }
        public DateTime? fecha_cancela { get; set; }
        public double can_tot { get; set; }
        public double imp_tot1 { get; set; }
        public double imp_tot2 { get; set; }
        public double imp_tot3 { get; set; }
        public double imp_tot4 { get; set; }
        public double des_tot { get; set; }
        public double des_fin { get; set; }
        public double com_tot { get; set; }
        public string condicion { get; set; }
        public int cve_obs { get; set; }
        public int num_alma { get; set; }
        public string act_cxc { get; set; }
        public string act_coi { get; set; }
        public string enlazado { get; set; }
        public string tip_doc_e { get; set; }
        public int num_moned { get; set; }
        public double tipcamb { get; set; }
        public int num_pagos { get; set; }
        public DateTime fechaelab { get; set; }
        public double primerpago { get; set; }
        public string rfc { get; set; }
        public int ctlpol { get; set; }
        public string escfd { get; set; }
        public int autoriza { get; set; }
        public string serie { get; set; }
        public int folio { get; set; }
        public string autoanio { get; set; }
        public int dat_envio { get; set; }
        public string contado { get; set; }
        public int cve_bita { get; set; }
        public string bloq { get; set; }
        public string formaenvio { get; set; }
        public double des_fin_porc { get; set; }
        public double des_tot_porc { get; set; }
        public double importe { get; set; }
        public double com_tot_porc { get; set; }
        public string metododepago { get; set; }
        public string numctapago { get; set; }
        public string tip_doc_ant { get; set; }
        public string doc_ant { get; set; }
        public string tip_doc_sig { get; set; }
        public string doc_sig { get; set; }
        public string tiposervicio { get; set; }
        public string estatuspedido { get; set; }
        public string ocurredomicilio { get; set; }
        public string cobrador_asignado { get; set; }
        public string cobrador_autorizo { get; set; }
        public string surtidor_asignado { get; set; }
        public string empaquetador_asignado { get; set; }
        public string etiquetador_asignado { get; set; }
        public string surtidor_area { get; set; }
        public float porc_surtido { get; set; }
        public float porc_empaque { get; set; }
        public string indicaciones { get; set; }
        public string lote { get; set; }
        public string cliente { get; set; }
        public string cobrador_asignado_n { get; set; }
        public string cobrador_autorizo_n { get; set; }
        public string surtidor_asignado_n { get; set; }
        public string empaquetador_asignado_n { get; set; }
        public string etiquetador_asignado_n { get; set; }
        public string surtidor_area_n { get; set; }
        public string prioridad { get; set; }
        public DateTime? fechaaut { get; set; }
        public double totcajacarton { get; set; }
        public double totcajamadera { get; set; }
        public double totbultos { get; set; }
        public double totrollos { get; set; }
        public double totcubetas { get; set; }
        public double totatados { get; set; }
        public double tottarimas { get; set; }
        public double totcostoguias { get; set; }
        public bool solarea { get; set; }
        public string ubicacionempaque { get; set; }
        public string direccion1 { get; set; }
        public string direccion2 { get; set; }
        public string flete { get; set; }
        public string flete2 { get; set; }
        public string causadetenido { get; set; }
        public string consignacion { get; set; }
        public string observaciones { get; set; }
        public string enviar { get; set; }
        public string nombre_vendedor { get; set; }
        public string capturo_n { get; set; }
    }

    public class DetallePedidos
    {
        public string cve_doc { get; set; }
        public int num_par { get; set; }
        public string cve_art { get; set; }
        public double cant { get; set; }
        public double pxs { get; set; }
        public double prec { get; set; }
        public double cost { get; set; }
        public double impu1 { get; set; }
        public double impu2 { get; set; }
        public double impu3 { get; set; }
        public double impu4 { get; set; }
        public int imp1apla { get; set; }
        public int imp2apla { get; set; }
        public int imp3apla { get; set; }
        public int imp4apla { get; set; }
        public double totimp1 { get; set; }
        public double totimp2 { get; set; }
        public double totimp3 { get; set; }
        public double totimp4 { get; set; }
        public double desc1 { get; set; }
        public double desc2 { get; set; }
        public double desc3 { get; set; }
        public double comi { get; set; }
        public double apar { get; set; }
        public string act_inv { get; set; }
        public int num_alm { get; set; }
        public string polit_apli { get; set; }
        public double tip_cam { get; set; }
        public string uni_venta { get; set; }
        public string tipo_prod { get; set; }
        public int cve_obs { get; set; }
        public int reg_serie { get; set; }
        public int e_ltpd { get; set; }
        public string tipo_elem { get; set; }
        public int num_mov { get; set; }
        public double tot_partida { get; set; }
        public string imprimir { get; set; }
        public double cantsurtido { get; set; }
        public bool surtido { get; set; }
        public double cantdevuelto { get; set; }
        public bool devuelto { get; set; }
        public double exist { get; set; }
        public string ubicacion { get; set; }
        public string descr { get; set; }
        public string comentario { get; set; }
        public bool aplicaexist { get; set; } 
        public double minexist { get; set; }
        public bool aplicalote { get; set; }
        public double cantdiferencia { get; set; }
        public string lin_prod { get; set; }
        public string ctrl_alm { get; set; }
        public string masters_ubi { get; set; }
        public double min { get; set; }
        public double mas { get; set; }
        public int orden { get; set; }
        public int sel { get; set; }
        public int con { get; set; }
        public double cantpendiente { get; set; }
        public bool sw { get; set; }
    }

    public class DetallePedidoMerc
    {
        public string cve_doc { get; set; }
        public int consec { get; set; }
        public int num_par { get; set; }
        public string cve_art { get; set; }
        public string codigo_barra { get; set; }
        public int cant { get; set; }
        public string tipopaquete { get; set; }
        public int consec_padre { get; set; }
        public string ultimo { get; set; }
        public string descr { get; set; }
        public bool cancelado { get; set; }
        public int totart { get; set; }
        public int consec_empaque { get; set; }
        public int consec_padre_guia { get; set; }
        public string cve_art_guia { get; set; }
        public double precio_guia { get; set; }
        public bool asig_pedido_guia { get; set; }
        public string num_guia { get; set; }
        public double pend { get; set; }
        public string empaque { get; set; }
    }

    public class OrdenUbicacion
    {
        public string cve_ubi { get; set; }
        public int orden { get; set; }
    }

    public class UbicacionEntrega
    {
        public bool seleccionado { get; set; }
        public string cve_zona { get; set; }
        public string cve_ubicacion { get; set; }
    }

    public class Catalogos
    {
        public int id { get; set; }
        public string catalogo { get; set; }
        public string valor { get; set; }
        public string valortexto { get; set; }
    }
}
