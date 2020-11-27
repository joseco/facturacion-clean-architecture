using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Distribucion.Domain.Persistence.Reporsitory;
using Tienda.Distribucion.Infraestructura.DTO;
using Tienda.WebApp.Features.OrdenEntrega.Query;

namespace Tienda.WebApp.Features.OrdenEntrega.Handler
{
    public class GetOrdenEntregaByIdHandler : IRequestHandler<GetOrdenEntregaByIdQuery, OrdenEntregaDTO>
    {
        private readonly IOrdenEntregaRepository _ordenEntregaRepository;

        public GetOrdenEntregaByIdHandler(IOrdenEntregaRepository ordenEntregaRepository)
        {
            _ordenEntregaRepository = ordenEntregaRepository;
        }

        public async Task<OrdenEntregaDTO> Handle(GetOrdenEntregaByIdQuery request, CancellationToken cancellationToken)
        {
            Distribucion.Domain.Model.Disitribucion.OrdenEntrega ordenEntrega
                = await _ordenEntregaRepository.GetOrdenEntregaById(request.Id);

            return new OrdenEntregaDTO()
            {
                Id = ordenEntrega.Id,
                LatitudDestino = ordenEntrega.LatitudDestino,
                LongitudDestino = ordenEntrega.LongitudDestino,
                NombreCliente = ordenEntrega.NombreCliente,
                Telefono = ordenEntrega.Telefono
            };
        }
    }
}
