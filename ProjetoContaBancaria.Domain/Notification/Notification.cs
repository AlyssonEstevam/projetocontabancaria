using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoContaBancaria.Domain.Notification
{
    public class Notification
    {
        public string Id { get; }
        public string Mensagem { get; }

        public Notification(string id, string mensagem)
        {
            Id = id;
            Mensagem = mensagem;
        }
    }
}
