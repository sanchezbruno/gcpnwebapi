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

using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using MailKit.Search;
using MimeKit;
using System.IO;
using MailKit.Net.Smtp;

namespace WebApi.Controllers
{
    [RoutePrefix("api/compra")]
    public class CompraController : ApiController
    {

        private static List<Compra> listaCompras = new List<Compra>();

        public string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["gcpnAgenciaConnectionString"].ConnectionString;

        public string ConnectionStringCadastro = System.Configuration.ConfigurationManager.ConnectionStrings["gcpnAgenciaConnectionStringCadastro"].ConnectionString;



        [AcceptVerbs("GET")]
        [Route("ConsultarCompras")]
        public List<Compra> ConsultarCompras()
        {



            listaCompras.Clear();
            listaComprasCarrega();

            //ESTA RETORNANDO JSON 
            return listaCompras;
        }


        public void listaComprasCarrega()
        {
            try
            {


                DataTable dt = new COMPRATableAdapter().getData();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {


                        Compra compra = new Compra(

                            Convert.ToInt32(item["ID_COMPRA"].ToString()),
                            item["CPF"].ToString(),
                            item["NOME"].ToString(),
                            item["EMAIL"].ToString(),
                            item["CEP"].ToString(),
                            item["ENDERECO"].ToString(),
                            item["NUMERO"].ToString(),
                            item["BAIRRO"].ToString(),
                            item["CIDADE"].ToString(),
                            item["ESTADO"].ToString(),

                            
                            Convert.ToBoolean(item["PASSAGEM"].ToString()),   
                            item["ORIGEM_PASSAGEM"].ToString(),
                            item["DESTINO_PASSAGEM"].ToString(),
                            item["INICIO_PASSAGEM"].ToString(),
                            item["FIM_PASSAGEM"].ToString(),
                            Convert.ToInt32(item["QTD_PASSAGEM"].ToString()),
                            Convert.ToDecimal(item["VALOR_PASSAGEM"].ToString()),

                            Convert.ToBoolean(item["HOTEL"].ToString()),    
                            item["CIDADE_HOTEL"].ToString(),    
                            item["INICIO_HOTEL"].ToString(),    
                            item["FIM_HOTEL"].ToString(),    
                            Convert.ToInt32(item["QTD_HOTEL"].ToString()),
                            Convert.ToDecimal(item["VALOR_HOTEL"].ToString()),    

                            Convert.ToBoolean(item["CRUZEIRO"].ToString()),    
                            item["ORIGEM_CRUZEIRO"].ToString(),    
                            item["DESTINO_CRUZEIRO"].ToString(),    
                            item["INICIO_CRUZEIRO"].ToString(),    
                            item["FIM_CRUZEIRO"].ToString(),    
                            Convert.ToInt32(item["QTD_CRUZEIRO"].ToString()),
                            Convert.ToDecimal(item["VALOR_CRUZEIRO"].ToString()), 

                            Convert.ToBoolean(item["SEGURO"].ToString()), 
                            item["INICIO_SEGURO"].ToString(),  
                            item["FIM_SEGURO"].ToString(),  
                            Convert.ToDecimal(item["VALOR_SEGURO"].ToString()), 

                            Convert.ToDecimal(item["VALOR_TOTAL"].ToString()), 
                            Convert.ToBoolean(item["PAGO"].ToString()),
                            ""

                            );
                        listaCompras.Add(compra);
                    }

                }
            }
            catch (Exception ex)
            {


            }

        }

        [AcceptVerbs("GET")]
        [Route("ConsultarCompraPorID/{id}")]
        public Compra ConsultarClientePorCodigo(Int32 id)
        {
            listaCompras.Clear();
            listaComprasCarrega();
            Compra compra = listaCompras.Where(n => n.Id_compra == id)
                                                .Select(n => n)
                                                .FirstOrDefault();

            if (compra == null)
            {
                compra = new Compra(
                            0,                            
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",

                            false,
                            "",
                            "",
                            "",
                            "",
                            0,
                            0,

                            false,
                            "",
                            "",
                            "",
                            0,
                            0,

                            false,
                            "",
                            "",
                            "",
                            "",
                            0,
                            0,

                            false,
                            "",
                            "",
                            0,

                            0,
                            false,
                            
                            "COMPRA_NAO_ENCONTRADA"
                            );
            }

            return compra;
        }


        [AcceptVerbs("POST")]
        [Route("CadastrarCompra")]
        public Compra CadastrarCompra(Compra compra)
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



                       
                            //Insert



