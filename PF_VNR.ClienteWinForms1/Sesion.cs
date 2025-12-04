namespace PF_VNR.ClienteWinForms1
{
    public static class Sesion
    {
        public static string Usuario { get; set; } = string.Empty;
        public static string Rol { get; set; } = string.Empty;

        public static bool Autenticado => !string.IsNullOrEmpty(Usuario);

        public static void Cerrar()
        {
            Usuario = "";
            Rol = "";
        }
    }
}
