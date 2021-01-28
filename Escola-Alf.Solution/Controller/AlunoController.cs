using Escola.Alf.Application.Commom;
using Escola.Alf.Application.Interfaces;
using Escola.Alf.Application.Model.Aluno;
using Escola.Alf.Solution.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Escola.Alf.Solution.Controller
{
    [ApiController]
    [Route("api/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AlunoRequestModel alunoView)
        {
            try
            {
                var alunoId = await _alunoService.Create(alunoView);
                return CreatedAtRoute(_alunoService, "Aluno cadastrado com sucesso. \n" + "ID: " + alunoId);
            }
            catch (ValidateException ex)
            {
                return this.HandleException(ex);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AlunoRequestModel alunoView)
        {
            try
            {
                await _alunoService.Update(id, alunoView);
                return Ok("Atualizado com sucesso.");
            }
            catch (ValidateException ex)
            {

                return this.HandleException(ex);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _alunoService.Delete(id);
                return NoContent();
            }
            catch (ValidateException ex)
            {

                return this.HandleException(ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(await _alunoService.GetById(id));
            }
            catch(ValidateException ex)
            {
                return NotFound(ex.Erros);
            }
            catch(Exception ex)
            {
                return this.HandleException(ex);
            }
        }

    }
}
