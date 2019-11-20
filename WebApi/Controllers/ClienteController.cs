using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Sql;
using WebApi.Models;
using System.Data.SqlClient;
using WebApi.WebApiDataTableAdapters;
using System.Globalization;

namespace WebApi.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        private static List<Cliente> listaClientes = new List<Cliente>();

        public string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["gcpnAgenciaConnectionString"].ConnectionString;

        public string ConnectionStringCadastro = System.Configuration.ConfigurationManager.ConnectionStrings["gcpnAgenciaConnectionStringCadastro"].ConnectionString;

        [AcceptVerbs("POST")]
        [Route("CadastrarCliente")]
        public string CadastrarCliente(Cliente cliente)
        {
            string erro = "";
            

            try
            {


                using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection())
                {
                    connection.ConnectionString = ConnectionStringCadastro;
                    using (System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand())
                    {

                       

                        command.Connection = connection;

                        listaClientes.Clear();
                        listaClientesCarrega();
                        Cliente clientebusca = listaClientes.Where(n => n.Cpf == cliente.Cpf)
                                                            .Select(n => n)
                                                            .FirstOrDefault();

                        if (clientebusca != null)
                        {
                            //Update
                            command.CommandText = "update cliente " +
                                "set NOME = "+ "'" + cliente.Nome + "'," +
                                " CEP = "+ "'" + cliente.Cep + "'," +
                                " ENDERECO = "+ "'" + cliente.Endereco + "'," +
                                " NUMERO = "+ "'" + cliente.Numero + "'," +
                                " BAIRRO = "+ "'" + cliente.Bairro + "'," +
                                " CIDADE = "+ "'" + cliente.Cidade + "'," +
                                " ESTADO = "+ "'" + cliente.Estado + "'" +
                                " FROM cliente where cpf = "
                                + "'" + cliente.Cpf + "'";
                                
                                
                                
                        }
                        else
                        { 
                            //Insert
                            command.CommandText = "INSERT INTO cliente (NOME,CPF,CEP,ENDERECO,NUMERO,BAIRRO,CIDADE,ESTADO) VALUES ("
                            + "'" + cliente.Nome + "',"
                            + "'" + cliente.Cpf + "',"
                            + "'" + cliente.Cep + "',"
                            + "'" + cliente.Endereco + "',"
                            + "'" + cliente.Numero + "',"
                            + "'" + cliente.Bairro + "',"
                            + "'" + cliente.Cidade + "',"
                            + "'" + cliente.Estado + "'"


                         + ") ";
                        }



                        
                        


                        erro = command.CommandText;

                        connection.Open();
                        command.ExecuteNonQuery();

                        return "Cliente cadastrado com sucesso!";
                    }
                }



            }
            catch (Exception ex)
            {
                return erro + "" + ex.Message;
            }




        }



        [AcceptVerbs("GET")]
        [Route("ConsultarClientes")]
        public List<Cliente> ConsultarClientes()
        {



            listaClientes.Clear();
            listaClientesCarrega();

            //ESTA RETORNANDO JSON 
            return listaClientes;
        }


        public void listaClientesCarrega()
        {
            try
            {


                DataTable dt = new CLIENTETableAdapter().getData();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        

                        Cliente cliente = new Cliente(
                            item["CPF"].ToString(),
                            item["NOME"].ToString(),
                            
                            item["CEP"].ToString(),
                            item["ENDERECO"].ToString(),
                            item["NUMERO"].ToString(),
                            item["BAIRRO"].ToString(),
                            item["CIDADE"].ToString(),
                            item["ESTADO"].ToString()

                            );
                        listaClientes.Add(cliente);
                    }

                }
            }
            catch (Exception ex)
            {


            }

        }

        [AcceptVerbs("GET")]
        [Route("ConsultarClientePorCPF/{cpf}")]
        public Cliente ConsultarClientePorCodigo(string cpf)
        {
            listaClientes.Clear();
            listaClientesCarrega();
            Cliente cliente = listaClientes.Where(n => n.Cpf == cpf)
                                                .Select(n => n)
                                                .FirstOrDefault();

            return cliente;
        }

        [AcceptVerbs("GET")]
        [Route("ExcluirClientePorCPF/{cpf}")]
        public string ExcluirClientePorCpf(string cpf)
        {

            string erro = "";


            try
            {


                using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection())
                {
                    connection.ConnectionString = ConnectionStringCadastro;
                    using (System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand())
                    {



                        command.Connection = connection;
                        command.CommandText = "delete from cliente where cpf = '" + cpf + "'";
                            


                        erro = command.CommandText;

                        connection.Open();
                        command.ExecuteNonQuery();
                        listaClientes.Clear();
                        listaClientesCarrega();

                        return "Cliente excluído com sucesso!";
                    }
                }



            }
            catch (Exception ex)
            {
                listaClientes.Clear();
                listaClientesCarrega();

                return erro + "" + ex.Message;
            }

            
            
        }


    }
}
