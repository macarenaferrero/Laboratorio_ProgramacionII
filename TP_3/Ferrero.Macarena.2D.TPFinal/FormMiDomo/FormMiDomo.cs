using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiDomo;

namespace FormMiDomo
{
    public partial class FormMiDomo : Form
    {
        KitMadera kitMadera;
        KitPVC kitPVC;
        PendienteAConstruir<DomoGeodesico> pendienteAConstruir;
        List<DomoGeodesico> listaDomos;
        XML<List<DomoGeodesico>> xmlSerializador;
        string rutaArchivo = $"{Environment.CurrentDirectory}\\pendienteAContruir.xml";

        /// <summary>
        /// Constructor del formulario que inicializa la lista
        /// </summary>
        public FormMiDomo()
        {
            InitializeComponent();
            pendienteAConstruir = new PendienteAConstruir<DomoGeodesico>();
            xmlSerializador = new XML<List<DomoGeodesico>>();
            listaDomos = pendienteAConstruir.ListaPendientes;
        }

        /// <summary>
        /// Al cargar el formulario se seleccionan propiedades por defecto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMiDomo_Load(object sender, EventArgs e)
        {
            cmbConexion.SelectedIndex = 0;
            cmbFrecuencia.SelectedIndex = 0;
            rbtMadera.Checked = true;
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    if (xmlSerializador.Leer(rutaArchivo, out listaDomos))
                    {
                        pendienteAConstruir.ListaPendientes = listaDomos;
                        MessageBox.Show("Archivo cargaado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Boton que ingresa un domo a la lista de pendientes si todo se encuentra declarado correctamente, sino, expone las excepciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(txtCliente.Text is null) && !(txtRadio.Text is null))
                {
                    float radioAux;
                    string nombreAux = txtCliente.Text;
                    float.TryParse(txtRadio.Text, out radioAux);
                    if (rbtMadera.Checked)
                    {
                        cmbConexion.Enabled = true;
                        kitMadera = new KitMadera(radioAux, (EFrecuencia)cmbFrecuencia.SelectedIndex, nombreAux, (ETipoConexion)cmbConexion.SelectedIndex);
                        bool agregar = pendienteAConstruir + (DomoGeodesico)kitMadera;

                        if (agregar)
                        {
                            if (kitMadera.TipoDeConexion == ETipoConexion.Cono)
                            {
                                btnImagen.ImageIndex = 1;
                            }
                            else if (kitMadera.TipoDeConexion == ETipoConexion.GoodKarma)
                            {
                                btnImagen.ImageIndex = 0;
                            }
                            else
                            {
                                btnImagen.ImageIndex = 2;
                            }

                            MessageBox.Show("Domo añadido a la lista de pendientes.");
                        }
                        else
                        {
                            MessageBox.Show("Domo NO añadido a la lista de pendientes.");
                        }

                    }
                    else
                    {
                        kitPVC = new KitPVC(radioAux, (EFrecuencia)cmbFrecuencia.SelectedIndex, nombreAux);
                        bool agregar = pendienteAConstruir + (DomoGeodesico)kitPVC;
                        if (agregar)
                        {
                            btnImagen.ImageIndex = 3;
                            MessageBox.Show("Domo añadido a la lista de pendientes.");
                        }
                        else
                        {
                            MessageBox.Show("Domo NO añadido a la lista de pendientes.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese valor en todos los campos solicitados.");
                }

                txtCliente.Clear();
                txtRadio.Clear();
            }
            catch (DomoException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Evento que aparece cuando se esta cerrando el formulario, buscando confirmacion de que realmente desea salir del programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMiDomo_FormClosing(object sender, FormClosingEventArgs e)
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

        /// <summary>
        /// Metodo que corrobora que si el material seleccionado es de PVC no se deba seleccionar tipo de coneccion, y si se habilite en el caso de que sea de madera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtPVC_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPVC.Checked)
            {
                cmbConexion.Enabled = false;
            }
            else
            {
                cmbConexion.Enabled = true;
            }
        }

        /// <summary>
        /// Metodo que se inicializa con el boton SALIR, cierra el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                if (xmlSerializador.Guardar(rutaArchivo, pendienteAConstruir.ListaPendientes))
                {
                    MessageBox.Show("Se guardo la lista de pendientes", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            this.Close();
        }

        /// <summary>
        /// Metodo que se inicializa con el boton Ver informe e redirige a otro formulario que imprime informacion por pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerInforme_Click(object sender, EventArgs e)
        {
            if (pendienteAConstruir.ListaPendientes.Count > 0)
            {
                FormInforme informe = new FormInforme(pendienteAConstruir);
                informe.Location = this.Location;
                informe.Show();
            }
            else
            {
                MessageBox.Show("No hay domos pendientes a construir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
    }

}
