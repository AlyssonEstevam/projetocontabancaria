using System;
using ProjetoContaBancaria.Web.Application.Conta;
using ProjetoContaBancaria.Web.Application.Conta.Model;
using ProjetoContaBancaria.Web.Application.Pessoa;
using ProjetoContaBancaria.Web.Application.Pessoa.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.WebPages;
using ProjetoContaBancaria.Web.Application.Operacao;
using ProjetoContaBancaria.Web.Application.Operacao.Model;

namespace ProjetoContaBancaria.Web.Controllers
{
    public class PessoaController : Controller
    {
        private PessoaApplication _pessoaApplication;
        private ContaApplication _contaApplication;
        private OperacaoApplication _operacaoApplication;
        private HttpResponseMessage _response;

        public PessoaController()
        {
            PessoaApplication pessoaApplication = new PessoaApplication();
            ContaApplication contaApplication = new ContaApplication();
            OperacaoApplication operacaoApplication = new OperacaoApplication();
            _pessoaApplication = pessoaApplication;
            _contaApplication = contaApplication;
            _operacaoApplication = operacaoApplication;
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
        
        public ActionResult Saque(string id)
        {
            OperacoesContaModel operacoesConta = new OperacoesContaModel();
            operacoesConta.Num_NumeroContaT = string.Format("{0:N0}", id).Replace(".", "");
            return View(operacoesConta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Saque(OperacoesContaModel operacoesConta)
        {
            string conta = operacoesConta.Num_NumeroContaT;
            decimal valor = operacoesConta.Vlr_Valor;
            if (ModelState.IsValid)
            {
                _response = _contaApplication.Saque(operacoesConta);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ViewBag.Mensagem = "Saque realizado com sucesso!";
                    return View("Confirmacao");
                }
            }

            return View("Error404");
        }

        public ActionResult Deposito(string id)
        {
            OperacoesContaModel operacoesConta = new OperacoesContaModel();
            operacoesConta.Num_NumeroContaT = string.Format("{0:N0}", id).Replace(".", "");
            return View(operacoesConta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deposito(OperacoesContaModel operacoesConta)
        {
            if (ModelState.IsValid)
            {
                _response = _contaApplication.Deposito(operacoesConta);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ViewBag.Mensagem = "Depósito realizado com sucesso!";
                    return View("Confirmacao");
                }
            }

            return View("Error404");
        }

        public ActionResult Transferencia(string id)
        {
            OperacoesContaModel operacoesConta = new OperacoesContaModel();
            operacoesConta.Num_NumeroContaT = string.Format("{0:N0}", id).Replace(".", "");
            return View(operacoesConta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Transferencia(OperacoesContaModel operacoesConta)
        {
            if (ModelState.IsValid)
            {
                _response = _contaApplication.Transferencia(operacoesConta);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ViewBag.Mensagem = "Transferência realizada com sucesso!";
                    return View("Confirmacao");
                }
            }

            return View("Error404");
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
                    ViewBag.Mensagem = "Pessoa cadastrada com sucesso!";
                    return View("Confirmacao");
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
                    ViewBag.Mensagem = "Pessoa alterada com sucesso!";
                    return View("Confirmacao");
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
                ViewBag.Mensagem = "Pessoa removida com sucesso!";
                return View("Confirmacao");
            }
            else
            {
                return View("Error404");
            }
        }
    }
}
