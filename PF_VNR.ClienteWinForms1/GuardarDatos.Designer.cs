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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.GuardadoM);
            this.groupBox1.Controls.Add(this.btn_Volver);
            this.groupBox1.Location = new System.Drawing.Point(34, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 360);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mapa";
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
            // GuardarDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 480);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GuardarDatos";
            this.Text = "GuardarDatos";
            this.Load += new System.EventHandler(this.GuardarDatos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl GuardadoM;
        private System.Windows.Forms.Label lblLatitud;
        private System.Windows.Forms.Label lblLongitud;
        private System.Windows.Forms.Button btn_Volver;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}