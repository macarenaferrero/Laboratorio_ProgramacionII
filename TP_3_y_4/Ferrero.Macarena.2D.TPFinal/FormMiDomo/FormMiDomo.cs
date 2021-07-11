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
using System.Data.SqlClient;

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
        DomoDAO domo;

        /// <summary>
        /// Constructor del formulario que inicializa la lista, el objeto DomoDAO y el serializador
        /// </summary>
        public FormMiDomo()
        {
            InitializeComponent();
            pendienteAConstruir = new PendienteAConstruir<DomoGeodesico>();
            xmlSerializador = new XML<List<DomoGeodesico>>();
            listaDomos = pendienteAConstruir.ListaPendientes;
            domo = new DomoDAO();
        }

        /// <summary>
        /// Al cargar el formulario se seleccionan propiedades por defecto y se carga el archivo con los domos pendientes
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
                        MessageBox.Show("Archivo XML cargado correctamente con datos de la ultima ejecucion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DomoException("No se puede cargar el archivo XML", "FormMiDomo.cs","Load()", ex);
            }
        }

        /// <summary>
        /// Boton que ingresa un domo a la lista de pendientes si todo se encuentra declarado correctamente, sino, lanza excepciones
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
                       
                        kitMadera = new KitMadera(radioAux, (EFrecuencia)cmbFrecuencia.SelectedIndex, nombreAux, (ETipoConexion)cmbConexion.SelectedIndex, this.rbtMadera.Text.Trim(), EEstado.Pendiente);
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

                            domo.Guardar(kitMadera);
                            this.ActualizarLista();

                            MessageBox.Show("Domo añadido a la lista de pendientes.");
                        }
                        else
                        {
                            MessageBox.Show("Domo NO añadido a la lista de pendientes.");
                        }
                    }
                    else
                    {
                        kitPVC = new KitPVC(radioAux, (EFrecuencia)cmbFrecuencia.SelectedIndex, nombreAux, ETipoConexion.Incrustable, rbtPVC.Text.Trim(), EEstado.Pendiente);
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
                        domo.Guardar(kitPVC);
                        this.ActualizarLista();
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
        /// Metodo que limpia la lista y carga la misma con los datos de la base de datos
        /// </summary>
        private void ActualizarLista()
        {
            this.pendienteAConstruir.ListaPendientes.Clear();
            this.pendienteAConstruir.ListaPendientes = domo.Leer();
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
        /// Metodo que se inicializa con el boton SALIR, cierra el programa y guarda los domos pendientes en el archivo XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                if (xmlSerializador.Guardar(rutaArchivo, pendienteAConstruir.ListaPendientes))
                {
                    MessageBox.Show("Archivo XML guardado en la carpeta del ejecutable", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                throw new DomoException("No se pudo guardar el archivo XML", "FormMiDomo", "Salir()", ex);
            }

            this.Close();
        }

        /// <summary>
        /// Metodo que se inicializa con el boton Ver informe e redirige a otro formulario que imprime informacion en un DataGrid
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
