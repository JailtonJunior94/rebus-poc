using System;

namespace Mensagens.Eventos
{
    public class AdesaoBloqueada
    {
        public AdesaoBloqueada(Guid correlationId, string documento, string placa, string motivo)
        {
            CorrelationId = correlationId;
            Documento = documento;
            Placa = placa;
            Motivo = motivo;
        }

        public Guid CorrelationId { get; set; }
        public string Documento { get; set; }
        public string Placa { get; set; }
        public string Motivo { get; set; }
    }
}
