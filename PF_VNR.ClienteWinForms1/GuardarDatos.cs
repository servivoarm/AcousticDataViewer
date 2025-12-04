using System;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace PF_VNR.ClienteWinForms1
{
    public partial class GuardarDatos : Form
    {
        private double latSeleccionada = 0;
        private double lngSeleccionada = 0;

        public GuardarDatos()
        {
            InitializeComponent();
        }

        private void GuardarDatos_Load(object sender, EventArgs e)
        {
            // --- CONFIGURACIÓN DEL MAPA ---
            GuardadoM.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            GuardadoM.MinZoom = 3;
            GuardadoM.MaxZoom = 20;
            GuardadoM.Zoom = 12;
            GuardadoM.ShowCenter = false;

            GuardadoM.CanDragMap = true;
            GuardadoM.MouseWheelZoomEnabled = true;
            GuardadoM.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            GuardadoM.IgnoreMarkerOnMouseWheel = true;
            GuardadoM.DisableFocusOnMouseEnter = false;

            // CENTRAR EN PANAMÁ
            GuardadoM.Position = new PointLatLng(8.9833, -79.5167);

            // ⭐ REGISTRAR EVENTO DE CLIC (AQUÍ EL CONTROL YA EXISTE)
            GuardadoM.OnMapClick += Gmap_OnMapClick;
        }

        private void Gmap_OnMapClick(PointLatLng pointClick, MouseEventArgs e)
        {
            // --- GUARDAR COORDENADAS ---
            latSeleccionada = pointClick.Lat;
            lngSeleccionada = pointClick.Lng;

            lblLatitud.Text = $"Latitud: {latSeleccionada}";
            lblLongitud.Text = $"Longitud: {lngSeleccionada}";

            // --- LIMPIAR OVERLAYS PARA EVITAR MULTIPLES MARCADORES ---
            GuardadoM.Overlays.Clear();

            // Crear capa nueva
            var overlay = new GMapOverlay("seleccion");

            // Crear marcador rojo
            var marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                pointClick,
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot
            );

            marker.ToolTipText = "Selección";
            overlay.Markers.Add(marker);

            // Agregar overlay al mapa
            GuardadoM.Overlays.Add(overlay);

            // Refrescar
            GuardadoM.Refresh();
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();

        }
    }
}
