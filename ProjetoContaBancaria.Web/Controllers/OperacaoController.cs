using ProjetoContaBancaria.Web.Application.Operacao;
using ProjetoContaBancaria.Web.Application.Operacao.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

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

        public ActionResult Estorno(string id)
        {
            _response = _operacaoApplication.GetOperacao(id);
            OperacaoModel operacao = _response.Content.ReadAsAsync<OperacaoModel>().Result;

            decimal codigo = operacao.Num_Codigo;
            char tipoMov = operacao.Ind_TipoMovimento;
            decimal valor = operacao.Vlr_Valor;
            decimal conta = operacao.Num_NumeroConta;

            return View(operacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Estorno(OperacaoModel operacao)
        {
            decimal codigo = operacao.Num_Codigo;
            char tipoMov = operacao.Ind_TipoMovimento;
            decimal valor = operacao.Vlr_Valor;
            decimal conta = operacao.Num_NumeroConta;

            _response = _operacaoApplication.Estorno(operacao);
            if (_response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ViewBag.Mensagem = "Estorno realizado com sucesso!";
                return View("Confirmacao");
            }
            else
            {
                return View("Error404");
            }
        }
    }
}