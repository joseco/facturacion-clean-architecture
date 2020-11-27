using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Distribucion.Domain.Persistence.Reporsitory;
using Tienda.Distribucion.Infraestructura.DTO;
using Tienda.Distribucion.Infraestructura.Features.OrdenEntrega.Query;

namespace Tienda.Distribucion.Infraestructura.Features.OrdenEntrega.Handler
{
    public class GetAllOrdenEntregaHandler : IRequestHandler<GetAllOrdenEntregaQuery, List<OrdenEntregaDTO>>
    {
        private readonly IOrdenEntregaRepository _ordenEntregaRepository;

        public GetAllOrdenEntregaHandler(IOrdenEntregaRepository ordenEntregaRepository)
        {
            _ordenEntregaRepository = ordenEntregaRepository;
        }

        public async Task<List<OrdenEntregaDTO>> Handle(GetAllOrdenEntregaQuery request, CancellationToken cancellationToken)
        {
            List<Distribucion.Domain.Model.Disitribucion.OrdenEntrega> listOfOrders = 
                await _ordenEntregaRepository.GetAllOrdenEntrega();

            List<OrdenEntregaDTO> resultingList = new List<OrdenEntregaDTO>();

            foreach (var item in listOfOrders)
            {
                resultingList.Add(new OrdenEntregaDTO()
                {
                    LatitudDestino = item.LatitudDestino,
                    LongitudDestino = item.LongitudDestino,
                    NombreCliente = item.NombreCliente,
                    Telefono = item.Telefono
                });
            }

            return resultingList;
        }
    }
}
