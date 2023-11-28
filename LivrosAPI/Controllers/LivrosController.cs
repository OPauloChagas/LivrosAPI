using LivrosAPI.Models;
using LivrosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LivrosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {


        private readonly LivroService _livroService;

        public LivrosController(LivroService livroService) =>
            _livroService = livroService;
        
        [HttpGet]
        public async Task<List<Livro>> Get() => await _livroService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Livro>> Get(string id) 
        {
            var livro = await _livroService.GetAsync(id);            
            
            if (livro is null){return NotFound();}

            return Ok(livro);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Livro novoLivro)
        {
            await _livroService.CreateAsync(novoLivro);

            return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Livro livroAtualizado) 
        {
            var Livro = _livroService.GetAsync(id); 
            if (Livro is null) { return NotFound();}

            livroAtualizado.Id = (await Livro).Id;
            
            await _livroService.UpdateAsync(id, livroAtualizado);

            return NoContent();

        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Livro = await _livroService.GetAsync(id);

            if (Livro is null)
            {
                return NotFound();
            }

            await _livroService.RemoveAsync(id);

            return NoContent();
        }

    }
}
