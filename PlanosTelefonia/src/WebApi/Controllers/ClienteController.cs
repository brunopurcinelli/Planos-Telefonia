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
    public class ClienteController : ApiController
    {
        private readonly IClienteAppService _customerAppService;

        public ClienteController(
            IClienteAppService customerAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _customerAppService = customerAppService;
        }

        /// <summary>
        /// Busca todos Clientes
        /// </summary>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Lista com os Clientes</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpGet]
        [Route("clientes")]
        [Produces("application/json")]
        [SwaggerOperation(Tags = new[] { "Clientes" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult Get()
        {
            return Response(_customerAppService.GetAll());
        }

        /// <summary>
        /// Busca os Clientes por Id
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Lista com os Clientes</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpGet]
        [Route("clientes/{id:Guid}")]
        [Produces("application/json")]
        [SwaggerOperation(Tags = new[] { "Clientes" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult Get(Guid id)
        {
            var viewModel = _customerAppService.GetById(id);

            return Response(viewModel);
        }

        /// <summary>
        /// Atualiza o Cliente
        /// </summary>
        /// <param name="viewModel">Cliente</param>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Atualiza o Cliente</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpPost]
        [Route("clientes")]
        [Produces("application/json")]
        //[Authorize(Policy = "CanWriteClienteData")]
        [SwaggerOperation(Tags = new[] { "Clientes" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult Post([FromBody] ClienteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(viewModel);
            }

            _customerAppService.Register(viewModel);

            return Response(viewModel);
        }

        /// <summary>
        /// Novo Cliente
        /// </summary>
        /// <param name="viewModel">Cliente</param>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Cria o Cliente</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpPut]
        [Route("clientes")]
        [Produces("application/json")]
        //[Authorize(Policy = "CanWriteClienteData")]
        [SwaggerOperation(Tags = new[] { "Clientes" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult Put([FromBody] ClienteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(viewModel);
            }

            _customerAppService.Update(viewModel);

            return Response(viewModel);
        }
        
        /// <summary>
        /// Apaga o Cliente
        /// </summary>
        /// <param name="id">Id do Cliente</param>
        /// <remarks>
        /// *Necessário a autenticação Bearer
        /// </remarks>
        /// <response code="200">Sucesso: Deleta o Cliente</response>
        /// <response code="400">BadRequest: Erros de Modelo</response> 
        /// <response code="401">Unauthorized: Acesso não Autorizado</response> 
        [HttpDelete]
        [Route("clientes")]
        [Produces("application/json")]
        //[Authorize(Policy = "CanRemoveClienteData")]
        [SwaggerOperation(Tags = new[] { "Clientes" })]
        [SwaggerResponse(200, Type = typeof(Response))]
        public IActionResult Delete(Guid id)
        {
            _customerAppService.Remove(id);

            return Response();
        }
    }
}
