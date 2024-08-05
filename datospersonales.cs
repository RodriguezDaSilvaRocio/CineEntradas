using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace CineEntradas
{
    public partial class datospersonales : Form
    {
        // convierto los campos privados en propiedades públicas
        public string Nombre { get; private set; }
        public string NumTarjeta { get; private set; }
        public string CVV { get; private set; }
        public string DNI { get; private set; }
        public string Telefono { get; private set; }
        public string MedioPago { get; private set; }
        public string Sala { get; private set; }
        public string Horario { get; private set; }
        public string Pelicula { get; private set; }
        public string Asiento { get; private set; }
        public string Fecha { get; private set; }


        //creo un constructor para pasar lo seleccionado de un formulario a otro
        public datospersonales(List<string> sala, List<string> horario, List<string> asiento, DateTime fecha, string peliculaSeleccionada)
        {
            InitializeComponent();
            Pelicula = peliculaSeleccionada;
            MostrarDatosSeleccionados(sala, horario, asiento, fecha);
            MostrarPeliculaSeleccionada();
            MostrarFecha(fecha, lbl_mostrardia);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            EstablecerMaxLength();
        }

        private void EstablecerMaxLength()
        {
            textBox_nombre.MaxLength = 50;    
            textBox_numtarj.MaxLength = 16;   
            textBox_cvv.MaxLength = 3;         
            textBox_dni.MaxLength = 8;        
            textBox_telefono.MaxLength = 15;   
        }
        public void MostrarDatosSeleccionados(List<string> sala, List<string> horario, List<string> asiento, DateTime fecha)
        {
            lbl_muestrasala.Text = string.Join(", ", sala);
            lbl_mostrarhorario.Text = string.Join(", ", horario);
            lbl_mostrarasiento.Text = string.Join(", ", asiento);
            lbl_mostrardia.Text = fecha.ToString("dd/MM/yyyy");
        }

        public void MostrarPeliculaSeleccionada()
        {
            Pelicula = lbl_mostrarpelicula.Text;
        }

        public datospersonales()
        {
            InitializeComponent();
        }

        

       //Uno los elementos seleccionados en una sola cadena separadas por comas
        private void MostrarElementos(List<string> elementos, Label label)
        {
            string elementosTexto = string.Join(", ", elementos);
            //asigna la cadena al texto del label
            label.Text = elementosTexto;
        }

        private void MostrarFecha(DateTime fecha, Label label)
        {
            //utilizo el formato con meses como digitos ya que anteriormente no se reproducia correctamente
            label.Text = fecha.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

       

        private void textBox_numtarj_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permito solo numeros 
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_cvv_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permito solo numeros 
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permito solo letras y espacio en blanco 
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permito solo numeros 
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permito solo numeros 
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_año_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permito solo numeros 
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void datospersonales_Load(object sender, EventArgs e)
        {

        }

        private void Comprar_Click(object sender, EventArgs e)
        {   
            // Obtiene los datos ingresados por el cliente
            string nombre = textBox_nombre.Text;
            string numTarjeta = textBox_numtarj.Text;
            string cvv = textBox_cvv.Text;
            string dni = textBox_dni.Text;
            string telefono = textBox_telefono.Text;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(numTarjeta) || string.IsNullOrEmpty(cvv) ||
               string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(telefono) || comboBox_mediopago.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // verifico si se ha seleccionado un medio de pago o muestra un mensaje de advertecia
            if (comboBox_mediopago.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un método de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string medioPago = comboBox_mediopago.SelectedItem.ToString();

            string sala = lbl_muestrasala.Text;
            string horario = lbl_mostrarhorario.Text;
            string asiento = lbl_mostrarasiento.Text;
            string pelicula = lbl_mostrarpelicula.Text;
            string fecha = lbl_mostrardia.Text;

            // Instancia el formulario de compra
            var formularioCompra = new compra(nombre, numTarjeta, cvv, dni, telefono, medioPago, sala, horario, pelicula, asiento, fecha);
            
            
            // Muestra el formulario de compra
            formularioCompra.ShowDialog();

        }

    }
}
