using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProjetoContaBancaria.Application.Conta.Model;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace ProjetoContaBancaria.Application.Conta
{
    public class ContaApplication
    {
        static readonly HttpClient cliente = new HttpClient();
        private string _url="";
        private HttpResponseMessage _response;

        public HttpResponseMessage Get()
        {
            _url = "http://localhost:64771/api/Conta";
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _response = cliente.GetAsync(_url).Result;

            return _response;
        }

        public HttpResponseMessage Get(string id)
        {
            _url = "http://localhost:64771/api/Conta" + "?id=" + id;
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _response = cliente.GetAsync(_url).Result;

            return _response;
        }

        public HttpResponseMessage Post(ContaModel conta)
        {
            _url = "http://localhost:64771/api/Conta/Post";
            _response = cliente.PostAsync(_url, conta, new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new DefaultContractResolver
                    {
                        IgnoreSerializableAttribute = true
                    }
                }
            }).Result;

            return _response;
        }

        public HttpResponseMessage Put(ContaModel conta)
        {
            _url = "http://localhost:64771/api/Conta/Put";
            _response = cliente.PutAsync(_url, conta, new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new DefaultContractResolver
                    {
                        IgnoreSerializableAttribute = true
                    }
                }
            }).Result;

            return _response;
        }

        public HttpResponseMessage Delete(string id)
        {
            string URL = "http://localhost:64771/api/Conta/Delete" + "?id=" + id;

            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _response = cliente.DeleteAsync(URL).Result;


            return _response;
        }

        public HttpResponseMessage Deposito(decimal Num_NumeroConta, decimal Vlr_Valor)
        {
            _url = "http://localhost:64771/api/Conta/Deposito";

            OperacoesContaModel contaOperacao = new OperacoesContaModel(Num_NumeroConta, Vlr_Valor);

            _response = cliente.PutAsync(_url, contaOperacao, new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new DefaultContractResolver
                    {
                        IgnoreSerializableAttribute = true
                    }
                }
            }).Result;

            return _response;
        }

        public HttpResponseMessage Saque(decimal Num_NumeroConta, decimal Vlr_Valor)
        {
            _url = "http://localhost:64771/api/Conta/Saque";

            OperacoesContaModel contaOperacao = new OperacoesContaModel(Num_NumeroConta, Vlr_Valor);

            _response = cliente.PutAsync(_url, contaOperacao, new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new DefaultContractResolver
                    {
                        IgnoreSerializableAttribute = true
                    }
                }
            }).Result;

            return _response;
        }

        public HttpResponseMessage Transferencia(decimal Num_NumeroContaT, decimal Num_NumeroContaR, decimal Vlr_Valor)
        {
            _url = "http://localhost:64771/api/Conta/Transferencia";

            OperacoesContaModel contaOperacao = new OperacoesContaModel(Num_NumeroContaT, Num_NumeroContaR, Vlr_Valor);

            _response = cliente.PutAsync(_url, contaOperacao, new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new DefaultContractResolver
                    {
                        IgnoreSerializableAttribute = true
                    }
                }
            }).Result;

            return _response;
        }
    }
}
