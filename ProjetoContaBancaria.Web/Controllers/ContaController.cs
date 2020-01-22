using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ProjetoContaBancaria.Web.Application.Conta;
using ProjetoContaBancaria.Web.Application.Conta.Model;
using ProjetoContaBancaria.Web.Application.Pessoa;
using ProjetoContaBancaria.Web.Application.Pessoa.Model;

namespace ProjetoContaBancaria.Web.Controllers
{
    public class ContaController : Controller
    {
        private ContaApplication _contaApplication;
        private HttpResponseMessage _response;

        public ContaController()
        {
            ContaApplication contaApplication = new ContaApplication();
            _contaApplication = contaApplication;
        }

        public ActionResult Index()
        {
            _response = _contaApplication.Get();

            if (_response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View(_response.Content.ReadAsAsync<List<ContaModel>>().Result);
            }
            else
            {
                return View("Error404");
            }
        }

        public ActionResult Cadastrar()
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(ContaModel conta)
        {
            if (ModelState.IsValid)
            {
                _response = _contaApplication.Post(conta);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //Tela de Conta cadastrada com sucesso!
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error404");
                }
            }

            return View("Error404");
        }

        public ActionResult Alterar(string id)
        {
            _response = _contaApplication.Get(id);
            ContaModel conta = _response.Content.ReadAsAsync<ContaModel>().Result;

            return View(conta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(ContaModel conta)
        {
            if (ModelState.IsValid)
            {
                _response = _contaApplication.Put(conta);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //Tela de Conta alterada com sucesso!
                    return RedirectToAction("Index");
                }
            }

            return View("Error404");
        }

        public ActionResult Excluir(string id)
        {
            _response = _contaApplication.Get(id);
            ContaModel conta = _response.Content.ReadAsAsync<ContaModel>().Result;
            return View(conta);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(string id)
        {
            _response = _contaApplication.Delete(id);
            if (_response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //Tela de Pessoa removida com sucesso!
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error404");
            }
        }
    }
}