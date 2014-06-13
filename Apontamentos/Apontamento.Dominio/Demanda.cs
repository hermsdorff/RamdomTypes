namespace Apontamento.Dominio
{
    using System;

    public class Demanda
    {
        public TipoDemanda Tipo { get; set; }
        public String Request { get; set; }
        public String Descricao { get; set; }
        public String Solicitante { get; set; }
        public DateTime? Inicio { get; private set; }
        public DateTime? Termino { get; private set; }
        public TimeSpan Duracao
        {
            get
            {
                if (Inicio != null && Termino != null)
                {
                    return Termino.Value.Subtract(Inicio.Value);
                }

                return new TimeSpan(0);
            }
        }
    }
}