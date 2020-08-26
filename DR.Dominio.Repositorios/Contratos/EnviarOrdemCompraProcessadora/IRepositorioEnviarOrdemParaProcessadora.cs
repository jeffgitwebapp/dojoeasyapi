using DR.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.Repositorios.Contratos.EnviarOrdemCompraProcessadora
{
    public interface IRepositorioEnviarOrdemParaProcessadora : IRepositorio
    {
        void Enviar(OrdemCompra ordem);
    }
}
