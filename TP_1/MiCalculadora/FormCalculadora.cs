using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Numeros;
using Calcular;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        // Botones formularios

        /// <summary>
        /// Boton que llama al metodo limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_OnClick(object sender, EventArgs e)
        {
            Limpiar();
        }


        /// <summary>
        /// Boton que llama al metodo operar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_OnClick(object sender, EventArgs e)
        {
            Numero auxNum1 = new Numero(txtNumero1.Text);
            Numero auxNum2 = new Numero(txtNumero2.Text);

            if (this.cmbOperadores.SelectedItem == null)
            {
                this.cmbOperadores.Text = "+";
            }

            lblResultado.Text = (Calculadora.Operar(auxNum1, auxNum2, cmbOperadores.Text)).ToString();
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;

        }

        /// <summary>
        /// Boton que cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_OnClick(object sender, EventArgs e)
        {
            FormCalculadora.ActiveForm.Close();
        }


        /// <summary>
        /// Boton Binario a Decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_OnClick(object sender, EventArgs e)
        {
            string retorno;
            retorno = Numero.DecimalBinario(lblResultado.Text);

            if (retorno != "Resultado" && retorno != "Valor invalido")
            {
                lblResultado.Text = retorno;
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = true;
            }
        }

        /// <summary>
        /// Boton Decimal a Binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_OnClick(object sender, EventArgs e)
        {
            string retorno;
            retorno = Numero.BinarioDecimal(lblResultado.Text);

            if (retorno != "Resultado" && retorno != "Valor invalido")
            {
                lblResultado.Text = retorno;
                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = false;
            }
        }


        // Metodos

        /// <summary>
        /// Metodo que limpia y resetea todos los campos
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperadores.ResetText();
            this.cmbOperadores.Text = null;
            this.lblResultado.Text = "Resultado";
        }

        /// <summary>
        /// Metodo privado que realiza la operacion
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero auxPrimerOperando = new Numero(numero1);
            Numero auxSegundoOperando = new Numero(numero2);

            return Calculadora.Operar(auxPrimerOperando, auxSegundoOperando, operador);
        }
    }
}
