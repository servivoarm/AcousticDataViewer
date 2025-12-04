namespace PF_VNR.ClienteWinForms1
{
    partial class InicioSesion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_NombreUsuario = new System.Windows.Forms.TextBox();
            this.tb_Contrasenia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_inicioSesion = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.bt_inicioSesion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_Contrasenia);
            this.groupBox1.Controls.Add(this.tb_NombreUsuario);
            this.groupBox1.Location = new System.Drawing.Point(195, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 376);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inicio de Sesión";
            // 
            // tb_NombreUsuario
            // 
            this.tb_NombreUsuario.Location = new System.Drawing.Point(123, 115);
            this.tb_NombreUsuario.MaxLength = 50;
            this.tb_NombreUsuario.Name = "tb_NombreUsuario";
            this.tb_NombreUsuario.Size = new System.Drawing.Size(172, 22);
            this.tb_NombreUsuario.TabIndex = 0;
            // 
            // tb_Contrasenia
            // 
            this.tb_Contrasenia.Location = new System.Drawing.Point(123, 184);
            this.tb_Contrasenia.MaxLength = 50;
            this.tb_Contrasenia.Name = "tb_Contrasenia";
            this.tb_Contrasenia.PasswordChar = '*';
            this.tb_Contrasenia.Size = new System.Drawing.Size(172, 22);
            this.tb_Contrasenia.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña:";
            // 
            // bt_inicioSesion
            // 
            this.bt_inicioSesion.Location = new System.Drawing.Point(123, 241);
            this.bt_inicioSesion.Name = "bt_inicioSesion";
            this.bt_inicioSesion.Size = new System.Drawing.Size(172, 38);
            this.bt_inicioSesion.TabIndex = 2;
            this.bt_inicioSesion.Text = "Iniciar Sesión";
            this.bt_inicioSesion.UseVisualStyleBackColor = true;
            this.bt_inicioSesion.Click += new System.EventHandler(this.bt_inicioSesion_Click);
            // 
            // InicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "InicioSesion";
            this.Text = "InicioSesion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_Contrasenia;
        private System.Windows.Forms.TextBox tb_NombreUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_inicioSesion;
    }
}