                            command.CommandText = "INSERT INTO compra ( "+
                            "CPF,NOME,EMAIL,CEP,ENDERECO,NUMERO,BAIRRO,CIDADE,ESTADO, " +
                            "PASSAGEM,QTD_PASSAGEM,ORIGEM_PASSAGEM,DESTINO_PASSAGEM,INICIO_PASSAGEM,FIM_PASSAGEM,VALOR_PASSAGEM, " +
                            "HOTEL, QTD_HOTEL, CIDADE_HOTEL,INICIO_HOTEL ,FIM_HOTEL,VALOR_HOTEL, "+
                            "CRUZEIRO, QTD_CRUZEIRO,ORIGEM_CRUZEIRO,DESTINO_CRUZEIRO,INICIO_CRUZEIRO,FIM_CRUZEIRO,VALOR_CRUZEIRO, "+
                            "SEGURO, INICIO_SEGURO, FIM_SEGURO, VALOR_SEGURO, VALOR_TOTAL, PAGO ) " +
                            " values ( " 
                            + "'" + compra.Cpf+ "',"
                            + "'" + compra.Nome+ "',"
                            + "'" + compra.Email+ "',"
                            + "'" + compra.Cep+ "',"
                            + "'" + compra.Endereco+ "',"
                            + "'" + compra.Numero+ "',"
                            + "'" + compra.Bairro+ "',"
                            + "'" + compra.Cidade+ "',"
                            + "'" + compra.Estado+ "',"
                        
                            + "'" + compra.Passagem + "',"
                            + "'" + compra.Qtd_passageiros_passagem + "',"
                            + "'" + compra.Origem_passagem + "',"
                            + "'" + compra.Destino_passagem + "',"
                            + "'" + compra.Data_ida_passagem + "',"
                            + "'" + compra.Data_volta_passagem + "',"
                            + "'" + compra.Total_passagem + "',"
                        
                            + "'" + compra.Hotel + "',"
                            + "'" + compra.Qtd_hospedes_hotel + "',"
                            + "'" + compra.Cidade_hotel + "',"
                            + "'" + compra.Data_entrada_hotel + "',"
                            + "'" + compra.Data_saida_hotel + "',"
                            + "'" + compra.Total_hotel + "',"

                            + "'" + compra.Cruzeiro + "',"
                            + "'" + compra.Qtd_passageiros_cruzeiro + "',"
                            + "'" + compra.Origem_cruzeiro + "',"
                            + "'" + compra.Destino_cruzeiro + "',"
                            + "'" + compra.Data_inicio_cruzeiro + "',"
                            + "'" + compra.Data_fim_cruzeiro + "',"
                            + "'" + compra.Total_cruzeiro + "',"

                            + "'" + compra.Seguro + "',"
                            + "'" + compra.Data_inicio_seguro + "',"
                            + "'" + compra.Data_fim_seguro + "',"
                            + "'" + compra.Total_seguro + "',"

                            + "'" + compra.Total + "',"
                            + "'" + compra.Pago + "'"

                            + " ) ";
                        
                        
                        

                        erro = command.CommandText;

                        connection.Open();
                        command.ExecuteNonQuery();

