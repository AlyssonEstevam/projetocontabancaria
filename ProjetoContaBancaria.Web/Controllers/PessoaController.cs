using ProjetoContaBancaria.Web.Application.Conta;
using ProjetoContaBancaria.Web.Application.Conta.Model;
using ProjetoContaBancaria.Web.Application.Pessoa;
using ProjetoContaBancaria.Web.Application.Pessoa.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace ProjetoContaBancaria.Web.Controllers
{
    public class PessoaController : Controller
    {
        private PessoaApplication _pessoaApplication;
        private ContaApplication _contaApplication;
        private HttpResponseMessage _response;

        public PessoaController()
        {
            PessoaApplication pessoaApplication = new PessoaApplication();
            ContaApplication contaApplication = new ContaApplication();
            _pessoaApplication = pessoaApplication;
            _contaApplication = contaApplication;
        }
        
        public ActionResult Index()
        {
            _response = _pessoaApplication.Get();

            if (_response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View(_response.Content.ReadAsAsync<List<PessoaModel>>().Result);
            }
            else
            {
                return View("Error404");
            }
        }
        
        public ActionResult Operacoes(string id)
        {
            return View();
        }
        
        public ActionResult Cadastrar()
        {
            ViewBag.Num_NumeroConta = new SelectList(_contaApplication.Get().Content.ReadAsAsync<List<ContaModel>>().Result, "Num_NumeroConta", "Num_NumeroContaFormatada");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(PessoaModel pessoa)
        {
            if (ModelState.IsValid)
            {
                _response = _pessoaApplication.Post(pessoa);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //Tela de Pessoa cadastrada com sucesso!
                    return RedirectToAction("Index");
                }
            }

            return View("Error404");
        }
        
        public ActionResult Alterar(string id)
        {
            _response = _pessoaApplication.Get(id);
            PessoaModel pessoa = _response.Content.ReadAsAsync<PessoaModel>().Result;
            ViewBag.Num_NumeroConta = new SelectList(_contaApplication.Get().Content.ReadAsAsync<List<ContaModel>>().Result, "Num_NumeroConta", "Num_NumeroContaFormatada", pessoa.Num_NumeroConta);

            return View(pessoa);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(PessoaModel pessoa)
        {
            if (ModelState.IsValid)
            {
                _response = _pessoaApplication.Put(pessoa);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //Tela de Pessoa alterada com sucesso!
                    return RedirectToAction("Index");
                }
            }

            return View("Error404");
        }
        
        public ActionResult Excluir(string id)
        {
            _response = _pessoaApplication.Get(id);
            PessoaModel pessoa = _response.Content.ReadAsAsync<PessoaModel>().Result;
            return View(pessoa);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(string id)
        {
            _response = _pessoaApplication.Delete(id);
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
