namespace PF_VNR.Forms
{
    partial class inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbLugares = new System.Windows.Forms.ComboBox();
            this.btn_Filtrar = new System.Windows.Forms.Button();
            this.btnVolve = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart1 = new LiveCharts.Wpf.CartesianChart();
            this.SuspendLayout();
            // 
            // cbLugares
            // 
            this.cbLugares.DropDownWidth = 158;
            this.cbLugares.FormattingEnabled = true;
            this.cbLugares.Location = new System.Drawing.Point(121, 376);
            this.cbLugares.Name = "cbLugares";
            this.cbLugares.Size = new System.Drawing.Size(158, 24);
            this.cbLugares.TabIndex = 1;
            // 
            // btn_Filtrar
            // 
            this.btn_Filtrar.Location = new System.Drawing.Point(321, 371);
            this.btn_Filtrar.Name = "btn_Filtrar";
            this.btn_Filtrar.Size = new System.Drawing.Size(125, 37);
            this.btn_Filtrar.TabIndex = 2;
            this.btn_Filtrar.Text = "Filtrar";
            this.btn_Filtrar.UseVisualStyleBackColor = true;
            this.btn_Filtrar.Click += new System.EventHandler(this.btn_Filtrar_Click);
            // 
            // btnVolve
            // 
            this.btnVolve.Location = new System.Drawing.Point(486, 369);
            this.btnVolve.Name = "btnVolve";
            this.btnVolve.Size = new System.Drawing.Size(125, 37);
            this.btnVolve.TabIndex = 3;
            this.btnVolve.Text = "Volver";
            this.btnVolve.UseVisualStyleBackColor = true;
            this.btnVolve.Click += new System.EventHandler(this.btnVolve_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(101, 71);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(460, 260);
            this.elementHost1.TabIndex = 4;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.cartesianChart1;
            // 
            // inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.btnVolve);
            this.Controls.Add(this.btn_Filtrar);
            this.Controls.Add(this.cbLugares);
            this.Name = "inicio";
            this.Text = "Inicio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLugares;
        private System.Windows.Forms.Button btn_Filtrar;
        private System.Windows.Forms.Button btnVolve;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private LiveCharts.Wpf.CartesianChart cartesianChart1;
    }
}

