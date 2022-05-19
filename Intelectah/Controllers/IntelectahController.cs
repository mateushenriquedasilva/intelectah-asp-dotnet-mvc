using Intelectah.Data;
using Intelectah.Models;
using Intelectah.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intelectah.Controllers
{
    [ApiController]
    [Route(template:"v1")]
    public class IntelectahController : ControllerBase
    {
        //buscar pacientes
        [HttpGet]
        [Route(template: "pacientes")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context)
        {
            var pacientes = await context
                .Pacientes
                .AsNoTracking()
                .ToListAsync();

            return Ok(pacientes);
        }

        //buscar paciente pelo id
        [HttpGet]
        [Route(template: "pacientes/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context, [FromRoute]int id)
        {
            var paciente = await context
                .Pacientes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            //verificar se existe o item
            return paciente == null 
                ? NotFound() 
                : Ok(paciente);
        }

        //Criar paciente
        [HttpPost]
        [Route(template: "paciente")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody]CriarPacienteViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var paciente = new Paciente
            {
                Nome = model.Nome,
                Cpf = model.Cpf,
                DataDeNascimento = model.DataDeNascimento,
                Sexo = model.Sexo,
                Telefone = model.Telefone,
                Email = model.Email

            };

            try
            {
                await context.Pacientes.AddAsync(paciente);
                await context.SaveChangesAsync();
                return Created(uri: $"v1/paciente/{paciente.Id}", paciente);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //atualizar paciente
        [HttpPut]
        [Route(template: "paciente/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromBody] CriarPacienteViewModel model,
            [FromRoute]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var paciente = await context
                .Pacientes
                .FirstOrDefaultAsync(x => x.Id == id);

            if (paciente == null)
                return NotFound();

            try
            {
                paciente.Nome = model.Nome;
                paciente.Cpf = model.Cpf;
                paciente.DataDeNascimento = model.DataDeNascimento;
                paciente.Sexo = model.Sexo;
                paciente.Telefone = model.Telefone;
                paciente.Email = model.Email;

                context.Pacientes.Update(paciente);
                await context.SaveChangesAsync();
                return Ok(paciente);

            } 
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //apagar paciente
        [HttpDelete]
        [Route(template: "paciente/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute]int id)
        {
            var paciente = await context
                .Pacientes
                .FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.Pacientes.Remove(paciente);
                await context.SaveChangesAsync();
                return Ok("Paciente apagado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
