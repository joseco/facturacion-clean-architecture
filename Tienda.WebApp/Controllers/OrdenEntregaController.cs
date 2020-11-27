using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Tienda.Distribucion.Applicacion.DTO;
using Tienda.Distribucion.Applicacion.Features.OrdenEntrega.GetAllOrdenEntrega;
using Tienda.Distribucion.Applicacion.Features.OrdenEntrega.InsertOrdenEntrega;
using Tienda.Distribucion.Applicacion.Features.OrdenEntrega.GetOrdenEntregaById;

namespace Tienda.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenEntregaController : ControllerBase
    {
        private ILogger<OrdenEntregaController> _logger;
        private readonly IMediator _mediator;

        public OrdenEntregaController(IMediator mediator, ILogger<OrdenEntregaController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrder([FromBody] InsertOrdenEntregaCommand ordenEntregaCommand)
        {
            try
            {
                await _mediator.Send(ordenEntregaCommand);

                return Ok();
            }
            catch (Exception ex)
            {
                
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                _logger.LogInformation("Obteniendo ordenes de entrega...");
                List<OrdenEntregaDTO> list = await _mediator.Send(new GetAllOrdenEntregaQuery());

                return Ok(new
                {
                    orders = list
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las ordenes");
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("{guid:Guid}")]
        public async Task<IActionResult> GetOrders(Guid guid)
        {
            try
            {
                OrdenEntregaDTO obj = await _mediator.Send(new GetOrdenEntregaByIdQuery(guid));

                return Ok(obj); ;
            }
            catch (Exception ex)
            {

            }
            return BadRequest();
        }

        [HttpGet]        
        [Route("hello")]
        public string hello()
        {
            return "Hello";
        }


    }
}
