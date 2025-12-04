using System.Text.Json.Serialization;
namespace PF_VNR.Models
{
    public class Lugar
    {
        public int LugarId { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public double Latitud { get; set; }
        public double Longitud { get; set; }

        [JsonIgnore] 
        public ICollection<MedicionRuido> Mediciones { get; set; }
    }
}
