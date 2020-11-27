using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Infraestructura.DTO;

namespace Tienda.Distribucion.Infraestructura.Features.OrdenEntrega.Command
{
    public class InsertOrdenEntregaCommand : IRequest
    {

        public OrdenEntregaDTO OrdenEntrega { get; set; }

        public InsertOrdenEntregaCommand(OrdenEntregaDTO ordenEntrega)
        {
            OrdenEntrega = ordenEntrega;
        }
    }
}
