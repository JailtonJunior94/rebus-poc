using Comercial.Cliente.Adesao.Gestao.API.Commands;
using Mensagens.Eventos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Rebus.Bus;
using System;
using System.Threading.Tasks;

namespace RebusAzureFunction
{
    public class Function
    {
        private readonly IBus _bus;

        public Function(IBus bus)
        {
            _bus = bus;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "testando")] HttpRequest req)
        {
            try
            {
                var desvinculoMessage = new InformacoesDesvinculoAdesaoCommand("XPTO", "XPTO");
                await _bus.Advanced.Topics.Publish("desvinculoadesivo", desvinculoMessage);

                var adesaoMessage = new AdesaoBloqueada(Guid.NewGuid(), "XPTO", "XPTO", "XPTO");
                await _bus.Advanced.Topics.Publish("bloqueioadesivo", adesaoMessage);

                return new ObjectResult("Mensagens enviadas com sucesso!") { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception exception)
            {
                return new ObjectResult($"Erro ao enviar mensagens: {exception?.Message}") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
