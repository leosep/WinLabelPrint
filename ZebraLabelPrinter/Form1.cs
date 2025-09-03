using Dapper;
using Microsoft.Data.Sqlite;
using QRCoder;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;
using Zebra.Sdk.Printer.Discovery;
using Color = System.Drawing.Color;

namespace ZebraLabelPrinter
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=cajeros.db";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Crea la tabla si no existe
            CrearTablaCajeros();
            // Carga los datos de los cajeros en el DataGridView
            CargarDatos();
            // Configura el DataGridView para seleccionar filas completas y múltiples filas
            dgvCajeros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCajeros.MultiSelect = true;
            // Llenar el ComboBox con los puertos seriales disponibles
            LlenarPuertosSeriales();
            // Llenar el ComboBox para el lenguaje de la impresora Zebra
            // cboZebraLanguage.Items.AddRange(new string[] { "ZPL", "EPL" });
            cboZebraLanguage.SelectedIndex = 0; // Selecciona ZPL por defecto
        }

        private void LlenarPuertosSeriales()
        {
            // Limpia los elementos existentes en el ComboBox
            cboPuertos.Items.Clear();
            // Obtiene todos los nombres de puertos seriales disponibles
            string[] portNames = SerialPort.GetPortNames();
            // Añade cada nombre de puerto al ComboBox
            cboPuertos.Items.AddRange(portNames);
            // Si hay puertos disponibles, selecciona el primero
            if (portNames.Length > 0)
            {
                cboPuertos.SelectedIndex = 0;
            }
        }

        private void CrearTablaCajeros()
        {
            using (IDbConnection cnn = new SqliteConnection(connectionString))
            {
                // Comando SQL para crear la tabla si no existe
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Cajeros (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        NumeroDeSerie TEXT NOT NULL,
                        NombreBanco TEXT,
                        Modelo TEXT,
                        Ubicacion TEXT,
                        FechaDeInstalacion TEXT
                    );";
                cnn.Execute(createTableQuery);
            }
        }

        private void CargarDatos(string? searchTerm = null)
        {
            using (IDbConnection cnn = new SqliteConnection(connectionString))
            {
                string query = "SELECT * FROM Cajeros";
                var parameters = new DynamicParameters();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    // Añade la cláusula WHERE para filtrar los resultados por el término de búsqueda
                    query += " WHERE NumeroDeSerie LIKE @SearchTerm OR NombreBanco LIKE @SearchTerm OR Modelo LIKE @SearchTerm OR Ubicacion LIKE @SearchTerm";
                    parameters.Add("@SearchTerm", $"%{searchTerm}%");
                }

                var cajeros = cnn.Query<Cajero>(query, parameters).ToList();
                dgvCajeros.DataSource = cajeros;
            }

            // Oculta la columna 'Id' para una mejor visualización
            if (dgvCajeros.Columns.Contains("Id"))
            {
                dgvCajeros.Columns["Id"].Visible = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDatos(txtBuscar.Text);
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var formAgregar = new FormAgregarCajero())
            {
                if (formAgregar.ShowDialog() == DialogResult.OK)
                {
                    var nuevoCajero = formAgregar.NuevoCajero;
                    if (nuevoCajero != null)
                    {
                        using (IDbConnection cnn = new SqliteConnection(connectionString))
                        {
                            string insertQuery = @"
                                INSERT INTO Cajeros (NumeroDeSerie, NombreBanco, Modelo, Ubicacion, FechaDeInstalacion)
                                VALUES (@NumeroDeSerie, @NombreBanco, @Modelo, @Ubicacion, @FechaDeInstalacion)";
                            cnn.Execute(insertQuery, nuevoCajero);
                        }
                        CargarDatos();
                        MessageBox.Show("Cajero agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCajeros.SelectedRows.Count > 0)
            {
                var cajeroSeleccionado = dgvCajeros.SelectedRows[0].DataBoundItem as Cajero;
                if (cajeroSeleccionado != null)
                {
                    using (var formEditar = new FormAgregarCajero())
                    {
                        formEditar.txtNumeroSerie.Text = cajeroSeleccionado.NumeroDeSerie;
                        formEditar.txtNombreBanco.Text = cajeroSeleccionado.NombreBanco;
                        formEditar.txtModelo.Text = cajeroSeleccionado.Modelo;
                        formEditar.txtUbicacion.Text = cajeroSeleccionado.Ubicacion;
                        formEditar.dtpFechaInstalacion.Value = cajeroSeleccionado.FechaDeInstalacion;
                        if (formEditar.ShowDialog() == DialogResult.OK)
                        {
                            var cajeroEditado = formEditar.NuevoCajero;
                            if (cajeroEditado != null)
                            {
                                using (IDbConnection cnn = new SqliteConnection(connectionString))
                                {
                                    cajeroEditado.Id = cajeroSeleccionado.Id; // Mantener el mismo Id
                                    string updateQuery = @"
                                        UPDATE Cajeros
                                        SET NumeroDeSerie = @NumeroDeSerie,
                                            NombreBanco = @NombreBanco,
                                            Modelo = @Modelo,
                                            Ubicacion = @Ubicacion,
                                            FechaDeInstalacion = @FechaDeInstalacion
                                        WHERE Id = @Id";
                                    cnn.Execute(updateQuery, cajeroEditado);
                                }
                                CargarDatos();
                                MessageBox.Show("Cajero editado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cajero para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCajeros.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Estás seguro de que quieres eliminar el cajero seleccionado?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var cajeroSeleccionado = dgvCajeros.SelectedRows[0].DataBoundItem as Cajero;
                    if (cajeroSeleccionado != null)
                    {
                        using (IDbConnection cnn = new SqliteConnection(connectionString))
                        {
                            string deleteQuery = "DELETE FROM Cajeros WHERE Id = @Id";
                            cnn.Execute(deleteQuery, new { Id = cajeroSeleccionado.Id });
                        }
                        CargarDatos();
                        MessageBox.Show("Cajero eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cajero para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvCajeros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona al menos un cajero para imprimir.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string? selectedLanguage = cboZebraLanguage.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedLanguage))
            {
                MessageBox.Show("Por favor, selecciona un lenguaje de impresora Zebra.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Llama al método de impresión con el lenguaje seleccionado
            ImprimirZebra(selectedLanguage);
        }

        private void btnImprimirAvery_Click(object sender, EventArgs e)
        {
            if (dgvCajeros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona al menos un cajero para imprimir.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboPuertos.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un puerto COM.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var formConfig = new FormConfiguracionQR())
            {
                if (formConfig.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                bool incluirSerial = formConfig.IncluirNumeroSerie;
                bool incluirBanco = formConfig.IncluirNombreBanco;
                bool incluirModelo = formConfig.IncluirModelo;
                bool incluirUbicacion = formConfig.IncluirUbicacion;

                string comPort = cboPuertos.SelectedItem.ToString();
                int baudRate = 9600;

                using (var serialPort = new SerialPort(comPort, baudRate, Parity.None, 8, StopBits.One))
                {
                    try
                    {
                        serialPort.Open();

                        foreach (DataGridViewRow row in dgvCajeros.SelectedRows)
                        {
                            if (row.DataBoundItem is Cajero cajero)
                            {
                                string qrData = GenerarDatosQR(cajero, incluirSerial, incluirBanco, incluirModelo, incluirUbicacion);
                                // Genera el código EPL para el QR y el texto
                                string epl = GenerarEPL(cajero, qrData);
                                serialPort.Write(epl);
                                System.Threading.Thread.Sleep(500); // Pausa para que la impresora procese
                            }
                        }
                        MessageBox.Show("Etiquetas impresas exitosamente en la impresora Avery Dennison.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de comunicación con la impresora Avery Dennison: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ImprimirZebra(string language)
        {
            string? usbAddress = EncontrarImpresoraZebra();

            if (string.IsNullOrEmpty(usbAddress))
            {
                MessageBox.Show("No se encontró ninguna impresora Zebra conectada por USB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Connection? connection = null;
            try
            {
                connection = new UsbConnection(usbAddress);
                connection.Open();

                using (var formConfig = new FormConfiguracionQR())
                {
                    if (formConfig.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    bool incluirSerial = formConfig.IncluirNumeroSerie;
                    bool incluirBanco = formConfig.IncluirNombreBanco;
                    bool incluirModelo = formConfig.IncluirModelo;
                    bool incluirUbicacion = formConfig.IncluirUbicacion;

                    foreach (DataGridViewRow row in dgvCajeros.SelectedRows)
                    {
                        if (row.DataBoundItem is Cajero cajero)
                        {
                            string qrData = GenerarDatosQR(cajero, incluirSerial, incluirBanco, incluirModelo, incluirUbicacion);
                            string labelCommand = "";
                            if (language == "ZPL")
                            {
                                labelCommand = GenerarZPL(cajero, qrData);
                            }
                            else if (language == "EPL")
                            {
                                labelCommand = GenerarEPL(cajero, qrData);
                            }

                            if (!string.IsNullOrEmpty(labelCommand))
                            {
                                connection.Write(Encoding.ASCII.GetBytes(labelCommand));
                            }
                        }
                    }
                    MessageBox.Show($"Etiquetas impresas exitosamente en la impresora Zebra ({language}).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ConnectionException ex)
            {
                MessageBox.Show("Error de conexión con la impresora Zebra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (ConnectionException ex)
                    {
                        MessageBox.Show("Error al cerrar la conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string GenerarZPL(Cajero cajero, string qrData)
        {
            StringBuilder zpl = new StringBuilder();
            zpl.AppendLine("^XA");
            // Comando QR, se ajusta la posición y el tamaño
            zpl.AppendLine($"^FO50,50^BQN,2,8^FDQA,{qrData}^FS");
            // Texto para el número de serie
            zpl.AppendLine($"^FO50,250^A0N,30,30^FDNúmero de Serie: {cajero.NumeroDeSerie}^FS");
            // Texto para el nombre del banco
            zpl.AppendLine($"^FO50,290^A0N,20,20^FDNombre del Banco: {cajero.NombreBanco}^FS");
            // Texto para el modelo
            zpl.AppendLine($"^FO50,320^A0N,20,20^FDModelo: {cajero.Modelo}^FS");
            // Texto para la ubicación
            zpl.AppendLine($"^FO50,350^A0N,20,20^FDUbicación: {cajero.Ubicacion}^FS");
            zpl.AppendLine("^XZ");
            return zpl.ToString();
        }

        private string GenerarEPL(Cajero cajero, string qrData)
        {
            StringBuilder epl = new StringBuilder();
            epl.AppendLine("N");
            // Limpia el búfer de la imagen
            epl.AppendLine("I8,A,001");
            epl.AppendLine("q609");
            epl.AppendLine("Q406,24");
            // Comando QR para EPL2
            epl.AppendLine($"B50,50,0,Q4,S2,\"{qrData}\"");
            // Texto para el número de serie
            epl.AppendLine($"A50,250,0,4,1,1,N,\"Número de Serie: {cajero.NumeroDeSerie}\"");
            // Texto para el nombre del banco
            epl.AppendLine($"A50,280,0,3,1,1,N,\"Nombre del Banco: {cajero.NombreBanco}\"");
            // Texto para el modelo
            epl.AppendLine($"A50,310,0,3,1,1,N,\"Modelo: {cajero.Modelo}\"");
            // Texto para la ubicación
            epl.AppendLine($"A50,340,0,3,1,1,N,\"Ubicación: {cajero.Ubicacion}\"");
            epl.AppendLine("P1");
            return epl.ToString();
        }

        private string? EncontrarImpresoraZebra()
        {
            try
            {
                var discoveredPrinters = UsbDiscoverer.GetZebraUsbPrinters();
                if (discoveredPrinters.Count > 0)
                {
                    return discoveredPrinters[0].Address;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al descubrir impresoras: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private string GenerarDatosQR(Cajero cajero, bool incluirSerial, bool incluirBanco, bool incluirModelo, bool incluirUbicacion)
        {
            var sb = new StringBuilder();
            if (incluirSerial)
            {
                sb.AppendLine($"Numero de Serie: {cajero.NumeroDeSerie}");
            }
            if (incluirBanco)
            {
                sb.AppendLine($"Nombre del Banco: {cajero.NombreBanco}");
            }
            if (incluirModelo)
            {
                sb.AppendLine($"Modelo: {cajero.Modelo}");
            }
            if (incluirUbicacion)
            {
                sb.AppendLine($"Ubicacion: {cajero.Ubicacion}");
            }
            return sb.ToString();
        }
    }

    public class Cajero
    {
        public int Id { get; set; }
        public string NumeroDeSerie { get; set; } = string.Empty;
        public string NombreBanco { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public DateTime FechaDeInstalacion { get; set; }
    }
}