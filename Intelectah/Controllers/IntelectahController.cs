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

        //---------- Cadastro de Exames ----------
        //buscar todos os cadastros
        [HttpGet]
        [Route(template: "cadastrodeexames")]
        public async Task<IActionResult> GetAsyncCadastroDeExames(
            [FromServices] AppDbContext context)
        {
            var cadastrodeexames = await context
                .CadastroDeExames
                .AsNoTracking()
                .ToListAsync();

            return Ok(cadastrodeexames);
        }

        //buscar cadastros pole id
        [HttpGet]
        [Route(template: "cadastrodeexames/{id}")]
        public async Task<IActionResult> GetByIdAsyncCadastroDeExames(
            [FromServices] AppDbContext context, [FromRoute] int id)
        {
            var cadastrodeexame = await context
                .CadastroDeExames
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            //verificar se existe o item
            return cadastrodeexame == null
                ? NotFound()
                : Ok(cadastrodeexame);
        }

        //Criar Cadastro de Exame
        [HttpPost]
        [Route(template: "cadastrodeexames")]
        public async Task<IActionResult> PostAsyncCadastroDeExames(
            [FromServices] AppDbContext context,
            [FromBody] CriarCadastroDeExamesViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tipodeexame = await context
                .TiposDeExame
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == model.IdDoTipoDeExame);

            var cadastrodeexame = new CadastroDeExames
            {
                Nome = model.Nome, 
                Observacoes = model.Observacoes,
                IdDoTipoDeExame = model.IdDoTipoDeExame
            };

            try
            {
                if(tipodeexame != null)
                {
                    await context.CadastroDeExames.AddAsync(cadastrodeexame);
                    await context.SaveChangesAsync();
                    return Created(uri: $"v1/tiposdeexame/{cadastrodeexame.Id}", cadastrodeexame);
                }

                return BadRequest();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //atualizar cadastro de exame
        [HttpPut]
        [Route(template: "cadastrodeexames/{id}")]
        public async Task<IActionResult> PutAsyncCadastroDeExames(
            [FromServices] AppDbContext context,
            [FromBody] CriarCadastroDeExamesViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cadastrodeexame = await context
              .CadastroDeExames
              .FirstOrDefaultAsync(x => x.Id == id);

            var tipodeexame = await context
                .TiposDeExame
                .FirstOrDefaultAsync(x => x.Id == model.IdDoTipoDeExame);

            if (cadastrodeexame == null)
                return NotFound();

            try
            {
                if (tipodeexame != null)
                {
                    cadastrodeexame.Nome = model.Nome;
                    cadastrodeexame.Observacoes = model.Observacoes;
                    cadastrodeexame.IdDoTipoDeExame = model.IdDoTipoDeExame;

                    context.CadastroDeExames.Update(cadastrodeexame);
                    await context.SaveChangesAsync();
                    return Ok(cadastrodeexame);
                }

                return BadRequest();

            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

        //apagar cadastro de exame
        [HttpDelete]
        [Route(template: "cadastrodeexames/{id}")]
        public async Task<IActionResult> DeleteAsyncCadastroDeExames(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var cadastrodeexame = await context
                .CadastroDeExames
                .FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.CadastroDeExames.Remove(cadastrodeexame);
                await context.SaveChangesAsync();
                return Ok("Cadastro de exame apagado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        //---------- Marcação de Consultas ----------
        //buscar consultas
        [HttpGet]
        [Route(template:"marcacaodeconsultas")]
        public async Task<IActionResult> GetAsyncMarcacaoDeConsulta(
            [FromServices] AppDbContext context)
        {
            var consultas = await context
                .MarcacaoDeConsulta
                .AsNoTracking()
                .ToListAsync();

            return Ok(consultas);
        }

        //buscar consultas pelo id
        [HttpGet]
        [Route(template: "marcacaodeconsultas/{id}")]
        public async Task<IActionResult> GetByIdAsyncMarcacaoDeConsulta(
            [FromServices] AppDbContext context,
            [FromRoute]int id)
        {
            var consulta = await context
                .MarcacaoDeConsulta
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return consulta == null
                ? NotFound()
                : Ok(consulta);
        }


        //criar consulta
        [HttpPost]
        [Route(template: "marcacaodeconsultas")]
        public async Task<IActionResult> PostAsyncMarcacaoDeConsulta(
            [FromServices] AppDbContext context,
            [FromBody] CriarMarcacaoDeConsultaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //id do paciente
            var paciente = await context
                .Pacientes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Cpf == model.IdDoPaciente || p.Nome == model.IdDoPaciente);

            // id do exame cadastrado
            var exame = await context
                .CadastroDeExames
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == model.IdDoExameCadastrado);

            //data validação
            var data = await context
                .MarcacaoDeConsulta
                .AsNoTracking()
                .FirstOrDefaultAsync(data => data.DataDaConsulta == model.DataDaConsulta);

            var marcacaodeconsulta = new MarcacaoDeConsulta
            {
                IdDoPaciente = model.IdDoPaciente,
                IdDoExameCadastrado = model.IdDoExameCadastrado,
                DataDaConsulta = model.DataDaConsulta,
                NumeroDeProtocolo = model.NumeroDeProtocolo
            };

            try
            {
                if(paciente != null && exame != null)
                {
                    //validar data
                    if (data == null)
                    {
                        await context.MarcacaoDeConsulta.AddAsync(marcacaodeconsulta);
                        await context.SaveChangesAsync();
                        return Created(uri: $"v1/marcacaodeconsultas/{marcacaodeconsulta.Id}", marcacaodeconsulta);
                    }
                    return BadRequest();
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //atualizar marcação de cunsulta
        [HttpPut]
        [Route(template: "marcacaodeconsultas/{id}")]
        public async Task<IActionResult> PutAsyncMarcacaoDeConsulta(
            [FromServices] AppDbContext context,
            [FromBody] CriarMarcacaoDeConsultaViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var marcacaodeconsulta = await context
                .MarcacaoDeConsulta
                .FirstOrDefaultAsync(c => c.Id == id);

            //id do paciente
            var paciente = await context
                .Pacientes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Cpf == model.IdDoPaciente || p.Nome == model.IdDoPaciente);

            // id do exame cadastrado
            var exame = await context
                .CadastroDeExames
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == model.IdDoExameCadastrado);

            if (marcacaodeconsulta == null)
                return NotFound();

            try
            {
                if(paciente != null && exame != null){
                    marcacaodeconsulta.IdDoPaciente = model.IdDoPaciente;
                    marcacaodeconsulta.IdDoExameCadastrado = model.IdDoExameCadastrado;
                    marcacaodeconsulta.DataDaConsulta = model.DataDaConsulta;
                    marcacaodeconsulta.NumeroDeProtocolo = model.NumeroDeProtocolo;

                    context.MarcacaoDeConsulta.Update(marcacaodeconsulta);
                    await context.SaveChangesAsync();
                    return Ok(marcacaodeconsulta);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //apagar consulta
        [HttpDelete]
        [Route(template: "marcacaodeconsultas/{id}")]
        public async Task<IActionResult> DeleteAsyncMarcacaoDeConsulta(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var consulta = await context
                .MarcacaoDeConsulta
                .FirstOrDefaultAsync(c => c.Id == id);

            if (consulta == null)
                return NotFound();

            try
            {
                context.MarcacaoDeConsulta.Remove(consulta);
                await context.SaveChangesAsync();
                return Ok("Consulta apagado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
