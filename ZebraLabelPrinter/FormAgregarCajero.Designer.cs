// FormAgregarCajero.Designer.cs
namespace ZebraLabelPrinter
{
    partial class FormAgregarCajero
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroSerie = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreBanco = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaInstalacion = new System.Windows.Forms.DateTimePicker();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número de Serie:";
            // 
            // txtNumeroSerie
            // 
            this.txtNumeroSerie.Location = new System.Drawing.Point(114, 12);
            this.txtNumeroSerie.Name = "txtNumeroSerie";
            this.txtNumeroSerie.Size = new System.Drawing.Size(200, 20);
            this.txtNumeroSerie.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre del Banco:";
            // 
            // txtNombreBanco
            // 
            this.txtNombreBanco.Location = new System.Drawing.Point(114, 38);
            this.txtNombreBanco.Name = "txtNombreBanco";
            this.txtNombreBanco.Size = new System.Drawing.Size(200, 20);
            this.txtNombreBanco.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Modelo:";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(114, 64);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(200, 20);
            this.txtModelo.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ubicación:";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(114, 90);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(200, 20);
            this.txtUbicacion.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha de Instalación:";
            // 
            // dtpFechaInstalacion
            // 
            this.dtpFechaInstalacion.Location = new System.Drawing.Point(114, 116);
            this.dtpFechaInstalacion.Name = "dtpFechaInstalacion";
            this.dtpFechaInstalacion.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInstalacion.TabIndex = 9;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(114, 150);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(95, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(219, 150);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormAgregarCajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 185);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtpFechaInstalacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombreBanco);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumeroSerie);
            this.Controls.Add(this.label1);
            this.Name = "FormAgregarCajero";
            this.Text = "Agregar/Editar Cajero";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtNumeroSerie;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtNombreBanco;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DateTimePicker dtpFechaInstalacion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
