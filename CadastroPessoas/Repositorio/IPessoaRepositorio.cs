using CadastroPessoas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoas.Repositorio
{
    public interface IPessoaRepositorio
    {
        List<PessoaModel> BuscarTudo();
        PessoaModel BuscarPorId(int Id);
        PessoaModel Adicionar(PessoaModel pessoa);
        PessoaModel Editar(PessoaModel pessoa);
        bool Apagar(int Id);
    }
}
