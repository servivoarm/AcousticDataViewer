using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_VNR.Forms.Models
{
    internal class MedicionRuidoDto
    {
        public int MedicionRuidoId { get; set; }
        public int LugarId { get; set; }
        public DateTime FechaHora { get; set; }
        public double NivelDecibelios { get; set; }
        public string TipoZona { get; set; }

        public LugarDto Lugar { get; set; }

        public static double ObtenerRuidoPermitido(string tipoZona, DateTime fechaHora)
        {
            bool esDiurno = fechaHora.Hour >= 6 && fechaHora.Hour < 22;

            string zona = tipoZona.Trim().ToLower();

            switch (zona)
            {
                case "residencial":
                    return esDiurno ? 60 : 50;

                case "industrial":
                    return esDiurno ? 65 : 50;

                case "comercial":
                    return esDiurno ? 60 : 50;

                case "mixta":
                    return esDiurno ? 60 : 50;

                case "especial": // hospitales, asilos, escuelas
                    return esDiurno ? 50 : 40;

                case "salon":
                case "salón":
                case "salones":
                case "salones de clase":
                case "clase":
                case "clases":
                    return esDiurno ? 35 : 30;

                case "hospital":
                case "hospitales":
                case "habitaciones":
                    return 30; // todo el día

                default:
                    return esDiurno ? 60 : 50; // valor seguro por defecto
            }
        }

        public static double ObtenerPromedioRuido(IEnumerable<MedicionRuidoDto> datos)
        {
            if (datos == null || !datos.Any())
                return 0;

            return datos.Average(x => x.NivelDecibelios);
        }
    }
}
