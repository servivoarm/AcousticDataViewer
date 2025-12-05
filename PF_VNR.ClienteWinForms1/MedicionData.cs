using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_VNR.ClienteWinForms1
{
    public class MedicionData
    {
        public DateTime FechaHora { get; set; }
        public int NivelDecibelios { get; set; }

        // Constructor opcional para inicializar
        public MedicionData(DateTime fechaHora, int nivelDecibelios)
        {
            this.FechaHora = fechaHora;
            this.NivelDecibelios = nivelDecibelios;
        }
    }
}
