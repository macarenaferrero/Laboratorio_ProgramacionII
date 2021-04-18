using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor que inicializa el formulario con los botones de conversion desabilitados
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Evento cerrar formulario que se ejecuta al dar click en el boton cerrar
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Clase base de los eventos</param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FormCalculadora.ActiveForm.Close();
        }

        /// <summary>
        /// Evento que realiza la conversion de Decimal a Binario. Se ejecuta a dar click en el boton Convertir a Binario
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Clase base de los eventos</param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {

            Numeros auxValor = new Numeros();
            double auxDouble;
            string auxString;
            double.TryParse(lblResultado.Text, out auxDouble);
            auxString = auxValor.DecimalBinario(auxDouble);
            lblResultado.Text = auxString;
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = true;
        }

        /// <summary>
        /// Metodo que opera segun el operador recibido dos valores
        /// </summary>
        /// <param name="num1">String con el valor a operar</param>
        /// <param name="num2">String con el segundo valor a operar</param>
        /// <param name="operador">String con el signo numerico a operar</param>
        /// <returns>Retorna el calculo del tipo Double entre ambos valores y el operador recibido</returns>
        private double Operar(string num1, string num2, string operador)
        {
            Numeros valorA = new Numeros(num1);
            Numeros valorB = new Numeros(num2);

            return Calculadora.Operar(valorA, valorB, operador);
        }

        /// <summary>
        /// Evento que llama al metodo Operar, y devuelve el resultado del mismo, si no se elije operador, por defecto sera +
        /// </summary>
        /// <param name="sender">objeto</param>
        /// <param name="e">lase base de los eventos</param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string num1 = txtNumero1.Text.Replace(".", ",");
            string num2 = txtNumero2.Text.Replace(".", ",");

            string operador = "+";
            if (!(cmbOperador.SelectedItem is null))
            {
                operador = cmbOperador.SelectedItem.ToString();
            }
            lblResultado.Text = (Operar(num1, num2, operador)).ToString();
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = true;
        }

        /// <summary>
        /// Evento que llama al metodo Limpiar. Se ejecuta al dar click sobre el boton Limpiar
        /// </summary>
        /// <param name="sender">objeto</param>
        /// <param name="e">lase base de los eventos</param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Metodo que se encarga de limpiar la calculadora
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            cmbOperador.SelectedIndex = -1;
            lblResultado.Text = "0";
        }

        /// <summary>
        /// Evento que realiza la conversion de Binario a Decimal. Se ejecuta a dar click en el boton Convertir a Decimal
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">lase base de los eventos</param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numeros auxValor = new Numeros();
            string auxString;
            auxString = auxValor.BinarioDecimal(lblResultado.Text);
            lblResultado.Text = auxString;
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }
    }
}
