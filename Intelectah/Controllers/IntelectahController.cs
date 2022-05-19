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
        //---------- Pacientes ----------
        //buscar pacientes
        [HttpGet]
        [Route(template: "pacientes")]
        public async Task<IActionResult> GetAsyncPacientes(
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
        public async Task<IActionResult> GetByIdAsyncPacientes(
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
        public async Task<IActionResult> PostAsyncPaciente(
            [FromServices] AppDbContext context,
            [FromBody] CriarPacienteViewModel model)
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
        public async Task<IActionResult> PutAsyncPaciente(
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
        public async Task<IActionResult> DeleteAsyncPaciente(
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

        //---------- Tipos de Exame ----------
        //buscar tipos de exame
        [HttpGet]
        [Route(template: "tiposdeexame")]
        public async Task<IActionResult> GetAsyncTiposDeExame(
            [FromServices] AppDbContext context)
        {
            var TiposDeExame = await context
                .TiposDeExame
                .AsNoTracking()
                .ToListAsync();

            return Ok(TiposDeExame);
        }

        //buscar tipos de exame pole id
        [HttpGet]
        [Route(template: "tiposdeexame/{id}")]
        public async Task<IActionResult> GetByIdAsyncTiposDeExame(
            [FromServices] AppDbContext context, [FromRoute] int id)
        {
            var tipodeexame = await context
                .TiposDeExame
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            //verificar se existe o item
            return tipodeexame == null
                ? NotFound()
                : Ok(tipodeexame);
        }


        //Criar tipo de exame
        [HttpPost]
        [Route(template: "tiposdeexame")]
        public async Task<IActionResult> PostAsyncTipoDeExame(
            [FromServices] AppDbContext context,
            [FromBody] CriarTiposDeExameViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tipodeexame = new TiposDeExame
            {
                NomeDoTipoDeExame = model.NomeDoTipoDeExame,
                Descricao = model.Descricao
            };

            try
            {
                await context.TiposDeExame.AddAsync(tipodeexame);
                await context.SaveChangesAsync();
                return Created(uri: $"v1/tiposdeexame/{tipodeexame.Id}", tipodeexame);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        //atualizar tipo de exame
        [HttpPut]
        [Route(template: "tiposdeexame/{id}")]
        public async Task<IActionResult> PutAsyncTipoDeExame(
            [FromServices] AppDbContext context,
            [FromBody] CriarTiposDeExameViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tipodeexame = await context
                .TiposDeExame
                .FirstOrDefaultAsync(x => x.Id == id);

            if (tipodeexame == null)
                return NotFound();

            try
            {
                tipodeexame.NomeDoTipoDeExame = model.NomeDoTipoDeExame;
                tipodeexame.Descricao = model.Descricao;

                context.TiposDeExame.Update(tipodeexame);
                await context.SaveChangesAsync();
                return Ok(tipodeexame);

            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

        //apagar tipo de exame
        [HttpDelete]
        [Route(template: "tiposdeexame/{id}")]
        public async Task<IActionResult> DeleteAsyncTipoDeExame(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var tipodeexame = await context
                .TiposDeExame
                .FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.TiposDeExame.Remove(tipodeexame);
                await context.SaveChangesAsync();
                return Ok("Tipo de exame apagado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
