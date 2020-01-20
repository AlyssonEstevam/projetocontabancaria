using System;
using ProjetoContaBancaria.Domain.Notification;

namespace ProjetoContaBancaria.Domain.Pessoa.Dto
{
    public class PessoaDto
    {
        public decimal Num_Cpf { get; set; }
        public string Nom_Nome { get; set; }
        public string Nom_Sobrenome { get; set; }
        public DateTime Dat_DataNascimento { get; set; }
        public char Ind_Sexo { get; set; }
        public decimal Vlr_Renda { get; set; }
        public decimal Num_NumeroConta { get; set; }

        public bool IsValid(NotificationContext notification)
        {
            //VALIDAÇÃO DE CPF
            //VALIDAÇÃO DE DATA

            if (string.IsNullOrEmpty(Nom_Nome))
                notification.Add(new Notification.Notification("0", "O nome deve ser informado"));
            else if (Nom_Nome.Length < 2 || Nom_Nome.Length > 50)
                notification.Add(new Notification.Notification("1", "O nome deve estar entre 2 e 100 caracteres"));

            if (string.IsNullOrEmpty(Nom_Sobrenome))
                notification.Add(new Notification.Notification("2", "O sobrenome deve ser informado"));
            else if (Nom_Sobrenome.Length < 2 || Nom_Sobrenome.Length > 50)
                notification.Add(new Notification.Notification("3", "O sobrenome deve estar entre 2 e 100 caracteres"));
            if (string.IsNullOrEmpty(Dat_DataNascimento.ToString()))
                notification.Add(new Notification.Notification("4", "A data de nascimento deve ser informada"));
            if (string.IsNullOrEmpty(Vlr_Renda.ToString()))
                notification.Add(new Notification.Notification("5", "O valor da renda deve ser informado"));


            return !notification.HasNotifications;
        }
    }
}
