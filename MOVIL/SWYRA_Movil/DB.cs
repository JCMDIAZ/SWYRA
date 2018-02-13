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
}
