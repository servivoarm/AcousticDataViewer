using PF_VNR.ClienteWinForms1.Service;
using System;
using System.Windows.Forms;

namespace PF_VNR.ClienteWinForms1
{
    public partial class InicioSesion : Form
    {
        private readonly AuthApiService _authService;

        public InicioSesion()
        {
            InitializeComponent();
            _authService = new AuthApiService();
        }

        private async void bt_inicioSesion_Click(object sender, EventArgs e)
        {
            string usuario = tb_NombreUsuario.Text.Trim();
            string contrasena = tb_Contrasenia.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Debe ingresar usuario y contraseña");
                return;
            }

            /*var resp = await _authService.LoginAsync(usuario, contrasena);

            if (resp == null || !resp.Exito)
            {
                MessageBox.Show(resp?.Mensaje ?? "Error al conectar con el servidor");
                return;
            }*/

            try
            {
                var resp = await _authService.LoginAsync(usuario, contrasena);

                if (resp == null)
                {
                    MessageBox.Show("Resp null");
                    return;
                }

                if (!resp.Exito)
                {
                    MessageBox.Show("Login falló: " + resp.Mensaje);
                    return;
                }

                Sesion.Usuario = resp.Usuario;
                Sesion.Rol = resp.Rol;

                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR REAL: " + ex.Message);
            }



        }
    }
}
