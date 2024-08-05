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
    public partial class ElijePelicula : Form
    {
        private string peliculaSeleccionada;
        
        public ElijePelicula()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            checkedListBox_sala.ItemCheck += new ItemCheckEventHandler(checkedListBox_ItemCheck);
            checkedListBox_horario.ItemCheck += new ItemCheckEventHandler(checkedListBox_ItemCheck);
            checkedListBox_asiento.ItemCheck += new ItemCheckEventHandler(checkedListBox_ItemCheck);

        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ElijePelicula_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void intensamente_click(object sender, EventArgs e)
            
        {
            panel1.Visible = true;
            peliculaSeleccionada = "Intensamente";
        }

        private void foto_coherence_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            peliculaSeleccionada = "Coherence";

        }

        private void foto_planetasimios_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            peliculaSeleccionada = "Planeta de los Simios";
        }

        private void foto_interestelar_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            peliculaSeleccionada = "Interestelar";
        }

        private void foto_harrypotter_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            peliculaSeleccionada = "Harry Potter";
        }

        private void foto_desafiantes_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            peliculaSeleccionada = "Desafiantes";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var elementosSeleccionados1 = ObtenerElementosSeleccionados(checkedListBox_sala);
            var elementosSeleccionados2 = ObtenerElementosSeleccionados(checkedListBox_horario);
            var elementosSeleccionados3 = ObtenerElementosSeleccionados(checkedListBox_asiento);
 

            DateTime fechaseleccionada = dateTimePicker1.Value;
          
           

            if (elementosSeleccionados1.Count > 0 || elementosSeleccionados2.Count > 0 || elementosSeleccionados3.Count > 0 || fechaseleccionada != DateTime.MinValue)
            {


                var datospersonales = new datospersonales(elementosSeleccionados1, elementosSeleccionados2, elementosSeleccionados3, fechaseleccionada, peliculaSeleccionada);
                datospersonales.Show();
                
                
            }

            else
            {
                MessageBox.Show("Por favor seleccione al menor un elemento", "Mensaje", MessageBoxButtons.OK);
            }

        }
        private List<string> ObtenerElementosSeleccionados( CheckedListBox checkedListBox)
        {
            var elementosSeleccionados = new List<string> ();
            for(int i=0; i < checkedListBox.Items.Count; i++)
            {
                if (checkedListBox.GetItemChecked(i))
                {
                    elementosSeleccionados.Add(checkedListBox.Items[i].ToString());
                }
            }
            return elementosSeleccionados;
        }


        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox checkedListBox = sender as CheckedListBox;

            // Si se está marcando un elemento
            if (e.NewValue == CheckState.Checked)
            {
                // Desmarcar todos los demás elementos
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        checkedListBox.SetItemChecked(i, false);
                    }
                }
            }
        }
    }
}
