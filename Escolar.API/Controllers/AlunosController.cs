using Escolar.Application.DTOs;
using Escolar.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escolar.API.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class AlunosController : Controller
    {
        private readonly IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        // api/alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoDTO>>> Get()
        {
            var alunos = await _alunoService.GetAlunos();
            return Ok(alunos);
        }

        [HttpGet("{id}", Name = "GetAluno")]
        public async Task<ActionResult<AlunoDTO>> Get(int id)
        {
            var aluno = await _alunoService.GetById(id);

            if (aluno == null)
            {
                return NotFound();
            }
            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AlunoDTO alunoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _alunoService.Add(alunoDto);

            return new CreatedAtRouteResult("GetAluno",
                new { id = alunoDto.Id }, alunoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AlunoDTO alunoDto)
        {
            if (id != alunoDto.Id)
            {
                return BadRequest();
            }

            await _alunoService.Update(alunoDto);

            return Ok(alunoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AlunoDTO>> Delete(int id)
        {
            var alunoDto = await _alunoService.GetById(id);
            if (alunoDto == null)
            {
                return NotFound();
            }
            await _alunoService.Remove(id);
            return Ok(alunoDto);
        }
    }
}
