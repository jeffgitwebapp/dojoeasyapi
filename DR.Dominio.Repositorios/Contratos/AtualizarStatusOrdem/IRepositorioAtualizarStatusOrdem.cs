using DR.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.Repositorios.Contratos.AtualizarStatusOrdem
{
    public interface IRepositorioAtualizarStatusOrdem : IRepositorio
    {
        void AtualizarStatus(OrdemCompra ordem);
    }
}
