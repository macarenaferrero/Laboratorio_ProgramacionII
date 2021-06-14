namespace FormMiDomo
{
    partial class FormMiDomo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMiDomo));
            this.lblIngresoPedidos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRadio = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblConexion = new System.Windows.Forms.Label();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.cmbConexion = new System.Windows.Forms.ComboBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.rbtPVC = new System.Windows.Forms.RadioButton();
            this.rbtMadera = new System.Windows.Forms.RadioButton();
            this.cmbFrecuencia = new System.Windows.Forms.ComboBox();
            this.lblFrecuencia = new System.Windows.Forms.Label();
            this.btnImagen = new System.Windows.Forms.Button();
            this.btnVerInforme = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.ImgDomos = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lblIngresoPedidos
            // 
            this.lblIngresoPedidos.AutoSize = true;
            this.lblIngresoPedidos.BackColor = System.Drawing.Color.Transparent;
            this.lblIngresoPedidos.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresoPedidos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblIngresoPedidos.Location = new System.Drawing.Point(257, 76);
            this.lblIngresoPedidos.Name = "lblIngresoPedidos";
            this.lblIngresoPedidos.Size = new System.Drawing.Size(155, 21);
            this.lblIngresoPedidos.TabIndex = 1;
            this.lblIngresoPedidos.Text = "Ingreso de pedidos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe MDL2 Assets", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(147, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(353, 48);
            this.label2.TabIndex = 2;
            this.label2.Text = "Domos Geodésicos";
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.BackColor = System.Drawing.Color.Transparent;
            this.lblRadio.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRadio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRadio.Location = new System.Drawing.Point(26, 155);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(54, 21);
            this.lblRadio.TabIndex = 3;
            this.lblRadio.Text = "Radio";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.BackColor = System.Drawing.Color.Transparent;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCliente.Location = new System.Drawing.Point(26, 122);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(133, 21);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Nombre  cliente";
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.BackColor = System.Drawing.Color.Transparent;
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMaterial.Location = new System.Drawing.Point(26, 226);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(135, 21);
            this.lblMaterial.TabIndex = 8;
            this.lblMaterial.Text = "Tipo de Material";
            // 
            // lblConexion
            // 
            this.lblConexion.AutoSize = true;
            this.lblConexion.BackColor = System.Drawing.Color.Transparent;
            this.lblConexion.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConexion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblConexion.Location = new System.Drawing.Point(26, 283);
            this.lblConexion.Name = "lblConexion";
            this.lblConexion.Size = new System.Drawing.Size(144, 21);
            this.lblConexion.TabIndex = 11;
            this.lblConexion.Text = "Tipo de Conexión";
            // 
            // txtRadio
            // 
            this.txtRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRadio.Location = new System.Drawing.Point(163, 155);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(135, 22);
            this.txtRadio.TabIndex = 2;
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(163, 121);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(135, 22);
            this.txtCliente.TabIndex = 1;
            // 
            // cmbConexion
            // 
            this.cmbConexion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConexion.FormattingEnabled = true;
            this.cmbConexion.Items.AddRange(new object[] {
            "GoodKarma,",
            "Cono,",
            "Piped"});
            this.cmbConexion.Location = new System.Drawing.Point(184, 283);
            this.cmbConexion.Name = "cmbConexion";
            this.cmbConexion.Size = new System.Drawing.Size(114, 24);
            this.cmbConexion.TabIndex = 6;
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.DarkGray;
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnIngresar.Location = new System.Drawing.Point(30, 323);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(268, 36);
            this.btnIngresar.TabIndex = 7;
            this.btnIngresar.Text = "INGRESAR";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // rbtPVC
            // 
            this.rbtPVC.AutoSize = true;
            this.rbtPVC.BackColor = System.Drawing.Color.Transparent;
            this.rbtPVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtPVC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtPVC.Location = new System.Drawing.Point(184, 251);
            this.rbtPVC.Name = "rbtPVC";
            this.rbtPVC.Size = new System.Drawing.Size(56, 20);
            this.rbtPVC.TabIndex = 5;
            this.rbtPVC.TabStop = true;
            this.rbtPVC.Text = "PVC";
            this.rbtPVC.UseVisualStyleBackColor = false;
            this.rbtPVC.CheckedChanged += new System.EventHandler(this.rbtPVC_CheckedChanged);
            // 
            // rbtMadera
            // 
            this.rbtMadera.AutoSize = true;
            this.rbtMadera.BackColor = System.Drawing.Color.Transparent;
            this.rbtMadera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtMadera.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtMadera.Location = new System.Drawing.Point(184, 227);
            this.rbtMadera.Name = "rbtMadera";
            this.rbtMadera.Size = new System.Drawing.Size(79, 20);
            this.rbtMadera.TabIndex = 4;
            this.rbtMadera.TabStop = true;
            this.rbtMadera.Text = "Madera";
            this.rbtMadera.UseVisualStyleBackColor = false;
            // 
            // cmbFrecuencia
            // 
            this.cmbFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrecuencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFrecuencia.FormattingEnabled = true;
            this.cmbFrecuencia.Items.AddRange(new object[] {
            "F1",
            "F2"});
            this.cmbFrecuencia.Location = new System.Drawing.Point(163, 189);
            this.cmbFrecuencia.Name = "cmbFrecuencia";
            this.cmbFrecuencia.Size = new System.Drawing.Size(135, 24);
            this.cmbFrecuencia.TabIndex = 3;
            // 
            // lblFrecuencia
            // 
            this.lblFrecuencia.AutoSize = true;
            this.lblFrecuencia.BackColor = System.Drawing.Color.Transparent;
            this.lblFrecuencia.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrecuencia.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFrecuencia.Location = new System.Drawing.Point(26, 189);
            this.lblFrecuencia.Name = "lblFrecuencia";
            this.lblFrecuencia.Size = new System.Drawing.Size(92, 21);
            this.lblFrecuencia.TabIndex = 17;
            this.lblFrecuencia.Text = "Frecuencia";
            // 
            // btnImagen
            // 
            this.btnImagen.BackColor = System.Drawing.Color.White;
            this.btnImagen.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImagen.ForeColor = System.Drawing.Color.Transparent;
            this.btnImagen.ImageList = this.ImgDomos;
            this.btnImagen.Location = new System.Drawing.Point(345, 122);
            this.btnImagen.Name = "btnImagen";
            this.btnImagen.Size = new System.Drawing.Size(234, 204);
            this.btnImagen.TabIndex = 19;
            this.btnImagen.UseVisualStyleBackColor = false;
            // 
            // btnVerInforme
            // 
            this.btnVerInforme.BackColor = System.Drawing.Color.DarkGray;
            this.btnVerInforme.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerInforme.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnVerInforme.Location = new System.Drawing.Point(30, 370);
            this.btnVerInforme.Name = "btnVerInforme";
            this.btnVerInforme.Size = new System.Drawing.Size(268, 36);
            this.btnVerInforme.TabIndex = 8;
            this.btnVerInforme.Text = "VER INFORME";
            this.btnVerInforme.UseVisualStyleBackColor = false;
            this.btnVerInforme.Click += new System.EventHandler(this.btnVerInforme_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.DarkGray;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSalir.Location = new System.Drawing.Point(345, 347);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(234, 36);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ImgDomos
            // 
            this.ImgDomos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgDomos.ImageStream")));
            this.ImgDomos.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgDomos.Images.SetKeyName(0, "conexionKarma.jpg");
            this.ImgDomos.Images.SetKeyName(1, "conexionCono.jpg");
            this.ImgDomos.Images.SetKeyName(2, "piiiped.jpg");
            this.ImgDomos.Images.SetKeyName(3, "ConecionPVC.jpg");
            this.ImgDomos.Images.SetKeyName(4, "MaderaGoodKarmaII.jpg");
            this.ImgDomos.Images.SetKeyName(5, "MaderaCono.jpg");
            this.ImgDomos.Images.SetKeyName(6, "conexionPipedII.jpg");
            this.ImgDomos.Images.SetKeyName(7, "pipedddddd.jpg");
            this.ImgDomos.Images.SetKeyName(8, "YYYPVC.jpg");
            this.ImgDomos.Images.SetKeyName(9, "pipeddddddddd.jpg");
            this.ImgDomos.Images.SetKeyName(10, "conexionPiped.jpg");
            // 
            // FormMiDomo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::FormMiDomo.Properties.Resources._571218835_820;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(609, 418);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnVerInforme);
            this.Controls.Add(this.btnImagen);
            this.Controls.Add(this.cmbFrecuencia);
            this.Controls.Add(this.lblFrecuencia);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.cmbConexion);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtRadio);
            this.Controls.Add(this.lblConexion);
            this.Controls.Add(this.rbtPVC);
            this.Controls.Add(this.rbtMadera);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblRadio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblIngresoPedidos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMiDomo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiDomo";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMiDomo_FormClosing);
            this.Load += new System.EventHandler(this.FormMiDomo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblIngresoPedidos;
        private System.Windows.Forms.Label lblRadio;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblConexion;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbConexion;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.RadioButton rbtPVC;
        private System.Windows.Forms.RadioButton rbtMadera;
        private System.Windows.Forms.ComboBox cmbFrecuencia;
        private System.Windows.Forms.Label lblFrecuencia;
        private System.Windows.Forms.Button btnImagen;
        private System.Windows.Forms.Button btnVerInforme;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ImageList ImgDomos;
    }
}

