namespace PF_VNR.ClienteWinForms1
{
    partial class GuardarDatos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GuardadoM = new GMap.NET.WindowsForms.GMapControl();
            this.lblLatitud = new System.Windows.Forms.Label();
            this.lblLongitud = new System.Windows.Forms.Label();
            this.btn_Volver = new System.Windows.Forms.Button();
            this.gbTipoZona = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbTipoZona = new System.Windows.Forms.ComboBox();
            this.tbxNombreZona = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIngresarDatos = new System.Windows.Forms.Button();
            this.gbTipoZona.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GuardadoM
            // 
            this.GuardadoM.Bearing = 0F;
            this.GuardadoM.CanDragMap = true;
            this.GuardadoM.EmptyTileColor = System.Drawing.Color.Navy;
            this.GuardadoM.GrayScaleMode = false;
            this.GuardadoM.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.GuardadoM.LevelsKeepInMemory = 5;
            this.GuardadoM.Location = new System.Drawing.Point(19, 21);
            this.GuardadoM.MarkersEnabled = true;
            this.GuardadoM.MaxZoom = 2;
            this.GuardadoM.MinZoom = 2;
            this.GuardadoM.MouseWheelZoomEnabled = true;
            this.GuardadoM.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.GuardadoM.Name = "GuardadoM";
            this.GuardadoM.NegativeMode = false;
            this.GuardadoM.PolygonsEnabled = true;
            this.GuardadoM.RetryLoadTile = 0;
            this.GuardadoM.RoutesEnabled = true;
            this.GuardadoM.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.GuardadoM.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.GuardadoM.ShowTileGridLines = false;
            this.GuardadoM.Size = new System.Drawing.Size(375, 257);
            this.GuardadoM.TabIndex = 0;
            this.GuardadoM.Zoom = 0D;
            // 
            // lblLatitud
            // 
            this.lblLatitud.AutoSize = true;
            this.lblLatitud.Location = new System.Drawing.Point(59, 51);
            this.lblLatitud.Name = "lblLatitud";
            this.lblLatitud.Size = new System.Drawing.Size(60, 16);
            this.lblLatitud.TabIndex = 1;
            this.lblLatitud.Text = "lblLatitud";
            // 
            // lblLongitud
            // 
            this.lblLongitud.AutoSize = true;
            this.lblLongitud.Location = new System.Drawing.Point(59, 99);
            this.lblLongitud.Name = "lblLongitud";
            this.lblLongitud.Size = new System.Drawing.Size(72, 16);
            this.lblLongitud.TabIndex = 2;
            this.lblLongitud.Text = "lblLongitud";
            // 
            // btn_Volver
            // 
            this.btn_Volver.Location = new System.Drawing.Point(19, 311);
            this.btn_Volver.Name = "btn_Volver";
            this.btn_Volver.Size = new System.Drawing.Size(119, 37);
            this.btn_Volver.TabIndex = 3;
            this.btn_Volver.Text = "Volver";
            this.btn_Volver.UseVisualStyleBackColor = true;
            this.btn_Volver.Click += new System.EventHandler(this.btn_Volver_Click);
            // 
            // gbTipoZona
            // 
            this.gbTipoZona.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbTipoZona.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbTipoZona.Controls.Add(this.GuardadoM);
            this.gbTipoZona.Controls.Add(this.btn_Volver);
            this.gbTipoZona.Location = new System.Drawing.Point(34, 54);
            this.gbTipoZona.Name = "gbTipoZona";
            this.gbTipoZona.Size = new System.Drawing.Size(410, 360);
            this.gbTipoZona.TabIndex = 4;
            this.gbTipoZona.TabStop = false;
            this.gbTipoZona.Text = "Mapa";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.lblLatitud);
            this.groupBox2.Controls.Add(this.lblLongitud);
            this.groupBox2.Location = new System.Drawing.Point(477, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 153);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Coordenadas";
            // 
            // cmbTipoZona
            // 
            this.cmbTipoZona.FormattingEnabled = true;
            this.cmbTipoZona.Items.AddRange(new object[] {
            "Residencial",
            "Comercial",
            "Industrial",
            "Mixta"});
            this.cmbTipoZona.Location = new System.Drawing.Point(660, 237);
            this.cmbTipoZona.Name = "cmbTipoZona";
            this.cmbTipoZona.Size = new System.Drawing.Size(148, 24);
            this.cmbTipoZona.TabIndex = 6;
            // 
            // tbxNombreZona
            // 
            this.tbxNombreZona.Location = new System.Drawing.Point(660, 288);
            this.tbxNombreZona.Name = "tbxNombreZona";
            this.tbxNombreZona.Size = new System.Drawing.Size(148, 22);
            this.tbxNombreZona.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(477, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tipo de Zona";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(477, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nombre de Zona";
            // 
            // btnIngresarDatos
            // 
            this.btnIngresarDatos.Location = new System.Drawing.Point(689, 365);
            this.btnIngresarDatos.Name = "btnIngresarDatos";
            this.btnIngresarDatos.Size = new System.Drawing.Size(119, 37);
            this.btnIngresarDatos.TabIndex = 10;
            this.btnIngresarDatos.Text = "Ingresar Datos";
            this.btnIngresarDatos.UseVisualStyleBackColor = true;
            this.btnIngresarDatos.Click += new System.EventHandler(this.btnIngresarDatos_Click);
            // 
            // GuardarDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 480);
            this.Controls.Add(this.btnIngresarDatos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxNombreZona);
            this.Controls.Add(this.cmbTipoZona);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbTipoZona);
            this.Name = "GuardarDatos";
            this.Text = "GuardarDatos";
            this.Load += new System.EventHandler(this.GuardarDatos_Load);
            this.gbTipoZona.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl GuardadoM;
        private System.Windows.Forms.Label lblLatitud;
        private System.Windows.Forms.Label lblLongitud;
        private System.Windows.Forms.Button btn_Volver;
        private System.Windows.Forms.GroupBox gbTipoZona;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbTipoZona;
        private System.Windows.Forms.TextBox tbxNombreZona;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIngresarDatos;
    }
}