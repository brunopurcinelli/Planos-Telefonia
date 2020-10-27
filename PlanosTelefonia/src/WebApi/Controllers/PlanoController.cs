using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using WebApi.Application.Interfaces;
using WebApi.Application.ViewModels;
using WebApi.Domain.Core.Bus;
using WebApi.Domain.Core.Notifications;
using WebApi.Domain.Models;

namespace WebApi.Controllers
{
    [Authorize]
    public class PlanoController : ApiController
    {
        private readonly IPlanoAppService _appService;

        public PlanoController(
            IPlanoAppService customerAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _appService = customerAppService;
        }

        /// <summary>
        /// Busca por Tipo do Plano
        /// </summary>
        /// <param name="tipo">0: Controle - 1: Pós-Pago - 2: Pré-Pago</param>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Lista com os Planos</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpGet]
        [Route("planos/tipo/{tipo}")]
        [Produces("application/json")]
        [SwaggerOperation(Tags = new[] { "Planos" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult GetByType(TipoPlano tipo)
        {
            var viewModel = _appService.GetByType(tipo);

            return Response(viewModel);
        }

        /// <summary>
        /// Busca por Id da Operadora
        /// </summary>
        /// <param name="nomeOperadora">Nome da Operadora</param>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Lista com os Planos</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpGet]
        [Route("planos/operadora/{nomeOperadora}")]
        [Produces("application/json")]
        [SwaggerOperation(Tags = new[] { "Planos" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult GetByOperatorName(string nomeOperadora)
        {
            var viewModel = _appService.GetByOperatorName(nomeOperadora);

            return Response(viewModel);
        }

        /// <summary>
        /// Busca por Id da Operadora
        /// </summary>
        /// <param name="IdOperadora">Id da Operadora</param>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Lista com os Planos</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpGet]
        [Route("planos/operadora/{idOperadora:Guid}")]
        [Produces("application/json")]
        [SwaggerOperation(Tags = new[] { "Planos" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult GetByOperator(Guid IdOperadora)
        {
            var viewModel = _appService.GetByOperator(IdOperadora);

            return Response(viewModel);
        }

        /// <summary>
        /// Busca todos os Planos
        /// </summary>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Lista com os Planos</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpGet]
        [Route("planos")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(Tags = new[] { "Planos" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }

        /// <summary>
        /// Busca por Id
        /// </summary>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Detalhe do Plano</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpGet]
        [Route("planos/{id:Guid}")]
        [Produces("application/json")]
        [SwaggerOperation(Tags = new[] { "Planos" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult Get(Guid id)
        {
            var viewModel = _appService.GetById(id);

            return Response(viewModel);
        }

        /// <summary>
        /// Novo Plano
        /// </summary>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Cria um novo Plano</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpPost]
        [Route("planos")]
        //[Authorize(Policy = "CanWritePlanoData")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(Tags = new[] { "Planos" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult Post([FromBody] PlanoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(viewModel);
            }

            _appService.Register(viewModel);

            return Response(viewModel);
        }

        /// <summary>
        /// Atualiza o Plano 
        /// </summary>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Atualiza o Plano</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpPut]
        [Route("planos")]
        [Consumes("application/json")]
        [Produces("application/json")]
        //[Authorize(Policy = "CanWritePlanoData")]
        [SwaggerOperation(Tags = new[] { "Planos" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult Put([FromBody] PlanoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(viewModel);
            }

            _appService.Update(viewModel);

            return Response(viewModel);
        }

        /// <summary>
        /// Apaga o Plano por Id
        /// </summary>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Apaga o Plano</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpDelete]
        [Route("planos")]
        //[Authorize(Policy = "CanRemovePlanoData")]
        [Produces("application/json")]
        [SwaggerOperation(Tags = new[] { "Planos" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult Delete(Guid id)
        {
            _appService.Remove(id);

            return Response();
        }
    }
}
