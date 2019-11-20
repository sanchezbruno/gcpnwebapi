using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Xml;
using System.Web.UI.WebControls;
using System.Net.Http.Headers;

namespace WebApi.Controllers
{

    [RoutePrefix("api/teste")]
    public class TesteController : ApiController
    {
        private static List<Teste> listaUsuarios = new List<Teste>();

        [AcceptVerbs("POST")]
        [Route("CadastrarUsuario")]
        public string CadastrarUsuario(Teste usuario)
        {

            listaUsuarios.Add(usuario);

            return "Usuário cadastrado com sucesso!";
        }

        [AcceptVerbs("PUT")]
        [Route("AlterarUsuario")]
        public string AlterarUsuario(Teste usuario)
        {

            listaUsuarios.Where(n => n.Codigo == usuario.Codigo)
                         .Select(s =>
                         {
                             s.Codigo = usuario.Codigo;
                             s.Login = usuario.Login;
                             s.Nome = usuario.Nome;

                             return s;

                         }).ToList();



            return "Usuário alterado com sucesso!";
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirUsuario/{codigo}")]
        public string ExcluirUsuario(int codigo)
        {

            Teste usuario = listaUsuarios.Where(n => n.Codigo == codigo)
                                                .Select(n => n)
                                                .First();

            listaUsuarios.Remove(usuario);

            return "Registro excluido com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarioPorCodigo/{codigo}")]
        public Teste ConsultarUsuarioPorCodigo(int codigo)
        {

            Teste usuario = listaUsuarios.Where(n => n.Codigo == codigo)
                                                .Select(n => n)
                                                .FirstOrDefault();

            return usuario;
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarios")]
        public List<Teste> ConsultarUsuarios()
        {
            //ESTA RETORNANDO JSON 
            return listaUsuarios;
        }


       
        
    }
}
