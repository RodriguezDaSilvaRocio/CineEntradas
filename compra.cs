using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CineEntradas
{
    public partial class compra : Form
    {
        public compra(string nombre, string numTarjeta, string cvv, string dni, string telefono, string medioPago, string sala, string horario, string pelicula, string asiento, string fecha)
        {
            InitializeComponent();
            MostrarDatosCliente(nombre, numTarjeta, cvv, dni, telefono);
            MostrarMedioPago(medioPago);
            MostrarDatosSeleccionados(sala, horario, asiento, pelicula, fecha);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

        }

        public void MostrarDatosCliente(string nombre, string numTarjeta, string cvv, string dni, string telefono)
        {
            // Asigna los datos a los controles correspondientes en el formulario de compra
            lbl_resultado1.Text = nombre;
            lbl_resultado2.Text = numTarjeta;
            lbl_resultado3.Text = cvv;
            lbl_resultado4.Text = dni;
            lbl_resultado5.Text = telefono;

            
        } 
        
        public void MostrarMedioPago(string medioPago)
        {
            lbl_resultado6.Text = medioPago;
        }

        public void MostrarDatosSeleccionados(string sala, string horario, string asiento, string pelicula, string fecha)
        {
            lbl_muestrasala.Text = sala;
            lbl_mostrarhorario.Text = horario;
            lbl_mostrarasiento.Text = asiento;
            lbl_mostrarpelicula.Text = pelicula;
            lbl_mostrardia.Text = fecha;
        
        }

        private void btn_fin_Click(object sender, EventArgs e)
        {
            //muestro mensaje final de exito en la compra
            MessageBox.Show("Compra realizada con exito", "confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }


       
    }
}
