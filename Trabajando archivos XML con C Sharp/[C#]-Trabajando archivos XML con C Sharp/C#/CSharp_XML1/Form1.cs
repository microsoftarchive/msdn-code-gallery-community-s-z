using System;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.Linq;

namespace CSharp_XML1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region Crear XML

        private void bt_crear_XML_Click(object sender, EventArgs e)
        {
            crear_XML();
        }

        private void crear_XML()
        {
            XDocument miXML = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Empleados",

                new XElement("Empleado",
                new XAttribute("Id_Empleado", "321654"),
                new XElement("Nombre", "Miguel Suarez"),
                new XElement("Edad", "30")),

                new XElement("Empleado",
                new XAttribute("Id_Empleado", "123456"),
                new XElement("Nombre", "Maria Martinez"),
                new XElement("Edad", "27")),

                new XElement("Empleado",
                new XAttribute("Id_Empleado", "987654"),
                new XElement("Nombre", "Juan Gonzales"),
                new XElement("Edad", "25"))
                ));
            miXML.Save(@"C:\Prueba\MiDoc.xml");
            MessageBox.Show("Se ha creado un XML");
        }
        #endregion

        #region Buscar en XML
        private void bt_buscar_Click(object sender, EventArgs e)
        {
            buscarEnXML(txt_idEmpleado.Text);
        }

        private void buscarEnXML(string idempleado)
        {
            XDocument miXML = XDocument.Load(@"C:\Prueba\MiDoc.xml");


            var nombreusu = from nombre in miXML.Elements("Empleados").Elements("Empleado")
                            where nombre.Attribute("Id_Empleado").Value == idempleado
                            select nombre.Element("Nombre").Value;

            foreach (string minom in nombreusu)
            {
                MessageBox.Show(minom);
            }
        }
        #endregion

        #region Agregar Nodo
        private void bt_agregar_Click(object sender, EventArgs e)
        {
            addNode(txt_agr_id.Text, txt_agr_nombre.Text, txt_agr_Edad.Text);
        }

        private void addNode(string idEmpleado, string nombre, string edad)
        {
            XDocument miXML = XDocument.Load(@"C:\Prueba\MiDoc.xml");
            miXML.Root.Add(                            
                new XElement("Empleado",
                    new XAttribute("Id_Empleado", idEmpleado),
                    new XElement("Nombre", nombre),
                    new XElement("Edad", edad))
                    );
            miXML.Save(@"C:\Prueba\MiDoc.xml");
        }
        #endregion

        #region Eliminar Nodo
        private void bt_Eliminar_Click(object sender, EventArgs e)
        {
            dropNode(txt_elim_IdEmpleado.Text);
        }

        private void dropNode(string idEmpleado)
        {
            XDocument miXML = XDocument.Load(@"C:\Prueba\MiDoc.xml");            

            var consul = from persona in miXML.Elements("Empleados").Elements("Empleado")
                         where persona.Attribute("Id_Empleado").Value == idEmpleado
                         select persona;
            consul.ToList().ForEach(x => x.Remove());
            miXML.Save(@"C:\Prueba\MiDoc.xml");
        }
        #endregion
    }
}
