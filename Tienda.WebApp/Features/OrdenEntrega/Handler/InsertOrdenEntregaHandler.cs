using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Distribucion.Domain.Persistence;
using Tienda.Distribucion.Domain.Persistence.Reporsitory;
using Tienda.Distribucion.Infraestructura.Features.OrdenEntrega.Command;

namespace Tienda.Distribucion.Infraestructura.Features.OrdenEntrega.Handler
{
    public class InsertOrdenEntregaHandler : IRequestHandler<InsertOrdenEntregaCommand, VoidResult>
    {
        private readonly IOrdenEntregaRepository _ordenEntregaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertOrdenEntregaHandler(IOrdenEntregaRepository ordenEntregaRepository, IUnitOfWork unitOfWork)
        {
            _ordenEntregaRepository = ordenEntregaRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<VoidResult> Handle(InsertOrdenEntregaCommand request, CancellationToken cancellationToken)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            foreach (var item in request.OrdenEntrega.Items)
            {
                items.Add(item.Codigo, item.Descripcion);
            }

            Domain.Model.Disitribucion.OrdenEntrega obj = new
                Domain.Model.Disitribucion.OrdenEntrega(request.OrdenEntrega.NombreCliente,
                request.OrdenEntrega.Telefono,
                request.OrdenEntrega.LatitudDestino,
                request.OrdenEntrega.LongitudDestino,
                items
                );

            await _ordenEntregaRepository.Insert(obj);

            await _unitOfWork.Commit();

            return new VoidResult();
        }
    }
}
