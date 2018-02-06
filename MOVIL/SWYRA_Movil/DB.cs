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
}
