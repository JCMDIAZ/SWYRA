﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace SWYRA_Movil
{
    public partial class FrmEmpaqueInfo : Form
    {
        public Pedidos ped = new Pedidos();

        public FrmEmpaqueInfo()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmEmpaqueInfo_Load(object sender, EventArgs e)
        {
            lblPedido.Text = ped.cve_doc.Trim();
            lblCliente.Text = ped.cliente;
            txtTipoServicio.Text = ped.tiposervicio;
            txtEstatus.Text = ped.capturo_n;
            txtOcuDom.Text = ped.ocurredomicilio;
            txtUbicacion.Text = ped.ubicacionempaque;
            txtConsigna.Text = ((ped.consignacion == "")? ped.direccion1 + " " + ped.direccion2 : ped.consignacion);
            txtObservaciones.Text = ped.observaciones + " / " + ped.indicaciones;
            txtFecha.Text = ped.fecha_doc.ToString("yyyy-MM-dd");
            CultureInfo culture = new CultureInfo("es-MX");
            lblMonto.Text = ped.importe.ToString("c",culture);
        }
    }
}  