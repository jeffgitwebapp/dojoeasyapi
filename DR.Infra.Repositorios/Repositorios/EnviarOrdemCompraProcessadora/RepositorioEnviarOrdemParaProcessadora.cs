using DR.Dominio.Entidades.Entidades;
using DR.Dominio.Repositorios.Contratos.EnviarOrdemCompraProcessadora;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Infra.Repositorios.Repositorios.EnviarOrdemCompraProcessadora
{
    public class RepositorioEnviarOrdemParaProcessadora : IRepositorioEnviarOrdemParaProcessadora
    {
        public void Enviar(OrdemCompra ordem)
        {
            ordem.Status.ToString();
        }
    }
}
