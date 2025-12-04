using GMap.NET;
using GMap.NET.WindowsForms;
using LiveCharts;
using LiveCharts.Wpf;
using PF_VNR.ClienteWinForms1.Models;
using PF_VNR.ClienteWinForms1.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PF_VNR.ClienteWinForms1
{
    public partial class Form1 : Form
    {
        private ApiClient api;

        public Form1()
        {
            InitializeComponent();
            api = new ApiClient("https://localhost:7101/");
            btnAgregar.Visible = Sesion.Rol == "Admin";
            CargarLugares();
            CargarGraficaRegional();
        }

        private async void CargarLugares()
        {
            var lugares = await api.ObtenerLugares();

            cbLugares.Items.Clear();
            foreach (var l in lugares)
            {
                cbLugares.Items.Add(new ComboBoxItem
                {
                    Text = l.Nombre,
                    Value = l.LugarId
                });
            }

            cbLugares.DisplayMember = "Text";
            cbLugares.ValueMember = "Value";
        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
        }

        private async void CargarGraficaRegional()
        {
            var datos = await api.ObtenerMediciones();

            var agrupado = datos
                .GroupBy(m => m.Lugar.Nombre)
                .Select(g =>
                {
                    var primero = g.First();
                    double promedio = MedicionRuidoDto.ObtenerPromedioRuido(g);
                    double permitido = MedicionRuidoDto.ObtenerRuidoPermitido(
                        primero.TipoZona, primero.FechaHora);

                    return new
                    {
                        Lugar = g.Key,
                        RuidoActual = promedio,
                        RuidoPermitido = permitido
                    };
                })
                .ToList();

            var lugares = agrupado.Select(x => x.Lugar).ToArray();
            var ruidoActual = agrupado.Select(x => x.RuidoActual).ToArray();
            var ruidoPermitido = agrupado.Select(x => x.RuidoPermitido).ToArray();

            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            // --- EJE X (MOSTRAR TODOS LOS LUGARES) ---
            cartesianChart1.AxisX.Add(new Axis
            {
                Labels = lugares,
                LabelsRotation = 30,
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 1,
                    IsEnabled = false
                }
            });

            // --- SERIES ---
            cartesianChart1.Series.Add(new ColumnSeries
            {
                Title = "Ruido Actual",
                Values = new ChartValues<double>(ruidoActual),
                MaxColumnWidth = 45
            });

            cartesianChart1.Series.Add(new ColumnSeries
            {
                Title = "Ruido Permitido",
                Values = new ChartValues<double>(ruidoPermitido),
                MaxColumnWidth = 35
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Nivel (dB)",
                MinValue = 0
            });
        }

        private async void CargarGraficaLugar(int lugarId)
        {
            var datos = await api.ObtenerMedicionesPorLugar(lugarId);

            var valores = datos.Select(x => x.NivelDecibelios).ToArray();
            var tiempos = datos.Select(x => x.FechaHora.ToString("dd/MM HH:mm")).ToArray();

            // Calcular ruido permitido según la hora de cada medición
            var seriePermitido = datos
                .Select(x => MedicionRuidoDto.ObtenerRuidoPermitido(x.TipoZona, x.FechaHora))
                .ToArray();

            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            // --- EJE X ---
            cartesianChart1.AxisX.Add(new Axis
            {
                Labels = tiempos,
                LabelsRotation = 45,
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 1,
                    IsEnabled = false
                }
            });

            // --- SERIE: RUIDO REAL ---
            cartesianChart1.Series.Add(new LineSeries
            {
                Title = "Ruido Actual",
                Values = new ChartValues<double>(valores),
                LineSmoothness = 0.5,
                StrokeThickness = 3,
                Stroke = System.Windows.Media.Brushes.DeepSkyBlue,
                Fill = System.Windows.Media.Brushes.LightSkyBlue,
                PointGeometry = DefaultGeometries.Circle,
                PointGeometrySize = 12
            });

            // --- SERIE: RUIDO PERMITIDO (VARIANTE POR HORA) ---
            cartesianChart1.Series.Add(new LineSeries
            {
                Title = "Ruido Permitido",
                Values = new ChartValues<double>(seriePermitido),
                StrokeThickness = 3,
                Stroke = System.Windows.Media.Brushes.Red,
                Fill = System.Windows.Media.Brushes.Transparent,
                PointGeometry = DefaultGeometries.Diamond,
                PointGeometrySize = 14
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "dB",
                MinValue = 0
            });
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (cbLugares.SelectedItem is ComboBoxItem item)
            {
                CargarGraficaLugar(item.Value);  // gráfica del lugar
                await CargarMarcadorIndividual(item.Value); // mapa con círculo
            }
        }


        private async void btnVolver_Click(object sender, EventArgs e)
        {
            CargarGraficaRegional();
            await CargarMarcadoresTodos();
            Gmap.Zoom = 10;
        }

        private void Gmap_Load(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;

            Gmap.MinZoom = 3;
            Gmap.MaxZoom = 20;
            Gmap.Zoom = 12;
            Gmap.ShowCenter = false;

            await CargarMarcadoresTodos();   // ← Aquí ya centras automáticamente
        }
        private async Task CargarMarcadoresTodos()
        {
            var lugares = await api.ObtenerLugares();

            Gmap.Overlays.Clear();

            var overlay = new GMapOverlay("todos");

            foreach (var l in lugares)
            {
                var marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(l.Latitud, l.Longitud),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_dot
                );

                marker.ToolTipText = $"{l.Nombre}";
                overlay.Markers.Add(marker);
            }

            Gmap.Overlays.Add(overlay);

            // --- CENTRAR DINÁMICAMENTE ---
            if (lugares.Count > 0)
            {
                var primero = lugares.First();

                Gmap.Position = new GMap.NET.PointLatLng(primero.Latitud, primero.Longitud);

                // ⭐ ZOOM PREDETERMINADO
                Gmap.Zoom = 10;
            }
        }

        private async Task CargarMarcadorIndividual(int lugarId)
        {
            var lugar = await api.ObtenerLugarPorId(lugarId);

            Gmap.Overlays.Clear();

            var overlay = new GMapOverlay("seleccionado");

            // marcador rojo
            var marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                new GMap.NET.PointLatLng(lugar.Latitud, lugar.Longitud),
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot
            );

            marker.ToolTipText = $"{lugar.Nombre}";
            overlay.Markers.Add(marker);

            // círculo — radio mediano (200 metros)
            var circulo = CrearCirculo(lugar.Latitud, lugar.Longitud, 200);
            overlay.Polygons.Add(circulo);

            Gmap.Overlays.Add(overlay);

            // centrar
            Gmap.Position = new GMap.NET.PointLatLng(lugar.Latitud, lugar.Longitud);
            Gmap.Zoom = 16;
        }

        private GMapPolygon CrearCirculo(double lat, double lng, double radioMetros)
        {
            var puntos = new List<PointLatLng>();
            const int segmentos = 60;
            double latRad = lat * Math.PI / 180.0;
            double lngRad = lng * Math.PI / 180.0;
            double dRad = radioMetros / 6378137.0;

            for (int i = 0; i < segmentos; i++)
            {
                double theta = (i * Math.PI * 2) / segmentos;

                double latCirc = Math.Asin(Math.Sin(latRad) * Math.Cos(dRad) +
                                           Math.Cos(latRad) * Math.Sin(dRad) * Math.Cos(theta));

                double lngCirc = lngRad + Math.Atan2(
                    Math.Sin(theta) * Math.Sin(dRad) * Math.Cos(latRad),
                    Math.Cos(dRad) - Math.Sin(latRad) * Math.Sin(latCirc)
                );

                puntos.Add(new PointLatLng(latCirc * 180.0 / Math.PI,
                                           lngCirc * 180.0 / Math.PI));
            }

            var poligono = new GMapPolygon(puntos, "circle")
            {
                Stroke = new Pen(Color.FromArgb(180, Color.Red), 2),
                Fill = new SolidBrush(Color.FromArgb(60, Color.Red))
            };

            return poligono;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Sesion.Rol != "Admin")
            {
                MessageBox.Show("No tienes permisos para agregar datos.");
                return;
            }
            GuardarDatos form = new GuardarDatos();
            form.Show();
            this.Hide();

        }
    }
}
