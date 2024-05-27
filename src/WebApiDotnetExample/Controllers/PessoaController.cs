using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiDotnetExample.Model;

namespace WebApiDotnetExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private static List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa { Id = 1, Nome = "João Silva", CPF = "12345678901", Email = "joao.silva@example.com", DataDeNascimento = new DateTime(1990, 1, 1) },
            new Pessoa { Id = 2, Nome = "Maria Souza", CPF = "09876543210", Email = "maria.souza@example.com", DataDeNascimento = new DateTime(1985, 5, 23) }
        };

        // GET: api/Pessoa
        [HttpGet]
        public ActionResult<IEnumerable<Pessoa>> GetPessoas()
        {
            return Ok(pessoas);
        }

        // GET: api/Pessoa/5
        [HttpGet("{id}")]
        public ActionResult<Pessoa> GetPessoa(int id)
        {

            var pessoa = pessoas.FirstOrDefault(p => p.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        // POST: api/Pessoa
        [HttpPost]
        public ActionResult<Pessoa> PostPessoa([FromBody] Pessoa pessoa)
        {
            pessoa.Id = pessoas.Max(p => p.Id) + 1;
            pessoas.Add(pessoa);
            return CreatedAtAction(nameof(GetPessoa), new { id = pessoa.Id }, pessoa);
        }

        // PUT: api/Pessoa/5
        [HttpPut("{id}")]
        public ActionResult PutPessoa(int id, [FromBody] Pessoa pessoa)
        {
            var existingPessoa = pessoas.FirstOrDefault(p => p.Id == id);
            if (existingPessoa == null)
            {
                return NotFound();
            }

            existingPessoa.Nome = pessoa.Nome;
            existingPessoa.CPF = pessoa.CPF;
            existingPessoa.Email = pessoa.Email;
            existingPessoa.DataDeNascimento = pessoa.DataDeNascimento;

            return NoContent();
        }

        // DELETE: api/Pessoa/5
        [HttpDelete("{id}")]
        public ActionResult DeletePessoa(int id)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            pessoas.Remove(pessoa);
            return NoContent();
        }
    }
}

