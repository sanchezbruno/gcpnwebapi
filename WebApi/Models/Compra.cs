using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Compra
    {


        private Int32 id_compra;
        private string cpf;
        private string nome;
        private string email;
        private string cep;
        private string endereco;
        private string numero;
        private string bairro;
        private string cidade;
        private string estado;


        private bool passagem;
        private string origem_passagem;
        private string destino_passagem;
        private string data_ida_passagem;
        private string data_volta_passagem;
        private Int32 qtd_passageiros_passagem;
        private decimal total_passagem;

        private bool hotel;
        private string cidade_hotel;
        private string data_entrada_hotel;
        private string data_saida_hotel;
        private Int32 qtd_hospedes_hotel;
        private decimal total_hotel;

        private bool cruzeiro;
        private string origem_cruzeiro;
        private string destino_cruzeiro;
        private string data_inicio_cruzeiro;
        private string data_fim_cruzeiro;
        private Int32 qtd_passageiros_cruzeiro;
        private decimal total_cruzeiro;

        private bool seguro;
        private string data_inicio_seguro;
        private string data_fim_seguro;
        private decimal total_seguro;

        private decimal total;
        private bool pago;
        private string msg;





        public Compra()
        {
        }

        public Compra(
            Int32 id_compra, string cpf, string nome, string email,
            string cep, string endereco, string numero, string bairro, string cidade, string estado,
            
            bool passagem,
            string origem_passagem,
            string destino_passagem,
            string data_ida_passagem,
            string data_volta_passagem,
            Int32 qtd_passageiros_passagem,
            decimal total_passagem,
            
            bool hotel,
            string cidade_hotel,
            string data_entrada_hotel,
            string data_saida_hotel,
            Int32 qtd_hospedes_hotel,
            decimal total_hotel,
            
            bool cruzeiro,
            string origem_cruzeiro,
            string destino_cruzeiro,
            string data_inicio_cruzeiro,
            string data_fim_cruzeiro,
            Int32  qtd_passageiros_cruzeiro,
            decimal total_cruzeiro,
            
            bool seguro,
            string data_inicio_seguro,
            string data_fim_seguro,
            decimal total_seguro,

            decimal total,
            bool pago,
            string msg
            
            )
        {

            this.Id_compra = id_compra;
            this.Cpf = cpf;
            this.Nome = nome;
            this.Email = email;
            this.Cep = cep;
            this.Endereco = endereco;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;

            this.passagem = passagem;
            this.Origem_passagem = origem_passagem;
            this.Destino_passagem = destino_passagem;
            this.Data_ida_passagem = data_ida_passagem;
            this.Data_volta_passagem = data_volta_passagem;
            this.Qtd_passageiros_passagem = qtd_passageiros_passagem;
            this.Total_passagem = total_passagem;

            this.Hotel = hotel;
            this.Cidade_hotel = cidade_hotel;
            this.Data_entrada_hotel = data_entrada_hotel;
            this.Data_saida_hotel = data_saida_hotel;
            this.Qtd_hospedes_hotel = qtd_hospedes_hotel;
            this.Total_hotel = total_hotel;

            this.Cruzeiro = cruzeiro;
            this.Origem_cruzeiro = origem_cruzeiro;
            this.Destino_cruzeiro = destino_cruzeiro;
            this.Data_inicio_cruzeiro = data_inicio_cruzeiro;
            this.Data_fim_cruzeiro = data_fim_cruzeiro;
            this.Qtd_passageiros_cruzeiro = qtd_passageiros_cruzeiro;
            this.Total_cruzeiro = total_cruzeiro;

            this.Seguro = seguro;
            this.Data_inicio_seguro = data_inicio_seguro ;
            this.Data_fim_seguro = data_fim_seguro;
            this.Total_seguro = total_seguro;
        
            this.Total = total;
            this.Pago = pago;
            this.Msg = msg;
            
        }

        public Int32 Id_compra
        {
            get
            {
                return id_compra;
            }

            set
            {
                id_compra = value;
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

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Cep
        {
            get
            {
                return cep;
            }

            set
            {
                cep = value;
            }
        }

        public string Endereco
        {
            get
            {
                return endereco;
            }

            set
            {
                endereco = value;
            }
        }

        public string Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public string Bairro
        {
            get
            {
                return bairro;
            }

            set
            {
                bairro = value;
            }
        }

        public string Cidade
        {
            get
            {
                return cidade;
            }

            set
            {
                cidade = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }



        public bool Passagem
        {
            get
            {
                return passagem;
            }

            set
            {
                passagem = value;
            }
        }

        public string Origem_passagem
        {
            get
            {
                return origem_passagem;
            }

            set
            {
                origem_passagem = value;
            }
        }

        public string Destino_passagem
        {
            get
            {
                return destino_passagem;
            }

            set
            {
                destino_passagem = value;
            }
        }

        public string Data_ida_passagem
        {
            get
            {
                return data_ida_passagem;
            }

            set
            {
                data_ida_passagem = value;
            }
        }

        public string Data_volta_passagem
        {
            get
            {
                return data_volta_passagem;
            }

            set
            {
                data_volta_passagem = value;
            }
        }

        public Int32 Qtd_passageiros_passagem
        {
            get
            {
                return qtd_passageiros_passagem;
            }

            set
            {
                qtd_passageiros_passagem = value;
            }
        }

        public bool Hotel
        {
            get
            {
                return hotel;
            }

            set
            {
                hotel = value;
            }
        }


        public string Cidade_hotel
        {
            get
            {
                return cidade_hotel;
            }

            set
            {
                cidade_hotel = value;
            }
        }

        public string Data_entrada_hotel
        {
            get
            {
                return data_entrada_hotel;
            }

            set
            {
                data_entrada_hotel = value;
            }
        }

        public string Data_saida_hotel
        {
            get
            {
                return data_saida_hotel;
            }

            set
            {
                data_saida_hotel = value;
            }
        }

        public Int32 Qtd_hospedes_hotel
        {
            get
            {
                return qtd_hospedes_hotel;
            }

            set
            {
                qtd_hospedes_hotel = value;
            }
        }

        public bool Cruzeiro
        {
            get
            {
                return cruzeiro;
            }

            set
            {
                cruzeiro = value;
            }
        }

        public string Origem_cruzeiro
        {
            get
            {
                return origem_cruzeiro;
            }

            set
            {
                origem_cruzeiro = value;
            }
        }

        public string Destino_cruzeiro
        {
            get
            {
                return destino_cruzeiro;
            }

            set
            {
                destino_cruzeiro = value;
            }
        }

        public string Data_inicio_cruzeiro
        {
            get
            {
                return data_inicio_cruzeiro;
            }

            set
            {
                data_inicio_cruzeiro = value;
            }
        }


        public string Data_fim_cruzeiro
        {
            get
            {
                return data_fim_cruzeiro;
            }

            set
            {
                data_fim_cruzeiro = value;
            }
        }

        public Int32 Qtd_passageiros_cruzeiro
        {
            get
            {
                return qtd_passageiros_cruzeiro;
            }

            set
            {
                qtd_passageiros_cruzeiro = value;
            }
        }

        public bool Seguro
        {
            get
            {
                return seguro;
            }

            set
            {
                seguro = value;
            }
        }

        public string Data_inicio_seguro
        {
            get
            {
                return data_inicio_seguro;
            }

            set
            {
                data_inicio_seguro = value;
            }
        }

        public string Data_fim_seguro
        {
            get
            {
                return data_fim_seguro;
            }

            set
            {
                data_fim_seguro = value;
            }
        }


        public decimal Total_passagem 
        {
            get
            {
                return total_passagem; 
            }

            set
            {
                total_passagem = value;
            }
        }

        public decimal Total_hotel
        {
            get
            {
                return total_hotel;
            }

            set
            {
                total_hotel = value;
            }
        }

        public decimal Total_cruzeiro
        {
            get
            {
                return total_cruzeiro;
            }

            set
            {
                total_cruzeiro = value;
            }
        }

        public decimal Total_seguro
        {
            get
            {
                return total_seguro;
            }

            set
            {
                total_seguro = value;
            }
        }

        public decimal Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public bool Pago
        {
            get
            {
                return pago;
            }

            set
            {
                pago = value;
            }
        }


        public string Msg
        {
            get
            {
                return msg;
            }

            set
            {
                msg = value;
            }
        }

    }
}