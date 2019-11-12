//Written By Somdip Dey,
//Software Engineer, Steanne Solutions Ltd., UK

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

//<summary>
//This Example shows you how to use ArrayList to store many Objects with different properties
//And then fetch the properties of each Object stored in the ArrayList 
//when required for further computational purposes.
//</summary>

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //Declarng the ArrayList in the beginning (globally)
        //so that it can be accessed by anything in the Form1 class
        public ArrayList arraylist = new ArrayList();
       
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("NOT_SET"); //set for default value in ComboBox
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           //NOT_SET is default
            if(comboBox1.SelectedItem=="NOT_SET")
            {
                groupBox1.Text = "No Object Selected";
                label9.Text = "Null";
                label10.Text = "Null";
                label11.Text = "Null";
                label12.Text = "Null";
            }

            //<summary>
            //this for loop checks every Objects saved in the ArrayList
            //and the fetches the properties of each Object from that ArrayList.
            //In order to print out the properties of the Object, which is the selected item from the ComboBox,
            // it first compares the name of the Object saved in the ArrayList and the ComboBox selected item, 
            //and if the names are same then only prints that out to the user as the output
            //</summary>
            for (int i = 0; i < arraylist.Count; i++)
            {
                Objectify Ob = (Objectify)arraylist[i];
                if(string.Compare(comboBox1.SelectedItem.ToString(), Ob.name, true)==0) {
                    groupBox1.Text = Ob.name;
                    label9.Text = Ob.name;
                    label10.Text = Ob.property1;
                    label11.Text = Ob.property2;
                    label12.Text = Ob.property3;
                }
            }
        }

        //creating a Class, of which the Object belongs to....
        //The class has 3 property's fields and a name for identification
        public class Objectify
        {
            public string name;
            public string property1;
            public string property2;
            public string property3;
        }

        //method to add the Object to the ArrayLst with its property's value,
        //which are provided by the user
        public void AddObject() {
            //to check whether 
            if (textBox1.Text == "")
            {
                MessageBox.Show("Can not create Objects with no name!");
                return;
            }
            else if ((textBox2.Text == "") && (textBox3.Text == "") && (textBox4.Text == ""))
            {
                MessageBox.Show("Can not create Objects with no properties at all");
                return;
            }

            //Creating Object of class Objectify and storing all properties of it 
            //from user input textboxes
            Objectify objectify = new Objectify();
            objectify.name = textBox1.Text;
            objectify.property1 = textBox2.Text;
            objectify.property2 = textBox3.Text;
            objectify.property3 = textBox4.Text;

            //adding the Object with its properties in the ArrayList
            arraylist.Add((object)objectify);

            //adding this Object Name to the ComboBox so that
            //it can be accessed/referred easily from the
            //dropdown list
            comboBox1.Items.Add(objectify.name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddObject();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
