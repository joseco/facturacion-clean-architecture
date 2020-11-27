using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Infraestructura.DTO;

namespace Tienda.Distribucion.Infraestructura.Features.OrdenEntrega.Query
{
    public class GetAllOrdenEntregaQuery : IRequest<List<OrdenEntregaDTO>>
    {

    }
}
