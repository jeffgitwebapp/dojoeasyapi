using AutoMapper;
using DR.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.ModeloVisaoModelo.ProdutosDisponiveis
{
    public class VisaoModeloProdutosDisponiveis
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int QuantidadeDisponivel { get; set; }

        internal static IEnumerable<VisaoModeloProdutosDisponiveis> Resultado(IEnumerable<Produto> produtos)
        {
            var config = new MapperConfiguration(cfg =>
              cfg.CreateMap<Produto, VisaoModeloProdutosDisponiveis>()
             .ForMember(dest => dest.Id, m => m.MapFrom(origem => origem.Id))
             .ForMember(dest => dest.Codigo, m => m.MapFrom(origem => $"{origem.Codigo} - {origem.Descricao}"))
             .ForMember(dest => dest.PrecoUnitario, m => m.MapFrom(origem => origem.PrecoUnitario))
             .ForMember(dest => dest.QuantidadeDisponivel, m => m.MapFrom(origem => origem.Estoque)));

            var mapper = new Mapper(config);

            var produtosModelo = mapper.Map<IEnumerable<VisaoModeloProdutosDisponiveis>>(produtos);

            return produtosModelo;
        }
    }
}
