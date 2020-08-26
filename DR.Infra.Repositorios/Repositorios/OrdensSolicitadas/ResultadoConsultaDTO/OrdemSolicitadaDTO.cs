using AutoMapper;
using DR.Dominio.Entidades.Entidades;
using DR.Dominio.Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Infra.Repositorios.Repositorios.OrdensSolicitadas.ResultadoConsultaDTO
{
    class OrdemSolicitadaDTO
    {
        public Guid Id { get; set; }
        public DateTime DataOperacao { get; set; }
        public Guid ProdutoID { get; set; }
        public Guid ClienteID { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public decimal ValorOperacao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public OrdemCompraStatus Status { get; set; }


        public OrdemCompra MapearOrdemDominio()
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<OrdemSolicitadaDTO, OrdemCompra>()
            .ForMember(dest => dest.Id, m => m.MapFrom(origem => origem.Id))
            .ForMember(dest => dest.DataOperacao, m => m.MapFrom(origem => origem.DataOperacao))
            .ForMember(dest => dest.PrecoUnitario, m => m.MapFrom(origem => origem.PrecoUnitario))
            .ForMember(dest => dest.QuantidadeSolicitada, m => m.MapFrom(origem => origem.QuantidadeSolicitada))
            .ForMember(dest => dest.Status, m => m.MapFrom(origem => origem.Status))
            .ForMember(dest => dest.ValorOperacao, m => m.MapFrom(origem => origem.ValorOperacao))
            .ForMember(dest => dest.Produto, m => m.MapFrom(origem => new Produto(origem.ProdutoID)))
            .ForMember(dest => dest.Cliente, m => m.MapFrom(origem => new Cliente(origem.ClienteID))));

            var mapper = new Mapper(config);

            var ordem = mapper.Map<OrdemCompra>(this);

            return ordem;
        }
    }
}
