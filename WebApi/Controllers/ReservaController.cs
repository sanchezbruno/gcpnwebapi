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


    [RoutePrefix("api/reserva")]
    public class ReservaController : ApiController
    {

        public string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["gcpnAgenciaConnectionString"].ConnectionString;

        public string ConnectionStringCadastro = System.Configuration.ConfigurationManager.ConnectionStrings["gcpnAgenciaConnectionStringCadastro"].ConnectionString;

        private static List<Reserva> listaReservas = new List<Reserva>();



        [AcceptVerbs("POST")]
        [Route("CadastrarReserva")]
        public string CadastrarReserva(Reserva reserva)
        {
            string erro = "";
            //listaReservas.Add(reserva);

            try
            {

            
                using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection())
                {
                    connection.ConnectionString = ConnectionStringCadastro;
                    using (System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand())
                    {

                        string Data_ida_passagem = "";
                        string Data_volta_passagem = "";
                        string Data_entrada_hotel = "";
                        string Data_saida_hotel = "";
                        string Data_inicio_cruzeiro = "";
                        string Data_fim_cruzeiro = "";
                        string Data_inicio_seguro = "";
                        string Data_fim_seguro = "";

                        if (reserva.Passagem)
                        {
                            Data_ida_passagem = Convert.ToString(reserva.Data_ida_passagem);
                            Data_volta_passagem = Convert.ToString(reserva.Data_volta_passagem);
                        }

                        if (reserva.Hotel)
                        {
                            Data_entrada_hotel = Convert.ToString(reserva.Data_entrada_hotel);
                            Data_saida_hotel = Convert.ToString(reserva.Data_saida_hotel);
                        }

                        if (reserva.Cruzeiro)
                        {
                            Data_inicio_cruzeiro = Convert.ToString(reserva.Data_inicio_cruzeiro);
                            Data_fim_cruzeiro = Convert.ToString(reserva.Data_fim_cruzeiro);
                        }

                        if (reserva.Seguro)
                        {
                            Data_inicio_seguro = Convert.ToString(reserva.Data_inicio_seguro);
                            Data_fim_seguro = Convert.ToString(reserva.Data_fim_seguro);
                        }

                        command.Connection = connection;
                        command.CommandText = "INSERT INTO reserva (CPF,NOME,PASSAGEM,QTD_PASSAGEM,ORIGEM_PASSAGEM,DESTINO_PASSAGEM,INICIO_PASSAGEM,FIM_PASSAGEM,VALOR_PASSAGEM,HOTEL,QTD_HOTEL,CIDADE_HOTEL,INICIO_HOTEL,FIM_HOTEL,"
                            + "VALOR_HOTEL,CRUZEIRO,QTD_CRUZEIRO,ORIGEM_CRUZEIRO,DESTINO_CRUZEIRO,INICIO_CRUZEIRO,FIM_CRUZEIRO,VALOR_CRUZEIRO,SEGURO,INICIO_SEGURO,FIM_SEGURO,VALOR_SEGURO,VALOR_TOTAL) VALUES ("
                            +"'" + reserva.Cpf + "',"
                            +"'" + reserva.Nome + "',"
                            +"'" + reserva.Passagem + "',"
                            +"'" + reserva.Qtd_passageiros_passagem + "',"
                            +"'" + reserva.Origem_passagem + "',"
                            +"'" + reserva.Destino_passagem + "',"
                            + "convert(datetime,nullif('" + Convert.ToString(Data_ida_passagem) + "',''),103),"
                            + "convert(datetime,nullif('" + Convert.ToString(Data_volta_passagem) + "',''),103),"
                            +"'" + Convert.ToString(0) + "',"
                            +"'" + reserva.Hotel + "',"
                            +"'" + reserva.Qtd_hospedes_hotel + "',"
                            +"'" + reserva.Cidade_hotel + "',"

                            + "convert(datetime,nullif('" + Convert.ToString(Data_entrada_hotel) + "',''),103),"
                            + "convert(datetime,nullif('" + Convert.ToString(Data_saida_hotel) + "',''),103),"

                            + "'" + Convert.ToString(0) + "',"
                            +"'" + reserva.Cruzeiro + "',"
                            +"'" + reserva.Qtd_passageiros_cruzeiro + "',"
                            +"'" + reserva.Origem_cruzeiro + "',"
                            +"'" + reserva.Destino_cruzeiro + "',"

                            + "convert(datetime,nullif('" + Convert.ToString(Data_inicio_cruzeiro) + "',''),103),"
                            + "convert(datetime,nullif('" + Convert.ToString(Data_fim_cruzeiro) + "',''),103),"


                            + "'" + Convert.ToString(0) + "',"
                            +"'" + reserva.Seguro + "',"

                            + "convert(datetime,nullif('" + Convert.ToString(Data_inicio_seguro) + "',''),103),"
                            + "convert(datetime,nullif('" + Convert.ToString(Data_fim_seguro) + "',''),103),"


                            + "'" + Convert.ToString(0) + "',"
                            + "'" + Convert.ToString(0) + "'"
                            
                         +") ";


                        erro = command.CommandText;

                        connection.Open();
                        command.ExecuteNonQuery();

                        return "Reserva cadastrada com sucesso!" ;
                    }
                }

                

            }
            catch (Exception ex)
            {
                return erro + "" + ex.Message;
            }



            
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirReserva/{cpf}")]
        public string ExcluirUsuario(string cpf)
        {

            Reserva reserva = listaReservas.Where(n => n.Cpf == cpf)
                                                .Select(n => n)
                                                .First();

            listaReservas.Remove(reserva);

            return "Registro excluido com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarReservaPorCPF/{cpf}")]
        public Reserva ConsultarUsuarioPorCodigo(string cpf)
        {
            listaReservas.Clear();
            listaReservasCarrega();
            Reserva reserva = listaReservas.Where(n => n.Cpf == cpf)
                                                .Select(n => n)
                                                .FirstOrDefault();

            return reserva;
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarReservas")]
        public List<Reserva> ConsultarReservas()
        {

           // DateTime.ParseExact(DateTime.Now.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime dt = DateTime.Parse(DateTime.Now.ToString(), new CultureInfo("en-CA"));
            //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
           // DateTime dt = DateTime.Parse(DateTime.Now.ToString());


            listaReservas.Clear();
            listaReservasCarrega();

            //ESTA RETORNANDO JSON 
            return listaReservas;
        }


        public void listaReservasCarrega()
        {
            try
            {


                DataTable dt = new RESERVATableAdapter().getData();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        /*
                        DateTime? INICIO_PASSAGEM = null;
                        if (item["INICIO_PASSAGEM"].ToString() != "")
                        {
                            INICIO_PASSAGEM = Convert.ToDateTime(item["INICIO_PASSAGEM"].ToString());
                        }
                        DateTime? FIM_PASSAGEM = null;
                        if (item["FIM_PASSAGEM"].ToString() != "")
                        {
                            FIM_PASSAGEM = Convert.ToDateTime(item["FIM_PASSAGEM"].ToString());
                        }

                        DateTime? INICIO_HOTEL = null;
                        if (item["INICIO_HOTEL"].ToString() != "")
                        {
                            INICIO_HOTEL = Convert.ToDateTime(item["INICIO_HOTEL"].ToString());
                        }
                        DateTime? FIM_HOTEL = null;
                        if (item["FIM_HOTEL"].ToString() != "")
                        {
                            FIM_HOTEL = Convert.ToDateTime(item["FIM_HOTEL"].ToString());
                        }

                        DateTime? INICIO_CRUZEIRO = null;
                        if (item["INICIO_CRUZEIRO"].ToString() != "")
                        {
                            INICIO_CRUZEIRO = Convert.ToDateTime(item["INICIO_CRUZEIRO"].ToString());
                        }
                        DateTime? FIM_CRUZEIRO = null;
                        if (item["FIM_CRUZEIRO"].ToString() != "")
                        {
                            FIM_CRUZEIRO = Convert.ToDateTime(item["FIM_CRUZEIRO"].ToString());
                        }

                        DateTime? INICIO_SEGURO = null;
                        if (item["INICIO_SEGURO"].ToString() != "")
                        {
                            INICIO_SEGURO = Convert.ToDateTime(item["INICIO_SEGURO"].ToString());
                        }
                        DateTime? FIM_SEGURO = null;
                        if (item["FIM_SEGURO"].ToString() != "")
                        {
                            FIM_SEGURO = Convert.ToDateTime(item["FIM_SEGURO"].ToString());
                        }
                        */

                        Reserva reserva = new Reserva(
                           item["CPF"].ToString(),
                           item["NOME"].ToString(),
                           Convert.ToBoolean(item["passagem"].ToString()),
                           item["ORIGEM_PASSAGEM"].ToString(),
                           item["DESTINO_PASSAGEM"].ToString(),
                           item["INICIO_PASSAGEM"].ToString(),
                           item["FIM_PASSAGEM"].ToString(),//FIM_PASSAGEM,
                           Convert.ToInt32(item["QTD_PASSAGEM"].ToString()),

                           Convert.ToBoolean(item["HOTEL"].ToString()),
                           item["CIDADE_HOTEL"].ToString(),
                           item["INICIO_HOTEL"].ToString(),
                           item["FIM_HOTEL"].ToString(),
                           Convert.ToInt32(item["QTD_HOTEL"].ToString()),

                           Convert.ToBoolean(item["CRUZEIRO"].ToString()),
                           item["ORIGEM_CRUZEIRO"].ToString(),
                           item["DESTINO_CRUZEIRO"].ToString(),
                           item["INICIO_CRUZEIRO"].ToString(),
                           item["FIM_CRUZEIRO"].ToString(),
                           Convert.ToInt32(item["QTD_CRUZEIRO"].ToString()),

                           Convert.ToBoolean(item["SEGURO"].ToString()),
                           item["INICIO_SEGURO"].ToString(),
                           item["FIM_SEGURO"].ToString()

                            );
                        listaReservas.Add(reserva);
                    }

                }
            }
            catch (Exception ex)
            {
                

            }

        }

    }
}
