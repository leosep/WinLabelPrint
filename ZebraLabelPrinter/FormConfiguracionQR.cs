// FormConfiguracionQR.cs
using System;
using System.Windows.Forms;

namespace ZebraLabelPrinter
{
    public partial class FormConfiguracionQR : Form
    {
        // Propiedades públicas para acceder a las selecciones del usuario
        public bool IncluirNumeroSerie { get; private set; }
        public bool IncluirNombreBanco { get; private set; }
        public bool IncluirModelo { get; private set; }
        public bool IncluirUbicacion { get; private set; }

        public FormConfiguracionQR()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Al hacer clic en Aceptar, guarda el estado de los CheckBoxes
            IncluirNumeroSerie = chkNumeroSerie.Checked;
            IncluirNombreBanco = chkNombreBanco.Checked;
            IncluirModelo = chkModelo.Checked;
            IncluirUbicacion = chkUbicacion.Checked;

            // Establece el resultado del diálogo en OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Si el usuario cancela, simplemente cierra el formulario
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
