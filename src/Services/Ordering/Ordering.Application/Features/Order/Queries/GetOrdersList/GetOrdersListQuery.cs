using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Order.Queries.GetOrdersList
{
    internal class GetOrdersListQuery : IRequest
    {
        public string UserName { get; set; }

        public GetOrdersListQuery(string username)
        {
            UserName = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
