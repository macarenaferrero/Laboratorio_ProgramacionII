using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiDomo;
using System.IO;

namespace FormMiDomo
{
    public partial class FormInforme : Form
    {
        PendienteAConstruir<DomoGeodesico> pendienteAConstruir2;

        /// <summary>
        /// Constructor del formulario que no recibe parametros e inicializa la lista
        /// </summary>
        public FormInforme()
        {
            InitializeComponent();
            pendienteAConstruir2 = new PendienteAConstruir<DomoGeodesico>();
        }

        /// <summary>
        /// Constructor que recibe una lista de parametro 
        /// </summary>
        /// <param name="listadoPendiente">Lista que acepta solo Domos geodesicos de la que se imprimiran los datos</param>
        public FormInforme(PendienteAConstruir<DomoGeodesico> listadoPendiente) : this()
        {
            pendienteAConstruir2 = listadoPendiente;
        }

        /// <summary>
        /// Metodo publico que devuelve un string con los datos de la lista
        /// </summary>
        /// <param name="listadoPendiente">Lista de la cual se tomaran los datos</param>
        /// <returns>Retorna un string con los datos informados en la lista</returns>
        public string Mostrar(PendienteAConstruir<DomoGeodesico> listadoPendiente)
        {
            StringBuilder sb = new StringBuilder();
            if (!(listadoPendiente is null))
            {
                foreach (DomoGeodesico item in listadoPendiente.ListaPendientes)
                {
                    sb.AppendLine(item.InformeFabricacion());
                }
                sb.AppendLine($"Stock de Material de madera: {Decimal.Round((decimal)Fabrica.StockM2Madera, 2)} m2");
                sb.AppendLine($"Stock de Material de PVC: {Decimal.Round((decimal)Fabrica.StockM2PVC, 2)} m2");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Evento donde se cargara la informacion a mostrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormInforme_Load(object sender, EventArgs e)
        {
            if (pendienteAConstruir2.ListaPendientes.Count >= 1)
            {
                rtbInforme.Text = Mostrar(pendienteAConstruir2);
            }
        }

        /// <summary>
        /// Evento del Boton imprimir que genera un archivo con el listado pendiente a construir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string file_name = AppDomain.CurrentDomain.BaseDirectory + "ArchivoDeInforme01.txt";

            try
            {
                if (File.Exists(file_name) && (MessageBox.Show($"El archivo {file_name} existe. ¿Desea sobreescribirlo (SI) o agregar los datos al existente (NO)?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                {
                    using (StreamWriter sw = new StreamWriter(file_name))
                    {
                        if (pendienteAConstruir2.ListaPendientes.Count >= 1)
                        {
                            sw.Write("Fecha del Informe: ");
                            sw.WriteLine(DateTime.Now);
                            sw.WriteLine("-----------------------------");

                            sw.WriteLine(Mostrar(pendienteAConstruir2));
                        }

                        MessageBox.Show("El archivo fue modificado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(file_name, true))
                    {
                        sw.Write("Fecha del Informe: ");
                        sw.WriteLine(DateTime.Now);
                        sw.WriteLine("-----------------------------");

                        sw.WriteLine(Mostrar(pendienteAConstruir2));
                        MessageBox.Show("El archivo fue creado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Boton que elimina los domos pendientes solicitados y limpia la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            rtbInforme.Text = String.Empty;
            pendienteAConstruir2.ListaPendientes.Clear();
        }

        /// <summary>
        /// Metodo que se inicializa con el boton SALIR, cierra el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que se inicia en el omento en que se esta cerrando, buscando confirmacion de concluir con el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormInforme_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                this.Dispose();
            }
        }
    }
}
