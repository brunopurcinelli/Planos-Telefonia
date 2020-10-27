using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using WebApi.Application.Interfaces;
using WebApi.Application.ViewModels;
using WebApi.Domain.Core.Bus;
using WebApi.Domain.Core.Notifications;

namespace WebApi.Controllers
{
    [Authorize]
    public class OperadoraController : ApiController
    {
        private readonly IOperadoraAppService _appService;

        public OperadoraController(
            IOperadoraAppService customerAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _appService = customerAppService;
        }

        /// <summary>
        /// Busca todas Operadoras
        /// </summary>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Lista com as Operadoras</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpGet]
        [Route("operadoras")]
        [Produces("application/json")]
        [SwaggerOperation(Tags = new[] { "Operadoras" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }


        /// <summary>
        /// Busca as Operadoras por Id
        /// </summary>
        /// <param name="id">Id da Operadora</param>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Lista com as Operadoras</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpGet]
        [Route("operadoras/{id:Guid}")]
        [Produces("application/json")]
        [SwaggerOperation(Tags = new[] { "Operadoras" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult Get(Guid id)
        {
            var viewModel = _appService.GetById(id);

            return Response(viewModel);
        }

        /// <summary>
        /// Atualiza A Operadora
        /// </summary>
        /// <param name="viewModel">Operadora</param>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Atualiza a Operadora</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpPost]
        [Route("operadoras")]
        [Produces("application/json")]
        //[Authorize(Policy = "CanWriteOperadoraData")]
        [SwaggerOperation(Tags = new[] { "Operadoras" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult Post([FromBody] OperadoraViewModel viewModel)
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
        /// Nova Operadora
        /// </summary>
        /// <param name="viewModel">Operadora</param>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Cria a Operadora</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpPut]
        [Route("operadoras")]
        [Produces("application/json")]
        //[Authorize(Policy = "CanWriteOperadoraData")]
        [SwaggerOperation(Tags = new[] { "Operadoras" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult Put([FromBody] OperadoraViewModel viewModel)
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
        /// Apaga a Operadora
        /// </summary>
        /// <param name="id">Id da Operadora</param>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Deleta a Operadora</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpDelete]
        [Route("operadoras")]
        [Produces("application/json")]
        //[Authorize(Policy = "CanRemoveOperadoraData")]
        [SwaggerOperation(Tags = new[] { "Operadoras" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult Delete(Guid id)
        {
            _appService.Remove(id);

            return Response();
        }
    }
}
