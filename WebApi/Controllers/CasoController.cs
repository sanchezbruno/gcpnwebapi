using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    

    [RoutePrefix("api/caso")]
    public class CasoController : ApiController
    {
        private static List<Caso> listaCasos = new List<Caso>();

        private static Caso caso = new Caso();
        private static string ID = "";
        private static string CPF = "";

        [AcceptVerbs("GET")]
        [Route("ConsultarCaso")]
        public Caso ConsultarCaso()
        {

            Caso caso = new Caso(ID, CPF);

            

            //ESTA RETORNANDO JSON 
            return caso;
        }

        [AcceptVerbs("GET")]
        [Route("SalvarCaso/{id}/{cpf}")]
        public Caso SalvarCaso(string id, string cpf)
        {

            ID = id;
            CPF = cpf;

            Caso caso = new Caso(ID, CPF);



            //ESTA RETORNANDO JSON 
            return caso;
        }


    }
}
