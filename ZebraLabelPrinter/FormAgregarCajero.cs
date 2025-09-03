using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace ZebraLabelPrinter
{
    public partial class FormAgregarCajero : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Cajero? NuevoCajero { get; private set; }

        public FormAgregarCajero()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNumeroSerie.Text) ||
                string.IsNullOrWhiteSpace(txtNombreBanco.Text) ||
                string.IsNullOrWhiteSpace(txtModelo.Text) ||
                string.IsNullOrWhiteSpace(txtUbicacion.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NuevoCajero = new Cajero
            {
                NumeroDeSerie = txtNumeroSerie.Text,
                NombreBanco = txtNombreBanco.Text,
                Modelo = txtModelo.Text,
                Ubicacion = txtUbicacion.Text,
                FechaDeInstalacion = dtpFechaInstalacion.Value
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}