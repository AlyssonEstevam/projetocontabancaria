using System;
using ProjetoContaBancaria.Domain.Notification;

namespace ProjetoContaBancaria.Domain.Conta.Dto
{
    public class ContaDto
    {
        public decimal Num_NumeroConta { get; set; }
        public decimal Vlr_Saldo { get; set; }
        public DateTime Dat_DataAbertura { get; set; }
        public bool Ind_ContaAtiva { get; set; }

        public bool IsValid(NotificationContext notification)
        {
            if (string.IsNullOrEmpty(Num_NumeroConta.ToString()))
                notification.Add(new Notification.Notification("0", "O número da conta deve ser informado"));
            if (string.IsNullOrEmpty(Vlr_Saldo.ToString()))
                Vlr_Saldo = 0;

            return !notification.HasNotifications;
        }
    }
}
