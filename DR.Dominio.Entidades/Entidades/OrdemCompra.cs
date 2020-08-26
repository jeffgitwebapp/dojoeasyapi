using DR.Dominio.Entidades.Enums;
using System;
using System.Collections.Generic;

namespace DR.Dominio.Entidades.Entidades
{
    public class OrdemCompra
    {
        public Guid Id { get; private set; }
        public DateTime DataOperacao { get; private set; }
        public Produto Produto { get; private set; }
        public Cliente Cliente { get; private set; }
        public int QuantidadeSolicitada { get; private set; }
        public decimal ValorOperacao { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public OrdemCompraStatus Status { get; private set; }

        public void AtribuirProduto(Produto produto)
        {
            Produto = produto;
            PrecoUnitario = Produto.PrecoUnitario;
            ValorOperacao = Produto.PrecoUnitario * QuantidadeSolicitada;
        }

        public void AtribuirCliente(Cliente cliente)
        {
            Cliente = cliente;
        }

        public static OrdemCompra IniciarOrdem(Guid clienteId, Guid produtoId, int quantidadeSolicitada)
        {
            return new OrdemCompra()
            {
                Id = Guid.NewGuid(),
                DataOperacao = DateTime.Now,
                Status = OrdemCompraStatus.Solicitado,
                Produto = new Produto(produtoId),
                Cliente = new Cliente(clienteId),
                QuantidadeSolicitada = quantidadeSolicitada
            };
        }

        public void CancelarOrdem()
        {
            if (Status != OrdemCompraStatus.Fechado)
            {
                Status = OrdemCompraStatus.Cancelado;
            }
        }

        public void Fechar()
        {
            if (Status != OrdemCompraStatus.Cancelado)
            {
                Status = OrdemCompraStatus.Fechado;
            }
        }
    }
}