                        //TODO: Devolver a compra com o ID
                        try
                        {


                            DataTable dt = new SCOPE_IDTableAdapter().getData();

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow item in dt.Rows)
                                {

                                    compra.Id_compra = Convert.ToInt32(item["MAX_ID"].ToString());

                                }
                            }
                        }
                        catch (Exception ex)
                        {


                        }

                        return compra;
                    }
                }



            }
            catch (Exception ex)
            {

                
                compra = new Compra(
                                            0,
                                            "",
                                            "",
                                            "",
                                            "",
                                            "",
                                            "",
                                            "",
                                            "",
                                            "",

                                            false,
                                            "",
                                            "",
                                            "",
                                            "",
                                            0,
                                            0,

                                            false,
                                            "",
                                            "",
                                            "",
                                            0,
                                            0,

                                            false,
                                            "",
                                            "",
                                            "",
                                            "",
                                            0,
                                            0,

                                            false,
                                            "",
                                            "",
                                            0,

                                            0,
                                            false,

                                            erro + " " + ex.Message
                                            );

                return compra;
            }




        }


        [AcceptVerbs("GET")]
        [Route("EnviarMailCompra/{id}")]
        public Compra EnviarMailCompra(Int32 id)
        {

            string excecao = "";


            listaCompras.Clear();
            listaComprasCarrega();
            Compra compraMail = listaCompras.Where(n => n.Id_compra == id)
                                                .Select(n => n)
                                                .FirstOrDefault();

           
            try
            {
                // STEP 1: Navigate to this page https://www.google.com/settings/security/lesssecureapps & set to "Turn On"

                using (var client = new SmtpClient ()) 
                {

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;


                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.Auto);

                client.Authenticate("gcpn.bpmn@gmail.com", "1q2w3e4r@");

                var message = new MimeMessage();

                message.From.Add(new MailboxAddress("Agência de Viagens BPMN", "gcpn.bpmn@gmail.com"));
                message.To.Add(new MailboxAddress(compraMail.Nome, compraMail.Email));
                message.Subject = "Recibo de sua compra de pacote de viagens - " + Convert.ToString(compraMail.Id_compra) ;
                message.Body = new TextPart("plain") { Text = @"Olá! "+
                    Environment.NewLine +
                    Environment.NewLine +
                    "Este é o recibo de sua compra de pacote de viagens! " +
                    Environment.NewLine +
                    Environment.NewLine +
                    compraMail.Nome + " - " + compraMail.Cpf +
                    Environment.NewLine +
                    "Endereço: CEP " + compraMail.Cep + " - " + compraMail.Endereco + ", " + compraMail.Numero + 
                    Environment.NewLine +
                    compraMail.Bairro + " - " + compraMail.Cidade + " - " + compraMail.Estado +
                    Environment.NewLine +
                    Environment.NewLine +
                    "Passagem: " + compraMail.Passagem + " Qtd. Passageiros: " + compraMail.Qtd_passageiros_passagem + 
                    Environment.NewLine +
                    "Origem: " + compraMail.Origem_passagem + " - Destino: " + compraMail.Destino_passagem +
                    Environment.NewLine +                    
                    "Ida: " + compraMail.Data_ida_passagem + " - Volta: " + compraMail.Data_volta_passagem +
                    Environment.NewLine +
                    "Valor: " + compraMail.Total_passagem +

                    Environment.NewLine +
                    Environment.NewLine +

                    "Hotel: " + compraMail.Hotel + " Qtd. Hóspedes: " + compraMail.Qtd_hospedes_hotel +
                    Environment.NewLine +
                    "Cidade: " + compraMail.Cidade_hotel + 
                    Environment.NewLine +
                    "Entrada: " + compraMail.Data_entrada_hotel + " - Saída: " + compraMail.Data_saida_hotel +
                    Environment.NewLine +
                    "Valor: " + compraMail.Total_hotel +

                    Environment.NewLine + 
                    Environment.NewLine +

                    "Cruzeiro: " + compraMail.Cruzeiro + " Qtd. Passageiros: " + compraMail.Qtd_passageiros_cruzeiro +
                    Environment.NewLine +
                    "Origem: " + compraMail.Origem_cruzeiro + " - Destino: " + compraMail.Destino_cruzeiro +
                    Environment.NewLine +
                    "Ida: " + compraMail.Data_inicio_cruzeiro + " - Volta: " + compraMail.Data_fim_cruzeiro +
                    Environment.NewLine +
                    "Valor: " + compraMail.Total_cruzeiro +

                    Environment.NewLine + 
                    Environment.NewLine +
                    "Seguro " + compraMail.Seguro + 
                    Environment.NewLine +
                    "De: " + compraMail.Data_inicio_seguro + " Até: " + compraMail.Data_fim_seguro +
                    Environment.NewLine+
                    "Valor: " + compraMail.Total_seguro +

                    Environment.NewLine + 
                    Environment.NewLine +
                    "Total: " + compraMail.Total +

                    Environment.NewLine + 
                    Environment.NewLine +

                    "Obrigado por comprar com a Agência de Viagens BPMN "
                };

                client.Send(message);
                    

                }
                                
                excecao = "E-Mail enviado!";
            }
            catch (Exception ex)
            {
                excecao = ex.ToString();
            }

            Compra compra = new Compra(
                                           0,
                                           "",
                                           "",
                                           "",
                                           "",
                                           "",
                                           "",
                                           "",
                                           "",
                                           "",

                                           false,
                                           "",
                                           "",
                                           "",
                                           "",
                                           0,
                                           0,

                                           false,
                                           "",
                                           "",
                                           "",
                                           0,
                                           0,

                                           false,
                                           "",
                                           "",
                                           "",
                                           "",
                                           0,
                                           0,

                                           false,
                                           "",
                                           "",
                                           0,

                                           0,
                                           false,

                                           excecao
                                           );

            //ESTA RETORNANDO JSON 
            return compra;
        }


    }
}
