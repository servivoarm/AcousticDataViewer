using System.Text.Json.Serialization;
namespace PF_VNR.Models
{
    public class MedicionRuido
    {
        public int MedicionRuidoId { get; set; }

        public int LugarId { get; set; }

        // Fecha y hora reales de la medición (del CSV)
        public DateTime FechaHora { get; set; }

        public double NivelDecibelios { get; set; }

        // Zona elegida por el usuario al subir el CSV
        public string TipoZona { get; set; } = string.Empty;
        public Lugar Lugar { get; set; }
    }
}
