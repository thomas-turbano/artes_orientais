﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maes_solteiras_athur
{
    public class Usuario
    {

        private int _id;
        private string _nome;
        private string _email;
        private string _telefone;
        private string _senha;
        private string _cep;
        private string _rua;
        private string _Bairro;
        private string _Numero_casa;


        public Usuario(int id,
                string nome,
                string email,
                string telefone,
                string cep,
            string senha)
        {
            Id = id;
            _nome = nome;
            _email = email;
            _telefone = telefone;
            _cep = cep;
            _senha = senha;
            
        }
        public Usuario(string nome, string email, string telefone, string cep,string senha)
        {
            Id = Id;
            _nome = nome;
            _email = email;
            _telefone = telefone;
            _cep = cep;
            _senha = senha;
            
        }
        public Usuario(string Rua, string Bairro,string Numero )
        {
           
            _rua = Rua;
            _Bairro = Bairro;
            _Numero_casa = Numero;

        }

        public int Id
        {
            set { _id = value; }
            get { return _id; }

        }
        public string Nome
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO Nome");

                _nome = value;
            }
            get { return _nome; }

        }
        public string Email
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO Email");

                _email = value;
            }
            get { return _email; }

        }
        public string telefone
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO Email agr");

                _telefone = value;
            }
            get { return _telefone; }

        }
        public string cep
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO Email agr");

                _cep = value;
            }
            get { return _cep; }

        }
        public string senha
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO Email agr");

                _senha = value;
            }
            get { return _senha; }

        }
        public string rua
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO Email agr");

                _rua = value;
            }
            get { return _rua; }

        }
        public string Bairro
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO Email agr");

                _Bairro = value;
            }
            get { return _Bairro; }

        }
        public string Numero
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO Email agr");

                _Numero_casa = value;
            }
            get { return _Numero_casa; }

        }


    }
}
