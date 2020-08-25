using DR.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.Repositorios.Contratos.CriarOrdemCompra
{
    public interface IRepositorioCriarOrdemCompra : IRepositorio
    {
        void CriarOrdem(OrdemCompra novaOrdemCompra);
    }
}
