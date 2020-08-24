using AutoMapper;
using DR.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.ModeloVisaoModelo.ClientesCadastrados
{
    public class ModeloClientesCadastrados
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public static IEnumerable<ModeloClientesCadastrados> ModeloParaVisao(IEnumerable<Cliente> clientes)
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<Cliente, ModeloClientesCadastrados>()
              .ForMember(dest => dest.Nome, m => m.MapFrom(origem => origem.Nome))
              .ForMember(dest => dest.Cidade, m => m.MapFrom(origem => origem.Endereco.Cidade))
              .ForMember(dest => dest.Estado, m => m.MapFrom(origem => origem.Endereco.Estado)));

            var mapper = new Mapper(config);

            var clientesModelo = mapper.Map<IEnumerable<ModeloClientesCadastrados>>(clientes);

            return clientesModelo;
        }

    }
}
