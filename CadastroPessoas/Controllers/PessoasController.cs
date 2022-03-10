using CadastroPessoas.Models;
using CadastroPessoas.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoas.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoasController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        public IActionResult Index()
        {
            List<PessoaModel> lPessoas = _pessoaRepositorio.BuscarTudo();

            return View(lPessoas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int Id)
        {
            PessoaModel pessoa = _pessoaRepositorio.BuscarPorId(Id);

            return View(pessoa);
        }

        public IActionResult Apagar(int Id)
        {
            _pessoaRepositorio.Apagar(Id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(PessoaModel pessoa)
        {
            _pessoaRepositorio.Adicionar(pessoa);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(PessoaModel pessoa)
        {
            _pessoaRepositorio.Editar(pessoa);
            return RedirectToAction("Index");
        }
    }
}
