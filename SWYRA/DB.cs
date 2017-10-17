﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace SWYRA
{
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
        public string empaquetador_asignado { get; set; }public string etiquetador_asignado { get; set; }
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
    }

    public class Actividad
    {
        public string cve_actividad { get; set; }
        public string descr { get; set; }
        public int prioridad { get; set; }
        public string status { get; set; }
    }

    public class Perfil
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string modulo { get; set; }

    }

    public class UsuarioAlmacen
    {
        public string usuario { get; set; }
        public string almacen { get; set; }
        public string nombre { get; set; }
    }

    public class Almacen
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public string Zona { get; set; }
        public decimal Area { get; set; }
        public decimal Altura { get; set; }
        public decimal offset { get; set; }public bool Activo { get; set; }

    }

    public class Areas
    {
        public string areaid { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string almacen { get; set; }
        public string ubicacion { get; set; }
        public decimal aream2 { get; set; }
        public decimal altura { get; set; }
        public bool activo { get; set; }

    }

    public class Cliente
    {
        public string clave { get; set; }
        public string status { get; set; }
        public string nombre { get; set; }
        public string calle { get; set; }
        public string numint { get; set; }
        public string numext { get; set; }
        public string cruzamientos { get; set; }
        public string cruzamientos2 { get; set; }
        public string colonia { get; set; }
        public string codigo { get; set; }
        public string municipio { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        public string telefono { get; set; }
        public string cve_vend { get; set; }
        public int cve_obs { get; set; }
        public string tipo_empresa { get; set; }
        public string calle_envio { get; set; }
        public string numint_envio { get; set; }
        public string numext_envio { get; set; }
        public string cruzamientos_envio { get; set; }
        public string cruzamientos_envio2 { get; set; }
        public string colonia_envio { get; set; }
        public string localidad_envio { get; set; }
        public string municipio_envio { get; set; }
        public string estado_envio { get; set; }
        public string pais_envio { get; set; }
        public string codigo_envio { get; set; }
        public double ult_compm { get; set; }
        public DateTime fch_ultcom { get; set; }
        public string clasific { get; set; }
    }
}
