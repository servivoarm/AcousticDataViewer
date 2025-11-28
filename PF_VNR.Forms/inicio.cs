using LiveCharts;
using LiveCharts.Wpf;
using PF_VNR.Forms.Models;
using PF_VNR.Forms.Service;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;

namespace PF_VNR.Forms
{
    public partial class inicio : Form
    {
        private ApiClient api;
        public inicio()
        {
            InitializeComponent();
            api = new ApiClient("https://localhost:7101/");
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

        private void btn_Filtrar_Click(object sender, EventArgs e)
        {
            if (cbLugares.SelectedItem is ComboBoxItem item)
                CargarGraficaLugar(item.Value);
        }

        private void btnVolve_Click(object sender, EventArgs e)
        {
            CargarGraficaRegional();
        }
    }
}
