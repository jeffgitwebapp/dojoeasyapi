﻿using DR.Dominio.Entidades.ObjetoValor;
using System;

namespace DR.Dominio.Entidades.Entidades
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Endereco Endereco { get; private set; }
        public int Idade { get; private set; }
        public decimal Saldo { get; private set; }
    }
}