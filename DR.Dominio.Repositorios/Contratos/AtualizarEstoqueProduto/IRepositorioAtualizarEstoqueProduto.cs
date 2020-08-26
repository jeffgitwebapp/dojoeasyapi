using DR.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.Repositorios.Contratos.AtualizarEstoqueProduto
{
    public interface IRepositorioAtualizarEstoqueProduto : IRepositorio
    {
        void AtualizarEstoque(Produto produto);
    }
}
