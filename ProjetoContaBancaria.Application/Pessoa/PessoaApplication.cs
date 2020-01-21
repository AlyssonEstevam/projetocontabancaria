using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProjetoContaBancaria.Application.Conta.Model;
using ProjetoContaBancaria.Application.Pessoa.Model;

namespace ProjetoContaBancaria.Application.Pessoa
{
    class PessoaApplication
    {
        static readonly HttpClient cliente = new HttpClient();
        private string _url = "";
        private HttpResponseMessage _response;

        public HttpResponseMessage Get()
        {
            _url = "http://localhost:64771/api/Pessoa";
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

        public HttpResponseMessage Post(PessoaModel pessoa)
        {
            _url = "http://localhost:64771/api/Pessoa/Post";
            _response = cliente.PostAsync(_url, pessoa, new JsonMediaTypeFormatter
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

        public HttpResponseMessage Put(PessoaModel pessoa)
        {
            _url = "http://localhost:64771/api/Pessoa/Put";
            _response = cliente.PutAsync(_url, pessoa, new JsonMediaTypeFormatter
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
            string URL = "http://localhost:64771/api/Pessoa/Delete" + "?id=" + id;

            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _response = cliente.DeleteAsync(URL).Result;


            return _response;
        }
    }
}
