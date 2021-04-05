using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NormasService.Application.Interfaces;
using NormasService.Application.Models;
using NormasService.Domain.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NormasService.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/normas")]
    [ApiController]
    public class NormaController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly INormaApplication _normaApplication;

        public NormaController(IMapper mapper, INormaApplication normaApplication)
        {
            _mapper = mapper;
            _normaApplication = normaApplication;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin, Manager, User")]
        [ProducesResponseType(typeof(NormaModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            try
            {
                var norma = await _normaApplication.ObterPorId(id);

                if (norma.Object == null)
                    return NotFound("Norma não encontrada");

                return Ok(_mapper.Map<Norma, NormaModel>(norma.Object));
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "NormaController > ObterPorId - Erro Interno");

                //retorna 500 - default
                return InternalServerError();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        [ProducesResponseType(typeof(NormaModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Inserir([FromBody] NormaModel normaModel)
        {
            try
            {
                var result = await _normaApplication.Incluir(normaModel);

                if (result.Success)
                    return Created($"/normas/{result.Object.Id}", _mapper.Map<Norma, NormaModel>(result.Object));

                return BadRequest(result.Notifications);
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "NormaController > Inserir - Erro Interno");

                //retorna 500 - default
                return InternalServerError();
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin, Manager")]
        [ProducesResponseType(typeof(NormaModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Atualizar([FromBody] NormaModel normaModel)
        {
            if (normaModel.Id == null || normaModel.Id == Guid.Empty)
                return BadRequest("Norma sem um Id.");

            try
            {
                Norma norma = _mapper.Map<Norma>(normaModel);
                if (norma.Invalid)
                    return BadRequest(norma.Notifications);

                var result = await _normaApplication.Atualizar(normaModel);

                if (result.Success)
                    return Ok(_mapper.Map<Norma, NormaModel>(result.Object));

                return BadRequest(result.Notifications);
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "NormaController > Atualizar - Erro Interno");

                //retorna 500 - default
                return InternalServerError();
            }
        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        [ProducesResponseType(typeof(NormaModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                await _normaApplication.Excluir(id);

                return Ok();
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "NormaController > Excluir - Erro Interno");

                //retorna 500 - default
                return InternalServerError();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Manager, User")]
        [ProducesResponseType(typeof(IList<NormaModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var listaNorma = await _normaApplication.ListarTodos();

                if (listaNorma.Object == null)
                    return NotFound("Norma não encontrada");

                return Ok(_mapper.Map<IEnumerable<Norma>, IEnumerable<NormaModel>>(listaNorma.Object));
            }
            catch (Exception ex)
            {
                //adiciona o log
                Log.Logger.Error(ex, "NormaController > ListarTodos - Erro Interno");

                //retorna 500 - default
                return InternalServerError();
            }
        }
    }
}
