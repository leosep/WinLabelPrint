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
            ((System.ComponentModel.ISupportInitialize)dgvCajeros).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(16, 23);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(55, 20);
            label1.TabIndex = 0;
            label1.Text = "Buscar:";
            // 
            // dgvCajeros
            // 
            dgvCajeros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCajeros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCajeros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCajeros.Location = new System.Drawing.Point(20, 63);
            dgvCajeros.Margin = new Padding(4, 5, 4, 5);
            dgvCajeros.Name = "dgvCajeros";
            dgvCajeros.RowHeadersWidth = 51;
            dgvCajeros.Size = new System.Drawing.Size(1031, 566);
            dgvCajeros.TabIndex = 1;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new System.Drawing.Point(81, 18);
            txtBuscar.Margin = new Padding(4, 5, 4, 5);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new System.Drawing.Size(265, 27);
            txtBuscar.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new System.Drawing.Point(356, 15);
            btnBuscar.Margin = new Padding(4, 5, 4, 5);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new System.Drawing.Size(100, 35);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnRecargar
            // 
            btnRecargar.Location = new System.Drawing.Point(464, 15);
            btnRecargar.Margin = new Padding(4, 5, 4, 5);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new System.Drawing.Size(100, 35);
            btnRecargar.TabIndex = 4;
            btnRecargar.Text = "Recargar";
            btnRecargar.UseVisualStyleBackColor = true;
            btnRecargar.Click += btnRecargar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAgregar.Location = new System.Drawing.Point(20, 638);
            btnAgregar.Margin = new Padding(4, 5, 4, 5);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new System.Drawing.Size(160, 46);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar Cajero";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditar.Location = new System.Drawing.Point(188, 638);
            btnEditar.Margin = new Padding(4, 5, 4, 5);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new System.Drawing.Size(160, 46);
            btnEditar.TabIndex = 6;
            btnEditar.Text = "Editar Cajero";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEliminar.Location = new System.Drawing.Point(356, 638);
            btnEliminar.Margin = new Padding(4, 5, 4, 5);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new System.Drawing.Size(160, 46);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "Eliminar Cajero";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnImprimir.Location = new System.Drawing.Point(891, 638);
            btnImprimir.Margin = new Padding(4, 5, 4, 5);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new System.Drawing.Size(160, 46);
            btnImprimir.TabIndex = 8;
            btnImprimir.Text = "Imprimir Zebra";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnImprimirAvery
            // 
            btnImprimirAvery.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnImprimirAvery.Location = new System.Drawing.Point(723, 638);
            btnImprimirAvery.Margin = new Padding(4, 5, 4, 5);
            btnImprimirAvery.Name = "btnImprimirAvery";
            btnImprimirAvery.Size = new System.Drawing.Size(160, 46);
            btnImprimirAvery.TabIndex = 8;
            btnImprimirAvery.Text = "Imprimir Avery";
            btnImprimirAvery.UseVisualStyleBackColor = true;
            btnImprimirAvery.Click += btnImprimirAvery_Click;
            // 
            // labelPuertoSerial
            // 
            labelPuertoSerial.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelPuertoSerial.AutoSize = true;
            labelPuertoSerial.Location = new System.Drawing.Point(699, 23);
            labelPuertoSerial.Margin = new Padding(4, 0, 4, 0);
            labelPuertoSerial.Name = "labelPuertoSerial";
            labelPuertoSerial.Size = new System.Drawing.Size(183, 20);
            labelPuertoSerial.TabIndex = 9;
            labelPuertoSerial.Text = "Puerto COM para la Avery:";
            // 
            // cboPuertos
            // 
            cboPuertos.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cboPuertos.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPuertos.FormattingEnabled = true;
            cboPuertos.Location = new System.Drawing.Point(887, 18);
            cboPuertos.Margin = new Padding(4, 5, 4, 5);
            cboPuertos.Name = "cboPuertos";
            cboPuertos.Size = new System.Drawing.Size(160, 28);
            cboPuertos.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1067, 703);
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
            Controls.Add(labelPuertoSerial);
            Controls.Add(cboPuertos);
            Margin = new Padding(4, 5, 4, 5);
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