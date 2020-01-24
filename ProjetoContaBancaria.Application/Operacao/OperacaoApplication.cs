using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProjetoContaBancaria.Web.Application.Operacao.Model;

namespace ProjetoContaBancaria.Web.Application.Operacao
{
    public class OperacaoApplication
    {
        static readonly HttpClient cliente = new HttpClient();
        private string _url = "";
        private HttpResponseMessage _response;

        public HttpResponseMessage Get()
        {
            _url = "http://localhost:64771/api/Operacao";
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _response = cliente.GetAsync(_url).Result;

            return _response;
        }

        public HttpResponseMessage Get(string id)
        {
            _url = "http://localhost:64771/api/Operacao" + "?id=" + id;
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _response = cliente.GetAsync(_url).Result;

            return _response;
        }

        public HttpResponseMessage GetOperacao(string id)
        {
            _url = "http://localhost:64771/api/Operacao/GetOperacao?id=" + id;
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _response = cliente.GetAsync(_url).Result;

            return _response;
        }

        public HttpResponseMessage Estorno(OperacaoModel operacao)
        {
            decimal codigo = operacao.Num_Codigo;
            char tipoMov = operacao.Ind_TipoMovimento;
            decimal valor = operacao.Vlr_Valor;
            decimal conta = operacao.Num_NumeroConta;


            _url = "http://localhost:64771/api/Operacao/Estorno";

            _response = cliente.PostAsync(_url, operacao, new JsonMediaTypeFormatter
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
