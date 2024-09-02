using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using porunga.Models;

namespace porunga.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        static List<Pessoa> pessoas = new List<Pessoa>();

        [HttpPost]
        [Route("AddPessoa")]

        public IActionResult Adicionar(Pessoa pessoa)
        {
            pessoas.Add(pessoa);

            return Ok();
        }

        [HttpPut]
        [Route("AtualizarPessoa")]

        public IActionResult atualizar(string cpf, Pessoa porungaPessoas)
        {
            var pessoaPesquisado = pessoas.Where(a => a.Cpf == cpf).FirstOrDefault();


            if (pessoaPesquisado is null)
                return NotFound($"Aluno com cpf {cpf} não encontrado.");

            pessoaPesquisado.Nome = porungaPessoas.Nome;
            pessoaPesquisado.Cpf = porungaPessoas.Cpf;
            pessoaPesquisado.Peso = porungaPessoas.Peso;
            pessoaPesquisado.Altura = porungaPessoas.Altura;

            return NoContent();
        }

        [HttpGet]
        [Route("BuscarPessoa")]

        public IActionResult Buscar()
        {
            return Ok(pessoas);
        }

        [HttpDelete]
        [Route("DeletePessoa")]

        public IActionResult Deletar(string Cpf)
        {
            var PessoaPesquisado = pessoas.Where(a => a.Cpf == Cpf).FirstOrDefault();

            if (PessoaPesquisado is null)
                return NotFound($"Aluno com cpf {Cpf} não encontrado.");

            pessoas.Remove(PessoaPesquisado);

            return NoContent();
        }

        [HttpGet]
        [Route("EspecificaPessoa")]

        public IActionResult BuscarEspecifica (string Cpf)
        {
            var PessoaPesquisando = pessoas.Where(a => a.Cpf == Cpf).FirstOrDefault();

            if (PessoaPesquisando is null)
                return NotFound($"Aluno com cpf {Cpf} não encontrado.");

            return Ok(PessoaPesquisando);

        }





    }
}
