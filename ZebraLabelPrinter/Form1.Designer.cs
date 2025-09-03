namespace ZebraLabelPrinter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelPuertoSerial;
        private System.Windows.Forms.ComboBox cboPuertos;
        private System.Windows.Forms.Label labelZebraLanguage;
        private System.Windows.Forms.ComboBox cboZebraLanguage;

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
            label1 = new System.Windows.Forms.Label();
            dgvCajeros = new DataGridView();
            txtBuscar = new TextBox();
            btnBuscar = new System.Windows.Forms.Button();
            btnRecargar = new System.Windows.Forms.Button();
            btnAgregar = new System.Windows.Forms.Button();
            btnEditar = new System.Windows.Forms.Button();
            btnEliminar = new System.Windows.Forms.Button();
            btnImprimir = new System.Windows.Forms.Button();
            btnImprimirAvery = new System.Windows.Forms.Button();
            labelPuertoSerial = new System.Windows.Forms.Label();
            cboPuertos = new ComboBox();
            labelZebraLanguage = new System.Windows.Forms.Label();
            cboZebraLanguage = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvCajeros).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(14, 17);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Buscar:";
            // 
            // dgvCajeros
            // 
            dgvCajeros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCajeros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCajeros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCajeros.Location = new System.Drawing.Point(18, 47);
            dgvCajeros.Margin = new Padding(4);
            dgvCajeros.Name = "dgvCajeros";
            dgvCajeros.RowHeadersWidth = 51;
            dgvCajeros.Size = new System.Drawing.Size(1041, 424);
            dgvCajeros.TabIndex = 1;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new System.Drawing.Point(71, 14);
            txtBuscar.Margin = new Padding(4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new System.Drawing.Size(232, 23);
            txtBuscar.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new System.Drawing.Point(312, 11);
            btnBuscar.Margin = new Padding(4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new System.Drawing.Size(88, 26);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnRecargar
            // 
            btnRecargar.Location = new System.Drawing.Point(406, 11);
            btnRecargar.Margin = new Padding(4);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new System.Drawing.Size(88, 26);
            btnRecargar.TabIndex = 4;
            btnRecargar.Text = "Recargar";
            btnRecargar.UseVisualStyleBackColor = true;
            btnRecargar.Click += btnRecargar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAgregar.Location = new System.Drawing.Point(18, 478);
            btnAgregar.Margin = new Padding(4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new System.Drawing.Size(140, 34);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar Cajero";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditar.Location = new System.Drawing.Point(164, 478);
            btnEditar.Margin = new Padding(4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new System.Drawing.Size(140, 34);
            btnEditar.TabIndex = 6;
            btnEditar.Text = "Editar Cajero";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEliminar.Location = new System.Drawing.Point(312, 478);
            btnEliminar.Margin = new Padding(4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new System.Drawing.Size(140, 34);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "Eliminar Cajero";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnImprimir.Location = new System.Drawing.Point(919, 478);
            btnImprimir.Margin = new Padding(4);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new System.Drawing.Size(140, 34);
            btnImprimir.TabIndex = 8;
            btnImprimir.Text = "Imprimir Zebra";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnImprimirAvery
            // 
            btnImprimirAvery.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnImprimirAvery.Location = new System.Drawing.Point(772, 478);
            btnImprimirAvery.Margin = new Padding(4);
            btnImprimirAvery.Name = "btnImprimirAvery";
            btnImprimirAvery.Size = new System.Drawing.Size(140, 34);
            btnImprimirAvery.TabIndex = 8;
            btnImprimirAvery.Text = "Imprimir Avery";
            btnImprimirAvery.UseVisualStyleBackColor = true;
            btnImprimirAvery.Click += btnImprimirAvery_Click;
            // 
            // labelPuertoSerial
            // 
            labelPuertoSerial.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelPuertoSerial.AutoSize = true;
            labelPuertoSerial.Location = new System.Drawing.Point(769, 17);
            labelPuertoSerial.Margin = new Padding(4, 0, 4, 0);
            labelPuertoSerial.Name = "labelPuertoSerial";
            labelPuertoSerial.Size = new System.Drawing.Size(109, 15);
            labelPuertoSerial.TabIndex = 9;
            labelPuertoSerial.Text = "Puerto COM Avery:";
            // 
            // cboPuertos
            // 
            cboPuertos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboPuertos.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPuertos.FormattingEnabled = true;
            cboPuertos.Location = new System.Drawing.Point(879, 14);
            cboPuertos.Margin = new Padding(4);
            cboPuertos.Name = "cboPuertos";
            cboPuertos.Size = new System.Drawing.Size(140, 23);
            cboPuertos.TabIndex = 10;
            // 
            // labelZebraLanguage
            // 
            labelZebraLanguage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelZebraLanguage.AutoSize = true;
            labelZebraLanguage.Location = new System.Drawing.Point(503, 17);
            labelZebraLanguage.Name = "labelZebraLanguage";
            labelZebraLanguage.Size = new System.Drawing.Size(147, 15);
            labelZebraLanguage.TabIndex = 11;
            labelZebraLanguage.Text = "Lenguaje Impresora Zebra:";
            // 
            // cboZebraLanguage
            // 
            cboZebraLanguage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboZebraLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cboZebraLanguage.FormattingEnabled = true;
            cboZebraLanguage.Items.AddRange(new object[] { "ZPL", "EPL" });
            cboZebraLanguage.Location = new System.Drawing.Point(650, 14);
            cboZebraLanguage.Margin = new Padding(3, 2, 3, 2);
            cboZebraLanguage.Name = "cboZebraLanguage";
            cboZebraLanguage.Size = new System.Drawing.Size(106, 23);
            cboZebraLanguage.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1073, 527);
            Controls.Add(cboZebraLanguage);
            Controls.Add(labelZebraLanguage);
            Controls.Add(cboPuertos);
            Controls.Add(labelPuertoSerial);
            Controls.Add(btnImprimirAvery);
            Controls.Add(btnImprimir);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(btnRecargar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvCajeros);
            Controls.Add(label1);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Zebra Label Printer";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCajeros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCajeros;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRecargar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnImprimirAvery;
    }
}