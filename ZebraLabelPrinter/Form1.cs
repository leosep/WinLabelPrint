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
            // Nuevo: Llenar el ComboBox con los puertos seriales disponibles
            LlenarPuertosSeriales();
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

        private void CargarDatos(string searchTerm = null)
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
                    using (IDbConnection cnn = new SqliteConnection(connectionString))
                    {
                        var nuevoCajero = formAgregar.NuevoCajero;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCajeros.SelectedRows.Count > 0)
            {
                var cajeroSeleccionado = dgvCajeros.SelectedRows[0].DataBoundItem as Cajero;
                using (var formEditar = new FormAgregarCajero())
                {
                    formEditar.txtNumeroSerie.Text = cajeroSeleccionado.NumeroDeSerie;
                    formEditar.txtNombreBanco.Text = cajeroSeleccionado.NombreBanco;
                    formEditar.txtModelo.Text = cajeroSeleccionado.Modelo;
                    formEditar.txtUbicacion.Text = cajeroSeleccionado.Ubicacion;
                    formEditar.dtpFechaInstalacion.Value = cajeroSeleccionado.FechaDeInstalacion;
                    if (formEditar.ShowDialog() == DialogResult.OK)
                    {
                        using (IDbConnection cnn = new SqliteConnection(connectionString))
                        {
                            var cajeroEditado = formEditar.NuevoCajero;
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
                    using (IDbConnection cnn = new SqliteConnection(connectionString))
                    {
                        string deleteQuery = "DELETE FROM Cajeros WHERE Id = @Id";
                        cnn.Execute(deleteQuery, new { Id = cajeroSeleccionado.Id });
                    }
                    CargarDatos();
                    MessageBox.Show("Cajero eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // Muestra el formulario de configuración del QR
            using (var formConfig = new FormConfiguracionQR())
            {
                if (formConfig.ShowDialog() != DialogResult.OK)
                {
                    // Si el usuario cancela, no se hace nada
                    return;
                }
                // Obtiene las opciones de configuración del QR desde el formulario
                bool incluirSerial = formConfig.IncluirNumeroSerie;
                bool incluirBanco = formConfig.IncluirNombreBanco;
                bool incluirModelo = formConfig.IncluirModelo;
                bool incluirUbicacion = formConfig.IncluirUbicacion;
                string usbAddress = EncontrarImpresoraZebra();

                if (string.IsNullOrEmpty(usbAddress))
                {
                    MessageBox.Show("No se encontró ninguna impresora Zebra conectada por USB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Connection connection = new UsbConnection(usbAddress);
                try
                {
                    connection.Open();
                    ZebraPrinter printer = ZebraPrinterFactory.GetInstance(connection);

                    foreach (DataGridViewRow row in dgvCajeros.SelectedRows)
                    {
                        if (row.DataBoundItem is Cajero cajero)
                        {
                            // 1. Limpiar el área del código QR antes de imprimir
                            LimpiarAreaQR(connection);
                            // 2. Generar el contenido del QR basándonos en las opciones del usuario
                            string qrData = GenerarDatosQR(cajero, incluirSerial, incluirBanco, incluirModelo, incluirUbicacion);
                            // 3. Generar el código QR como una imagen
                            QRCodeGenerator qrGenerator = new QRCodeGenerator();
                            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);
                            QRCode qrCode = new QRCode(qrCodeData);
                            Bitmap qrImage = qrCode.GetGraphic(20);
                            // 4. Convertir la imagen del QR a formato de byte para ZPL
                            string hexString = BitmapToZpl(qrImage);
                            // 5. Construir el comando ZPL para la etiqueta
                            StringBuilder zpl = new StringBuilder();
                            zpl.AppendLine("^XA");
                            zpl.AppendLine($"^FO50,50^GFA,{hexString}^FS"); // Comando para dibujar la imagen del QR
                            zpl.AppendLine("^FX Posición del texto.");
                            zpl.AppendLine("^FO50,250^A0N,30,30^FD" + cajero.NumeroDeSerie + "^FS");
                            zpl.AppendLine("^FO50,300^A0N,20,20^FD" + cajero.NombreBanco + "^FS");
                            zpl.AppendLine("^XZ");
                            // Se cambia a Write para mayor compatibilidad
                            connection.Write(Encoding.ASCII.GetBytes(zpl.ToString()));
                        }
                    }
                    MessageBox.Show("Etiquetas impresas exitosamente en la impresora Zebra.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                StringBuilder epl = new StringBuilder();

                                epl.AppendLine("N");
                                epl.AppendLine("q812");
                                epl.AppendLine("Q609,24");
                                epl.AppendLine("B450,100,0,M,2,4,4,Q,S\"" + qrData + "\"");
                                epl.AppendLine("A450,250,0,4,1,1,N,\"" + cajero.NumeroDeSerie + "\"");
                                epl.AppendLine("A450,280,0,3,1,1,N,\"" + cajero.NombreBanco + "\"");
                                epl.AppendLine("P1");

                                serialPort.Write(epl.ToString());
                                serialPort.WriteLine("\n");

                                System.Threading.Thread.Sleep(500);
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

        private string EncontrarImpresoraZebra()
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
            // Código para generar los datos del QR
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

        private void LimpiarAreaQR(Connection connection)
        {
            // Comando ZPL para borrar la memoria de imagen de la impresora
            string zplClear = "^XA^IDR:*.GRF^FS^XZ";
            try
            {
                connection.Write(Encoding.ASCII.GetBytes(zplClear));
            }
            catch (ConnectionException e)
            {
                // Manejar el error
            }
        }

        private string BitmapToZpl(Bitmap qrImage)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    qrImage.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                    byte[] bmpBytes = stream.ToArray();
                    StringBuilder hexString = new StringBuilder();
                    foreach (byte b in bmpBytes)
                    {
                        hexString.AppendFormat("{0:X2}", b);
                    }
                    return hexString.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al convertir la imagen a ZPL: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
    }
}