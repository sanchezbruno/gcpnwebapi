﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Teste
    {

        private int codigo;
        private string nome;
        private string login;
 
        public Teste()
        {
        }

        public Teste(int codigo, string nome, string login)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Login = login;
        }
 
        public int Codigo
        {
            get
            {
                return codigo;
            }
 
            set
            {
                codigo = value;
            }
        }
 
        public string Nome
        {
            get
            {
                return nome;
            }
 
            set
            {
                nome = value;
            }
        }
 
        public string Login
        {
            get
            {
                return login;
            }
 
            set
            {
                login = value;
            }
        }

    }
}