using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using static PF_VNR.ClienteWinForms1.GuardarBaseDatos;

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

        private void btnIngresarDatos_Click(object sender, EventArgs e)
        {
            // --- VALIDACIONES DE INTERFAZ ---
            if (latSeleccionada == 0 || lngSeleccionada == 0)
            {
                MessageBox.Show("Por favor, seleccione un punto en el mapa.");
                return;
            }

            // Asumiendo que tus controles se llaman txtNombre y cmbTipoZona
            if (string.IsNullOrWhiteSpace(tbxNombreZona.Text) || cmbTipoZona.SelectedIndex == -1)
            {
                MessageBox.Show("Complete el nombre y el tipo de zona.");
                return;
            }

            // --- LECTURA DEL ARCHIVO ---
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Lógica de lectura (Parseo)
                    string filePath = openFileDialog.FileName;

                    // La variable 'listaMediciones' (antes 'datosArchivo') ahora contiene la LISTA.
                    var listaMediciones = LeerDatosDelArchivo(filePath);

                    // Le pasamos los datos
                    GestorDeDatos db = new GestorDeDatos();

                    // 🚨 CORRECCIÓN CLAVE: La función GuardarLevantamientoMultiple 
                    // ahora solo requiere la lista de mediciones, ya no necesita la fecha/dB por separado.
                    db.GuardarLevantamientoMultiple(
                        tbxNombreZona.Text,
                        cmbTipoZona.SelectedItem.ToString(),
                        latSeleccionada,
                        lngSeleccionada,
                        listaMediciones 
                    );

                    MessageBox.Show("¡Datos importados y guardados correctamente!");

                    // Opcional: Limpiar controles
                    tbxNombreZona.Clear();
                    cmbTipoZona.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al guardar datos");
                }
            }
        }

        private List<MedicionData> LeerDatosDelArchivo(string path)
        {
            var mediciones = new List<MedicionData>();
            string[] lineas = File.ReadAllLines(path);

            var cultureDecimal = new CultureInfo("es-ES");

            foreach (string linea in lineas)
            {
                if (string.IsNullOrWhiteSpace(linea)) continue;
                // El formato es: 2025-11-26 01:47:41;54.1
                string[] partes = linea.Split(';');

                if (partes.Length == 2)
                {
                    string fechaStr = partes[0].Trim();
                    string dbStr = partes[1].Trim();

                    // 1. Parsear Fecha (Usando formato exacto y cultura Invariante)
                    if (DateTime.TryParseExact(fechaStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
                    {
                        // 2. Parsear Decibelios (Usando la cultura española por la coma)
                        if (int.TryParse(dbStr, NumberStyles.Any, cultureDecimal, out int db))
                        {
                            mediciones.Add(new MedicionData(fecha, db));
                        }
                    }
                }
            }

            if (mediciones.Count == 0)
                throw new Exception("El archivo no contiene mediciones válidas. Asegúrese de que el formato sea 'YYYY-MM-DD HH:mm:ss;Decibel'.");

            return mediciones;
        }
    }
}