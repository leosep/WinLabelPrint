// FormConfiguracionQR.Designer.cs
namespace ZebraLabelPrinter
{
    partial class FormConfiguracionQR
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
            this.chkNumeroSerie = new System.Windows.Forms.CheckBox();
            this.chkNombreBanco = new System.Windows.Forms.CheckBox();
            this.chkModelo = new System.Windows.Forms.CheckBox();
            this.chkUbicacion = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkNumeroSerie
            // 
            this.chkNumeroSerie.AutoSize = true;
            this.chkNumeroSerie.Checked = true;
            this.chkNumeroSerie.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNumeroSerie.Location = new System.Drawing.Point(30, 60);
            this.chkNumeroSerie.Name = "chkNumeroSerie";
            this.chkNumeroSerie.Size = new System.Drawing.Size(107, 17);
            this.chkNumeroSerie.TabIndex = 0;
            this.chkNumeroSerie.Text = "Número de Serie";
            this.chkNumeroSerie.UseVisualStyleBackColor = true;
            // 
            // chkNombreBanco
            // 
            this.chkNombreBanco.AutoSize = true;
            this.chkNombreBanco.Checked = true;
            this.chkNombreBanco.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNombreBanco.Location = new System.Drawing.Point(30, 85);
            this.chkNombreBanco.Name = "chkNombreBanco";
            this.chkNombreBanco.Size = new System.Drawing.Size(95, 17);
            this.chkNombreBanco.TabIndex = 1;
            this.chkNombreBanco.Text = "Nombre Banco";
            this.chkNombreBanco.UseVisualStyleBackColor = true;
            // 
            // chkModelo
            // 
            this.chkModelo.AutoSize = true;
            this.chkModelo.Checked = true;
            this.chkModelo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkModelo.Location = new System.Drawing.Point(30, 110);
            this.chkModelo.Name = "chkModelo";
            this.chkModelo.Size = new System.Drawing.Size(61, 17);
            this.chkModelo.TabIndex = 2;
            this.chkModelo.Text = "Modelo";
            this.chkModelo.UseVisualStyleBackColor = true;
            // 
            // chkUbicacion
            // 
            this.chkUbicacion.AutoSize = true;
            this.chkUbicacion.Checked = true;
            this.chkUbicacion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUbicacion.Location = new System.Drawing.Point(30, 135);
            this.chkUbicacion.Name = "chkUbicacion";
            this.chkUbicacion.Size = new System.Drawing.Size(76, 17);
            this.chkUbicacion.TabIndex = 3;
            this.chkUbicacion.Text = "Ubicación";
            this.chkUbicacion.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(30, 175);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 25);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(126, 175);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 25);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Seleccione los datos para el QR:";
            // 
            // FormConfiguracionQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 220);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.chkUbicacion);
            this.Controls.Add(this.chkModelo);
            this.Controls.Add(this.chkNombreBanco);
            this.Controls.Add(this.chkNumeroSerie);
            this.Name = "FormConfiguracionQR";
            this.Text = "Configuración de QR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkNumeroSerie;
        private System.Windows.Forms.CheckBox chkNombreBanco;
        private System.Windows.Forms.CheckBox chkModelo;
        private System.Windows.Forms.CheckBox chkUbicacion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
    }
}
