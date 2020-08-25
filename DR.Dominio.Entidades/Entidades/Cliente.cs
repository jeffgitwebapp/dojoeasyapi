using DR.Dominio.Entidades.ObjetoValor;
using System;

namespace DR.Dominio.Entidades.Entidades
{
    public class Cliente
    {
        public Cliente()
        {

        }

        public Cliente(Guid clienteId)
        {
            this.Id = clienteId;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Endereco Endereco { get; private set; }
        public int Idade { get; private set; }
        public decimal Saldo { get; private set; }

        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
    }
}
