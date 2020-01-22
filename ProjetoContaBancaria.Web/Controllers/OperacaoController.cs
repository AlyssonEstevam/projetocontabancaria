using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using ProjetoContaBancaria.Web.Application.Operacao;
using ProjetoContaBancaria.Web.Application.Operacao.Model;

namespace ProjetoContaBancaria.Web.Controllers
{
    public class OperacaoController : Controller
    {
        private OperacaoApplication _operacaoApplication;
        private HttpResponseMessage _response;

        public OperacaoController()
        {
            OperacaoApplication operacaoApplication = new OperacaoApplication();
            _operacaoApplication = operacaoApplication;
        }

        public ActionResult Index()
        {
            _response = _operacaoApplication.Get();

            if (_response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View(_response.Content.ReadAsAsync<List<OperacaoModel>>().Result);
            }
            else
            {
                return View("Error404");
            }
        }

        public ActionResult Extrato(string id)
        {
            _response = _operacaoApplication.Get(id);

            if (_response.StatusCode == System.Net.HttpStatusCode.OK && !id.IsEmpty())
            {
                return View(_response.Content.ReadAsAsync<List<OperacaoModel>>().Result);
            }
            else
            {
                return View("Error404");
            }
        }
    }
}