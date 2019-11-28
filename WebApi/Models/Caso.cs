using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Caso
    {

        private string id;
        private string cpf;


    

        public Caso()
        {
        }

        public Caso(string id, string cpf)
        {
            this.Id = id;
            this.Cpf = cpf;
            
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Cpf
        {
            get
            {
                return cpf;
            }

            set
            {
                cpf = value;
            }
        }
    }
}