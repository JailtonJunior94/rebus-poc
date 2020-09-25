namespace Comercial.Cliente.Adesao.Gestao.API.Commands
{
    public class InformacoesDesvinculoAdesaoCommand
    {
        public InformacoesDesvinculoAdesaoCommand(string clienteId, string numeroSerie)
        {
            ClienteId = clienteId;
            NumeroSerie = numeroSerie;
        }

        public string ClienteId { get; set; }
        public string NumeroSerie { get; set; }
    }
}
