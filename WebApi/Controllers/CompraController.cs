using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/compra")]
    public class CompraController : ApiController
    {

        private static List<Compra> listaCompras = new List<Compra>();

    }
}
