using Comercial.Cliente.Adesao.Gestao.API.Commands;
using Mensagens.Eventos;
using Microsoft.Extensions.DependencyInjection;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;

namespace RebusAzureFunction.Config
{
    public static class ImplementRebus
    {
        public static void AddRebusConfiguration(this IServiceCollection services)
        {
            var connectionString = "";
            var desvinculoadesivoTopic = "";
            var bloqueioadesivoTopic = "";

            services
                .AddRebus(configure => configure
                .Transport(t => t.UseAzureServiceBusAsOneWayClient(connectionString))
                .Routing(r => r.TypeBased()
                                .MapAssemblyOf<InformacoesDesvinculoAdesaoCommand>(desvinculoadesivoTopic)
                                .MapAssemblyOf<AdesaoBloqueada>(bloqueioadesivoTopic)))
                .BuildServiceProvider()
                .UseRebus();
        }
    }
}
