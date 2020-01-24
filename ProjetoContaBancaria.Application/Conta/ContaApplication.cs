using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProjetoContaBancaria.Web.Application.Conta.Model;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace ProjetoContaBancaria.Web.Application.Conta
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
            _url = "http://localhost:64771/api/Conta/Delete" + "?id=" + id;

            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _response = cliente.DeleteAsync(_url).Result;


            return _response;
        }

        public HttpResponseMessage Deposito(OperacoesContaModel operacoesConta)
        {
            _url = "http://localhost:64771/api/Conta/Deposito";

            _response = cliente.PostAsync(_url, operacoesConta, new JsonMediaTypeFormatter
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

        public HttpResponseMessage Saque(OperacoesContaModel operacoesConta)
        {
            _url = "http://localhost:64771/api/Conta/Saque";

            _response = cliente.PostAsync(_url, operacoesConta, new JsonMediaTypeFormatter
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

        public HttpResponseMessage Transferencia(OperacoesContaModel operacoesConta)
        {
            _url = "http://localhost:64771/api/Conta/Transferencia";

            _response = cliente.PostAsync(_url, operacoesConta, new JsonMediaTypeFormatter
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
