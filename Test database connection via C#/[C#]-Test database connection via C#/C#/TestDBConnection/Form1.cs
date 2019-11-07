using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDBConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            try
            {
                //----------------PT-BR----------------//
                // Cria uma nova instância de conexão com o SQL passando como parâmetro a string de conexão,
                // com os dados digitados pelo usuário.
                //----------------EN-US----------------//
                // Create a new instance of connection with the SQL parameter and the string connection,
                // with the typed data by the user.
                using (SqlConnection connection = new SqlConnection("Data Source='" + txtServidor.Text + "';Initial Catalog='" + txtBase.Text +
                                                                    "';User ID='" + txtUsuario.Text + "';Password='" + txtSenha.Text + "'"))
                {
                    btnTeste.Enabled = false;

                    try
                    {
                        //----------------PT-BR----------------//
                        // Tenta abrir a conexão com o banco de dados.
                        //----------------EN-US----------------//
                        // Try to open the connection with the database.
                        connection.Open();

                        //----------------PT-BR----------------//
                        // Se a conexão estiver aberta, é executado o bloco abaixo. 
                        //----------------EN-US----------------//
                        // If the connection is open, the code below is executed.
                        if (connection.State == ConnectionState.Open)
                        {
                            //----------------PT-BR----------------//
                            // Fecha a conexão, pois já entrou na condição.
                            //----------------EN-US----------------//
                            // Close the connection, because it's inside this condition.
                            connection.Close();

                            MessageBox.Show("A conexão está válida!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    //----------------PT-BR----------------//
                    // Caso não for possível conectar, é exibido uma mensagem de erro do SQL.
                    // Por exemplo, pode dar erro de conexão com o usuário "X" ou o banco "A" não foi encontrado.
                    //----------------EN-US----------------//
                    // If the connection fail, it is shown a SQL error message.
                    // For example, it is possible an error because the user "X" or the database "A" it was not found.
                    catch (SqlException exSQL)
                    {
                        MessageBox.Show("Não foi possível conectar no banco de dados. Motivo: " + exSQL.Message,
                                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            //----------------PT-BR----------------//
            // Em caso de erro na criação da instância de conexão com o SQL, é executado o bloco abaixo.
            //----------------EN-US----------------//
            // In case of error in the creation of new SQL instance, the code below is executed.
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível conectar no banco de dados. Motivo: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                btnTeste.Enabled = true;
            }
            
        }
    }
}
