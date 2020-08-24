using DR.Dominio.Entidades.Entidades;
using DR.Dominio.Repositorios.Contratos.ProdutosDisponiveis;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Infra.Repositorios.Repositorios.ProdutosDisponiveis
{
    public class RepositorioObterProdutosDisponiveis : IRepositorioObterProdutosDisponiveis
    {
        public IEnumerable<Produto> Obter()
        {
            throw new NotImplementedException();
        }
    }
}
