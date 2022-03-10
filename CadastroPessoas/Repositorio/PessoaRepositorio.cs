using CadastroPessoas.Data;
using CadastroPessoas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoas.Repositorio
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly BancoContext _bancoContext;

        public PessoaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public PessoaModel Adicionar(PessoaModel pessoa)
        {
            _bancoContext.Pessoa.Add(pessoa);
            _bancoContext.SaveChanges();

            return pessoa;
        }

        public PessoaModel Editar(PessoaModel pessoa)
        {
            PessoaModel pessoaDB = BuscarPorId(pessoa.Id);

            if (pessoaDB == null)
                throw new Exception("Erro ao atualizar o cadastro!");

            pessoaDB.Nome = pessoa.Nome;
            pessoaDB.Sobrenome = pessoa.Sobrenome;
            pessoaDB.Celular = pessoa.Celular;
            pessoaDB.CPF = pessoa.CPF;

            _bancoContext.Pessoa.Update(pessoaDB);
            _bancoContext.SaveChanges();

            return pessoaDB;
        }

        public bool Apagar(int Id)
        {
            PessoaModel pessoaDB = BuscarPorId(Id);

            if (pessoaDB == null)
                throw new Exception("Erro ao apagar o cadastro!");

            _bancoContext.Pessoa.Remove(pessoaDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public PessoaModel BuscarPorId(int Id)
        {
            return _bancoContext.Pessoa.FirstOrDefault(x => x.Id == Id);
        }

        public List<PessoaModel> BuscarTudo()
        {
            return _bancoContext.Pessoa.ToList();
        }        
    }
}
