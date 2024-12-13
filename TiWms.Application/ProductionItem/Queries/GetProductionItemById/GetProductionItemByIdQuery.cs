﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ProductionItem.DTOs;

namespace TiWms.Application.ProductionItem.Queries.GetProductionItemById
{
    public class GetProductionItemByIdQuery : IRequest<ProductionItemDto>
    {
        public int Id { get; set; }
        public GetProductionItemByIdQuery(int id)
        {
            Id = id;
        }
    }
}
