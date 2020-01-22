using System.Net.Http;
using System.Net.Http.Headers;

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
    }
}
