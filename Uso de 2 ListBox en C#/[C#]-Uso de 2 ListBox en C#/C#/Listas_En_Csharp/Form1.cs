using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listas_En_Csharp
{
    public partial class FormularioPrincipal : Form
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListaIzq.Items.Add("Asael");
            ListaIzq.Items.Add("Isai");
            ListaIzq.Items.Add("Darwin");
            ListaIzq.Items.Add("Jaime");
            ListaIzq.Items.Add("Timoteo");
            ListaIzq.Items.Add("Dr:Messi");
            ListaIzq.Items.Add("Ronaldo");
            ListaIzq.Items.Add("David Nukelee");
            ListaIzq.Items.Add("Sonia");
            ListaIzq.Items.Add("King-Flip");
            itemsIzq();
            itemsDer();
        }
        private void itemsIzq()//Contamos los items de la lista isq
        {
            lblitemsIzq.Text = ListaIzq.Items.Count.ToString()+" items";
        }
        private void itemsDer()//Contamos los items de la lista Der
        {
            lblitemsDer.Text = ListaDer.Items.Count.ToString() + " items";
            
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            //A;adimos un nuevo elemento a la lista izq.
            if (txtNuevoElem.Text.Trim().Length != 0)//Si nos es vacio guerda
            {
                ListaIzq.Items.Add(txtNuevoElem.Text.Trim());//Agrega el contenido del textbox a la lista izquirda
                txtNuevoElem.Clear();//Limpia el textbox
                txtNuevoElem.Focus();//Posiciona el cusrsor en el textbox :xd...
                itemsIzq();//Actuliza los items contados

            }
            else
            {
                MessageBox.Show("Debe Ingresar algo...Xd","Aviso!");//Te mostrara este mensaje si no digitastes nada en el textbox,,,
                txtNuevoElem.Focus();//Posiciona el cusrsor en el textbox :xd...
            }
        }

        private void DerTodos_Click(object sender, EventArgs e)
        {
            PasarTodoDerecha();            
        }
        private void IzqTodos_Click(object sender, EventArgs e)
        {
            PasarTodoIzquierda();
        }
        private void PasarTodoDerecha()
        {
            if (ListaIzq.Items.Count > 0)
            {
                while (ListaIzq.Items.Count > 0)
                {
                    ListaIzq.SelectedIndex = ListaIzq.Items.Count - 1;
                    ListaDer.Items.Add(ListaIzq.SelectedItem);
                    ListaIzq.Items.RemoveAt(ListaIzq.SelectedIndex);
                }
                itemsIzq();
                itemsDer();
            }
            else
            {
                MessageBox.Show("No hay items que pasar... ","Aviso!");
            }
        
        }
        private void PasarTodoIzquierda()
        {
            
            if (ListaDer.Items.Count > 0)
            {
                while (ListaDer.Items.Count > 0)
                {
                    ListaDer.SelectedIndex = ListaDer.Items.Count - 1;
                    ListaIzq.Items.Add(ListaDer.SelectedItem);
                    ListaDer.Items.RemoveAt(ListaDer.SelectedIndex);
                }
                itemsIzq();
                itemsDer();

            }
            else
            {
                MessageBox.Show("No hay items que pasar... ", "Aviso!");
            }
        }

        private void DerUno_Click(object sender, EventArgs e)
        {
            if (ListaIzq.SelectedIndex >-1)
            {
                ListaDer.Items.Add(ListaIzq.SelectedItem);
                ListaIzq.Items.RemoveAt(ListaIzq.SelectedIndex);
                itemsIzq();
                itemsDer();
            }
            else
            {
                MessageBox.Show("Seleccione un Items de la lista1 a pasar a la lista2", "Aviso!");
            }
        }

        private void IzqUno_Click(object sender, EventArgs e)
        {

            if (ListaDer.SelectedIndex > -1)
            {
                ListaIzq.Items.Add(ListaDer.SelectedItem);
                ListaDer.Items.RemoveAt(ListaDer.SelectedIndex);
                itemsIzq();
                itemsDer();
            }
            else
            {
                MessageBox.Show("Seleccione un Items de la lista1 a pasar a la lista2", "Aviso!");
            }

        }


        private void btonOrdenar_Click(object sender, EventArgs e)
        {
            if (ListaDer.Items.Count > 0)
            {
                ListaDer.Sorted = true;
            }
            else
            {
                MessageBox.Show("No hay items para ordenar Lista2","Aviso!");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void btonOrdenar0_Click(object sender, EventArgs e)
        {
            if (ListaIzq.Items.Count > 0)
            {
                ListaIzq.Sorted = true;
            }
            else
            {
                MessageBox.Show("No hay items para ordenar Lista2", "Aviso!");
            }
        }
        private void BotonBorar_Click(object sender, EventArgs e)
        {
            if (ListaIzq.SelectedIndex != -1)
            {
                DialogResult opcion = MessageBox.Show("Esta Seguro de Eliminar a:\n" + ListaIzq.SelectedItem.ToString(), "Aviso!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    ListaIzq.Items.RemoveAt(ListaIzq.SelectedIndex);
                    itemsIzq();
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un Elemento a Eliminar","Aviso!");
            }
        }


        
       



        }
    


    }
  

 



