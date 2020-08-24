using AutoMapper;
using DR.Dominio.Entidades.Entidades;
using DR.Dominio.ServicosAplicacao.Contratos.ClientesCadastrados;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.ModeloVisaoModelo.ClientesCadastrados
{
    public class VisaoModeloClientesCadastrados
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        internal static IEnumerable<VisaoModeloClientesCadastrados> Resultado(IEnumerable<Cliente> clientes)
        {
            var config = new MapperConfiguration(cfg =>
           cfg.CreateMap<Cliente, VisaoModeloClientesCadastrados>()
             .ForMember(dest => dest.Nome, m => m.MapFrom(origem => origem.Nome))
             .ForMember(dest => dest.Cidade, m => m.MapFrom(origem => origem.Endereco.Cidade))
             .ForMember(dest => dest.Estado, m => m.MapFrom(origem => origem.Endereco.Estado)));

            var mapper = new Mapper(config);

            var clientesModelo = mapper.Map<IEnumerable<VisaoModeloClientesCadastrados>>(clientes);

            return clientesModelo;
        }
    }
}
