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
        public FormCalculadora()
        {
            InitializeComponent();
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FormCalculadora.ActiveForm.Close();
        }

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
