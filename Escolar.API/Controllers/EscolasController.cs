using Escolar.Application.DTOs;
using Escolar.Application.Interfaces;
using Escolar.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escolar.API.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class EscolasController : ControllerBase
    {
        private readonly IEscolaService _escolaService;
        public EscolasController(IEscolaService escolaService)
        {
            _escolaService = escolaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EscolaDTO>>> Get()
        {
            var categorias = await _escolaService.GetEscolas();
            return Ok(categorias);
        }

        [HttpGet("{id}", Name = "GetEscola")]
        public async Task<ActionResult<Escola>> Get(int id)
        {
            var escola = await _escolaService.GetById(id);

            if (escola == null)
            {
                return NotFound();
            }
            return Ok(escola);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EscolaDTO escolaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _escolaService.Add(escolaDto);

            return new CreatedAtRouteResult("GetEscola",
                new { id = escolaDto.Id }, escolaDto);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EscolaDTO escolaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != escolaDto.Id)
            {
                return BadRequest();
            }
            await _escolaService.Update(escolaDto);
            return Ok(escolaDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Escola>> Delete(int id)
        {
            var escolaDto = await _escolaService.GetById(id);
            if (escolaDto == null)
            {
                return NotFound();
            }
            await _escolaService.Remove(id);
            return Ok(escolaDto);
        }
    }
}
