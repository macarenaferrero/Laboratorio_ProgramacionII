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
            btnConvtABin.Enabled = false;
            btnConvertADec.Enabled = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FormCalculadora.ActiveForm.Close();
        }

        private void btnConvtABin_Click(object sender, EventArgs e)
        {

            Numeros auxValor = new Numeros();
            double auxDouble;
            string auxString;
            double.TryParse(lblResultado.Text, out auxDouble);
            auxString = auxValor.DecimalBinario(auxDouble);
            lblResultado.Text = auxString;
            btnConvtABin.Enabled = false;
            btnConvertADec.Enabled = true;
        }

        private double Operar(string num1, string num2, string operador)
        {
            Numeros valorA = new Numeros(num1);
            Numeros valorB = new Numeros(num2);

            return Calculadora.Operar(valorA, valorB, operador);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string num1 = txtValorA.Text.Replace(".", ",");
            string num2 = txtValorB.Text.Replace(".", ",");

            string operador = "+";
            if (!(cmbOperador.SelectedItem is null))
            {
                operador = cmbOperador.SelectedItem.ToString();
            }
            lblResultado.Text = (Operar(num1, num2, operador)).ToString();
            btnConvtABin.Enabled = true;
            btnConvertADec.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtValorA.Text = string.Empty;
            txtValorB.Text = string.Empty;
            cmbOperador.SelectedIndex = -1;
            lblResultado.Text = "0";
        }

        private void btnConvertADec_Click(object sender, EventArgs e)
        {
            Numeros auxValor = new Numeros();
            string auxString;
            auxString = auxValor.BinarioDecimal(lblResultado.Text);
            lblResultado.Text = auxString;
            btnConvertADec.Enabled = false;
            btnConvtABin.Enabled = true;
        }
    }
}
