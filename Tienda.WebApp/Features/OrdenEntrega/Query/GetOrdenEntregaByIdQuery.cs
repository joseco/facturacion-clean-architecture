using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Distribucion.Infraestructura.DTO;

namespace Tienda.WebApp.Features.OrdenEntrega.Query
{
    public class GetOrdenEntregaByIdQuery : IRequest<OrdenEntregaDTO>
    {
        public Guid Id { get; set; }

        public GetOrdenEntregaByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
