using System;
using ProjetoContaBancaria.Domain.Conta.Dto;
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
        public ContaDto Conta { get; set; }

        public bool IsValid(NotificationContext notification)
        {
            if (string.IsNullOrEmpty(Num_Cpf.ToString()))
                notification.Add(new Notification.Notification("0", "O CPF deve ser informado"));

            //------------------> VALIDAÇÃO DE DATA

             if (!validaCpf(Num_Cpf))
            {
                notification.Add(new Notification.Notification("2", "O CPF está invalido"));
            }

            if (string.IsNullOrEmpty(Nom_Nome))
                notification.Add(new Notification.Notification("3", "O nome deve ser informado"));
            else if (Nom_Nome.Length < 2 || Nom_Nome.Length > 50)
                notification.Add(new Notification.Notification("4", "O nome deve estar entre 2 e 100 caracteres"));

            if (string.IsNullOrEmpty(Nom_Sobrenome))
                notification.Add(new Notification.Notification("5", "O sobrenome deve ser informado"));
            else if (Nom_Sobrenome.Length < 2 || Nom_Sobrenome.Length > 50)
                notification.Add(new Notification.Notification("6", "O sobrenome deve estar entre 2 e 100 caracteres"));
            
            if (string.IsNullOrEmpty(Dat_DataNascimento.ToString()))
                notification.Add(new Notification.Notification("7", "A data de nascimento deve ser informada"));
            if (string.IsNullOrEmpty(Vlr_Renda.ToString()))
                notification.Add(new Notification.Notification("9", "O valor da renda deve ser informado"));


            return !notification.HasNotifications;
        }

        private bool validaCpf(decimal Num_Cpf)
        {
            //Formatação da vírgula e casas decimais
            string cpf = string.Format("{0:N0}", Num_Cpf).Replace(".", "");

            //Tamanho 11 excedido
            if (cpf.Length > 11)
            {
                return false;
            }

            //Tratamento de 0(Zero) à esquerda
            for (int i = cpf.Length; i < 11; i++)
            {
                cpf = "0" + cpf;
            }

            //Verificação do primeiro dígito
            int resultado = 0;
            for (int i = 0, j = 10; i < 9; i++, j--)
            {
                resultado += int.Parse(cpf[i].ToString()) * j;
            }

            resultado = (resultado * 10) % 11;
            if (resultado == 10)
            {
                resultado = 0;
            }

            if (resultado != int.Parse(cpf[9].ToString()))
            {
                return false;
            }

            //Verifica segundo dígito
            resultado = 0;
            for (int i = 0, j = 11; i < 10; i++, j--)
            {
                resultado += int.Parse(cpf[i].ToString()) * j;
            }

            resultado = (resultado * 10) % 11;
            if (resultado == 10)
            {
                resultado = 0;
            }

            if (resultado != int.Parse(cpf[10].ToString()))
            {
                return false;
            }

            return true;
        }
    }
}
